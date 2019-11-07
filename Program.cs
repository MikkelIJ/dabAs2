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
                            createResturant(context);
                            break;
                        case "w":
                            createWaiter(context);
                            break;
                        case "t":
                            createTable(context);
                            break;
                        case "d":
                            createDish(context);
                            break;
                        case "g":
                            createGuest(context);
                            break;
                        case "rw":
                            createReview(context);
                            break;
                        case "x":
                            Environment.Exit(0);
                            break;
                    
                    }
                }
            }
            
        
        }

        private static void ListResturantType(MyDbContext context)
        {
            System.Console.WriteLine("Choose Resturant type to list:");
            System.Console.WriteLine("b(Breakfast), d(Diner), bu(Buffet), a(A la Carte):");
            string line = Console.ReadLine();

            switch(line)
            {
                case "b":
                    List<Resturant> list = context.Resturants
                    .Include(rt => rt.ResturantType)
                    .ToList();
                    foreach (var resturant in list)
                    {


                        System.Console.WriteLine(resturant);
                    }
                    break;
                case "d":
                    break;
                case "bu":
                    break;
                case "a":
                    break;
            }
        
        }

        private static void ListResturantAddr(MyDbContext context)
        {
            
        }

        private static void createResturant(MyDbContext context)
        {

        }

        private static void createWaiter(MyDbContext context)
        {
            
        }

        private static void createTable(MyDbContext context)
        {
            
        }

        private static void createDish(MyDbContext context)
        {
            
        }

        private static void createGuest(MyDbContext context)
        {
            
        }

        private static void createReview(MyDbContext context)
        {
            
        }
       
        
    }
}
