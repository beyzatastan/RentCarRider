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
   
    public DbSet<UserModel> Users { get; set; } // Table for users
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<SupplierModel> Suppliers { get; set; } // Table for suppliers
    public DbSet<LocationModel> Locations { get; set; } // Table for locations
    public DbSet<CarModel> Cars { get; set; } // Table for cars
    public DbSet<BookingModel> Bookings { get; set; } // Table for bookings
    public DbSet<ReviewModel> Reviews { get; set; } // Table for reviews
   
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TCKimlikNo için benzersiz bir indeks oluşturma
        modelBuilder.Entity<CustomerModel>()
            .HasIndex(c => c.IdentityNumber)
            .IsUnique();

        // DrivingLicenseNumber için benzersiz bir indeks oluşturma
        modelBuilder.Entity<CustomerModel>()
            .HasIndex(c => c.DrivingLicenseNumber)
            .IsUnique();
        
        
        modelBuilder.Entity<CustomerModel>()
            .HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<CustomerModel>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Review - User ilişkisi
        modelBuilder.Entity<ReviewModel>()
            .HasOne(r => r.Customer) // Review'in bir User'ı var
            .WithMany(u => u.Reviews) // User'ın birçok Review'i olabilir
            .HasForeignKey(r => r.CustomerId) // Foreign Key UserId
            .OnDelete(DeleteBehavior.Restrict);

        // Review - Supplier ilişkisi
        modelBuilder.Entity<ReviewModel>()
            .HasOne(r => r.Supplier) // Review'in bir Supplier'ı var
            .WithMany(s => s.Reviews) // Supplier'ın birçok Review'i olabilir
            .HasForeignKey(r => r.SupplierId) // Foreign Key SupplierId
            .OnDelete(DeleteBehavior.Restrict);

        // Review - Car ilişkisi (Eğer gerekliyse)
        modelBuilder.Entity<ReviewModel>()
            .HasOne(r => r.Car) // Review bir arabayı referans alıyor
            .WithMany(c => c.Reviews) // Bir araba birden fazla Review'e sahip olabilir
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);
    }


}