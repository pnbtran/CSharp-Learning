using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace _014_AverageArray
{
    internal class Program
    {
        static double Average(int[] arr)
        {
            // Tinh tong cac phan tu mang
            if (arr.Length == 0) return 0;
            int sum = 0;
            foreach (int x in arr) sum += x;
            return (double)sum / arr.Length;
        }
        
        static void Main(string[] args)
        {
            // Tinh trung binh cong
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            Console.WriteLine($"Trung binh cong cua mang: {Average(numbers):F2}");

            // Viet gon bang LINQ
            Console.WriteLine($"Tong cac phan tu cua mang: {numbers.Sum()} (dung LINQ)");
            Console.WriteLine($"Trung binh cong cua mang: {numbers.Average():F2} (dung LINQ)");
        }
    }
}
