using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Core;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

UIExtensions.AddCustomServices(builder.Services);
CoreExtensions.AddCustomServices(builder.Services);
InfrastructureExtensions.AddRepositoryService(builder.Services);
InfrastructureExtensions.AddContextService(builder.Services, connectionString);
InfrastructureExtensions.AddIdentityService(builder.Services);

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

    var userManager = provider.GetRequiredService<UserManager<Person>>();
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
