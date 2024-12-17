namespace RentCar.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserModel {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id otomatik olarak oluşturulacak
    public int Id { get; set; } // Unique identifier for each user

    [Required]
    public string FirstName { get; set; } = string.Empty; // User's first name

    [Required]
    public string LastName { get; set; } = string.Empty; // User's last name

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty; // User's email address for login and communication

    [Required]
    public string PasswordHash { get; set; } = string.Empty; // Hashed password for security
    
    [Required]
    public string PhoneNumber { get; set; } = string.Empty; // Hashed password for security
    [Required]
    public string Role { get; set; }  // Role of the user, such as 'Customer' or 'Admin'
    
}