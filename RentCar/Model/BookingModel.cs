using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Model;
public class BookingModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // Unique identifier for each booking

    [Required, ForeignKey("Customer")]
    public int CustomerId { get; set; } // Foreign key linking to the user who made the booking
    public CustomerModel Customer { get; set; } // Navigation property

    [Required, ForeignKey("Car")]
    public int CarId { get; set; } // Foreign key linking to the booked car
    public CarModel Car { get; set; } // Navigation property

    [Required]
    [CustomValidation(typeof(BookingModel), "ValidateDates")]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; } // End date of the booking

    [Required, Range(0, double.MaxValue)]
    public decimal TotalPrice { get; set; } // Total price for the booking
    
    [ForeignKey("StartLocation")]
    public int StartLocationId { get; set; }
    public LocationModel StartLocation { get; set; }

    [ForeignKey("EndLocation")]
    public int EndLocationId { get; set; }
    public LocationModel EndLocation { get; set; }
    public decimal Deposit { get; set; }
    // Custom validation method
    public static ValidationResult ValidateDates(DateTime startDate, ValidationContext context)
    {
        var instance = (BookingModel)context.ObjectInstance;
        if (startDate >= instance.EndDate)
        {
            return new ValidationResult("Start date must be earlier than end date.");
        }
        return ValidationResult.Success;
    }
}