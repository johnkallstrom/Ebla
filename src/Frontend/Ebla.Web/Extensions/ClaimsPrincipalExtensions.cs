namespace Ebla.Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetIdentifier(this ClaimsPrincipal user)
        {
            var id = user.Claims.FirstOrDefault(claim => claim.Type.Equals("nameid")).Value;

            return Guid.Parse(id);
        }

        public static string GetAvatarLetter(this ClaimsPrincipal user)
        {
            var claims = user.Claims.ToList();
            var username = claims.FirstOrDefault(claim => claim.Type.Equals("unique_name")).Value;

            if (!string.IsNullOrEmpty(username))
            {
                return username.First().ToString().ToUpper();
            }

            return null;
        }
    }
}
