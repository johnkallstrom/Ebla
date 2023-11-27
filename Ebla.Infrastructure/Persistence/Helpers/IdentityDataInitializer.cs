namespace Ebla.Infrastructure.Persistence.Helpers
{
    public static class IdentityDataInitializer
    {
        public static async Task InitializeIdentityData(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                var userList = FileManager.ParseJsonFileToList<InitialUser>("users.json");

                foreach (var user in userList)
                {
                    await CreateRoles(roleManager, user.Roles);

                    if (await userManager.FindByNameAsync(user.Username) == null)
                    {
                        var applicationUser = new ApplicationUser();
                        applicationUser.UserName = user.Username;
                        applicationUser.Email = user.Email;

                        string hashedPassword = userManager.PasswordHasher.HashPassword(applicationUser, user.Password);
                        applicationUser.PasswordHash = hashedPassword;

                        var result = await userManager.CreateAsync(applicationUser);

                        if (result.Succeeded)
                        {
                            await userManager.AddToRolesAsync(applicationUser, user.Roles);
                        }
                        else
                        {
                            throw new Exception($"Failed to create initial user - {applicationUser.UserName}");
                        }
                    }
                }
            }
        }

        private static async Task CreateRoles(RoleManager<ApplicationRole> roleManager, string[] roles)
        {
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
        }
    }
}