namespace Ebla.Api.Authorization
{
    /// <summary>
    /// This attribute controls whether a user is authorized to write data or not
    /// </summary>
    public class HasWriteAccessAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] requiredRoles = new[] { "Administrator" };

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"] as UserResponse;
            if (user is null)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new JsonResult(new { Message = "Unauthorized", StatusCode = StatusCodes.Status401Unauthorized });
            }
            else
            {
                bool hasRequiredRole = user.Roles.Any(x => requiredRoles.Contains(x));
                if (hasRequiredRole == false)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Result = new JsonResult(new { Message = "Unauthorized", StatusCode = StatusCodes.Status401Unauthorized });
                }
            }
        }
    }
}
