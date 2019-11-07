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
            var resturantDish = new StringBuilder();
            foreach (var rd in ResturantDish)
            {
                resturantDish.Append(rd.Resturant).Append(",");
            }


            return string.Format("\n{0}, Price: {1}DKK,", name, price);
        }
        
    }
}