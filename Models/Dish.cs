using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Dish
    {
        public float price {get;set;}
        public int id{get;set;}
        public Review Review {get;set;}
        public int reviewId {get;set;}
        public List<DishType> DishType {get;set;}
        public List<ResturantDish> ResturantDish {get;set;}
        public List<GuestDish> GuestDish {get;set;}
    }
}