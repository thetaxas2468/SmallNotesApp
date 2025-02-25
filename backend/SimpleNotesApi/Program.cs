using Microsoft.EntityFrameworkCore;
using Serilog;
using SimpleNotesApi.Database;
using SimpleNotesApi.Interfaces;
using SimpleNotesApi.Models;
using SimpleNotesApi.Repositories;
using SimpleNotesApi.Services;
using DotNetEnv;



var builder = WebApplication.CreateBuilder(args);

// Set up Serilog to log to a file with a rolling interval for each month
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Month,
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [Level: {Level}] {Message} {NewLine}{Exception}")
    .CreateLogger();

// Add Serilog as the logging provider
builder.Host.UseSerilog();

Env.Load();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();


builder.Services.AddDbContext<SimpleNotesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});

builder.Services.AddScoped<SimpleNotesContext>();
builder.Services.AddScoped<INoteService, NotesService>();
builder.Services.AddScoped<INotesRepository, NotesRepository>();

var app = builder.Build();

app.UseCors("AllowAngularApp");

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
