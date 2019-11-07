using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class ResturantType
    {
        public string type {get;set;}
        public int resturantTypeId {get;set;}
        public string resturantAdress {get;set;}
        public Resturant Resturant {get;set;}

        public override string ToString()
        {
            
            return string.Format("\nType: {0}",type);

        }
    }
}