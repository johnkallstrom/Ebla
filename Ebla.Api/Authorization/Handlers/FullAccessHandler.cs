using Ebla.Application.Common.Interfaces;

namespace Ebla.Api.Authorization.Handlers
{
    public class FullAccessHandler : AuthorizationHandler<FullAccessRequirement>
    {
        private readonly IJwtProvider _jwtProvider;

        public FullAccessHandler(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, FullAccessRequirement requirement)
        {
            var user = context.User;

            var httpContext = context.Resource as HttpContext;
            if (httpContext is null)
            {
                context.Fail();
                return;
            }

            var authorizationHeader = httpContext.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                context.Fail();
                return;
            }

            var token = authorizationHeader.Split(" ").FirstOrDefault(x => !x.Equals("Bearer"));
            var tokenValidationResult = await _jwtProvider.ValidateToken(token);

            if (tokenValidationResult.Succeeded && user.IsInRole("Administrator"))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
