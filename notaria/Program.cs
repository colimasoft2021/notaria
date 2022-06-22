using Microsoft.EntityFrameworkCore;
using notaria.DataContext;
using notaria.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddScoped<JwtServices>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NotariaContext>
    (opt =>{
        opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        opt.EnableSensitiveDataLogging();
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
