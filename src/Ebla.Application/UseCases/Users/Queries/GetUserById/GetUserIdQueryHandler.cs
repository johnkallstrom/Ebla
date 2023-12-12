namespace Ebla.Application.UseCases.Users.Queries
{
    public class GetUserIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public GetUserIdQueryHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.GetUserAsync(request.Id);
            var roles = await _identityService.GetUserRolesAsync(user);

            var mappedUser = _mapper.Map<UserDto>(user);
            mappedUser.Roles = roles;

            return mappedUser;
        }
    }
}
