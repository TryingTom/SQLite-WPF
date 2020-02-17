using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppimistehtävä_5.Models
{
    class OrderRow
    {
        public int Id{ get; set; }
        public float Discount{ get; set; }

        public Order order{ get; set; }
        public Product product { get; set; }

        public override string ToString()
        {
            if (product != null){
                return $"Product name: {product.Name}\nPrice: {product.Price}€\nDiscount: {Discount}%";
            }
            else
            {
                return "The Product is null :(";
            }
        }

        public float GetPrice()
        {
            return (product.Price * 1 - (Discount / 100));
        }
    }
}
