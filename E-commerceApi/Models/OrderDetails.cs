﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApi.Models
{
    public class OrderDetails
    {
        public int Id { set; get; }
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public int Unit_price { set; get; }
    }
}
