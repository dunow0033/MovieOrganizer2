using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieOrganizer.Data;
using MovieOrganizer.Models.Domain;
using MovieOrganizer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MovieOrganizerCon")));

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.RequireUniqueEmail = true;
	options.Password.RequireUppercase = false;
	options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<MovieDBContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
   // .AddEntityFrameworkStores<MovieDBContext>();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieLogRepository, MovieLogRepository>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//builder.Services.AddScoped<UserManager<User>>();
//builder.Services.AddScoped<SignInManager<User>>();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MovieDBContext>();
    dbContext.Database.Migrate();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    string[] roleNames = { "User" };
    foreach(var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if(!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
        }
    }
}

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

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
