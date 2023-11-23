namespace Ebla.Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetIdentifier(this ClaimsPrincipal user)
        {
            var id = user.Claims.FirstOrDefault(claim => claim.Type.Equals("nameid")).Value;

            return Guid.Parse(id);
        }
    }
}
