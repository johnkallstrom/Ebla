namespace Ebla.Application.UseCases.Users.Queries
{
    public class GetUserIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IIdentityService _identityService;

        public GetUserIdQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.GetUserAsync(request.Id);

            return user;
        }
    }
}
