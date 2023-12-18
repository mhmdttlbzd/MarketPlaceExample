using Microsoft.EntityFrameworkCore;
using MarketPlace.Domain.Core.Identity.Entities;
using MarketPlace.Infra.Data.Repoes.Ef;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.AspNetCore.Identity;
using MarketPlace.Domain.AppServices;
using System.Data;
using MarketPlace.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Application.Entities._Admin;
using MarketPlace.Domain.Core;
using Microsoft.Extensions.DependencyInjection;
using MarketPlace.Infra.Cache.Redis;
using MarketPlace.Domain.AppServices.Midllewares;
using MarketPlace.Infra.Data.Log.Dapper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(opt => opt.EnableEndpointRouting = false);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddCachingRedis();
builder.Services.AddApplicationLogging();

builder.Services.AddSingleton(new AppSetting(builder.Configuration));



builder.Services.AddIdentity<ApplicationUser , ApplicationRole>(options =>
{
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<MarketPlaceDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Customer>(options =>
{
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<MarketPlaceDbContext>().AddDefaultTokenProviders();

 builder.Services.AddIdentityCore<Seller>(options =>
{
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<MarketPlaceDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityCore<Admin>(options =>
{
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<MarketPlaceDbContext>().AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(option =>
{
    //UserSetting
    option.User.RequireUniqueEmail = true;

    //Password Setting
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;//!@#$%^&*()_+
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 4;
    option.Password.RequiredUniqueChars = 1;

    //Lokout Setting
    option.Lockout.MaxFailedAccessAttempts = 3;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(10);

    //SignIn Setting
    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;

});
builder.Services.ConfigureApplicationCookie(option =>
{
    // cookie setting
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    option.LoginPath = "/Account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});

var app = builder.Build();

app.UseCustomMidllewares();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseMvc(routes => {
    routes.MapRoute("AdminRoute", "{area:exists}/{controller=Admin}/{action=index}");
    routes.MapRoute("SellerRoute", "{area:exists}/{controller=Seller}/{action=index}");
    routes.MapRoute("default", "{controller = Home}/{action = Index}");
});

app.Run();
