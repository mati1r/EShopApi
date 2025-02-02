using Core.Models;
using EShopApi.Models.EShop;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductElement> ProductElements { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductValue> ProductValues { get; set; }
        public DbSet<ProductPhotos> ProductPhotos { get; set; }
        public DbSet<ProductRefHistory> ProductRefHistory { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(pk => new { pk.Id });

            modelBuilder.Entity<Tokens>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tokens)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<ProductRefHistory>()
                .HasKey(prh => new { prh.ProductId, prh.HistoryId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
