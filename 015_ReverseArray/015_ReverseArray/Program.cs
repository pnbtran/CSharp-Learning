using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_ReverseArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.WriteLine("Original Array");
            PrintArray(numbers);

            ReverseArray(numbers);

            Console.WriteLine("\nReversed Array");
            PrintArray(numbers);
        }

        static void ReverseArray(int[] numbers)
        {
            // Thuat toan 2 con tro 
            int FirstIndex = 0;
            int LastIndex = numbers.Length - 1;

            while (FirstIndex < LastIndex)
            {
                // Dung bien tam de hoan doi vi tri
                int temp = numbers[FirstIndex];
                numbers[FirstIndex] = numbers[LastIndex];
                numbers[LastIndex] = temp;

                FirstIndex++;
                LastIndex--;
            }
        }


        // In toan bo phan tu mang
        static void PrintArray(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
