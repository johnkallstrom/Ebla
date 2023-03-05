namespace Ebla.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public IdentityService(
            IMapper mapper,
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task CreateUserAsync(string username, string password)
        {
            var user = new ApplicationUser
            {
                UserName = username
            };

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded == false)
            {
                var errors = result?.Errors?.Select(x => x.Description).ToList();
                throw new Exception($"Failed to create user: {user.UserName} with following errors: {string.Join(", ", errors)}");
            }
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var userList = await _userManager.Users.ToListAsync();

            return _mapper.Map<List<UserDto>>(userList);
        }

        public async Task<UserDto> GetUserAsync(Guid userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user != null)
            {
                var roles = await GetUserRoles(user);

                var mappedUser = _mapper.Map<UserDto>(user);
                mappedUser.Roles = roles;

                return mappedUser;
            }

            return null;
        }

        public async Task<UserDto> GetUserAsync(string username)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => string.Equals(x.UserName, username));

            if (user != null)
            {
                var roles = await GetUserRoles(user);

                var mappedUser = _mapper.Map<UserDto>(user);
                mappedUser.Roles = roles;

                return mappedUser;
            }

            return null;
        }

        private async Task<string[]> GetUserRoles(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return roles.ToArray();
        }
    }
}
