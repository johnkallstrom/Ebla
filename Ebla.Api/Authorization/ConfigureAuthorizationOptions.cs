namespace Ebla.Api.Authorization
{
    public static class ConfigureAuthorizationOptions
    {
        public static AuthorizationOptions AddDefaultPolicy(this AuthorizationOptions options)
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

            return options;
        }

        public static AuthorizationOptions AddWriteAccessPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(Policies.WriteAccess, new AuthorizationPolicyBuilder()
                .AddRequirements(new WriteAccessRequirement())
                .RequireAuthenticatedUser()
                .Build());

            return options;
        }

        public static AuthorizationOptions AddReadAccessPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(Policies.ReadAccess, new AuthorizationPolicyBuilder()
                .AddRequirements(new ReadAccessRequirement())
                .RequireAuthenticatedUser()
                .Build());

            return options;
        }
    }
}
