using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_Max_mang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 15, 7, 23, 9, 11, 23, 18, 9, 5, 0 };
            int max = numbers[0];

            // Dung vong lap FOR, CO tinh den chi so index tung phan tu trong mang
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            Console.WriteLine($" So lon nhat: {max}, dung FOR");

            // Dung vong lap FOREACH, KHONG tinh den chi so index tung phan tu trong mang
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($" So lon nhat: {max}, dung FOREACH");


            // Dung LINQ, KHONG tinh den chi so index tung phan tu trong mang
            Console.WriteLine($" So lon nhat: {numbers.Max()}, dung LINQ");
        }
    }
}
