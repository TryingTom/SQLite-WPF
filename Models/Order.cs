using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppimistehtävä_5.Models
{
    class Order
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public DateTime Ordered{ get; set; }
        public int status{ get; set; }

        public List<OrderRow> orderRows{ get; set; }
        public Customer customer{ get; set; }

        // note: this is required to get the data in string format, rather than --/Models/Orders
        public override string ToString()
        {
            return $"Customer Name: {Name}\nCustomer Id: {Id}";
        }
    }
}
