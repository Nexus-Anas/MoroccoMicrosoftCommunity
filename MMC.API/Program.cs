using Microsoft.EntityFrameworkCore;
using MMC.Core.Interfaces;
using MMC.Core.Services;
using MMC.EF;
using MMC.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Con"), b => b.MigrationsAssembly("MMC.API")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICityService,CityService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IEventService,EventService>();
builder.Services.AddScoped<IParticipantService,ParticipantService>();
builder.Services.AddScoped<ISessionService,SessionService>();
builder.Services.AddScoped<ISpeakerInfoService,SpeakerInfoService>();
builder.Services.AddScoped<ISponsorService,SponsorService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
