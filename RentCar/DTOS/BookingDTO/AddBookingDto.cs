using System.ComponentModel.DataAnnotations;

namespace RentCar.DTOS.BookingDTO;


public class AddBookingDto
{
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int CarId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    public int StartLocationId { get; set; } // Araç teslim alınacak lokasyon

    [Required]
    public int EndLocationId { get; set; } // Araç teslim edilecek lokasyon

    [Range(0, double.MaxValue, ErrorMessage = "Deposit must be a positive value")]
    public decimal Deposit { get; set; }
}