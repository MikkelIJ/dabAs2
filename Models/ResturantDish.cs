using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class ResturantDish
    {
        public int ResturantDishId {get;set;}
        public int DishId {get;set;}
        public string ResturantAddress {get;set;}  
        public Resturant Resturant {get;set;}
        public Dish Dish {get;set;}

        public override string ToString()
        {
           var dish = "";
            if (Dish != null)
            {
                dish = string.Join("",Dish);
            }

            return string.Format("{0}", Dish);
        }
    }
}