using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.DTOS.BookingDTO;
using RentCar.Model;

namespace RentCar.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookingsContoller:ControllerBase
{
        private readonly DataContext _context;

        public BookingsContoller(DataContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBooking([FromBody] AddBookingDto dto)
        {
            var car = await _context.Cars.FindAsync(dto.CarId);
            if (car == null) return NotFound("Car not found");

            var booking = new BookingModel
            {
                CustomerId = dto.CustomerId,
                CarId = dto.CarId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                StartLocationId = dto.StartLocationId,
                EndLocationId = dto.EndLocationId,
                Deposit = dto.Deposit,
                TotalPrice = (dto.EndDate - dto.StartDate).Days * car.DailyPrice
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok("Booking created successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Car)
                .Include(b => b.Customer)
                .ToListAsync();

            return Ok(bookings);
        }
    }

 