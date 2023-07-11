using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApi.Models
{
    public class Order
    {
        public string Id { set; get; }
        public int UserId { set; get; }
        public string OrderDate { set; get; }
        public string OrderStatus { set; get; }
        public string OrderTotal { set; get; }
    }
}
