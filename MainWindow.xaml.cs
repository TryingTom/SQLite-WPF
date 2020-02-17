using Microsoft.EntityFrameworkCore;
using Oppimistehtävä_5.DataBaseContext;
using Oppimistehtävä_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oppimistehtävä_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrderDbContext _db = new OrderDbContext();

        public MainWindow()
        {
            InitializeComponent();
            PouplateDb();

            this.OrdersList.ItemsSource = _db.Orders.ToList();
        }

        public void PouplateDb()
        {
            // if the database is empty
            if (_db.Orders.Count() == 0)
            {
                Product Pr1 = new Product
                {
                    Name = "Tuote 1",
                    Price = 50,
                    orderRows = new List<OrderRow>()
                };
                Order O1 = new Order
                {
                    Name = "Order 1",
                    Ordered = DateTime.Now,
                    status = 1,
                    orderRows = new List<OrderRow>()
                };
                OrderRow Or1 = new OrderRow
                {
                    Discount = 50.0F
                };

                Pr1.orderRows.Add(Or1);
                Or1.product = Pr1;

                Customer C1 = new Customer
                {
                    Name = "Customer 1",
                    Address = "Address 1",
                    Orders = new List<Order>()
                };

                OrderRow Or2 = new OrderRow
                {
                    Discount = 20.0F
                };
                Product Pr2 = new Product
                {
                    Name = "Tuote 2",
                    Price = 120,
                    orderRows = new List<OrderRow>()
                };

                Or2.product = Pr2;
                Pr2.orderRows.Add(Or2);
                O1.orderRows.Add(Or2);

                C1.Orders.Add(O1);
                O1.orderRows.Add(Or1);

                _db.OrderRows.Add(Or2);
                _db.Products.Add(Pr2);

                _db.Orders.Add(O1);
                _db.Products.Add(Pr1);
                _db.OrderRows.Add(Or1);
                _db.Customers.Add(C1);

                _db.SaveChanges();
            }
        }

        private void OrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrder = this.OrdersList.SelectedItem as Order;
            if(selectedOrder != null)
            {
                // reset view
                this.OrderInfoList.ItemsSource = null;

                // show the info
                //      include the product information - where the order id is the same with the selected id
                var data = _db.OrderRows.Include(o => o.product).Where(d => d.order.Id == selectedOrder.Id);
                this.OrderInfoList.ItemsSource = data.ToList();

                // calculate the price
                //      from the data query, sum of the product price multiplying with discount
                float price = data.Sum(p => (p.product.Price)*(1-(p.Discount/100)));

                // show the price
                this.PriceLabel.Content = price.ToString();

                
            }
            else
            {
                // else just show empty screen
                this.OrderInfoList.ItemsSource = null;
            }
        }
    }
}
