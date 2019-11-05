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
            modelBuilder.Entity<Dish>().HasKey(d => d.id);
            
            //DishType
            modelBuilder.Entity<DishType>()
                .HasOne(dt => dt.Dish)
                .WithMany(d => d.DishType)
                .HasForeignKey(dt => dt.dishId);

            //Guest
            modelBuilder.Entity<Guest>().HasKey(g => g.id);

            //GuestDish
            modelBuilder.Entity<GuestDish>()
                .HasOne(gd => gd.Guest)
                .WithMany(g => g.GuestDish)
                .HasForeignKey(gd => gd.guestId);
            modelBuilder.Entity<GuestDish>()
                .HasOne(gd => gd.Dish)
                .WithMany(d => d.GuestDish)
                .HasForeignKey(gd => gd.dishId);

            //Person
            //// arv

            //Resturant
            modelBuilder.Entity<Resturant>().HasKey(r => new {r.address}); // primary key
            modelBuilder.Entity<Resturant>() //one to many of Review
                .HasMany<Review>(r => r.Review)
                .WithOne(rw => rw.Resturant)
                .HasForeignKey(rw => rw.resturantAddress);
            modelBuilder.Entity<Resturant>() //one to many of Table
                .HasMany<Table>(r => r.Table)
                .WithOne(t => t.Resturant)
                .HasForeignKey(t => t.resturantAddress);
            
            //ResturantDish
            modelBuilder.Entity<ResturantDish>()
                .HasOne(rd => rd.Resturant)
                .WithMany(d => d.ResturantDish)
                .HasForeignKey(rd => rd.ResturantAddress);
            modelBuilder.Entity<ResturantDish>()
                .HasOne(rd => rd.Dish)
                .WithMany(d => d.ResturantDish)
                .HasForeignKey(rd => rd.DishId); 

            //ResturantType
            modelBuilder.Entity<ResturantType>()
                .HasOne(rt => rt.Resturant)
                .WithMany(r => r.ResturantType)
                .HasForeignKey(rt => rt.resturantAdress);

            //Review
            modelBuilder.Entity<Review>().HasKey(r => r.id);
            modelBuilder.Entity<Review>()
                .HasMany<Guest>(r => r.Guest)
                .WithOne(g => g.Review)
                .HasForeignKey(g => g.reviewId);
            modelBuilder.Entity<Review>()
                .HasMany<Dish>(r => r.Dish)
                .WithOne(d => d.Review)
                .HasForeignKey(d => d.reviewId);

            //Table
            modelBuilder.Entity<Table>().HasKey(t => t.Number);
            modelBuilder.Entity<Table>()
                .HasMany<Guest>(t =>t.Guest)
                .WithOne(g => g.Table)
                .HasForeignKey(g => g.tableNumber);
            
            //Waiter
            modelBuilder.Entity<Waiter>().HasKey(w => w.id);

            //WaiterTable
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.waiter)
                .WithMany(w => w.WaiterTable)
                .HasForeignKey(wt => wt.waiterId);
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.table)
                .WithMany(t => t.WaiterTable)
                .HasForeignKey(wt => wt.tableNumber);
        
        }
    }
}