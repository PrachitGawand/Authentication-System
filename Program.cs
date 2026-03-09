using Microsoft.EntityFrameworkCore;     // EF Core
using TeamAuthMvc.Data;                  // ApplicationDbContext
using TeamAuthMvc.Repositories;          // Repository interfaces & implementation

var builder = WebApplication.CreateBuilder(args);

// Register MVC services (Controllers + Views)
builder.Services.AddControllersWithViews();

// Register DbContext (connects app to SQL Server via connection string)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repository for Dependency Injection
// When controller asks for IUserRepository, give UserRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();   // Auth logic will be added later (Dev-2/Dev-3)

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();