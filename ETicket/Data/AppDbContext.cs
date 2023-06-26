using ETicket.Models;
using ETicket.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ETicket.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Cinemas_Movies>().HasKey(cm => new
            {
                cm.CinemaId,
                cm.MovieId
            });

            modelBuilder.Entity<Parties_Movies>().HasKey(pm => new
            {
                pm.PartyId,
                pm.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.ActorId);

            modelBuilder.Entity<Cinemas_Movies>().HasOne(m => m.Movie).WithMany(cm => cm.Cinemas_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Cinemas_Movies>().HasOne(c =>c.Cinema).WithMany(cm => cm.Cinemas_Movies).HasForeignKey(a => a.CinemaId);

            modelBuilder.Entity<Parties_Movies>().HasOne(m => m.Movie).WithMany(pm => pm.Parties_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Parties_Movies>().HasOne(p => p.Parties).WithMany(pm => pm.Parties_Movies).HasForeignKey(p => p.PartyId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Parties> Parties { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Cinemas_Movies> Cinemas_Movies { get; set; }
        public DbSet<Parties_Movies> Parties_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
