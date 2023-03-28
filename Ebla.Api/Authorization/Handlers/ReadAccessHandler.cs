namespace Ebla.Api.Authorization.Handlers
{
    public class ReadAccessHandler : AuthorizationHandler<ReadAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadAccessRequirement requirement)
        {
            var user = context.User;
            if (user.IsInRole("Administrator") || user.IsInRole("User"))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
