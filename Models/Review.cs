using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Review
    {
        public int id {get;set;}
        public int stars {get;set;}
        public string text {get;set;}
        public string resturantAddress {get;set;}
        public Resturant Resturant {get;set;}
        public List<Dish> Dish {get;set;}
        public List<Guest> Guest {get;set;}

         public override string ToString()
        {
            return string.Format("\nReview: {0} \nStars: {1}\n",text,stars);
        }
    }
}