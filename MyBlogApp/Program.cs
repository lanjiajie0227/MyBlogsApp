using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MyBlogApp.Data;
using MyBlogApp.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMasaBlazor();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//
builder.Services.AddScoped<DbContext, myblogsContext>();
builder.Services.AddDbContext<myblogsContext>(options=>options.UseMySql("name=ConnectionString:MySqlConnection",Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"))
.EnableSensitiveDataLogging(false)
.EnableDetailedErrors());

builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
