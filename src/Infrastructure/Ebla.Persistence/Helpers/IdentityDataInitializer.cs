namespace Ebla.Persistence.Helpers
{
    public static class IdentityDataInitializer
    {
        public static async Task SeedIdentityData(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                var userList = FileManager.ParseJsonFileToList<InitialUser>("users.json");

                foreach (var user in userList)
                {
                    await CreateApplicationRoles(roleManager, user.Roles);
                    await CreateApplicationUser(userManager, user);
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

        private static async Task CreateApplicationUser(UserManager<ApplicationUser> userManager, InitialUser user)
        {
            if (await userManager.FindByNameAsync(user.Username) == null)
            {
                var applicationUser = new ApplicationUser();
                applicationUser.UserName = user.Username;
                applicationUser.FirstName = user.FirstName;
                applicationUser.LastName = user.LastName;
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