namespace RentCar.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CarModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id otomatik olarak oluşturulacak
        public int Id { get; set; } // Unique identifier for each car
        public string Brand { get; set; } // Car brand, e.g., 'Toyota'
        public string Model { get; set; } // Car model, e.g., 'Corolla'
        public int Year { get; set; } // Manufacturing year of the car
        public string LicensePlate { get; set; } // License plate number
        public string TransmissionType { get; set; } // 'Automatic' or 'Manual' transmission
        public int SeatCount { get; set; } // Number of seats in the car
        public decimal DailyPrice { get; set; } // Daily rental price
        public int SupplierId { get; set; } // Foreign key linking to the supplier
        public SupplierModel Supplier { get; set; } // Supplier providing this car
        public int LocationId { get; set; } // Foreign key linking to the location
        public LocationModel Location { get; set; } // Location where the car is available
        public ICollection<BookingModel> Bookings { get; set; } // List of bookings for this car
        public ICollection<ReviewModel> Reviews { get; set; } // Aracın incelemeleri

}

