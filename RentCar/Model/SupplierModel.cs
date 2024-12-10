using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Model;

public class SupplierModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id otomatik olarak oluşturulacak
        public int Id { get; set; } // Unique identifier for each supplier
        public string Name { get; set; } // Name of the supplier
        public string ContactNumber { get; set; } // Contact number for communication
        public string Email { get; set; } // Email address of the supplier
        public ICollection<CarModel> Cars { get; set; } // List of cars provided by this supplier
        public ICollection<ReviewModel> Reviews { get; set; } // Tedarikçinin incelemeleri


}