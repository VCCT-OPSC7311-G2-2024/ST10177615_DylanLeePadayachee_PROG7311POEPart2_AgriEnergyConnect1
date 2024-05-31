// C# class generated with assistance from ChatGPT


using AgriEnergyConnect1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Represents the Farmers table in the database
        public DbSet<Farmer> Farmers { get; set; }

        // Represents the Products table in the database
        public DbSet<Product> Products { get; set; }

        // Override the OnModelCreating method to configure entity relationships or other configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add any additional configurations here if needed
        }
    }
}