using JSTD2E_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace JSTD2E_HFT_2021221.Data
{
    public class ModelsDbContext : DbContext
    {
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<DeveloperTeam> DeveloperTeam { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }

        public ModelsDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity
                .HasOne(game => game.DevTeam)
                .WithMany(devteam => devteam.Games)
                .HasForeignKey(game => game.BuyerId)
                .HasForeignKey(game => game.DevTeamId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            Buyer buyer0 = new Buyer() { Id = 1, Age = 23, DateofPurchase = 2010, Name = "Ryan Smith" };
            Buyer buyer1 = new Buyer() { Id = 2, Age = 70, DateofPurchase = 2007, Name = "Ben Dover" };
            Buyer buyer2 = new Buyer() { Id = 3, Age = 27, DateofPurchase = 2008, Name = "Roxanne Beck" };
            Buyer buyer3 = new Buyer() { Id = 4, Age = 23, DateofPurchase = 2011, Name = "Adam Horvath" };
            Buyer buyer4 = new Buyer() { Id = 5, Age = 19, DateofPurchase = 2012, Name = "Mike Hunt" };
            Buyer buyer5 = new Buyer() { Id = 6, Age = 27, DateofPurchase = 2008, Name = "Jennifer Lopertz" };
            Buyer buyer6 = new Buyer() { Id = 7, Age = 18, DateofPurchase = 2014, Name = "Hugh Jass" };
            Buyer buyer7 = new Buyer() { Id = 8, Age = 10, DateofPurchase = 2018, Name = "Jenny Talia" };
            Buyer buyer8 = new Buyer() { Id = 9, Age = 44, DateofPurchase = 2011, Name = "Michael Fassbender" };
            Buyer buyer9 = new Buyer() { Id = 10, Age = 38, DateofPurchase = 2015, Name = "Henry Cavil" };

            DeveloperTeam devteam0 = new DeveloperTeam() { Id = 1, DevTeam = "Riot Games", DateofFoundation = 2006, HQ = "Los Angeles" };
            DeveloperTeam devteam1 = new DeveloperTeam() { Id = 2, DevTeam = "Activison", DateofFoundation = 1979, HQ = "Sunnyvale" };
            DeveloperTeam devteam2 = new DeveloperTeam() { Id = 3, DevTeam = "Blizzard", DateofFoundation = 1991, HQ = "Irvine" };
            DeveloperTeam devteam3 = new DeveloperTeam() { Id = 4, DevTeam = "CD Project", DateofFoundation = 1994, HQ = "Warsaw" };
            DeveloperTeam devteam4 = new DeveloperTeam() { Id = 5, DevTeam = "Ubisoft", DateofFoundation = 1986, HQ = "Montreuil" };

            Game game0 = new Game() { Id = 1, Price = 0, Type = "Moba", GameName = "League of Legends", DevTeamId = 1, BuyerId = buyer0.Id };
            Game game1 = new Game() { Id = 2, Price = 2000, Type = "RPG", GameName = "World of Warcraft", DevTeamId = 3, BuyerId = buyer1.Id };
            Game game2 = new Game() { Id = 3, Price = 0, Type = "Strategy", GameName = "Starcraft", DevTeamId = 3, BuyerId = buyer2.Id };
            Game game3 = new Game() { Id = 4, Price = 12000, Type = "FPS", GameName = "Call of Duty: Black Ops", DevTeamId = 2, BuyerId = buyer3.Id };
            Game game4 = new Game() { Id = 5, Price = 9000, Type = "FPS", GameName = "Call of Duty: Modern Warfare", DevTeamId = 2, BuyerId = buyer4.Id };
            Game game5 = new Game() { Id = 6, Price = 15000, Type = "FPS", GameName = "Call of Duty: Ghosts", DevTeamId = 2, BuyerId = buyer5.Id };
            Game game6 = new Game() { Id = 7, Price = 5000, Type = "FPS", GameName = "Far Cry", DevTeamId = 5, BuyerId = buyer6.Id };
            Game game7 = new Game() { Id = 8, Price = 8000, Type = "TPS", GameName = "Watchdogs", DevTeamId = 5, BuyerId = buyer7.Id };
            Game game8 = new Game() { Id = 9, Price = 4000, Type = "TPS", GameName = "Assassin's Creed: Brotherhood", DevTeamId = 5, BuyerId = buyer8.Id };
            Game game9 = new Game() { Id = 10, Price = 20000, Type = "TPS", GameName = "The Witcher 3: Wild Hunt", DevTeamId = 4, BuyerId = buyer9.Id };

            modelBuilder.Entity<DeveloperTeam>().HasData(devteam0, devteam1, devteam2, devteam3, devteam4);
            modelBuilder.Entity<Game>().HasData(game0, game1, game2, game3, game4, game5, game6, game7, game8, game9);
            modelBuilder.Entity<Buyer>().HasData(buyer0, buyer1, buyer2, buyer3, buyer4, buyer5, buyer6, buyer7, buyer8, buyer9);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GameStore.mdf;Integrated Security=True";
            builder.UseLazyLoadingProxies().UseSqlServer(conn);
        }
    }
}
