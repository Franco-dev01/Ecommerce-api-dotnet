using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApi.Models
{
    public class ECommerceApiContext: DbContext
    {
        public ECommerceApiContext (DbContextOptions<ECommerceApiContext> options): base(options) { }
        //context api
        public DbSet<User> Users { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Address> Address { set; get; }
        public DbSet<Payment> Payments { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<OrderDetails> Order_details { set; get; }
    }
}
