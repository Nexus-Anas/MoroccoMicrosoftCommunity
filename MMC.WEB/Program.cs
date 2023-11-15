using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MMC.WEB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();




// APIs
builder.Services.AddHttpClient<EventService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<EventService>();

builder.Services.AddHttpClient<CategoryService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<CategoryService>();

builder.Services.AddHttpClient<CityService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<CityService>();

builder.Services.AddHttpClient<ParticipantService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<ParticipantService>();

builder.Services.AddHttpClient<SessionService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<SessionService>();

builder.Services.AddHttpClient<SpeakerInfoService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<SpeakerInfoService>();

builder.Services.AddHttpClient<SponsorService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<SponsorService>();

builder.Services.AddHttpClient<UserService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:BaseUrl"));
});
builder.Services.AddScoped<UserService>();




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
