
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using siteEcommerceMovies.Models;

namespace siteEcommerceMovies.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the composite key for Actor_Movie
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });

            // Configure relationships for Actor_Movie
            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Movie).WithMany(m => m.Actors_Movies).HasForeignKey(am => am.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Actor).WithMany(a => a.Actors_Movies).HasForeignKey(am => am.ActorId);
            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
               
            });

            // Additional configurations for other entities can be added here

            base.OnModelCreating(modelBuilder);
        }

        // Define DbSet properties for your entities
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }

        // Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        

    }
}
