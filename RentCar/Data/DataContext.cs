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
    public DbSet<CarImageModel> CarImages { get; set; }
    public DbSet<SupplierModel> Suppliers { get; set; } // Table for suppliers
    public DbSet<LocationModel> Locations { get; set; } // Table for locations
    public DbSet<CarModel> Cars { get; set; } // Table for cars
    public DbSet<BookingModel> Bookings { get; set; } // Table for bookings
    public DbSet<ReviewModel> Reviews { get; set; } // Table for reviews


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TCKimlikNo için benzersiz bir indeks oluşturma
        // Unique Constraints
        modelBuilder.Entity<CustomerModel>()
            .HasIndex(c => c.IdentityNumber)
            .IsUnique();
        modelBuilder.Entity<CustomerModel>()
            .HasIndex(c => c.DrivingLicenseNumber)
            .IsUnique();

        // User and Customer Relationship
        modelBuilder.Entity<CustomerModel>()
            .HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<CustomerModel>(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Car and Images Relationship
        modelBuilder.Entity<CarImageModel>()
            .HasOne(ci => ci.Car)
            .WithMany(c => c.Images)
            .HasForeignKey(ci => ci.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        // Reviews Relationships
        modelBuilder.Entity<ReviewModel>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ReviewModel>()
            .HasOne(r => r.Supplier)
            .WithMany(s => s.Reviews)
            .HasForeignKey(r => r.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ReviewModel>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Reviews)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.SetNull);
        
        
        modelBuilder.Entity<UserModel>()
            .Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired();
        
        modelBuilder.Entity<CustomerModel>()
            .Property(u => u.IdentityNumber)
            .HasMaxLength(11)
            .IsRequired();

        
    }


}