using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Resturant
    {
        public string name{get;set;}
        public string address{get;set;}
        //public Review review {get;set;}
        public List<ResturantType> ResturantType {get;set;}
        public List<Review> Review {get;set;}
        public List<ResturantDish> ResturantDish {get;set;}
        public List<MyTable> myTable {get;set;}
        
        public override string ToString()
        {
            var resturantType = "";
            if (ResturantType != null)
            {
                resturantType = string.Join(", ",ResturantType);
            }
            var review = "";
            if (Review != null)
            {
                review = string.Join("",Review);
            }
            var resturantDish = "";
            if (ResturantDish != null)
            {
                resturantDish = string.Join("",ResturantDish);
            }
            
            return string.Format("Resturant: {0} \nAdress: {1} {2} {3} {4}\n",name,address,resturantType,review,resturantDish);

        }

    }
}