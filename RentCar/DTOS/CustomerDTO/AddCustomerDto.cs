using System.ComponentModel.DataAnnotations;

namespace RentCar.DTOS.CustomerDTO;
public class AddCustomerDto
{
    [Required, StringLength(11, ErrorMessage = "Identity Number must be 11 characters.")]
    public string IdentityNumber { get; set; } // T.C. Kimlik No

    [Required]
    public DateTime DrivingLicenseIssuedDate { get; set; } // Ehliyet Veriliş Tarihi

    [Required, StringLength(20, ErrorMessage = "Driving License Number cannot exceed 20 characters.")]
    public string DrivingLicenseNumber { get; set; } // Ehliyet Numarası

    [Required]
    public DateTime BirthDate { get; set; } // Doğum Tarihi

    [Required, Phone]
    public string Phone { get; set; } // Telefon Numarası

    [Required, StringLength(100, ErrorMessage = "City name is too long.")]
    public string City { get; set; } // Şehir

    [Required, StringLength(100, ErrorMessage = "District name is too long.")]
    public string District { get; set; } // İlçe

    [Required, StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
    public string Address { get; set; } // Adres

    [Required, StringLength(10, ErrorMessage = "Postal Code cannot exceed 10 characters.")]
    public string PostalCode { get; set; } // Posta Kodu
}