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
            var firstName = user.Claims.FirstOrDefault(claim => claim.Type.Equals("given_name")).Value;

            if (!string.IsNullOrEmpty(firstName))
            {
                return firstName.First().ToString().ToUpper();
            }

            return string.Empty;
        }

        public static string GetFullName(this ClaimsPrincipal user)
        {
            var firstName = user.Claims.FirstOrDefault(claim => claim.Type.Equals("given_name")).Value;
            var lastName = user.Claims.FirstOrDefault(claim => claim.Type.Equals("family_name")).Value;

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return $"{firstName} {lastName}";
            }

            return string.Empty;
        }

        public static string GetPrimaryRole(this ClaimsPrincipal user)
        {
            var roles = user.Claims.Where(claim => claim.Type.Equals("role")).Select(x => x.Value).ToList();

            foreach (var role in roles)
            {
                if (role.Equals(Roles.Administrator)) return role;
                if (role.Equals(Roles.User)) return role;
            }

            return string.Empty;
        }
    }
}
