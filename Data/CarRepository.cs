using DotNetSixMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetSixMinimalApi.Data;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext _context;
    public CarRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Car?> GetCarById(int id)
    {
        return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Car>> GetAllCars()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task CreateCar(Car car)
    {
        if (car == null)
            throw new ArgumentNullException(nameof(car));
        await _context.AddAsync(car);
    }

    public void DeleteCar(Car car)
    {
        if (car == null)
            throw new ArgumentNullException(nameof(car));
        _context.Cars.Remove(car);
    }
}