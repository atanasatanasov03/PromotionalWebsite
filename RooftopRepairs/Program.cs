using Microsoft.Extensions.Configuration;
using RooftopRepairs.Firestore;
using Microsoft.Extensions.Configuration;
using RooftopRepairs.Helpers;
using NToastNotify;
using RooftopRepairs.Models;
using RooftopRepairs.Services;
using RooftopRepairs.Interfaces;
using Webpack;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new NToastNotify.ToastrOptions()
{
    ProgressBar = true,
    TimeOut = 5000,
    PositionClass = ToastPositions.BottomRight

}) ;

builder.Services.AddWebpack();

builder.Services.AddScoped<IFireService, FireService>();

builder.Services.AddScoped<IOptionsService, OptionsService>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.Configure<MailOptions>(builder.Configuration.GetSection("Mail"));

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

app.UseNToastNotify();  

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
