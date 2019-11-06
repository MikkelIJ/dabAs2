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
                    System.Console.WriteLine("View: l(List all resturants)");
                    System.Console.WriteLine("Create: r(Resturant), w(Waiter), t(Table), d(Dish), g(Guest), rw(Review)");
                    System.Console.WriteLine("Exit: x");
                    System.Console.WriteLine("Type Command");
                    string line = Console.ReadLine();

                    switch (line)
                    {
                        case "l":
                            ListResturants(context);
                            break;
                    
                    }
                }
            }
            
        
        }

    private static void ListResturants(MyDbContext context)
    {
        List<Resturant> resturants = context.Resturants.ToList();

            System.Console.WriteLine(string.Join(",",resturants));
        
    }
       
        
    }
}
