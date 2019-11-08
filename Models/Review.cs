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
            var guest = "";
            if (Guest != null)
            {
                guest = string.Join(", ",Guest);
            }
            var dish = "";
            if (Dish != null)
            {
                dish = string.Join(", ",Dish);
            }

            return string.Format("{0} {1}\nReview: {2} \nStars: {3}\n",guest,dish,text,stars);
        }
    }
}