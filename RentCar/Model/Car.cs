namespace RentCar.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id otomatik olarak oluşturulacak
    //ben girerken ıd girmicem
    public int Id { get; set; }
    public string Model { get; set; }  = string.Empty;
    public string Name { get; set; }  = string.Empty;
    public string Color { get; set; }  = string.Empty;
    public int Year { get; set; } 
    public int SeatCount { get; set; } 
    //kilometre
    public string Mileage { get; set; } 
    public string FuelType { get; set; }  = string.Empty;
    //vites türü
    public string Transmission { get; set; }  = string.Empty;
    public  decimal DaileyPrice { get; set; } 
    public string imageUrl { get; set; }  = string.Empty;
    public string Status { get; set; } = "Available";
    
}