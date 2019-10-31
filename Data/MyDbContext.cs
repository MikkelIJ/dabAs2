using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;

using DABAS2.Models;

namespace DABAS2.Data
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source=dabas2.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Dish

            //DishType

            //Guest

            //GuestDish

            //Person

            //Resturant
            modelBuilder.Entity<Resturant>().HasKey(a => new {a.address});
            modelBuilder.Entity<Resturant>() //one to many
                .HasMany<Review>(b => b.Review)
                .WithOne(c => c.Resturant)
                .HasForeignKey(d => d.resturantAddress);
            modelBuilder.Entity<Resturant>() //one to many
                .HasMany<Table>(b => b.Table)
                .WithOne(c => c.Resturant)
                .HasForeignKey(d => d.resturantAddress);

            //ResturantDish

            //ResturantType

            //Review

            //Table

            //Waiter
        }
    }
}