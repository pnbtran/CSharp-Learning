using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Chuyendoinhietdo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double doC;

            while (true)
            {
                Console.Write("Vui long nhap nhiet do C: ");

                string input = Console.ReadLine();

                if (double.TryParse(input,
                    NumberStyles.Float | NumberStyles.AllowThousands,
                    CultureInfo.CurrentCulture,
                    out doC))
                {
                    break;
                }

                Console.WriteLine("Loi! Vui long nhap lai.");
            }

            double doF = doC * 9 / 5 + 32;
            // - 40 do C = -40 do F, diem giao

            double doK = doC + 273.15;

            Console.WriteLine($"{doC} do C = {doF:F2} do F");
            Console.WriteLine($" {doC} do C = {doK:F2} do K");
        }
    }
}
