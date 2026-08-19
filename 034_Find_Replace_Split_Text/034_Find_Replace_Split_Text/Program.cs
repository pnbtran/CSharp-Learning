using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _034_Find_Replace_Split_Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chuoiGoc = "Hey, ban oi! Nho cuoi nhieu len nhe! Ban cuoi xinh lam";
            string tuCanTim = "XINH";

            //Kiem tra ket qua chuoi co chua tu can tim khong 
            bool ketQua = chuoiGoc.Contains(tuCanTim);
            Console.WriteLine($"- Chuoi co chua: '{tuCanTim}' khong? {ketQua}");

            // Ket qua khong phan biet hoa thuong 
            bool KetQuaKhongPhanBiet = chuoiGoc.IndexOf(tuCanTim, StringComparison.OrdinalIgnoreCase) >= 0;
            Console.WriteLine($"- Ket quan (khong phan biet hoa thuong) cua tu '{tuCanTim}': {KetQuaKhongPhanBiet}");

            string baiHat = "Hello, hello, hello, how are you?";
            string tuKhoa = "hello";

            // Tim tu khoa dau tien (phan biet hoa thuong) 
            int viTriDauuTien = baiHat.IndexOf(tuKhoa);
            Console.WriteLine($"- Vi tri dau tien (phan biet hoa thuong): '{tuKhoa}' - {viTriDauuTien}");

            // Tim vi tri dau tien (khong phan biet hoa thuong) 
            int viTriKhongPB = baiHat.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"- Vi tri dau tien (khong phan biet hoa thuong): {viTriKhongPB}");

            // VỊ tri cuoi cung 
            int viTriCuoiCung = baiHat.LastIndexOf("hello", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"- Vi tri cuoi cung cua 'hello': {viTriCuoiCung}");

            string duongDan = "D:\\002_DU BI\\5_VIETNAM\\CHI-BO\\Bai-thi-chinh-luan-2026_Pham-Nguyen-Bao-Tran.docx";

            // Kiem tra duong dan co bat dau bang "D:\\" khong 
            bool batDauBang = duongDan.StartsWith("D:\\");
            Console.WriteLine($"- Duong dan co bat dau bang C:\\: {batDauBang}");

            // Kiem tra xem file có phải .docx khong 
            bool ketThucBang = duongDan.EndsWith(".docx", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"- File cuoi co ket thuc bang .docx: {ketThucBang}");

            // Ung dung de kiem tra mail 
            string email = "pnbtran.work@gmail.com";
            if (email.EndsWith("@gmail.com"))
            {
                Console.WriteLine($"- {email} - Day la email cua Gmail.");
            }
            else
            {
                Console.WriteLine($"- {email} - Day khong phai la email cua Gmail.");
            }

            string cauNoi = "Hey, ban oi! Dung ham choi nua, di hoc bai di!";

            // Thay "hoc bai" thanh "lam bai"
            string kqThayThe = cauNoi.Replace("hoc bai", "lam bai");
            Console.WriteLine($"- Sau khi thay the: {kqThayThe}");

            // Ung dung: xoa khoang trang thua 
            string chuoiLoi = "To         con    tre, to             muon                   di                             choi.";

            // Lap + thay the den khi het loi
            while (chuoiLoi.Contains("  "))
            {
                chuoiLoi = chuoiLoi.Replace("  ", " ");
            }

            string chuoiSach = chuoiLoi.Trim();

            Console.WriteLine($"- Chuoi sau lam sach: {chuoiSach} ");

            // Thay the ki tu 
            string mattKhau = "mat-khau-may-nay-la-abc";
            string mkLap = mattKhau.Replace('-', '*');
            Console.WriteLine($"Mat khau moi: {mkLap}");

            string vanBan = "Nhan xet: Do an hien tai cua Tr dang dung TCVN2737:1995. Do an moi can cap nhat sang TCVN2737:2023. De tinh toan tai trong cong trinh.";

            if (vanBan.Contains("TCVN"))
            {
                string vbMoi = vanBan.Replace("TCVN", "Tieu chuan Viet Nam ");
                Console.WriteLine($"- Van ban moi: {vbMoi}");
            }

            // CHIA TACH DON GIAN 
            string list = "Tao, cam, chuoi, nho, xoai";
            char kiTuPhanCach = ',';

            string[] cacLoaiQua = list.Split(kiTuPhanCach);

            Console.WriteLine("Cac loai qua trong danh sach: ");
            for (int i = 0; i < cacLoaiQua.Length; i++)
            {
                Console.WriteLine($" {i + 1} - {cacLoaiQua[i]}");
            }

            // CHIA CACH VOI NHIEU KI TU PHAN CACH 
            string cauPhucTap = "Tao; Cam, Chuoi. Nho, Xoai, Oi; Lua";
            char[] nhieuKiTuPhanCach = { ';', ',', '.' };

            string[] cacQua = cauPhucTap.Split(nhieuKiTuPhanCach, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("\nCac loai qua (da loai bo khoang trang va phan tu rong): ");
            foreach (string qua in cacQua)
            {
                Console.WriteLine($"- {qua.Trim()}");
            }

            // CHIA TACH VOI TUY CHON StringSplitOptions
            string Data = "Name: Khue;;Age: 26;;City: Ho Chi Minh";
            string[] Result = Data.Split(new string[] { ";" }, StringSplitOptions.None);

            Console.WriteLine("\n- Thong tin ca nhan: ");

            foreach (string part in Result)
            {
                Console.WriteLine($"{part}");
            }

            // UNG DUNG SPLIT XU LI CHUOI CSV
            string dataCSV = "Nguyen Van A, 25, so 76 - Khu pho 1 - Phuong Phu Tan - Tinh Vinh Long, Ky su" +
                "\nTran Thi B, 27, So 15 - Ap An Hoa - Xa Binh Khanh - Tinh Vinh Long, Nhan vien van phong";

            // 1-Chia thanh tung dong
            string[] lines = dataCSV.Split('\n');

            Console.WriteLine("Danh sach nhan su: ");

            foreach (string line in lines)
            {
                string[] column = line.Split(','); 

                if (column.Length >= 4)
                {
                    Console.WriteLine($"- Ho ten: {column[0]}, Tuoi: {column[1]}, Dia chi: {column[2]}, Chuc vu: {column[3]}.");
                }
            }

            string ID = "NV2026081973740209";

            string year = ID.Substring(2, 4);
            Console.WriteLine($"- Nam bat dau cong viec: {year}");

            string ordinal = ID.Substring(14, 4);
            Console.WriteLine($"- So thu tu trong Cong ty: {ordinal}"); 

            // Trich xuat ten file tu duong dan 
            string link = @"D:\\002_DU BI\\5_VIETNAM\\CHI-BO\\Bai-thi-chinh-luan-2026_Pham-Nguyen-Bao-Tran.docx"; 

            int last = link.LastIndexOf('\\');

            string nameFile = link.Substring(last + 1);
            Console.WriteLine($"- Ten File: {nameFile}");

            // CHUAN HOA DANH SACH MAIL 
            string listEmail = " USER1@GMAIL.COM; user2@yandex.ru; USER3@UNIVERSITY.VN; user1@gmail.com";

            // 1 - Loai bo khoang trang thua o dau va cuoi chuoi 
            listEmail = listEmail.Trim();

            // 2 - Thay the ki tu phan cach khan nhau thanh cung loai
            listEmail = listEmail.Replace(';', ',');

            // 3 - Chia mang thanh Email nho 
            string[] Email = listEmail.Split(',');

            // 4 - Chuan hoa tung mail(viet thuong, loai bo khoang trang)
            Console.WriteLine("Danh sach Email: "); 

            for (int i = 0; i < Email.Length; i++)
            {
                Email[i] = Email[i].ToLower().Trim();

                Console.WriteLine($" {i + 1} - {Email[i]}"); 
            }
            // Loai bo email trung lap (su dung LINQ) 
            var EmailkhongTrung = Email.Distinct();
            Console.WriteLine("\nDanh sach Email khong trung: "); 
            foreach (string mail in EmailkhongTrung)
            {
                Console.WriteLine($"- {mail}"); 
            }
        }
    }
}
