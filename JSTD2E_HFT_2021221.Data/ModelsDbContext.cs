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
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>(entity =>
            //{
            //    entity
            //    .HasOne(car => car.Brand)
            //    .WithMany(brand => brand.Cars)
            //    .HasForeignKey(car => car.BrandId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //});

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                .HasOne(game => game.DevTeam);
                //.WithMany()
                //.OnDelete(DeleteBehavior.Restrict);
            });

            Game game1 = new Game() { DevTeam = "Riot Games", GameName = "League of Legends", Price = 0, Type = "Moba" };
            Game game2 = new Game() { DevTeam = "Blizzard", GameName = "World of Warcraft", Price = 2000, Type = "RPG" };
            Game game3 = new Game() { DevTeam = "Blizzard", GameName = "Starcraft", Price = 0, Type = "Strategy" };
            Game game4 = new Game() { DevTeam = "Call of Duty: Black Ops", GameName = "Activison", Price = 12000, Type = "FPS" };
            Game game5 = new Game() { DevTeam = "Call of Duty: Modern Warfare", GameName = "Activison", Price = 9000, Type = "FPS" };
            Game game6 = new Game() { DevTeam = "Call of Duty: Ghosts", GameName = "Activison", Price = 15000, Type = "FPS" };
            Game game7 = new Game() { DevTeam = "Ubisoft", GameName = "Far Cry", Price = 5000, Type = "FPS" };
            Game game8 = new Game() { DevTeam = "Ubisoft", GameName = "Watchdogs", Price = 8000, Type = "TPS" };
            Game game9 = new Game() { DevTeam = "Ubisoft", GameName = "Assassin's Creed: Brotherhood", Price = 4000, Type = "TPS" };
            Game game10 = new Game() { DevTeam = "CD Project", GameName = "The Witcher 3: Wild Hunt", Price = 20000, Type = "TPS" };

            DeveloperTeam devteam1 = new DeveloperTeam() { DevTeam = "Riot Games", DateofFoundation = 206, HQ = "Los Angeles" };
            DeveloperTeam devteam2 = new DeveloperTeam() { DevTeam = "Activison", DateofFoundation = 1979, HQ = "Sunnyvale" };
            DeveloperTeam devteam3 = new DeveloperTeam() { DevTeam = "Blizzard", DateofFoundation = 1991, HQ = "Irvine" };
            DeveloperTeam devteam4 = new DeveloperTeam() { DevTeam = "CD Project", DateofFoundation = 1994, HQ = "Warsaw" };
            DeveloperTeam devteam5 = new DeveloperTeam() { DevTeam = "Ubisoft", DateofFoundation = 1986, HQ = "Montreuil" };

            Buyer buyer1 = new Buyer() { GameName = "League of Legends", Age = 23, DateofPurchase = 2010, Name = "Ryan Smith" };
            Buyer buyer2 = new Buyer() { GameName = "World of Warcraft", Age = 70, DateofPurchase = 2007, Name = "Ben Dover" };
            Buyer buyer3 = new Buyer() { GameName = "Call of Duty: Modern Warfare", Age = 19, DateofPurchase = 2012, Name = "Mike Hunt" };
            Buyer buyer4 = new Buyer() { GameName = "The Witcher 3: Wild Hunt", Age = 38, DateofPurchase = 2015, Name = "Henry Cavil" };
            Buyer buyer5 = new Buyer() { GameName = "Assassin's Creed: Brotherhood", Age = 44, DateofPurchase = 2011, Name = "Michael Fassbender" };
            Buyer buyer6 = new Buyer() { GameName = "Watchdogs", Age = 10, DateofPurchase = 2018, Name = "Jenny Talia" };
            Buyer buyer7 = new Buyer() { GameName = "Far Cry", Age = 18, DateofPurchase = 2014, Name = "Hugh Jass" };
            Buyer buyer8 = new Buyer() { GameName = "Starcraft", Age = 27, DateofPurchase = 2008, Name = "Roxanne Beck" };

            //modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi);
            //modelBuilder.Entity<Car>().HasData(bmw1, bmw2, citroen1, citroen2, audi1, audi2);
        }
    }
}

