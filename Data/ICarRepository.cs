using DotNetSixMinimalApi.Models;

namespace DotNetSixMinimalApi.Data;

public interface ICarRepository
{
    Task SaveChanges();
    Task<Car?> GetCarById(int id);
    Task<IEnumerable<Car>> GetAllCars();
    Task CreateCar(Car car);
    void DeleteCar(Car car);
}