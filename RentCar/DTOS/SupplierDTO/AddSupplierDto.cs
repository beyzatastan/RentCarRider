using System.ComponentModel.DataAnnotations;

namespace RentCar.DTOS.SupplierDTO;

public class AddSupplierDto
{
    [Required]
    public string Name { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format")]
    public string ContactNumber { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
}