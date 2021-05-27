using GameShop.Core;
using GameShop.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameShop.DataAccess
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<GameShopWarehouseStatus> ShopWarehouseStatus { get; set; }

        public GameContext(DbContextOptions<GameContext> options) :
            base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    SeedData(modelBuilder);
        //}

        //private void SeedData(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Game>().HasData(
        //      new Game
        //      {
        //          Id = 1,
        //          Name = "Mortal Kombat",
        //          IsAvailable = false
        //      },
        //      new Game
        //      {
        //          Id = 2,
        //          Name = "Dune 2",
        //          IsAvailable = true
        //      },
        //      new Game
        //      {
        //          Id = 3,
        //          Name = "StrongHold",
        //          IsAvailable = true
        //      }
        //    );
        //}
    }
}
