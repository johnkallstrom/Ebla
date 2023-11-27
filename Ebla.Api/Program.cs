var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddHttpContextAccessor();
services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    string[] allowedOrigins = { "http://localhost:5056" };
    builder.AllowAnyHeader().AllowAnyMethod().WithOrigins(allowedOrigins);
}));
services.ConfigureSwagger();
services.ConfigureAuthentication(configuration);
services.ConfigureAuthorization();
services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

services.AddApplicationServices();
services.AddInfrastructureServices();
services.AddPersistenceServices(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

await app.Services.InitializeIdentityData();

app.UseRouting();
app.UseCustomSwagger();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.UseJwtMiddleware();
app.MapControllers();

app.Run();