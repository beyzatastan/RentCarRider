using RentCar.Model;
using Microsoft.EntityFrameworkCore;

namespace RentCar.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
            
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER,1433;Database=rentcar;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true;");
        }
    }
    //modelin oldugu için Car yazmam lazım
    //veritabanında bir tabloyu temsil edr
    public DbSet<CarModel> RentCars { get; set; }
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<UserModel> Users { get; set; }

}