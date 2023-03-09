namespace Ebla.Api.Configurations
{
    public static class CustomSwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ebla Api",
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    BearerFormat = "JWT",
                    Name = "Authorization",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfigurations(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ebla Api");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}