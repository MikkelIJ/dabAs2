using System;
using System.Text;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Dish
    {
        public string name {get;set;}
        public float price {get;set;}
        public int id{get;set;}
 
        public Review Review {get;set;}
        
        public int? reviewId {get;set;}
 
        public List<DishType> DishType {get;set;}
        public List<ResturantDish> ResturantDish {get;set;}
        public List<GuestDish> GuestDish {get;set;}

        public override string ToString()
        {
            var dishType = "";
            if (DishType != null)
            {
                dishType = string.Join(", ",DishType);
            }

            return string.Format("\nDish: {0}, Price: {1}DKK, {2}", name, price, dishType);
        }
        
    }
}