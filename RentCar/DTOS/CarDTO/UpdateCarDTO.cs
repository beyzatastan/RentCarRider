namespace RentCar.CarDTO;

public class UpdateCarDto
{
    public int Id { get; set; } // Güncellenecek arabanın ID'si
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? LicensePlate { get; set; }
    public string? TransmissionType { get; set; }
    public int? SeatCount { get; set; }
    public decimal? DailyPrice { get; set; }
    public int? SupplierId { get; set; }
    public int? LocationId { get; set; }
}
