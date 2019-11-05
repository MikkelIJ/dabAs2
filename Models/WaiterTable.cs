using System;
using System.Collections.Generic;

namespace DABAS2.Models
{
    public class WaiterTable
    {
        public int waiterTableId {get;set;}
        public int waiterId {get;set;}
        public int tableNumber {get;set;}
        public Waiter waiter {get;set;}
        public Table table {get;set;}
    }
}