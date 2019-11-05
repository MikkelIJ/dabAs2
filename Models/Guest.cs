using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Guest
    {
        public int id {get;set;}
        public DateTime Time {get;set;}
        public Review Review {get;set;}
        public int reviewId {get;set;}
        public int tableNumber {get;set;}
        public Table Table {get;set;}
        public List<GuestDish> GuestDish {get;set;}
    }
}