using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _031_ProductManagement
{
    internal class Program
    {
        public class Product
        {
            public int IDProduct { get; set; }
            public string NameProduct { get; set; }
            public decimal Price { get; set; } 

            public Product (int idProduct, string nameProduct, decimal price)
            {
                IDProduct = idProduct;
                NameProduct = nameProduct;
                Price = price;
            }
        }

        public class Customer
        {
            public int IDCustomer { get; set; }
            public string NameCustomer { get; set; }

            public Customer (int idCustomer, string nameCustomer)
            {
                IDCustomer = idCustomer;
                NameCustomer = nameCustomer;
            }
        }

        public class OrderItem
        {
            // Quan he HAS-A: OrderItem chua product 
            public Product Product { get; set; }
            public int Quantity { get; set; }

            public OrderItem (Product product, int quantity)
            {
                Product = product;
                Quantity = quantity;
            }

            public decimal SubTotal => Product.Price * Quantity;
        } 

        public class Order
        {
            public int Id { get; set; }
            public Customer Customer { get; set; }
            public List<OrderItem> Items { get; set; } = new List<OrderItem>();

            public Order (int id, Customer customer)
            {
                Id = id;
                Customer = customer;
            }

            // Them san pham vao don
            public void AddItem(Product p, int qty) => Items.Add(new OrderItem(p, qty));

            // Thanh tien cua don hang (LINQ)
            public decimal Total => Items.Sum(item => item.SubTotal); 

            public void MenuShow()
            {
                Console.WriteLine($" Don hang {Id} - Khach hang: {Customer.NameCustomer}");

                foreach (var item in Items)
                {
                    Console.WriteLine($"- SP: {item.Product.NameProduct} x SL: {item.Quantity} = TT: {item.SubTotal:N0} VND");
                }
                Console.WriteLine($" -- TONG CONG: {Total:N0} VND");
                Console.WriteLine(); 
            }
        }

        static void Main(string[] args)
        {
            var laptop = new Product (1, "Laptop", 35000000);
            var macbook = new Product (2, "Macbook", 50000000);
            var chuot = new Product (3, "Chuot", 650000);
            var banphim = new Product(4, "ban phim", 340000);

            var cus1 = new Customer (001, "Hoa");
            var cus2 = new Customer (002, "Lan");
            var cus3 = new Customer(003, "Khue");

            var order1 = new Order (01, cus1);
            order1.AddItem(macbook, 2);
            order1.AddItem(chuot, 1);
            order1.MenuShow();

            var order2 = new Order (02, cus2);
            order2.AddItem(laptop, 1);
            order2.AddItem(chuot, 1);
            order2.AddItem(banphim, 1);
            order2.MenuShow();

            var order3 = new Order(03, cus3);
            order3.AddItem(laptop, 3);
            order3.AddItem(macbook, 1);
            order3.AddItem(chuot, 2);
            order3.AddItem(banphim, 3);
            order3.MenuShow();

            List<Order> orders = new List<Order>
            {
                order1,
                order2,
                order3
             };

            decimal doanhThu = orders.Sum(o => o.Total);
            Console.WriteLine($"\n - Tong doanh thu cua cua hang: {doanhThu:N0} VND");

            Order orderMax = orders.OrderByDescending(o => o.Total).First();
            Console.WriteLine($" - Don hang co gia tri lon nhat: #{orderMax.Id} - {orderMax.Total:N0} VND");

            var orderKhue = orders.Where(o => o.Customer.NameCustomer == "Khue").ToList();
            Console.WriteLine($" - So don cua Khue: {orderKhue.Count}");
        }
    }
}
