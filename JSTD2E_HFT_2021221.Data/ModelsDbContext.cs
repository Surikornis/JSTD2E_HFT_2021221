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
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity
                .HasMany(buyer => buyer.Games)
                .WithOne(game => game.Buyer)
                .OnDelete(DeleteBehavior.Restrict);
            });
            DeveloperTeam RiotGames = new DeveloperTeam() { DevTeam = "Riot Games", DateofFoundation = 2006, HQ = "Los Angeles" };
            DeveloperTeam Activison = new DeveloperTeam() { DevTeam = "Activison", DateofFoundation = 1979, HQ = "Sunnyvale" };
            DeveloperTeam Blizzard = new DeveloperTeam() { DevTeam = "Blizzard", DateofFoundation = 1991, HQ = "Irvine" };
            DeveloperTeam CDProject = new DeveloperTeam() { DevTeam = "CD Project", DateofFoundation = 1994, HQ = "Warsaw" };
            DeveloperTeam Ubisoft = new DeveloperTeam() { DevTeam = "Ubisoft", DateofFoundation = 1986, HQ = "Montreuil" };

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

            Game game0 = new Game() { GameName = "League of Legends", Price = 0, Type = "Moba", Buyer = buyer0, /*DevTeamName = RiotGames.DevTeam,*/ DevTeam = RiotGames };
            Game game1 = new Game() { GameName = "World of Warcraft", Price = 2000, Type = "RPG", Buyer = buyer1, /*DevTeamName = Blizzard.DevTeam,*/ DevTeam = Blizzard };
            Game game2 = new Game() { GameName = "Starcraft", Price = 0, Type = "Strategy", Buyer = buyer2, /*DevTeamName = Blizzard.DevTeam,*/ DevTeam = Blizzard };
            Game game3 = new Game() { GameName = "Call of Duty: Black Ops", Price = 12000, Type = "FPS", Buyer = buyer3, /*DevTeamName = Activison.DevTeam,*/ DevTeam = Activison };
            Game game4 = new Game() { GameName = "Call of Duty: Modern Warfare", Buyer = buyer4, Price = 9000, Type = "FPS", /*DevTeamName = Activison.DevTeam,*/ DevTeam = Activison };
            Game game5 = new Game() { GameName = "Call of Duty: Ghosts", Buyer = buyer5, Price = 15000, Type = "FPS", /*DevTeamName = Activison.DevTeam,*/ DevTeam = Activison };
            Game game6 = new Game() { GameName = "Far Cry", Buyer = buyer6, Price = 5000, Type = "FPS", /*DevTeamName = Ubisoft.DevTeam,*/ DevTeam = Ubisoft };
            Game game7 = new Game() { GameName = "Watchdogs", Buyer = buyer7, Price = 8000, Type = "TPS", /*DevTeamName = Ubisoft.DevTeam,*/ DevTeam = Ubisoft };
            Game game8 = new Game() { GameName = "Assassin's Creed: Brotherhood", Buyer = buyer8, Price = 4000, Type = "TPS", /*DevTeamName = Ubisoft.DevTeam,*/ DevTeam = Ubisoft };
            Game game9 = new Game() { GameName = "The Witcher 3: Wild Hunt", Buyer = buyer9, Price = 20000, Type = "TPS", /*DevTeamName = CDProject.DevTeam,*/ DevTeam = CDProject };





            modelBuilder.Entity<DeveloperTeam>().HasData(RiotGames, Activison, Blizzard, CDProject, Ubisoft);
            modelBuilder.Entity<Game>().HasData(game0, game1, game2, game3, game4, game5, game6, game7, game8, game9);
            //modelBuilder.Entity<Buyer>().HasData(buyer1, buyer2, buyer3, buyer4, buyer5, buyer6, buyer7, buyer8);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FoodReciepts.mdf;Integrated Security=True";
            builder.UseLazyLoadingProxies().UseSqlServer(conn);
        }
    }
}
