using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class Guest
    {
        public DateTime Time {get;set;}
        public Review Review {get;set;}
        public List<GuestDish> GuestDish {get;set;}
    }
}