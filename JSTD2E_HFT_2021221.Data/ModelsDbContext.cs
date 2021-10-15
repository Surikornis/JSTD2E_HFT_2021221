﻿using JSTD2E_HFT_2021221.Models;
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
            modelBuilder.Entity<Game>(entity =>
            {
                entity
                .HasOne(game => game.DevTeam)
                .WithMany(devTeam => devTeam.Games)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DeveloperTeam>(entity =>
            {
                entity
                .HasMany(devteam => devteam.Games);
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity
                .HasOne(buyer => buyer.GameName);
            });

            DeveloperTeam RiotGames = new DeveloperTeam() { DevTeam = "Riot Games", DateofFoundation = 206, HQ = "Los Angeles" };
            DeveloperTeam Activison = new DeveloperTeam() { DevTeam = "Activison", DateofFoundation = 1979, HQ = "Sunnyvale" };
            DeveloperTeam Blizzard = new DeveloperTeam() { DevTeam = "Blizzard", DateofFoundation = 1991, HQ = "Irvine" };
            DeveloperTeam CDProject = new DeveloperTeam() { DevTeam = "CD Project", DateofFoundation = 1994, HQ = "Warsaw" };
            DeveloperTeam Ubisoft = new DeveloperTeam() { DevTeam = "Ubisoft", DateofFoundation = 1986, HQ = "Montreuil" };

            Game game0 = new Game() { GameName = "League of Legends", DevTeamName = RiotGames.DevTeam, Price = 0, Type = "Moba" };
            Game game1 = new Game() { GameName = "World of Warcraft", DevTeamName = Blizzard.DevTeam, Price = 2000, Type = "RPG" };
            Game game2 = new Game() { GameName = "Starcraft", DevTeamName = Blizzard.DevTeam, Price = 0, Type = "Strategy" };
            Game game3 = new Game() { GameName = "Call of Duty: Black Ops", DevTeamName = Activison.DevTeam, Price = 12000, Type = "FPS" };
            Game game4 = new Game() { GameName = "Call of Duty: Modern Warfare", DevTeamName = Activison.DevTeam, Price = 9000, Type = "FPS" };
            Game game5 = new Game() { GameName = "Call of Duty: Ghosts", DevTeamName = Activison.DevTeam, Price = 15000, Type = "FPS" };
            Game game6 = new Game() { GameName = "Far Cry", DevTeamName = Ubisoft.DevTeam, Price = 5000, Type = "FPS" };
            Game game7 = new Game() { GameName = "Watchdogs", DevTeamName = Ubisoft.DevTeam, Price = 8000, Type = "TPS" };
            Game game8 = new Game() { GameName = "Assassin's Creed: Brotherhood", DevTeamName = Ubisoft.DevTeam, Price = 4000, Type = "TPS" };
            Game game9 = new Game() { GameName = "The Witcher 3: Wild Hunt", DevTeamName = CDProject.DevTeam, Price = 20000, Type = "TPS" };

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

