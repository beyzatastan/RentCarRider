namespace RentCar.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class CarImageModel
{
    [Key]
    public int Id { get; set; } // Primary Key

    [Required, ForeignKey("Car")]
    public int CarId { get; set; } // Foreign Key to RentCarModel
    public CarModel Car { get; set; } // Navigation property

    [Required]
    public string ImageUrl { get; set; } // URL or Path of the image

    public bool IsPrimary { get; set; } // Flag to indicate the primary image
}
