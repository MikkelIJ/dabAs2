using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Review
    {
        public int stars {get;set;}
        public string text {get;set;}
        public string resturantAddress {get;set;}
        public Resturant Resturant {get;set;}
        public List<Dish> Dish {get;set;}
        public List<Guest> Guest {get;set;}
    }
}