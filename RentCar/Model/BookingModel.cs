using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Model;

public class BookingModel
{
       [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Unique identifier for each booking

        [ForeignKey("User")]
        public int UserId { get; set; } // Foreign key linking to the user who made the booking
        public UserModel User { get; set; } // User who made the booking

        [ForeignKey("Car")]
        public int CarId { get; set; } // Foreign key linking to the booked car
        public CarModel Car { get; set; } // Booked car

        public DateTime StartDate { get; set; } // Start date of the booking
        public DateTime EndDate { get; set; } // End date of the booking

        public decimal TotalPrice { get; set; } // Total price for the booking

}