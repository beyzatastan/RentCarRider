using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Model;

namespace RentCar.Services;

public class RentCarService:IRentCarService
{
    private readonly DataContext _context;

    public RentCarService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Car>>? GetAllCars()
    {
        var cars = await _context.RentCars.ToListAsync();
        return cars;
    }

    public async Task<Car>? GetSingleCar(int id)
    {
        var car =  await _context.RentCars.FindAsync(id);
        if (car == null)
            return null;
        return car;
    }
    public async Task<List<Car>>? AddCar(Car car)
    {
        _context.RentCars.Add(car);
        await _context.SaveChangesAsync();
        return await _context.RentCars.ToListAsync();
    }
    
    public async Task<List<Car>>? UpdateHero(int id, Car request)
    {
        var car =  await _context.RentCars.FindAsync(id);
        if (car is null)
            return null;
           
        car.Name = request.Name;
        car.Model = request.Model;
        car.Color = request.Color;
        car.imageUrl = request.imageUrl;
        car.Mileage = request.Mileage;
        car.Year = request.Year;
        car.Status = request.Status;
        car.Transmission = request.Transmission;
        car.DaileyPrice = request.DaileyPrice;
        car.FuelType = request.FuelType;
        car.SeatCount = request.SeatCount;
        
        await _context.SaveChangesAsync();
        return await _context.RentCars.ToListAsync();
    }

    public  async Task<List<Car>>?  DeleteHero(int id)
    {
        var car =  await _context.RentCars.FindAsync(id);
        if (car is null)
            return null;
           
        _context.RentCars.Remove(car);
        await _context.SaveChangesAsync();
        return await _context.RentCars.ToListAsync();
    }
}