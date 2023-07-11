using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApi.Models
{
    //comment
    public class Address
    {
        public int Id { set; get; }
        public int User_id { set; get; }
        public string Address_type { set; get; }
        public string City { set; get; }
        public string Post_code { set; get; }
        public string Country { set; get; }
    }
}
