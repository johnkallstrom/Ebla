namespace Ebla.Application.UseCases.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public GetUsersQueryHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _identityService.GetAllUsersAsync();

            var result = new List<UserDto>();
            foreach (var user in users)
            {
                var roles = await _identityService.GetUserRolesAsync(user);

                var mappedUser = _mapper.Map<UserDto>(user);
                mappedUser.Roles = roles;

                result.Add(mappedUser);
            }

            return result;
        }
    }
}
