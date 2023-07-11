using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApi.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Email_address { set; get; }
        public string DefaultShoppingAddress { set; get; }
        public string DefaultBillingAddress { set; get; }
    }
}
