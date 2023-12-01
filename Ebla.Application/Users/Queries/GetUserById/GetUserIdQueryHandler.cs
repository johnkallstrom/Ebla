namespace Ebla.Application.Users.Queries.GetUserById
{
    public class GetUserIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IIdentityService _identityService;

        public GetUserIdQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.GetUserAsync(request.Id);

            return user;
        }
    }
}
