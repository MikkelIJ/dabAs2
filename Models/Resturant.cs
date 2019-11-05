using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Resturant
    {
        public string name{get;set;}
        public string address{get;set;}
        public List<ResturantType> ResturantType {get;set;}
        public List<Review> Review {get;set;}
        public List<ResturantDish> ResturantDish {get;set;}
        public List<MyTable> myTable {get;set;}
    }
}