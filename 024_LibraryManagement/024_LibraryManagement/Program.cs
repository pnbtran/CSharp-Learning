using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _024_LibraryManagement
{
    internal class Program
    {
        // CLASS BOOK
        public class Book
        {
            public string BookID { get; set; }   
            public string Title { get; set; }
            public string Author { get; set; }
            public bool IsAvailable { get; set; } = true;

            public Book(string bookID, string title, string author, bool isAvailable)
            {
                BookID = bookID;
                Title = title;
                Author = author;
                IsAvailable = isAvailable;
            } 

            public void DisplayInfo()
            {
                string status = IsAvailable ? "DANG CO SAN" : "KHONG CO SAN";
                Console.WriteLine($"{BookID} - Quyen: {Title} - TG: {Author} - {status}");
            }
        }

        // CLASS MEMBER 
        public class Member
        {
            public string MemberID { get; set; } 
            public string Name { get; set; }
            public List<Book> BorrowedBooks { get; private set; }

            public Member (string memberID, string name)
            {
                MemberID = memberID;
                Name = name;

                // Khoi tao danh sach rong
                BorrowedBooks = new List<Book>();
            }

            public void BorrowBook(Book book)
            {
                if (book.IsAvailable)
                {
                    BorrowedBooks.Add(book);

                    // Them danh sach SACH da muon
                    book.IsAvailable = false;

                    Console.WriteLine($"{Name} da muon {book.Title}");
                }

                else
                {
                    Console.WriteLine($"Sach {book.Title} hien khong co san");
                }
            }

            public void ReturnBook(Book book)
            {
                if (BorrowedBooks.Contains(book))
                {
                    BorrowedBooks.Remove(book);
                    book.IsAvailable = true;
                    Console.WriteLine($"{Name} da tra '{book.Title}'.");
                }
                else
                {
                    Console.WriteLine($"{Name} khong muon '{book.Title}' nen khong the tra.");
                }
            }

            // In danh sach cac quyen da muon
            public void ShowBorrowedBooks()
            {
                Console.WriteLine($"\n- Sach {Name} dang muon ({BorrowedBooks.Count} cuon)");

                if (BorrowedBooks.Count == 0)
                {
                    Console.WriteLine("Chua muon quyen sach nao.");
                    return;
                }

                foreach (Book book in BorrowedBooks)
                {
                    Console.WriteLine($"- Quyen {book.Title}, TG: {book.Author}.");
                }
            }
        }

        // CLASS LIBRARY
        public class Library
        {
            private List<Book> books = new List<Book>();
            private List<Member> members = new List<Member>();

            public void AddBook (Book book) => books.Add(book);
            public void AddMember(Member member) => members.Add(member);

            // Tim ma sach trong danh sach
            public Book FindBook(string id) => books.Find(b => b.BookID == id);

            public void ShowAllBooks()
            {
                Console.WriteLine("\n DANH SACH QUAN LI CUA THU VIEN");

                foreach (Book book in books)
                {
                    book.DisplayInfo();
                }
            }
        }

        static void Main(string[] args)
        {
            Library lib = new Library();
            Book b1 = new Book("B001", "Ruoi trau", "Ethel L. Voynich", true);
            Book b2 = new Book("B002", "Nuoc Nga hoi sinh - Suc manh trat tu the gioi moi", "Kathryn E. Stoner", true);
            Book b3 = new Book("B003", "Nhung hon da nho vi su phat trien ben vung", "Nguyen Ngoc Tran", true);

            lib.AddBook(b1);
            lib.AddBook(b2);
            lib.AddBook(b3);

            Member an = new Member("M001", "An");
            Member binh = new Member("M002", "Binh");
            lib.AddMember(an);
            lib.AddMember(binh);

            lib.ShowAllBooks();

            an.BorrowBook(b1);
            binh.BorrowBook(b2);

            an.ShowBorrowedBooks();
            binh.ShowBorrowedBooks();

            lib.ShowAllBooks();

            an.ReturnBook(b1);
            binh.ReturnBook(b2); 

            lib.ShowAllBooks();
        }
    }
}