using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DABAS2.Models
{
    public class Person
    {
        public string name {get;set;}
        public int id {get;set;}
        public Waiter waiter {get;set;}
        public Guest guest {get;set;}

        public override string ToString()
        {
            return string.Format("{0}", name);
        }
    }
    
}