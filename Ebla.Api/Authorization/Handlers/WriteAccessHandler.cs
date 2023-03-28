﻿namespace Ebla.Api.Authorization.Handlers
{
    public class WriteAccessHandler : AuthorizationHandler<WriteAccessRequirement>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WriteAccessHandler(IJwtProvider jwtProvider, IHttpContextAccessor httpContextAccessor)
        {
            _jwtProvider = jwtProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, WriteAccessRequirement requirement)
        {
            var user = context.User;
            var httpContext = _httpContextAccessor.HttpContext;

            var authorizationHeader = httpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                var token = authorizationHeader.ToString().Split(" ").FirstOrDefault(x => !x.Equals("Bearer"));
                var tokenValidationResult = await _jwtProvider.ValidateToken(token);

                if (tokenValidationResult.Succeeded && user.IsInRole("Administrator"))
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}