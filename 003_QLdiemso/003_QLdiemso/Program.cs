using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_QLdiemso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hien thi Tieng Viet
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("CHUONG TRINH QUAN LY DIEM SO DON GIAN");

            // Nhap diem mon hoc va kiem tra tinh hop le
            int soMonHoc = 0;
            bool nhapThanhCong = false;

            while (!nhapThanhCong)
            {
                Console.Write("\nNhap so luong mon hoc: ");
                string nhap = Console.ReadLine();

                if (int.TryParse(nhap, out soMonHoc)) // Kiem tra xem nhap co phai la so nguyen khong
                {
                    if (soMonHoc > 0)
                        nhapThanhCong = true;
                    else
                        Console.WriteLine("So luong mon hoc phai la so nguyen duong. Vui long nhap lai.");
                }
                else
                {
                    Console.WriteLine("Vui long nhap mot so nguyen duong.");
                }
            }

            // Nhap diem tung mon
            double tongDiem = 0;
            for (int i = 1; i <= soMonHoc; i++)
            {
                bool nhapDiemOk = false;
                double diem = 0;

                while (!nhapDiemOk)
                {
                    Console.Write($"Nhap diem mon thu {i}: ");
                    if (double.TryParse(Console.ReadLine(), out diem))
                    {
                        if (diem >= 0 && diem <= 10)
                        {
                            tongDiem += diem;
                            nhapDiemOk = true;
                        }
                        else Console.WriteLine("Diem phai nam trong khoang tu 0 den 10. Vui long nhap lai.");
                    }
                    else Console.WriteLine("Du lieu khong hop le. Nhap mot so thuc tu 0 den 10. Vui long nhap lai.");
                }
            }

            // Tinh diem trung binh và xep loai
            double diemTrungbinh = tongDiem / soMonHoc;

            string xeploai;
            if (diemTrungbinh >= 9) xeploai = "XUAT SAC";
            else if (diemTrungbinh >= 8) xeploai = "GIOI";
            else if (diemTrungbinh >= 7) xeploai = "KHA";
            else if (diemTrungbinh >= 5) xeploai = "TRUNG BINH";
            else xeploai = "YEU";

            // In ket qua
            Console.WriteLine("\n KET QUA XEP LOAI");
            Console.WriteLine($" So mon hoc: {soMonHoc}");
            Console.WriteLine($" Tong diem: {tongDiem}");
            Console.WriteLine($" Diem trung binh: {diemTrungbinh}");
            Console.WriteLine($" Xep loai: {xeploai}");

            Console.WriteLine("\n Nhan phim bat ky de ket thuc");
            Console.ReadKey();
        }
    }
}
