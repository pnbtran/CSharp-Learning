using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_ArrayAscendingSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Nhap mang ban dau
            int[] numbers = { 9, 5, 22, 0, 1, 6, 88, 11, 3, 21, 26, 10, 2 };

            Console.WriteLine("Mang ban dau: ");
            PrintArray(numbers);

            // In ket qua Array Sort 
            Array.Sort(numbers);

            Console.WriteLine("Sau khi sap xep tang dan: ");
            PrintArray(numbers);

            //In ket qua Bubble Sort
            BubbleSort(numbers);

            Console.WriteLine("Ket qua can tim: ");
            PrintArray(numbers);

            // In ket qua Selection Sort
            SelectionSort(numbers);

            Console.WriteLine("Ket qua sap xep: ");
            PrintArray(numbers);

            // In ket qua Array Reversre
            Array.Reverse(numbers);

            Console.WriteLine("Sau khi sap xep giam dan: ");
            PrintArray(numbers);
        }

        //CACH 1 - Dung Array.Sort - sap xep tang dan
        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
                Console.Write(num + " ");
            Console.WriteLine();
        }

        // Cach 2 - Dung BUBBLE SORT
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n -1; i++)             // So luot vong lap
            {
                for (int j = 0; j < n - i - 1; j++)         // So sanh tung cap
                {
                    if (arr[j] > arr[j + 1])          // Doi thu tu 
                    {

                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

        }

        // Cach 3 - Dung Selection Sort 
        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;                       // Gia su i la min
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;                   // Nho vi tri MIN vua tim duoc
                    }
                }

                // Doi cho phan tu MIN tim duoc
                int temp = arr[i]; 
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

    }
}
