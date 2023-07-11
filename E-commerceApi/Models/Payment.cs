using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApi.Models
{
    public class Payment
    {
        public int Id { set; get; }
        public int Order_id { set; get; }
        public string Payment_method { set; get; }
        public string Amount_paid { set; get; }
        public System.DateTime Payment_date { set; get; }
        public string Payment_status { set; get; }
    }
}
