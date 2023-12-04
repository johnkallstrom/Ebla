namespace Ebla.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly RequestDelegate _next;

        public JwtMiddleware(
            RequestDelegate next, 
            IJwtProvider jwtProvider)
        {
            _next = next;
            _jwtProvider = jwtProvider;
        }

        public async Task InvokeAsync(HttpContext context, IIdentityService identityService)
        {
            var authenticationHeader = context.Request.Headers.Authorization;
            var token = authenticationHeader.ToString().Split(" ").LastOrDefault();
            if (!string.IsNullOrEmpty(token))
            {
                var userId = await _jwtProvider.ValidateToken(token);
                var user = await identityService.GetUserAsync(userId);
                context.Items["User"] = user;
            }

            await _next(context);
        }
    }
}
