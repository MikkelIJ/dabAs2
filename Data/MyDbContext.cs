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
        public DbSet <ResturantType> ResturantType {get;set;}
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
            modelBuilder.Entity<Resturant>()
                .HasMany<ResturantType>(rt => rt.ResturantType)
                .WithOne(r => r.Resturant)
                .HasForeignKey(rt => rt.resturantAdress)
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
            modelBuilder.Entity<WaiterTable>().HasKey(wt => wt.waiterTableId);
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

            //// Resturant Types
            modelBuilder.Entity<ResturantType>().HasData(new ResturantType {resturantTypeId = 1, type = "Brekfast", resturantAdress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantType>().HasData(new ResturantType {resturantTypeId = 2, type = "Diner", resturantAdress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantType>().HasData(new ResturantType {resturantTypeId = 3 ,type = "Buffet", resturantAdress = "Wierdo street 13"});
            modelBuilder.Entity<ResturantType>().HasData(new ResturantType {resturantTypeId = 4 ,type = "A la Carte", resturantAdress = "Mortility street 5"});

            //// Resturant Dish
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 1, DishId = 1, ResturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 2, DishId = 2, ResturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 3, DishId = 3, ResturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 4, DishId = 4, ResturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 5, DishId = 5, ResturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 6, DishId = 6, ResturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 7, DishId = 7, ResturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 8, DishId = 8, ResturantAddress = "Mortility street 5"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 9, DishId = 9, ResturantAddress = "Mortility street 5"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 10, DishId = 10, ResturantAddress = "Mortility street 5"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 11, DishId = 11, ResturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<ResturantDish>().HasData(new ResturantDish {ResturantDishId = 12, DishId = 12, ResturantAddress = "Oldtimers road 7"});

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
            modelBuilder.Entity<Person>().HasData(new Person {id = 11, name = "Alfred"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 12, name = "George"});
            modelBuilder.Entity<Person>().HasData(new Person {id = 13, name = "Atilla the Hun"});

            //// Waiter
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 1, personId = 2, salary = 18000.00f});
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 2, personId = 7, salary = 100.00f});
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 3, personId = 8, salary = 500.00f});
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 4, personId = 11, salary = 20000.00f});
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 5, personId = 12, salary = 24000.00f});
            modelBuilder.Entity<Waiter>().HasData(new Waiter {id = 6, personId = 13, salary = 5.00f});

            //// WaiterTable
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 1, waiterId = 1, tableNumber = 1});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 2, waiterId = 2, tableNumber = 4});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 3, waiterId = 1, tableNumber = 2});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 4, waiterId = 3, tableNumber = 7});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 5, waiterId = 3, tableNumber = 9});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 6, waiterId = 4, tableNumber = 1});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 7, waiterId = 5, tableNumber = 6});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 8, waiterId = 5, tableNumber = 4});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 9, waiterId = 6, tableNumber = 7});
            modelBuilder.Entity<WaiterTable>().HasData(new WaiterTable {waiterTableId = 10, waiterId = 6, tableNumber = 9});

            //// Guests
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 1, personId = 1, Time =  new DateTime(2019,04,15), reviewId = 7, tableNumber = 7});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 2, personId = 3, Time =  new DateTime(2019,07,02), reviewId = 1, tableNumber = 1});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 3, personId = 4, Time =  new DateTime(2019,07,02), reviewId = 2, tableNumber = 1});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 4, personId = 5, Time =  new DateTime(2019,07,02), reviewId = 3, tableNumber = 2});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 5, personId = 6, Time =  new DateTime(2019,01,04), reviewId = 4, tableNumber = 4});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 6, personId = 9, Time =  new DateTime(1964,07,25), reviewId = 5, tableNumber = 6});
            modelBuilder.Entity<Guest>().HasData(new Guest {id = 7, personId = 10, Time =  new DateTime(2019,11,01), reviewId = 6, tableNumber = 9});

            //// GuestDish
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 1, guestId = 1, dishId = 5});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 2, guestId = 1, dishId = 7});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 3, guestId = 2, dishId = 3});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 4, guestId = 3, dishId = 1});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 5, guestId = 3, dishId = 4});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 6, guestId = 4, dishId = 2});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 7, guestId = 5, dishId = 9});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 8, guestId = 6, dishId = 8});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 9, guestId = 6, dishId = 10});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 10, guestId = 7, dishId = 6});
            modelBuilder.Entity<GuestDish>().HasData(new GuestDish {guestDishId = 11, guestId = 7, dishId = 7});

        
            //// Review
            modelBuilder.Entity<Review>().HasData(new Review {id = 1, stars = 6, text = "Reminds me of my childhood", resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 2, stars = 6, text = "Boller i karry is always a winner", resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 3, stars = 2, text = "The amount of sovs was way to low", resturantAddress = "Oldtimers road 7"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 4, stars = 5, text = "Cozy interior", resturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 5, stars = 5, text = "Bulls testicels where perfect", resturantAddress = "Wierdo street 13"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 6, stars = 3, text = "The staff gives me a funny look", resturantAddress = "Mortility street 5"});
            modelBuilder.Entity<Review>().HasData(new Review {id = 7, stars = 1, text = "Tasted like feet", resturantAddress = "Mortility street 5"});
            
            //// Dish
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 1, name = "Boller i karry", price = 49.95f, reviewId = 2});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 2, name = "Tarteletter", price = 44.95f, reviewId = 3});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 3, name = "Kotteletter i fad", price = 59.95f});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 4, name = "Rød grød med fløde", price = 19.95f, reviewId = 1});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 5, name = "Feet stew", price = 49.95f, reviewId = 7});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 6, name = "Eyeball supe", price = 29.95f,});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 7, name = "Chocolate fingers", price = 19.95f, reviewId = 3});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 8, name = "Bulls testicels", price = 49.95f, reviewId = 5});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 9, name = "Frog Tounge", price = 29.95f});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 10, name = "Worm brulé", price = 19.95f});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 11, name = "Pariser toast", price = 9.95f, reviewId = 2});
            modelBuilder.Entity<Dish>().HasData(new Dish {id = 12, name = "Spejlæg", price = 4.95f});

            //// DishType
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 1, type = "Apperticer", dishId = 6});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 2, type = "Apperticer", dishId = 9});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 3, type = "Apperticer", dishId = 11});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 4, type = "Apperticer", dishId = 2});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 5, type = "Apperticer", dishId = 12});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 6, type = "Main course", dishId = 1});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 7, type = "Main course", dishId = 2});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 8, type = "Main course", dishId = 1});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 9, type = "Main course", dishId = 3});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 10, type = "Main course", dishId = 5});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 11, type = "Main course", dishId = 8});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 12, type = "Desert", dishId = 4});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 13, type = "Desert", dishId = 7});
            modelBuilder.Entity<DishType>().HasData(new DishType {dishTypeId = 14, type = "Desert", dishId = 10});

            

        }
    }
}