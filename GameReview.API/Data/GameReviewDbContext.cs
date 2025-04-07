using Microsoft.EntityFrameworkCore;
using GameReview.API.Models;

namespace GameReview.API.Data
{
    public class GameReviewDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Game> Game { get; set; }
        
        

        public GameReviewDbContext(DbContextOptions<GameReviewDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.UserId, r.GameId });

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Game)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.GameId);
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseNpgsql(@"Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase");

        public GameReviewDbContext()
        {
            
        }

    }


}
