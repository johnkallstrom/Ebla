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
                    await CreateApplicationRoles(roleManager, user.Roles);
                    await CreateApplicationUser(userManager, user.Username, user.Password, user.Email, user.Roles);
                }
            }
        }

        private static async Task CreateApplicationUser(UserManager<ApplicationUser> userManager, string username, string password, string email, string[] roles)
        {
            if (await userManager.FindByNameAsync(username) == null)
            {
                var applicationUser = new ApplicationUser();
                applicationUser.UserName = username;
                applicationUser.Email = email;

                string hashedPassword = userManager.PasswordHasher.HashPassword(applicationUser, password);
                applicationUser.PasswordHash = hashedPassword;

                var result = await userManager.CreateAsync(applicationUser);

                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(applicationUser, roles);
                }
                else
                {
                    throw new Exception($"Failed to create initial user - {applicationUser.UserName}");
                }
            }
        }

        private static async Task CreateApplicationRoles(RoleManager<ApplicationRole> roleManager, string[] roles)
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