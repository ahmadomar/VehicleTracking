using Microsoft.EntityFrameworkCore;
using VehicleTracking.Models;

namespace VehicleTracking.DataMS.DataContext
{
    public class VehicleDBContext : DbContext
    {
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModel>()
            .HasMany(g => g.Vehicles)
            .WithOne(s => s.Customer)
            .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<VehicleModel>()
             .HasOne(s => s.Customer)
             .WithMany(g => g.Vehicles)
             .HasForeignKey(s => s.CustomerId);
        }
    }
}
