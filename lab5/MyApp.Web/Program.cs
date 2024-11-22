using MyApp.Web.Services;


var builder = WebApplication.CreateBuilder(args);

// Додавання конфігурації з файлу appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Додавання сервісу Auth0UserService
builder.Services.AddScoped<Auth0UserService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Маршрутизація
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
