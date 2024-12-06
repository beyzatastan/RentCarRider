namespace RentCar.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CustomerModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id otomatik olarak oluşturulacak
    public int Id { get; set; }

    // Kiralayan Adı ve Soyadı
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    // Telefon Numarası
    public string Phone { get; set; } = string.Empty;

    // E-posta
    public string Email { get; set; } = string.Empty;

    // TC Kimlik Numarası (string çünkü bazen başında sıfır olabilir)
    public string TCKimlikNo { get; set; } = string.Empty;

    // Doğum Tarihi
    public DateTime BirthDate { get; set; }

    // İl
    public string City { get; set; } = string.Empty;

    // İlçe
    public string District { get; set; } = string.Empty;

    // Adres
    public string Address { get; set; } = string.Empty;

    // Posta Kodu
    public string PostalCode { get; set; } = string.Empty;
}