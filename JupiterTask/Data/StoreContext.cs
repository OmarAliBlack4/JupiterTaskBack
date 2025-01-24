using JupiterTask.Entites;
using Microsoft.EntityFrameworkCore;

namespace JupiterTask.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) :base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Score> Scores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region  Fluent API
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Score>()
                .HasOne(s => s.Team)
                .WithMany(t => t.Scores)
                .HasForeignKey(s => s.TeamId);
            #endregion

            #region Data Seeding 
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Web", Description = "Web development competition", ImageUrl = "https://example.com/web-image.jpg" },
                new Category { Id = 2, Name = "Flutter", Description = "Flutter development competition", ImageUrl = "https://example.com/flutter-image.jpg" },
                new Category { Id = 3, Name = "Sumo", Description = "Sumo robot competition", ImageUrl = "https://example.com/sumo-image.jpg" },
                new Category { Id = 4, Name = "LineFollower", Description = "Line follower robot competition", ImageUrl = "https://example.com/linefollower-image.jpg" }
            );


            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Team Alpha", CategoryId = 1 },
                new Team { Id = 2, Name = "Team Beta", CategoryId = 2 },
                new Team { Id = 3, Name = "Team Gamma", CategoryId = 1 }
            );

            modelBuilder.Entity<Score>().HasData(
                new Score { Id = 1, TeamId = 1, Value = 85 },
                new Score { Id = 2, TeamId = 2, Value = 90 },
                new Score { Id = 3, TeamId = 3, Value = 75 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", PhoneNumber = "123456789", Password = "Password123" },
                new User { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "janedoe@example.com", PhoneNumber = "987654321", Password = "Password456" }
            );
            #endregion
        }

    }
}
