namespace Ebla.Api.Authorization.Handlers
{
    public class WriteAccessHandler : AuthorizationHandler<WriteAccessRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WriteAccessRequirement requirement)
        {
            if (context.User.IsInRole("Administrator"))
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