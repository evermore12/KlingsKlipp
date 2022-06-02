using KlingsKlipp.Data;
using KlingsKlipp.Data.Services;
using KlingsKlipp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Database>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("KlingsklippDb"), providerOptions =>
    {
        providerOptions.EnableRetryOnFailure();
    });
});

builder.Services.AddScoped<IScheduleService, ScheduleService>();

builder.Services.AddScoped<ICRUDService<Break>, CRUDService<Break>>();
builder.Services.AddScoped<ICRUDService<Customer>, CRUDService<Customer>>();
builder.Services.AddScoped<ICRUDService<Treatment>, CRUDService<Treatment>>();
builder.Services.AddScoped<ICRUDService<Day>, CRUDService<Day>>();
builder.Services.AddScoped<ICRUDService<Booking>, CRUDService<Booking>>();

builder.Services.AddSwaggerGen();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
