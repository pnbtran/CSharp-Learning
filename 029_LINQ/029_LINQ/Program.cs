using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_LINQ
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public Product(string name, decimal price) { Name = name; Price = price; }
        }

        static void Main(string[] args)
        {
            List<Product> list = new List<Product>
            {
                new Product ("Laptop", 20000000),
                new Product ("Chuot", 200000),
                new Product ("Ban phim", 500000)
            };
            
              
            var product = list.Where (p => p.Price > 200000)
                              .OrderByDescending(p => p.Price)
                              .Select(p => p.Name)
                              .ToList();

            Console.WriteLine("Cac san pham dat (theo gia giam dan): ");
            foreach (string name in product)
            {
                Console.WriteLine($"- {name}");
            }

            decimal sumPrice = list.Sum(p => p.Price);
            Product cheap = list.OrderBy(p => p.Price).First();

            Console.WriteLine($" - Tong gia tri cac san pham: {sumPrice} VND");
            Console.WriteLine($" - Sam pham re nhat: {cheap.Name}");

            //----------------------------------------------- 
            Console.WriteLine();
            Console.WriteLine("Lam quen LINQ (phan nay de nhap kq cau lenh)");
            // Cach viet loc Where 
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //CACH 1: Query Syntax 
            var soChan1 = from num in numbers
                          where num % 2 == 0
                          select num;

            Console.WriteLine("Cac so chan (Query Syntax): ");
            foreach (var num in soChan1) Console.Write($"{num} ");
            Console.WriteLine();

            // CACH 2: Method Syntax 
            var soChan2 = numbers.Where(num => num % 2 == 0);

            Console.WriteLine("Cac so chan (Method Syntax): ");
            foreach (var n in soChan2) Console.Write($"{n} ");

            // Cac thao tac voi LINQ
            List<int> nums = new List<int> { 5, 2, 8, 1, 9, 3 };

            // Noi chuoi, loc sap xep roi chuyen thanh List (so lon hon 2, sap tang dan)
            var locVaSap = nums.Where(n => n > 2)
                                .OrderBy(n => n)
                                .ToList();

            int sum = nums.Sum();
            int count = nums.Count(n => n > 4);
            int max = nums.Max();
            double  average = nums.Average();
            int first = nums.First(n => n > 4);
            bool n100 = nums.Any(n => n > 100);

            Console.WriteLine($"- Tong: {sum}");
            Console.WriteLine($"- So luong ca so lon hon 4: {count}");
            Console.WriteLine($"- So lon nhat: {max}");
            Console.WriteLine($"- Gia tri trung binh: {average:N2}");
            Console.WriteLine($"-  dau tien (lon hon 4): {first}");
            Console.WriteLine($"- Co so lon hon 100 trong chuoi? {n100}");
        }
    }
}
