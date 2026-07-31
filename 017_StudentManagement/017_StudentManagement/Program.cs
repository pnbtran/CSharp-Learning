using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _017_StudentManagement
{
    internal class Program
    {
        // KHOI TAO CAC BIEN TOAN CUC
        // Mang luu danh sach sinh vien
        static string[] ListStudent;

        // So luong sinh vien hien co
        static int CountStudent = 0;

        // Suc chua toi da
        static int CapacityStudent = 100;

        static void Main(string[] args)
        {
            ListStudent = new string[CapacityStudent];
            ShowMenu();
        }

        //Khoi tao Menu
        static void ShowMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                DisplayMenu();

                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        DisplayStudents();
                        break;

                    case "3":
                        FindStudent();
                        break;

                    case "4":
                        DeleteStudent();
                        break;

                    case "5":
                        Console.WriteLine("Tam biet!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                Console.WriteLine();
            }
        }

        // Hien thi Menu
        static void DisplayMenu()
        {
            Console.WriteLine("========== QUAN LY SINH VIEN ==========");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Hien thi danh sach");
            Console.WriteLine("3. Tim kiem sinh vien");
            Console.WriteLine("4. Xoa sinh vien");
            Console.WriteLine("5. Thoat");
            Console.Write("Chon (1-5): ");
        }

        //Them 
        static void AddStudent()
        {
            if (CountStudent >= CapacityStudent)
            {
                Console.WriteLine("Danh sach da day!");
                return;
            }

            Console.Write("Nhap ten sinh vien: ");
            ListStudent[CountStudent] = Console.ReadLine();

            CountStudent++;

            Console.WriteLine("Them thanh cong!");
        }

        //Hien thi
        static void DisplayStudents()
        {
            if (CountStudent == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.WriteLine("\n===== DANH SACH SINH VIEN =====");

            for (int i = 0; i < CountStudent; i++)
            {
                Console.WriteLine($"{i + 1}. {ListStudent[i]}");
            }
        }

        //Tim kiem
        static void FindStudent()
        {
            if (CountStudent == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.Write("Nhap ten can tim: ");
            string searchName = Console.ReadLine();

            for (int i = 0; i < CountStudent; i++)
            {
                if (ListStudent[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Tim thay tai vi tri {i + 1}.");
                    return;
                }
            }

            Console.WriteLine("Khong tim thay sinh vien!");
        }

        //Xoa s
        static void DeleteStudent()
        {
            if (CountStudent == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.Write("Nhap ten sinh vien can xoa: ");
            string deleteName = Console.ReadLine();

            int position = -1;

            for (int i = 0; i < CountStudent; i++)
            {
                if (ListStudent[i].Equals(deleteName, StringComparison.OrdinalIgnoreCase))
                {
                    position = i;
                    break;
                }
            }

            if (position == -1)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }

            for (int i = position; i < CountStudent - 1; i++)
            {
                ListStudent[i] = ListStudent[i + 1];
            }

            CountStudent--;

            Console.WriteLine("Da xoa thanh cong!");
        }
    }
}