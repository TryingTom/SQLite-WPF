using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppimistehtävä_5.Models
{
    class Product
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public float Price{ get; set; }

        public List<OrderRow> orderRows { get; set; }

        public override string ToString()
        {
            return $"Product: {Name}\nPrice: {Price}";
        }
    }
}
