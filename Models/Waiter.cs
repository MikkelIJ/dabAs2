using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Waiter : Person
    {
        public int id {get;set;}
        public float salary {get;set;}
        public List<WaiterTable> WaiterTable {get;set;}
        
    }
}