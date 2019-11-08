using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DABAS2.Data;
using DABAS2.Models;

namespace Assignment2_EFcore_au529152
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("This is Assignment 2. System a");
            
            using (var context = new MyDbContext())
            {
                while (true)
                {
                    System.Console.WriteLine("Choose:");
                    System.Console.WriteLine("View: l(List Resturants by type), a(List Resturant by address)");
                    System.Console.WriteLine("Create: r(Resturant), w(Waiter), t(Table), d(Dish), g(Guest), rw(Review)");
                    System.Console.WriteLine("Exit: x");
                    System.Console.WriteLine("Type Command");
                    string line = Console.ReadLine();

                    switch (line)
                    {
                        case "l":
                            ListResturantType(context);
                            break;
                        case "a":
                            ListResturantAddr(context);
                            break;
                        case "r":
                            Resturant resturant = createResturant(context);
                            context.Resturants.Add(resturant);

                            ResturantType resturantType = setResturantType(context);
                            context.ResturantType.Add(resturantType);
                            
                            context.SaveChanges();

                            break;
                        case "w":
                            Waiter waiter = createWaiter(context);
                            context.Waiters.Add(waiter);
                            context.SaveChanges();
                            break;
                        case "t":
                            MyTable myTable = createTable(context);
                            context.MyTables.Add(myTable);
                            context.SaveChanges();
                            break;
                        case "d":
                            Dish dish = createDish(context);
                            context.Dishes.Add(dish);
                            context.SaveChanges();
                            break;
                        case "g":
                            Guest guest = createGuest(context);
                            context.Guests.Add(guest);
                            context.SaveChanges();
                            break;
                        case "rw":
                            Review review = createReview(context);
                            context.Reviews.Add(review);
                            context.SaveChanges();
                            break;
                        case "x":
                            Environment.Exit(0);
                            break;
                        default:
                            System.Console.WriteLine("Unknown command");
                            break;
                    
                    }
                }
            }
        }

        private static void ListResturantType(MyDbContext context)
        {
            System.Console.WriteLine("\nChoose Resturant type to list:");
            System.Console.WriteLine("b(Breakfast), d(Diner), bu(Buffet), a(A la Carte):");
            string line = Console.ReadLine();

            switch(line)
            {
                case "b":
                    List<Resturant> breakfast =(from r in context.Resturants
                    join rt in context.ResturantType on r.address equals rt.resturantAdress
                    where rt.type == "Breakfast"
                    select r)
                    .Include(r => r.ResturantType)
                    .Include(rv => rv.Review)
                    .Take(5)
                    .ToList();
                    foreach (var resType in breakfast)
                    {
                        System.Console.WriteLine(resType);
                    }
                    break;
                case "d":
                    List<Resturant> diner =(from r in context.Resturants
                    join rt in context.ResturantType on r.address equals rt.resturantAdress
                    where rt.type == "Diner"
                    select r)
                    .Include(r => r.ResturantType)
                    .Include(rv => rv.Review)
                    .Take(5)
                    .ToList();
                    foreach (var resType in diner)
                    {
                        System.Console.WriteLine(resType);
                    }
                    break;
                case "bu":
                    List<Resturant> buffet =(from r in context.Resturants
                    join rt in context.ResturantType on r.address equals rt.resturantAdress
                    where rt.type == "Buffet"
                    select r)
                    .Include(r => r.ResturantType)
                    .Include(rv => rv.Review)
                    .Take(5)
                    .ToList();
                    foreach (var resType in buffet)
                    {
                        System.Console.WriteLine(resType);
                    }

                    break;
                case "a":
                    List<Resturant> carte =(from r in context.Resturants
                    join rt in context.ResturantType on r.address equals rt.resturantAdress
                    where rt.type == "A la Carte"
                    select r)
                    .Include(r => r.ResturantType)
                    .Include(rv => rv.Review)
                    .Take(5)
                    .ToList();
                    foreach (var resType in carte)
                    {                        
                        System.Console.WriteLine(resType);
                    }
                    break;
            }
        
        }

        private static void ListResturantAddr(MyDbContext context)
        {
            System.Console.WriteLine("\nThe resturants are:\n");
            List<Resturant> list = context.Resturants.ToList();
            foreach (var resturant in list)
                {
                    System.Console.WriteLine(resturant);
                }

            System.Console.WriteLine("\nFor more information about a resturant, please write its address:\n");
            string input = Console.ReadLine();
            System.Console.WriteLine("\nChosen resturant is:\n");
            List<Resturant> chosen = context.Resturants.Where(r => r.address.Equals(input)).ToList();
            foreach (var resturant in chosen)
                {
                    System.Console.WriteLine(resturant);
                }
            System.Console.WriteLine("Choose: m(menu), g(Guest review on dishes)");
            string choise = System.Console.ReadLine();

            switch(choise)
            {
                case "m":
                    List<Resturant> dishList =context.Resturants
                    .Where(r => r.address.Equals(input))
                    .Include(rd => rd.ResturantDish)
                    .ThenInclude(d => d.Dish)
                    .ThenInclude(d => d.DishType)
                    .ToList();

                    System.Console.WriteLine(string.Join("", dishList));
                    
                    break;
                case "g":
                    List<Review> guestList =context.Reviews
                    .Where(r => r.resturantAddress.Equals(input))
                    .Include(r => r.Guest)
                    .ThenInclude(g => g.myTable)
                    .Include(r => r.Guest)
                    .ThenInclude(g => g.person)
                    .Include(r => r.Dish)
                    .ToList();

                    System.Console.WriteLine(string.Join("", guestList));
                    break;
            }
        }

        private static Resturant findResturant(MyDbContext context)
        {
            Console.Write("Resturant address: ");
            string addr = Console.ReadLine();

            return context.Resturants.Where(r => r.address == addr).Single();
        }

        private static Dish findDish(MyDbContext context)
        {
            Console.Write("Dish name: ");
            string dish = Console.ReadLine();

            return context.Dishes.Where(d => d.name == dish).Single();
        }

        private static MyTable findTable(MyDbContext context)
        {
            Console.Write("Table number: ");
            int tableNum = int.Parse(Console.ReadLine());

            return context.MyTables.Where(t => t.Number == tableNum).Single();
        }

        private static Person newPerson(MyDbContext context)
        {
            Console.Write("Enter persons name: ");
            string persName = Console.ReadLine();

            Person person = new Person()
            {
                name = persName,
            };
            return person;
        }

        private static Resturant createResturant(MyDbContext context)
        {
            Console.Write("Name: ");
            string newName = Console.ReadLine();

            Console.Write("Address: ");
            string newAddress = Console.ReadLine();


            Resturant resturant = new Resturant()
            {
                name = newName,
                address = newAddress,
            };
            return resturant;
        }

        private static ResturantType setResturantType(MyDbContext context)
        {
    
            Console.Write("Choose type: ");
            Console.Write("Choose type: \nb(Breakfast)\nd(Diner)\nbu(Buffet)\na(A la Carte)");
            string newType = Console.ReadLine();

            switch(newType)
            {
                case "b":
                    newType = "Breakfast";
                break;

                case "d":
                    newType = "Diner";
                break;

                case "bu":
                    newType = "Buffet";
                break;

                case "a":
                    newType = "A la Carte";
                break;
            }
            ResturantType resturantType = new ResturantType()
            {
                type = newType,
                
            };

            return resturantType;
        }



        private static Waiter createWaiter(MyDbContext context)
        {
            Person person = newPerson(context);
            context.Persons.Add(person);
            context.SaveChanges();

            Console.Write("Assing waiter to resturant by the resturant table number: ");
            MyTable table = findTable(context);

            Console.Write("Waiters salaty: ");
            float waiterSalaty = float.Parse(Console.ReadLine());

            Waiter waiter = new Waiter()
            {
                personId = person.id,
                salary = waiterSalaty,
            };

            if (table != null)
            {
                table.WaiterTable = new List<WaiterTable>() 
                {
                    new WaiterTable()
                    {
                        myTable = table,
                        Waiter = waiter
                    }
                };
            }
            

            return waiter;
        }

        private static MyTable createTable(MyDbContext context)
        {
            Resturant resturant = findResturant(context);

            MyTable table = new MyTable()
            {
                resturantAddress = resturant.address,
            };

            return table;
        }

        private static Dish createDish(MyDbContext context)
        {
            Resturant resturant = findResturant(context);

            Console.Write("Dish name: ");
            string dishName = Console.ReadLine();

            Console.Write("Dish price: ");
            float dishPrice = float.Parse(Console.ReadLine());

            Dish dish = new Dish()
            {
                name = dishName,
                price = dishPrice,

            };

            if (resturant != null)
            {
                dish.ResturantDish = new List<ResturantDish>() 
                {
                    new ResturantDish()
                    {
                        Resturant = resturant,
                        Dish = dish
                    }
                };
            }

            return dish;
        }

        private static Guest createGuest(MyDbContext context)
        {
            Person person = newPerson(context);
            context.Persons.Add(person);
            context.SaveChanges();

            Console.Write("Assing Guest to resturant by the resturant table number ");
            MyTable table = findTable(context);

            Console.Write("Which dish is the new guest ordering? ");
            Dish orderDish = findDish(context);


            Guest guest = new Guest()
            {
                personId = person.id,
                tableNumber = table.Number,
                Time = DateTime.Now
            };

            if (orderDish != null)
            {
                orderDish.GuestDish = new List<GuestDish>() 
                {
                    new GuestDish()
                    {
                        Guest = guest,
                        Dish = orderDish
                    }
                };
            }
            
            return guest;
        }

        private static Review createReview(MyDbContext context)
        {
            Resturant resturant = findResturant(context);

            Console.Write("Review: ");
            string rev = Console.ReadLine();

            Console.Write("Stars: ");
            int revStars = int.Parse(Console.ReadLine());

                Review review = new Review()
                {
                    text = rev,
                    stars = revStars,
                    resturantAddress = resturant.address,
                };
            return review;
        }
       
        
    }
}
