using System.ComponentModel.DataAnnotations;

namespace RentCar.DTOS.UserDTO;

public class AddUserDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; }
    [Required]
    [MinLength(11, ErrorMessage = "Phone must be at least 6 characters")]
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
}