using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _013_ArraySearching
{
    internal class Program
    {
        // Thuat toan tim kiem tuyen tinh (KQ: tim thay tra i, khong thay tra -1)
        static int LinearSearch(int[] arr, int targetLS)
        {
            for (int i = 0; i < arr.Length; i++ )
            {
                if (arr[i] == targetLS)
                    return i;
            }
            return -1;
        }

        // Thuat toan tim kiem nhi phan
        static int BinarySearch(int[] arr, int targetBS)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int center = left + (right - left) / 2;

                if (arr[center] == targetBS)
                    return center;
                if (arr[center] < targetBS)
                    left = center + 1;
                else
                    right = center - 1;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            // Tim kiem tuyen tinh
            int[] number = { 8, 4, 0, 12, 2, 32, 45, 56 };
            int resultLS = LinearSearch(number, 2);

            // Cach viet day du 
            if (resultLS != -1)
                Console.WriteLine($"Tim thay 2 tai vi tri: {resultLS}");
            else
                Console.WriteLine("Khong tim thay so 45 trong mang");

            // Tim kiem nhi phan
            int[] arrSort = { 0, 2, 4, 8, 12, 32, 45, 56 };
            int resultBS = BinarySearch(arrSort, 10);

            // Cach viet gon: đieu_kien ? gia_tri_neu_đung : gia_tri_neu_sai;
            Console.WriteLine(resultBS != -1 ? $"Tim thay so 10 tại vị trí {resultBS}" : "Khong tim thay so 10 trong mang");
        }
    }
}
