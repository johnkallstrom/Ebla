namespace Ebla.Infrastructure.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _configuration;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly byte[] _key;

        public JwtProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _issuer = _configuration.GetValue<string>("Jwt:Issuer");
            _audience = _configuration.GetValue<string>("Jwt:Audience");
            _key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key"));
        }

        public string GenerateToken(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(60),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public async Task<bool> ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationResult = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(_key),
            });

            var validatedToken = validationResult.SecurityToken as JwtSecurityToken;
            if (validatedToken != null)
            {
                var userId = validatedToken.Claims?.FirstOrDefault(x => x.Type == "nameid").Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
