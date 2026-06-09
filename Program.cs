using AbsoluteCinema.Data;
using AbsoluteCinema.Mappings;
using AbsoluteCinema.Models.Domain;
using AbsoluteCinema.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AbsoluteCinemaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AbsoluteCinemaConnectionString")));

builder.Services.AddScoped<IShowRepository, SQLShowRepository>();
builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
builder.Services.AddScoped<IBookingRepository, SQLBookingRepository>();

builder.Services.AddAutoMapper(options =>
options.AddProfile(new AutoMapperProfiles()));

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
