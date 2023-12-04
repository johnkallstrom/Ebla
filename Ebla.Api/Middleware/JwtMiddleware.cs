namespace Ebla.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;
        private readonly RequestDelegate _next;

        public JwtMiddleware(
            RequestDelegate next,
            IJwtProvider jwtProvider,
            IMapper mapper)
        {
            _next = next;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
        }

        public async Task InvokeAsync(HttpContext context, IIdentityService identityService)
        {
            var authenticationHeader = context.Request.Headers.Authorization;
            var token = authenticationHeader.ToString().Split(" ").LastOrDefault();
            if (!string.IsNullOrEmpty(token))
            {
                var userId = await _jwtProvider.ValidateToken(token);

                var user = await identityService.GetUserAsync(userId);
                var roles = await identityService.GetUserRolesAsync(user);

                var mappedUser = _mapper.Map<UserDto>(user);
                mappedUser.Roles = roles;

                context.Items["User"] = mappedUser;
            }

            await _next(context);
        }
    }
}
