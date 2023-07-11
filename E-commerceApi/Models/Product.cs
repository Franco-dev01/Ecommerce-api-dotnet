using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApi.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Price { set; get; }
        public string Description { set; get; }
        public string AvailableStock { set; get; }
        public string Category { set; get; }
    }
}
