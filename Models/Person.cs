using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Person
    {
        public string Name {get;set;}
        public int id {get;set;}
        public Waiter waiter {get;set;}
        public Guest guest {get;set;}
        
    }
}