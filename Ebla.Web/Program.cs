var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddHttpContextAccessor();
services.AddMvc(options => options.EnableEndpointRouting = false);

services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Add("/Views/Partials/{0}" + RazorViewEngine.ViewExtension);
});

services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole(new[] { "Administrator" }));
    options.AddPolicy("RequireUserRole", policy => policy.RequireRole(new[] { "User" }));
    options.AddPolicy("RequireAdministratorAndUserRole", policy => policy.RequireRole(new[] { "Administrator", "User"} ));
});

services.AddApplicationServices();
services.AddInfrastructureServices(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

await app.Services.InitializeIdentityData();

app.UseRouting();
app.UseAuthorization(); 
app.UseMvc();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Start}/{action=Index}/{id?}");

app.Run();