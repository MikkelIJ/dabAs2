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
