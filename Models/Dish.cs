using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Dish
    {
        public float price {get;set;}
        public Review Review {get;set;}
        public List<DishType> DishType {get;set;}
        public List<ResturantDish> ResturantDish {get;set;}
    }
}