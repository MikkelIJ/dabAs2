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
            //optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Database=gr11;User ID=SA;Password=Mikkelsql88;");
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Database=gr11;User ID=SA;Password=FroiFroi14;");
        }


        public DbSet <Person> Persons {get;set;}
        public DbSet <Resturant> Resturants {get;set;}
        public DbSet <ResturantType> ResturantTypes {get;set;}
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
            modelBuilder.Entity<DishType>().HasKey(d => d.dishTypeId);
            modelBuilder.Entity<DishType>()
                .HasOne(dt => dt.Dish)
                .WithMany(d => d.DishType)
                .HasForeignKey(dt => dt.dishId)
                .OnDelete(DeleteBehavior.Cascade);
            
            


            //Guest
            modelBuilder.Entity<Guest>().HasKey(g => g.id);

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
            modelBuilder.Entity<Person>()
                .HasOne(g => g.guest)
                .WithOne(p => p.person)
                .HasForeignKey<Guest>(g => g.personId);
            modelBuilder.Entity<Person>()
                .HasOne(w => w.waiter)
                .WithOne(p => p.person)
                .HasForeignKey<Waiter>(w => w.personId);

            //Resturant
            modelBuilder.Entity<Resturant>().HasKey(r => r.address); // primary key
            modelBuilder.Entity<Resturant>() //one to many of Review
                .HasMany<Review>(r => r.Review)
                .WithOne(rw => rw.Resturant)
                .HasForeignKey(rw => rw.resturantAddress);
                //.OnDelete(DeleteBehavior.Cascade);
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
            modelBuilder.Entity<ResturantType>().HasKey(d => d.resturantTypeId);
            modelBuilder.Entity<ResturantType>()
                .HasOne(rt => rt.Resturant)
                .WithMany(r => r.ResturantType)
                .HasForeignKey(rt => rt.resturantAdress)
                .OnDelete(DeleteBehavior.Cascade);
            

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


            // fill database with sample data
            //// Resturant
            modelBuilder.Entity<Resturant>().HasData(new Resturant {name = "MorMor's kitchen", address = "Oldtimers road 7"});
            modelBuilder.Entity<Resturant>().HasData(new Resturant {name = "Dare to eat it?", address = "Wierdo street 13"});
            modelBuilder.Entity<Resturant>().HasData(new Resturant {name = "Canibal stew", address = "Mortility street 5"});

            //// Tables
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 1, resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 2, resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 3, resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 4, resturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 5, resturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 6, resturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 7, resturantAddress = "Mortility street 5"});
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 8, resturantAddress = "Mortility street 5"});
            modelBuilder.Entity<MyTable>().HasData(new MyTable {Number = 9, resturantAddress = "Mortility street 5"});

            //// Person
            modelBuilder.Entity<Person>().HasData(new Person {id = 1, name = "Peter Madsen"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 2, name = "James"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 3, name = "Batman"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 4, name = "Robin"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 5, name = "Catwoman"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 6, name = "Caroline Pedersen"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 7, name = "Donald Trump"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 8, name = "Lars Løkke"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 9, name = "Elvis"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 10, name = "Pernille Rosendahl"});

            //// Waiter
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 1, personId = 2, salary = 18000.00f});
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 2, personId = 7, salary = 100.00f});
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 3, personId = 8, salary = 500.00f});

            //// Guests
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 1, personId = 1, Time =  new DateTime(2019,04,15), reviewId = 7, tableNumber = 7});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 2, personId = 3, Time =  new DateTime(2019,07,02), reviewId = 1, tableNumber = 1});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 3, personId = 4, Time =  new DateTime(2019,07,02), reviewId = 2, tableNumber = 1});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 4, personId = 5, Time =  new DateTime(2019,07,02), reviewId = 3, tableNumber = 2});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 5, personId = 6, Time =  new DateTime(2019,01,04), reviewId = 4, tableNumber = 4});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 6, personId = 9, Time =  new DateTime(1964,07,25), reviewId = 5, tableNumber = 6});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 7, personId = 10, Time =  new DateTime(2019,11,01), reviewId = 6, tableNumber = 9});

            //// Resturant Types
            modelBuilder.Entity<ResturantType>().HasData(new ResturantType {resturantTypeId = 1, type = "Brekfast", resturantAdress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantType>().HasData(new ResturantType {resturantTypeId = 2, type = "Diner", resturantAdress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantType>().HasData(new ResturantType {resturantTypeId = 3 ,type = "Buffet", resturantAdress = "Wierdo street 13"});
            modelBuilder.Entity<ResturantType>().HasData(new ResturantType {resturantTypeId = 4 ,type = "A la Carte", resturantAdress = "Mortility street 5"});

            //// Review
            modelBuilder.Entity<Review>().HasData(new Review {id = 1, stars = 6, text = "Reminds me of my childhood", resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 2, stars = 6, text = "Boller i karry is always a winner", resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 3, stars = 2, text = "The amount of sovs was way to low", resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 4, stars = 5, text = "Cozy interior", resturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 5, stars = 5, text = "Bulls testicels where perfect", resturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 6, stars = 3, text = "The staff gives me a funny look", resturantAddress = "Mortility street 5"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 7, stars = 1, text = "Tasted like feet", resturantAddress = "Mortility street 5"});
            
            /// Dish
            //modelBuilder.Entity<Dish>().HasData(new Dish {name = "Boller i karry", price = 49.95f, reviewId = 2});
        }
    }
}