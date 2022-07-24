using AutoMapper;
using DotNetSixMinimalApi.Data;
using DotNetSixMinimalApi.Dtos;
using DotNetSixMinimalApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionBuilder = new NpgsqlConnectionStringBuilder
{
    ConnectionString = builder.Configuration.GetConnectionString("dbConnection"),
    Username = builder.Configuration["UserId"],
    Password = builder.Configuration["Password"]
};

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbConnectionBuilder.ConnectionString));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/cars", async (ICarRepository repo, IMapper mapper) =>
{
    var cars = await repo.GetAllCars();
    return Results.Ok(mapper.Map<IEnumerable<GetCarDto>>(cars));
});

app.MapGet("api/v1/cars/{id}", async (ICarRepository repo, IMapper mapper, int id) =>
{
    var car = await repo.GetCarById(id);
    if (car is null)
        return Results.NotFound();
    
    return Results.Ok(mapper.Map<GetCarDto>(car));
});

app.MapPost("api/v1/cars", async (ICarRepository repo, IMapper mapper,CreateCarDto dto) =>
{
    var car = mapper.Map<Car>(dto);
    await repo.CreateCar(car);
    await repo.SaveChanges();

    var resultDto = mapper.Map<GetCarDto>(car);
    return Results.Created($"api/v1/commands/{resultDto.Id}", resultDto);
});

app.MapPut("api/v1/cars/{id}", async (ICarRepository repo, IMapper mapper,int id, UpdateCarDto dto) =>
{
    var car = await repo.GetCarById(id);
    if (car is null)
        return Results.NotFound();

    mapper.Map(dto,car);
    await repo.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("api/v1/cars/{id}", async (ICarRepository repo, int id) =>
{
    var car = await repo.GetCarById(id);
    if (car is null)
        return Results.NotFound();
    repo.DeleteCar(car);
    await repo.SaveChanges();
    return Results.NoContent();
});

app.Run();

