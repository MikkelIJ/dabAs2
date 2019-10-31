using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class GuestDish
    {
        public int GuestDishId {get;set;}
        public Guest Guest {get;set;}
        public Dish Dish {get;set;}
    }
}