using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
