using Microsoft.EntityFrameworkCore;
using CarShop_RoxanaLungu.Models;


namespace CarShop_RoxanaLungu.Data
{
    public class CarShopDbContext:DbContext
    {
        public CarShopDbContext()
        {
        }
        public CarShopDbContext(DbContextOptions<CarShopDbContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarShopDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>()
         .HasMany(c => c.Cars)
         .WithOne(car => car.Client)
         .HasForeignKey(car => car.ClientId)
         .OnDelete(DeleteBehavior.Restrict);

           }

        
    }
}
