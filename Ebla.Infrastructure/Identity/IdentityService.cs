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

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var userList = await _userManager.Users.ToListAsync();

            var userDtos = new List<UserDto>();
            foreach (var user in userList)
            {
                var roles = await _userManager.GetRolesAsync(user);

                userDtos.Add(new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToArray()
                });
            }

            return userDtos;
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

        public async Task<UserDto> GetUserAsync(Guid userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserAsync(string username)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<UserDto>(user);
        }
    }
}
