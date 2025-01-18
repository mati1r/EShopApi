using ApiTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.DB
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<Tokens> Tokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(pk => new { pk.Id });

            modelBuilder.Entity<Tokens>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tokens)
                .HasForeignKey(t => t.UserId);
        }
    }
}
