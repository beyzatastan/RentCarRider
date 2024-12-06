using RentCar.Model;

namespace RentCar.Services;

public interface IRentCarService
{
    Task<List<Car>>? GetAllCars();
    Task<Car>? GetSingleCar(int id);
    Task<List<Car>>? AddCar(Car car);
    Task<List<Car>>? UpdateHero(int id, Car request);
    Task<List<Car>>? DeleteHero(int id);
}