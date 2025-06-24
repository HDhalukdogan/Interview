using Microsoft.EntityFrameworkCore;
using PocAPI.Data;
using PocAPI.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DemoDbContext>(options =>{
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
    //options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});

builder.Services.AddScoped<IDemoEntityService, DemoEntityService>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
    opt.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
