using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Kiemtrachanle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap mot so nguyen bat ky: ");
            int so = Convert.ToInt32(Console.ReadLine());

            if (so % 2 == 0)
            {
                Console.WriteLine($" {so} LA SO CHAN/ CHIA HET CHO 2");
            }
            else
            {
                Console.WriteLine($" {so} LA SO LE/ KHONG CHIA HET CHO 2");
            }

            if (so > 0)
            {
                Console.WriteLine($" {so} LA SO NGUYEN DUONG");
            }
            else if (so < 0)
            {
                Console.WriteLine($" {so} LA SO NGUYEN AM");
            }
        }
    }
}
