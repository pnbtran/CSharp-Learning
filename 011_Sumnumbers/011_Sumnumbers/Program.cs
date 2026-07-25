using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_Sumnumbers
{
    internal class Program
    {
        // Dinh nghia phuong thuc 
        static int SumNumber (int a, int b)
        {
            return a + b;
        }
        
        static void Main(string[] args)
        {
            int Sum = SumNumber(5, 15);
            Console.WriteLine($" Tong cua 5 va 10 là: {Sum}");

            int x = 15, y = 35;
            int Answer = SumNumber(x, y);
            Console.WriteLine($"Tong cua {x} và {y} là: {Answer}"); 
        }
    }
}
