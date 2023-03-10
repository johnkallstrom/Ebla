namespace Ebla.Infrastructure.Persistence
{
    public static class IdentityDataInitializer
    {
        public static async Task InitializeIdentityData(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                string[] roles = { "Administrator", "User" };
                string username = "admin";
                string email = "admin@localhost";
                string password = "fJt7h8srmKvKYWXdJbdA";

                foreach (var role in roles)
                {
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        var result = await roleManager.CreateAsync(new ApplicationRole { Name = role });

                        if (result.Succeeded == false)
                        {
                            throw new Exception($"Failed to create initial role - {role}");
                        }
                    }
                }

                if (await userManager.FindByNameAsync(username) == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = username;
                    user.Email = email;

                    string hashedPassword = userManager.PasswordHasher.HashPassword(user, password);
                    user.PasswordHash = hashedPassword;

                    var result = await userManager.CreateAsync(user);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRolesAsync(user, roles);
                    }
                    else
                    {
                        throw new Exception($"Failed to create initial user - {user.UserName}");
                    }
                }
            }
        }
    }
}