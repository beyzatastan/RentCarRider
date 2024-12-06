using RentCar.Model;

namespace RentCar.Services;

public interface IRentCarService
{
    Task<List<CarModel>>? GetAllCars();
    Task<CarModel>? GetSingleCar(int id);
    Task<List<CarModel>>? AddCar(CarModel car);
    Task<List<CarModel>>? UpdateHero(int id, CarModel request);
    Task<List<CarModel>>? DeleteHero(int id);
}