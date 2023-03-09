var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.ConfigureSwagger();
services.ConfigureAuthentication(configuration);
services.ConfigureAuthorization();
services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

services.AddApplicationServices();
services.AddInfrastructureServices(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

await app.Services.InitializeIdentityData();

app.UseRouting();
app.UseSwagger();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
