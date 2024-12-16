using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.CarDTO;
using RentCar.Data;
using RentCar.Model;

namespace RentCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly DataContext _context;

    public CarController(DataContext context)
    {
        _context = context;
    }

    // GET: api/car
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var cars = await _context.Cars.Include(c => c.Images).ToListAsync();
        return Ok(cars);
    }

    // GET: api/car/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await _context.Cars.Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == id);
        if (car == null) return NotFound("Car not found");
        return Ok(car);
    }

    // POST: api/car
    [HttpPost]
    public async Task<IActionResult> AddCar(AddCarDto dto)
    {
        var car = new CarModel
        {
            Brand = dto.Brand,
            Model = dto.Model,
            Year = dto.Year,
            LicensePlate = dto.LicensePlate,
            TransmissionType = dto.TransmissionType,
            SeatCount = dto.SeatCount,
            DailyPrice = dto.DailyPrice,
            SupplierId = dto.SupplierId,
            LocationId = dto.LocationId
        };


        // Veritabanına ekle
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
    }

    // PUT: api/car/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCar(int id, UpdateCarDto dto)
    {
        // ID eşleşmesini kontrol et
        if (id != dto.Id)
        {
            return BadRequest("ID mismatch");
        }

        // Veritabanında arabayı bul
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound("Car not found");
        }

        // Gönderilen DTO'daki alanlarla arabayı güncelle
        if (!string.IsNullOrEmpty(dto.Brand)) car.Brand = dto.Brand;
        if (!string.IsNullOrEmpty(dto.Model)) car.Model = dto.Model;
        if (dto.Year.HasValue) car.Year = dto.Year.Value;
        if (!string.IsNullOrEmpty(dto.LicensePlate)) car.LicensePlate = dto.LicensePlate;
        if (!string.IsNullOrEmpty(dto.TransmissionType)) car.TransmissionType = dto.TransmissionType;
        if (dto.SeatCount.HasValue) car.SeatCount = dto.SeatCount.Value;
        if (dto.DailyPrice.HasValue) car.DailyPrice = dto.DailyPrice.Value;
        if (dto.SupplierId.HasValue) car.SupplierId = dto.SupplierId.Value;
        if (dto.LocationId.HasValue) car.LocationId = dto.LocationId.Value;

        // Değişiklikleri kaydet
        await _context.SaveChangesAsync();

        return NoContent();
    }



    // DELETE: api/car/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound("Car not found");

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}