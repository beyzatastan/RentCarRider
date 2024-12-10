using Microsoft.EntityFrameworkCore;

namespace RentCar.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CustomerModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // Primary Key for CustomerModel

    public int UserId { get; set; } // Foreign Key linking to UserModel
    [ForeignKey("UserId")]
    public UserModel User { get; set; }
    public string IdentityNumber { get; set; }
    public DateTime DrivingLicenseIssuedDate { get; set; }
    public string DrivingLicenseNumber { get; set; } // Driving license
    public DateTime BirthDate { get; set; } // Birth date
    public string Phone { get; set; } // Phone
    public string City { get; set; } // City
    public string District { get; set; } // District
    public string Address { get; set; } // Address
    public string PostalCode { get; set; } // Postal Code
    public ICollection<ReviewModel> Reviews { get; set; } // Kullanıcının incelemeleri
    public ICollection<BookingModel> Bookings { get; set; } = new List<BookingModel>(); // List of bookings made by the user

}
