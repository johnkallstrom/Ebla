namespace Ebla.Infrastructure.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }

    public class JwtOptionsConfiguration : IConfigureOptions<JwtOptions>
    {
        private const string Section = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtOptionsConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(Section).Bind(options);
        }
    }
}
