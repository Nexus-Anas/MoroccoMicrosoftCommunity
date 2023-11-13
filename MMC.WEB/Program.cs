using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MMC.WEB.Data;
using MMC.WEB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

//APIs

builder.Services.AddHttpClient<EventService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<EventService>();

builder.Services.AddHttpClient<CityService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<CityService>();



builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
