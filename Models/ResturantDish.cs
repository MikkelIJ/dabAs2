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
    }
}