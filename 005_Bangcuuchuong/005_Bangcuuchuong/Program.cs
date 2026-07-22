using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_Bangcuuchuong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BANG CUU CHUONG");

            // In ra bang cuu chuong tu 2 den 9 dang bang
            // / In tieu de cot
            Console.Write("    ");
            Console.Write("x |");

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($" {i,4}");
            }
            // in ra dong ke
            Console.ReadLine();
            Console.WriteLine(new string('-', 60));

            // / in ra cac dong
            for (int i = 2; i <= 9; i++)
            {
                Console.Write($" {i,4} |");

                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($" {i * j,4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // In ra bang cuu chuong tu 2 den 9 dang danh sach
            for (int i = 2; i <= 9; i++)
            {
                Console.WriteLine($"\n Bang cuu chuong {i}: ");
                for (int j = 1; j <= 10; j++)
                    Console.WriteLine($" {i} * {j} = {i * j}");
            }
        }
    }
}
