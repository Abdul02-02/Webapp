using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Webbapp.Contexts;
using Webbapp.Helpers.Repositories;
using Webbapp.Helpers.Services;
using Webbapp.Models.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//DB Connection
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));


//Services
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<ProductService>();


//Repositories
builder.Services.AddScoped<ProductEntityRepo>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<AddressRepository>();


//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredLength = 1;
    x.Password.RequireDigit = false;
    x.Password.RequireUppercase = false;

}).AddEntityFrameworkStores<IdentityContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
});

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
