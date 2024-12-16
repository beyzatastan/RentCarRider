using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentCar.Model;

public class SupplierModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id otomatik olarak oluşturulacak
        public int Id { get; set; } // Primary Key
        public string CompanyName { get; set; } // Supplier company name
        public string ContactPerson { get; set; } // Contact person
        public string Phone { get; set; } // Phone
        public string Email { get; set; } // Email
        public ICollection<CarModel> Cars { get; set; } // List of cars provided by this supplier
        public ICollection<ReviewModel> Reviews { get; set; } // Tedarikçinin incelemeleri


}