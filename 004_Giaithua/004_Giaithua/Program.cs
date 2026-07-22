using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_Giaithua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tinh gia thua bang vong lap while
            Console.Write("Nhap so nguyen m: ");
            int m = int.Parse(Console.ReadLine());

            if (m < 0)
            {
                Console.WriteLine("Loi: Giai thua can nhap so nguyen duong");
                return;
            }

            long GIAITHUA = 1;
            int y = 1;

            while (y <= m)
            {
                GIAITHUA *= y;
                y++;
            }

            Console.WriteLine($" Giai thua cua {m}! = {GIAITHUA}");

            // Tinh gia thua bang vong lap for
            Console.Write("Nhap so nguyen duong n: ");
            int n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                Console.WriteLine("Loi: Giai thua can nhap so nguyen duong");
                return;
            }

            //long giaithua = 1; // Use long for larger factorials
            long giaithua = 1; // Use BigInteger for very large factorials

            for (int i = 1; i <= n; i++)
            {
                giaithua *= i;
            }

            Console.WriteLine($" Giai thua cua {n}! = {giaithua}");


            // Nhap n tinh giai thua bang de quy
            Console.Write("NHAP SO NGUYEN DUONG k: ");
            int k = int.Parse(Console.ReadLine());

            if (k < 0)
            {
                Console.WriteLine("LOI: GIAI THUA CAN NHAP LA SO NGUYEN DUONG");
                return;
            }
            long Ketqua = Giaithua(k);

            Console.WriteLine($"GIAI THUA CUA {k}! = {Ketqua}");
        }

        // Tinh giai thua bang de quy
        static long Giaithua(int k)
        {
            if (k == 0 || k == 1)
            {
                return 1;
            }
            return k * Giaithua(k - 1);
        }
    }
}
