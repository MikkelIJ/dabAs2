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
            //optionsBuilder.UseSqlServer("Data Source=dabas2.db");
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Database=gr11;User ID=SA;Password=Mikkelsql88;");
            
        }


        public DbSet <Person> Persons {get;set;}
        public DbSet <Resturant> Resturants {get;set;}
        public DbSet <Waiter> Waiters {get;set;}
        public DbSet <Guest> Guests {get;set;}
        public DbSet <Review> Reviews {get;set;}
        public DbSet <MyTable> MyTables {get;set;}
        public DbSet <Dish> Dishes {get;set;}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Dish
            modelBuilder.Entity<Dish>().HasKey(d => d.id);
        
            //DishType
            modelBuilder.Entity<DishType>()
                .HasOne(dt => dt.Dish)
                .WithMany(d => d.DishType)
                .HasForeignKey(dt => dt.dishId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DishType>().HasKey(d => d.dishTypeId);
            


            //Guest
            modelBuilder.Entity<Guest>().HasKey(g => g.id);
            modelBuilder.Entity<Guest>()
                .HasOne(w => w.person)
                .WithOne(p => p.guest)  
                .HasForeignKey<Person>();
            

            //GuestDish
            modelBuilder.Entity<GuestDish>()
                .HasOne(gd => gd.Guest)
                .WithMany(g => g.GuestDish)
                .HasForeignKey(gd => gd.guestId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GuestDish>()
                .HasOne(gd => gd.Dish)
                .WithMany(d => d.GuestDish)
                .HasForeignKey(gd => gd.dishId)
                .OnDelete(DeleteBehavior.Cascade);

            //Person
            modelBuilder.Entity<Person>().HasKey(p => p.id);

            //Resturant
            modelBuilder.Entity<Resturant>().HasKey(r => r.address); // primary key
            modelBuilder.Entity<Resturant>() //one to many of Review
                .HasMany<Review>(r => r.Review)
                .WithOne(rw => rw.Resturant)
                .HasForeignKey(rw => rw.resturantAddress)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Resturant>() //one to many of MyTable
                .HasMany<MyTable>(r => r.myTable)
                .WithOne(t => t.Resturant)
                .HasForeignKey(t => t.resturantAddress)
                .OnDelete(DeleteBehavior.Cascade);
            
            //ResturantDish
            modelBuilder.Entity<ResturantDish>()
                .HasOne(rd => rd.Resturant)
                .WithMany(d => d.ResturantDish)
                .HasForeignKey(rd => rd.ResturantAddress)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ResturantDish>()
                .HasOne(rd => rd.Dish)
                .WithMany(d => d.ResturantDish)
                .HasForeignKey(rd => rd.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            //ResturantType
            modelBuilder.Entity<ResturantType>()
                .HasOne(rt => rt.Resturant)
                .WithMany(r => r.ResturantType)
                .HasForeignKey(rt => rt.resturantAdress)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ResturantType>().HasKey(d => d.resturantTypeId);

            //Review
            modelBuilder.Entity<Review>().HasKey(r => r.id);
            modelBuilder.Entity<Review>()
                .HasMany<Guest>(r => r.Guest)
                .WithOne(g => g.Review)
                .HasForeignKey(g => g.reviewId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>()
                .HasMany<Dish>(r => r.Dish)
                .WithOne(d => d.Review)
                .HasForeignKey(d => d.reviewId)
                .OnDelete(DeleteBehavior.Restrict); //ændret
                

            //MyTable
            modelBuilder.Entity<MyTable>().HasKey(t => t.Number);
            modelBuilder.Entity<Guest>()
                .HasOne<MyTable>(g =>g.myTable)
                .WithMany(t => t.Guest)
                .HasForeignKey(g => g.tableNumber)
                .OnDelete(DeleteBehavior.Restrict);
            
            //Waiter
            modelBuilder.Entity<Waiter>().HasKey(w => w.id);
            modelBuilder.Entity<Waiter>()
                .HasOne(w => w.person)
                .WithOne(p => p.waiter)  
                .HasForeignKey<Person>();
            

            //WaiterTable
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.waiter)
                .WithMany(w => w.WaiterTable)
                .HasForeignKey(wt => wt.waiterId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<WaiterTable>()
                .HasOne(wt => wt.myTable)
                .WithMany(t => t.WaiterTable)
                .HasForeignKey(wt => wt.tableNumber)
                .OnDelete(DeleteBehavior.Cascade);
        
        }
    }
}