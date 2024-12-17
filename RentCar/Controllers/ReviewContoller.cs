using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.DTOS.ReviewDTO;
using RentCar.Model;

namespace RentCar.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReviewContoller:ControllerBase
{
    
    private readonly DataContext _context;

    public ReviewContoller(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviews = await _context.Reviews
            .Include(r => r.Customer)
            .Include(r => r.Car)
            .ToListAsync();

        return Ok(reviews);
    }
    [HttpGet("car/{carId}")]
    public async Task<IActionResult> GetReviewsForCar(int carId)
    {
        var reviews = await _context.Reviews
            .Where(r => r.CarId == carId)
            .Include(r => r.Customer)
            .ToListAsync();

        if (!reviews.Any())
            return NotFound("No reviews found for this car");

        return Ok(reviews);
    }
    [HttpPost]
    public async Task<IActionResult> AddReview(AddReviewDto dto)
    {
        var customer = await _context.Customers.FindAsync(dto.CustomerId);
        var car = await _context.Cars.FindAsync(dto.CarId);

        if (customer == null || car == null)
            return NotFound("Customer or Car not found");

        var review = new ReviewModel
        {
            CustomerId = dto.CustomerId,
            CarId = dto.CarId,
            Rating = dto.Rating,
            Comment = dto.Comment
        };

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReviewsForCar), new { carId = review.CarId }, review);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null) return NotFound("Review not found");

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}