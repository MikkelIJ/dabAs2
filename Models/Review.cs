using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Review
    {
        public int stars {get;set;}
        public string text {get;set;}
        public Resturant Resturant {get;set;}
        public List<Dish> Dish {get;set;}
    }
}