using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class DishType
    {
        public string type {get;set;}
        public int dishTypeId {get;set;}
        public int dishId {get;set;}
        public Dish Dish {get;set;}

        public override string ToString()
        {
            return string.Format("Dish type: {0}",type);
        }
    }
}