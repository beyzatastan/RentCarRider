using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Model;

public class LocationModel
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id otomatik olarak oluşturulacak
        public int Id { get; set; } // Unique identifier for each location
        public string City { get; set; } // City name
        public string State { get; set; } // State name
        public string Country { get; set; } // Country name
        public ICollection<CarModel> Cars { get; set; } // List of cars available at this location
    
}