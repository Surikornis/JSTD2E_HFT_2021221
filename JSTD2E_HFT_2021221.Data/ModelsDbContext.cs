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
                .HasForeignKey(game => game.DevTeamName)
                .HasForeignKey(game => game.Buyer)
                .OnDelete(DeleteBehavior.Restrict);
            });

            //modelBuilder.Entity<Buyer>(entity =>
            //{
            //    entity
            //    .HasMany(buyer => buyer.Games)
            //    .WithOne(game => game.Buyer)
            //    .OnDelete(DeleteBehavior.Restrict);
            //});

            Buyer buyer0 = new Buyer() { Age = 23, DateofPurchase = 2010, Name = "Ryan Smith" };
            Buyer buyer1 = new Buyer() { Age = 70, DateofPurchase = 2007, Name = "Ben Dover" };
            Buyer buyer2 = new Buyer() { Age = 27, DateofPurchase = 2008, Name = "Roxanne Beck" };
            Buyer buyer3 = new Buyer() { Age = 23, DateofPurchase = 2011, Name = "Ryan Smith" };
            Buyer buyer4 = new Buyer() { Age = 19, DateofPurchase = 2012, Name = "Mike Hunt" };
            Buyer buyer5 = new Buyer() { Age = 27, DateofPurchase = 2008, Name = "Roxanne Beck" };
            Buyer buyer6 = new Buyer() { Age = 18, DateofPurchase = 2014, Name = "Hugh Jass" };
            Buyer buyer7 = new Buyer() { Age = 10, DateofPurchase = 2018, Name = "Jenny Talia" };
            Buyer buyer8 = new Buyer() { Age = 44, DateofPurchase = 2011, Name = "Michael Fassbender" };
            Buyer buyer9 = new Buyer() { Age = 38, DateofPurchase = 2015, Name = "Henry Cavil" };

            DeveloperTeam devteam0 = new DeveloperTeam() { DevTeam = "Riot Games", DateofFoundation = 2006, HQ = "Los Angeles" };
            DeveloperTeam devteam1 = new DeveloperTeam() { DevTeam = "Activison", DateofFoundation = 1979, HQ = "Sunnyvale" };
            DeveloperTeam devteam2 = new DeveloperTeam() { DevTeam = "Blizzard", DateofFoundation = 1991, HQ = "Irvine" };
            DeveloperTeam devteam3 = new DeveloperTeam() { DevTeam = "CD Project", DateofFoundation = 1994, HQ = "Warsaw" };
            DeveloperTeam devteam4 = new DeveloperTeam() { DevTeam = "Ubisoft", DateofFoundation = 1986, HQ = "Montreuil" };

            Game game0 = new Game() { Id = 0, Price = 0, Type = "Moba", GameName = "League of Legends" };
            Game game1 = new Game() { Id = 1, Price = 2000, Type = "RPG", GameName = "World of Warcraft" };
            Game game2 = new Game() { Id = 2, Price = 0, Type = "Strategy", GameName = "Starcraft" };
            Game game3 = new Game() { Id = 3, Price = 12000, Type = "FPS", GameName = "Call of Duty: Black Ops" };
            Game game4 = new Game() { Id = 4, Price = 9000, Type = "FPS", GameName = "Call of Duty: Modern Warfare" };
            Game game5 = new Game() { Id = 5, Price = 15000, Type = "FPS", GameName = "Call of Duty: Ghosts" };
            Game game6 = new Game() { Id = 6, Price = 5000, Type = "FPS", GameName = "Far Cry" };
            Game game7 = new Game() { Id = 7, Price = 8000, Type = "TPS", GameName = "Watchdogs" };
            Game game8 = new Game() { Id = 8, Price = 4000, Type = "TPS", GameName = "Assassin's Creed: Brotherhood" };
            Game game9 = new Game() { Id = 9, Price = 20000, Type = "TPS", GameName = "The Witcher 3: Wild Hunt" };

            modelBuilder.Entity<DeveloperTeam>().HasData(devteam0, devteam1, devteam2, devteam3, devteam4);
            modelBuilder.Entity<Game>().HasData(game0, game1, game2, game3, game4, game5, game6, game7, game8, game9);
            modelBuilder.Entity<Buyer>().HasData(buyer1, buyer2, buyer3, buyer4, buyer5, buyer6, buyer7, buyer8);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FoodReciepts.mdf;Integrated Security=True";
            builder.UseLazyLoadingProxies().UseSqlServer(conn);
        }
    }
}
