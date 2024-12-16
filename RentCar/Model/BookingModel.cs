using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Model;
public class BookingModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // Unique identifier for each booking

    [Required, ForeignKey("User")]
    public int UserId { get; set; } // Foreign key linking to the user who made the booking
    public UserModel User { get; set; } // Navigation property

    [Required, ForeignKey("Car")]
    public int CarId { get; set; } // Foreign key linking to the booked car
    public CarModel Car { get; set; } // Navigation property

    [Required]
    public DateTime StartDate { get; set; } // Start date of the booking

    [Required]
    public DateTime EndDate { get; set; } // End date of the booking

    [Required, Range(0, double.MaxValue)]
    public decimal TotalPrice { get; set; } // Total price for the booking

    // Additional behavior for cascading delete
    [ForeignKey("User")]
    public virtual UserModel Customer { get; set; }
}