using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Table
    {
        public int Number {get;set;}  
        public string resturantAddress {get;set;}
        public Resturant Resturant {get;set;}
        public List<Guest> Guest {get;set;}
        public List<WaiterTable> WaiterTable{get;set;}
    }
}