using Microsoft.EntityFrameworkCore;

namespace RentCar.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class CustomerModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // Primary Key

    [Required, ForeignKey("User")]
    public int UserId { get; set; } // Foreign key linking to UserModel
    public UserModel User { get; set; } // Navigation property

    [Required, StringLength(11)]
    public string IdentityNumber { get; set; } // National ID

    [Required]
    public DateTime DrivingLicenseIssuedDate { get; set; } // Driving license issue date

    [Required, StringLength(20)]
    public string DrivingLicenseNumber { get; set; } // Driving license number

    [Required]
    public DateTime BirthDate { get; set; } // Birth date

    [Required, Phone]
    public string Phone { get; set; } // Phone number

    [Required]
    public string City { get; set; } // City
    [Required]
    public string District { get; set; }
    [Required]
    public string Address { get; set; } 
    [Required]
    public string PostalCode { get; set; } 


    public ICollection<ReviewModel> Reviews { get; set; } = new HashSet<ReviewModel>();
    public ICollection<BookingModel> Bookings { get; set; } = new HashSet<BookingModel>();
}
