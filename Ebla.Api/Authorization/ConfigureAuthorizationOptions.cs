namespace Ebla.Api.Authorization
{
    public static class ConfigureAuthorizationOptions
    {
        public static AuthorizationOptions AddDefaultAuthorizationPolicy(this AuthorizationOptions options)
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

            return options;
        }

        public static AuthorizationOptions AddFullAccessPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(Policies.FullAccess, new AuthorizationPolicyBuilder()
                .AddRequirements(new FullAccessRequirement())
                .RequireAuthenticatedUser()
                .Build());

            return options;
        }
    }
}
