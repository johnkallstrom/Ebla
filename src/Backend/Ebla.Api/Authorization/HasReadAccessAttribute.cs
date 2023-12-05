namespace Ebla.Api.Authorization
{
    /// <summary>
    /// This attribute controls whether a user is authorized to read data or not
    /// </summary>
    public class HasReadAccessAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] requiredRoles = new[] { "Administrator", "User" };

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"] as UserDto;
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