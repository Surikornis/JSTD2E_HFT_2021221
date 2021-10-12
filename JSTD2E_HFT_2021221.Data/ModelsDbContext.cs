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

            Game game1 = new Game() { DevTeam = "Riot Games", GameName = "League of Legends", Price = 0, Type = "Multiplayer" };

            DeveloperTeam devteam1 = new DeveloperTeam() { DevTeam = "Riot Games", DateofFoundation = 2010, HQ = "America" };

            Buyer buyer1 = new Buyer() { GameName = "League of Legends", Age = 23, DateofPurchase = 2010, Name = "Ryan Smith" };

            //modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi);
            //modelBuilder.Entity<Car>().HasData(bmw1, bmw2, citroen1, citroen2, audi1, audi2);
        }
    }
}

