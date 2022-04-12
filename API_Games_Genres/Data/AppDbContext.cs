using API_Games_Genres.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Games_Genres.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>().HasData(new Team { CreationDate = DateTime.Now, TeamId = 1, MembersCount = 5, Name = "Liquid", MoneyWon = 5000, Owner = "Pepek", Place = "Praha"  });
            modelBuilder.Entity<Team>().HasData(new Team { CreationDate = DateTime.Now, TeamId = 2, MembersCount = 8, Name = "MeXXeSSovi Kamarádi", MoneyWon = 100, Owner = "NeeX", Place = "Brno" });
            modelBuilder.Entity<Player>().HasData(new Player { NickName = "Aldra1n", PlayerId = 1, FirstName = "Jouda", LastName = "Špatný", BiggestPrizeWon = 300, MoneyWon = 500, NumberOfTournamentsPlayed = 3, StartedPlaying = 2013, TeamId = 1 });
            modelBuilder.Entity<Player>().HasData(new Player { NickName = "Filadelfie", PlayerId = 2, FirstName = "Jarmil", LastName = "Holohlavý", BiggestPrizeWon = 8000, MoneyWon = 10000, NumberOfTournamentsPlayed = 15, StartedPlaying = 2015, TeamId = 1 });
        }
    }
}
