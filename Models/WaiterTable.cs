using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class WaiterTable
    {
        public int waiterTableId {get;set;}
        public int waiterId {get;set;}
        public int tableNumber {get;set;}
        public Waiter Waiter {get;set;}
        public MyTable myTable {get;set;}
    }
}