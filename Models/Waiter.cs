using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Waiter
    {
        public int id {get;set;}
        public int personId {get;set;}
        public float salary {get;set;}
        public List<WaiterTable> WaiterTable {get;set;}
        public Person person {get;set;}
        
    }
}