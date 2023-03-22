namespace Ebla.Infrastructure.Authentication
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string Section = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(Section).Bind(options);
        }
    }
}
