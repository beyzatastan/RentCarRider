namespace RentCar.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class CarModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // Unique identifier for each car

    [Required]
    public string Brand { get; set; } // Car brand

    [Required]
    public string Model { get; set; } // Car model

    [Required, Range(1900, 9999)]
    public int Year { get; set; } // Manufacturing year

    [Required]
    public string LicensePlate { get; set; } // License plate number

    [Required]
    public string TransmissionType { get; set; } // Transmission type

    [Required, Range(1, 10)]
    public int SeatCount { get; set; } // Number of seats

    [Required, Range(0, double.MaxValue)]
    public decimal DailyPrice { get; set; } // Daily rental price

    [Required, ForeignKey("Supplier")]
    public int SupplierId { get; set; } // Foreign key linking to the supplier
    public SupplierModel Supplier { get; set; } // Navigation property
    [Required, ForeignKey("Location")]
    public int LocationId { get; set; } // Foreign key linking to the location
    public LocationModel Location { get; set; } // Navigation property

    public ICollection<BookingModel> Bookings { get; set; } = new HashSet<BookingModel>(); // List of bookings
    public ICollection<CarImageModel> Images { get; set; } = new HashSet<CarImageModel>(); // Car images
    public ICollection<ReviewModel> Reviews { get; set; } = new HashSet<ReviewModel>(); // Car reviews
}
