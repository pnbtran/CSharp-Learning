using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020_ClassBookManagement
{
    internal class Program
    {
        public class Book
        {
            public int ID;
            public string Title;
            public string Publisher;
            public string Author;
            public int YearPublished;
            
            private decimal _price;
            public decimal Price
            {
                get
                {
                    return _price;
                }

                set
                {
                    if (value >= 0)
                    {
                        _price = value;
                    }
                }
            }
            
            public int NumberOfPages;

            public Book(int id, string title, string publisher, string author, int yearPublished, decimal price, int numberOfPages)
            {
                ID = id;
                Title = title;
                Publisher = publisher;
                Author = author;
                YearPublished = yearPublished;
                Price = price;
                NumberOfPages = numberOfPages;
            }

            public void Show()
            {
                Console.WriteLine($"[{ID}] - {Title}, NXB {Publisher}, {Author}, {YearPublished}, giá {Price:N0} VND, {NumberOfPages} trang");
            }
        }

        public static Book Input()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Ten sach: ");
            string title = Console.ReadLine();

            Console.Write("Nha xuat ban: ");
            string publisher = Console.ReadLine();

            Console.Write("Tac gia: ");
            string author = Console.ReadLine();

            Console.Write("Nam xuat ban: ");
            int yearPublished = int.Parse(Console.ReadLine());

            Console.Write("Gia: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("So trang: ");
            int numberOfPages = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");

            return new Book(id, title, publisher, author, yearPublished, price, numberOfPages);
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap so luong sach: ");
            int n = int.Parse(Console.ReadLine());

            Book[] library = new Book[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhap thong tin quyen sach thu: {i + 1}");

                library[i] = Input();
            }

            foreach (Book book in library)
            {
                book.Show();
            }
        }
    }
}