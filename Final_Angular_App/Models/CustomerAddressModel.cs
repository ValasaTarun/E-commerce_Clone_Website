using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerAddressModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string ZipCode { get; set; }
    }
}
