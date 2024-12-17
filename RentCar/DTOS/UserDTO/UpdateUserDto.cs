using System.ComponentModel.DataAnnotations;

namespace RentCar.DTOS.UserDTO;

public class UpdateUserDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? Email { get; set; }

    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string? Password { get; set; }
    
    [MinLength(11, ErrorMessage = "Phone must be at least 6 characters")]
    public string? PhoneNumber { get; set; }

    public string? Role { get; set; }
}