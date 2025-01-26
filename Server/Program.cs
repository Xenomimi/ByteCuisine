using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Server.Data;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("ByteCuisineConnection")));

builder.Services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DbInitializer.Seed(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapRazorPages();
app.UseStaticFiles();
app.UseBlazorFrameworkFiles();
app.UseRouting();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

