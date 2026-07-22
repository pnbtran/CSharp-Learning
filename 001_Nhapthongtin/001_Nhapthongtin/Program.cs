using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Nhapthongtin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" CHUONG TRINH NHAP XUAT THONG TIN CA NHAN");
            Console.WriteLine();

            // Nhap thong tin ca nhan
            Console.Write("Nhap ho ten: ");
            string hoten = Console.ReadLine();

            Console.Write("Nhap tuoi: ");
            int tuoi = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap que quan: ");
            string quequan = Console.ReadLine();

            Console.Write("Nhap nghe nghiep: ");
            string nghenghiep = Console.ReadLine();

            Console.Write("Nhap ten Co quan: ");
            string coquan = Console.ReadLine();

            Console.Write("Nhap so nam kinh nghiem: ");
            double namkinhnghiem;
            while (!double.TryParse(Console.ReadLine(), out namkinhnghiem))
            {
                Console.WriteLine("So nam kinh nghiem nhap khong hop le. Can nhap lai dang so");
            }

            Console.WriteLine();

            // Xuat thong tin ca nhan
            Console.WriteLine("THONG TIN CA NHAN");

            Console.WriteLine($" Ho ten: {hoten}");

            Console.WriteLine($" Tuoi: {tuoi}");

            Console.WriteLine($" Que quan: {quequan}");

            Console.WriteLine($" Nghe nghiep: {nghenghiep}");

            Console.WriteLine($" Co quan: {coquan}");

            Console.WriteLine($" Nam kinh nghiem: {namkinhnghiem}");

            Console.WriteLine("________");

            Console.WriteLine("\n Nhan phim bat ky de thoat chuong trinh...");
            Console.ReadKey();
        }
    }
}
