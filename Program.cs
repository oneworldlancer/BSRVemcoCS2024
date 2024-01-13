
using BSRVemcoCS.iApp_Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//////////////////////////////////////////////


var builder = WebApplication.CreateBuilder(args);






#region Identity

//////////builder.Services.AddDbContext<BSRDBModelContext>(options =>
//////////   options.UseSqlServer("BSRVEMCODB"),
//////////         ServiceLifetime.Scoped, ServiceLifetime.Scoped);



builder.Services.AddIdentity<AppCore_IdentityUser, AppCore_IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<BSRDBContext>();


builder.Services.AddDbContext<BSRDBContext>(options =>
{
    //the change occurs here.
    //builder.cofiguration and not just configuration
    options.UseSqlServer(builder.Configuration.GetConnectionString("BSRVEMCODB"));
});

builder.Services.Configure<IdentityOptions>(options =>
{

    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = true;


});

#endregion














// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
