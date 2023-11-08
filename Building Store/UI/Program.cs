using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<HomeService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityRole role1 = new IdentityRole("Admin");
    if (await roleManager.FindByNameAsync(role1.Name) == null)
    {
        await roleManager.CreateAsync(role1);
    }
    IdentityRole role2 = new IdentityRole("Customer");
    if (await roleManager.FindByNameAsync(role2.Name) == null)
    {
        await roleManager.CreateAsync(role2);
    }

    var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();
    var user = await userManager.FindByNameAsync("m.v.boichura@nuwm.edu.ua");
    await userManager.AddToRoleAsync(user, role1.Name);
    await userManager.AddToRoleAsync(user, role2.Name);
    user = await userManager.FindByNameAsync("bug@gmail.com");
    await userManager.AddToRoleAsync(user, role2.Name);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
