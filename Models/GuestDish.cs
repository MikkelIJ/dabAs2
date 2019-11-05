using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class GuestDish
    {
        public int guestDishId {get;set;}
        public int guestId {get;set;}
        public int dishId {get;set;}
        public Guest Guest {get;set;}
        public Dish Dish {get;set;}
    }
}