using Microsoft.EntityFrameworkCore;
using AuthenticationService.Models;

namespace AuthenticationService.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Datos iniciales para pruebas
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "editor", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"), Role = "editor" },
                new User { Id = 2, Username = "visitor", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"), Role = "visitor" }
            );
        }
    }
}