namespace Ebla.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public IdentityService(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<string[]> GetUserRolesAsync(IApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user as ApplicationUser);

            return roles.ToArray();
        }

        public async Task<List<IApplicationUser>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync<IApplicationUser>();

            return users;
        }

        public async Task<IApplicationUser> GetUserAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user;
        }

        public async Task<IApplicationUser> GetUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            return user;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new NotFoundException($"Incorrect username");
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
            if (signInResult.Succeeded == false)
            {
                throw new InvalidCredentialsException("Incorrect password");
            }
            else
            {
                return true;
            }
        }

        public async Task<Guid> CreateUserAsync(string username, string password, string[] rolesToAdd)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = $"{username}@localhost.com"
            };

            var hashedPassword = _userManager.PasswordHasher.HashPassword(user, password);
            user.PasswordHash = hashedPassword;

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                foreach (var role in rolesToAdd)
                {
                    if (await _roleManager.FindByNameAsync(role) is not null)
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }
            }
            else
            {
                var errors = result?.Errors?.Select(x => x.Description).ToList();
                throw new Exception($"Failed to create user: {user.UserName} with following errors: {string.Join(", ", errors)}");
            }

            return user.Id;
        }

        public async Task UpdateUserAsync(Guid userId, string email, string[] updatedRoleList)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                throw new NotFoundException(nameof(user), userId);
            }

            user.Email = email;
            
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);

                var rolesToRemove = currentRoles.Except(updatedRoleList).ToList();
                var rolesToAdd = updatedRoleList.Except(currentRoles).ToList();

                foreach (var role in rolesToRemove)
                {
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                    }
                }

                foreach (var role in rolesToAdd)
                {
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                throw new NotFoundException(nameof(user), userId);
            }

            await _userManager.DeleteAsync(user);
        }

        public async Task<int> GetTotalUsersAsync() => await _userManager.Users?.CountAsync();
    }
}