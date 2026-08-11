using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _027_CollectionsList
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }

            public Product(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }

        static void Main(string[] args)
        {
            // Gio hang la danh sach cac Products
            List<Product> gioHang = new List<Product>();
            gioHang.Add(new Product ("Macbook", 50000000));
            gioHang.Add(new Product("Chuot khong day", 1000000));
            gioHang.Add(new Product("Ban phim co", 2000000));
            gioHang.Add(new Product("Mieng dan man hinh", 200000));

            // Loc sp lon hon 1tr
            List<Product> Expensive = gioHang.FindAll(p => p.Price > 1000000);

            Console.WriteLine("Cac san pham co gia tren 1 trieu: ");
            foreach (var p in Expensive)
            {
                Console.WriteLine($"- {p.Name}: {p.Price:N0} VND");
            }
            Console.WriteLine();

            // Sap xep voi Sort
            List<int> diem = new List<int> { 8, 4, 6, 2, 5, 9, 10, 0, 3 };
            diem.Sort();
            foreach (int d in diem)
            {
                Console.Write(d + " ");
            }
            Console.WriteLine();

            // Sap xep theo gia tri tang dan
            List<Product> sanPham = new List<Product>
            {
                new Product ("Chuot", 200000),
                new Product ("Laptop", 35000000),
                new Product ("Ban phim", 500000)
            };

            sanPham.Sort((a, b) => a.Price.CompareTo(b.Price));

            Console.WriteLine("Sap xep theo gia tri tang dan");
            foreach (var p in sanPham)
            {
                Console.WriteLine($" - {p.Name}: {p.Price:N0} VND");
            }

            //-----------------------------------------------------------------------------
            // LAM QUEN LIST<T>
            Console.WriteLine();
            Console.WriteLine("LAM QUEN LIST<T>");

            List<string> products = new List<string>();
            products.Add("Laptop");
            products.Add("Chuot may tinh");

            Console.WriteLine(products[0]);
            Console.WriteLine($"So phan tu trong List<products>: {products.Count}");

            List<int> numbers = new List<int>();
            List<string> fruits = new List<string> { "Tao", "Chuoi" };

            // Them - Chen - Them  nhieu
            fruits.Add("Cam");
            fruits.Insert(0, "Bo");
            fruits.AddRange(new[] { "Dau", "Nho" });

            // Xoa
            fruits.Remove("Chuoi");
            fruits.RemoveAt(0); 

            //fruits.Clear();   - xoa tat ca 

            // In bang foreach, duyet tung phan tu
            foreach (var f in fruits)
            {
                Console.WriteLine(f);
            }

            //Tim kiem va loc 
            List<string> ten = new List<string> { "An", "Cuong", "Binh", "Thuy", "An", "Hung" };

            bool coAn = ten.Contains("An");                                  //Co ton tai AN khong? 
            int viTri = ten.IndexOf("Binh");                                // Vi tri
            string batDauC = ten.Find(n => n.StartsWith("C"));              // Tim phan tu co chua "C" dau tien
            List<string> tatCaA = ten.FindAll(n => n.StartsWith("A"));

            Console.WriteLine($"Co An? {coAn}");
            Console.WriteLine($"Ten bat dau bang C: {batDauC}");
            Console.WriteLine($"Tim tat ca, ten bat dau bang A: {string.Join(", ", tatCaA)}");  

        }
    }
}
