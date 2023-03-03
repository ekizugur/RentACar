using Microsoft.AspNetCore.Identity;
using NToastNotify;
using RentACar.Data.Context;
using RentACar.Data.Extensions;
using RentACar.Entity.Entities;
using RentACar.Service.CustomValidations;
using RentACar.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.LoadServiceLayerExtension();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential= true;
});
builder.Services.AddIdentity<AppUser, AppRole>(opt => { //identity yapýlanmasý
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
}).AddErrorDescriber<CustomIdentityErrorDescriber>()
   .AddRoleManager<RoleManager<AppRole>>()
   .AddEntityFrameworkStores<AppDbContext>()
   .AddDefaultTokenProviders(); //eðer appuser oluþturup AppRole oluþturmadýysak parametre olarak IdentityRole verebiliriz.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "RentACar";
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.AccessDeniedPath = new PathString("/Auth/AccessDenied");

    options.Events.OnRedirectToLogin = context =>
    {
        if (context.Request.Path.StartsWithSegments("/admin")) //startwithsegments bir URL nin belirtilen yolu ile baþlayýp baþlamadýðýný kontrol ederEðer bu URL "/admin" ile baþlarsa, StartsWithSegments yöntemi true döndürür. Aksi takdirde, false döndürür.
        {

            context.Response.Redirect("/Admin/Auth/Login");
        }
        else
        {
            context.Response.Redirect("/user/login");
        }
        return Task.CompletedTask;
    };
});

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions()
{
    PositionClass=ToastPositions.TopRight,
    TimeOut=3000,
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication(); //identity den geliyor yeri önemli
app.UseAuthorization();




app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{Id?}"
        );

    endpoints.MapDefaultControllerRoute();
});

app.Run();
