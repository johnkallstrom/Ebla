namespace Ebla.Api.Authorization
{
    public static class AuthorizationPolicyHelper
    {
        public static AuthorizationPolicy BuildDefaultPolicy()
        {
            var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

            return policy;
        }

        public static AuthorizationPolicy BuildReadAccessPolicy()
        {
            var policy = new AuthorizationPolicyBuilder()
                .AddRequirements(new ReadAccessRequirement())
                .Build();

            return policy;
        }

        public static AuthorizationPolicy BuildWriteAccessPolicy()
        {
            var policy = new AuthorizationPolicyBuilder()
                .AddRequirements(new WriteAccessRequirement())
                .Build();

            return policy;
        }
    }
}
