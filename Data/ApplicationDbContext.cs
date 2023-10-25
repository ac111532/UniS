using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniS.Models;

namespace UniS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UniS.Models.CartItem>? CartItem { get; set; }
        public DbSet<Customer>? Customer { get; set; }
        public DbSet<Order>? Order { get; set; }
        public DbSet<UniS.Models.Product>? Product { get; set; }
        public DbSet<Transaction>? Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Use seed method here
            builder.Seed();
        }
    }
}