using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _028_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> tuDien = new Dictionary<string, string>();

            // Them bang Add
            tuDien.Add("любезно", "kich su, vui long");
            tuDien.Add("общаться", "giao tiep, tro chuyen");
            tuDien.Add("скучать", "nho nhung");
            tuDien.Add("замечательный", "tuyet voi");
            tuDien.Add("великолепный", "trang le");
            tuDien.Add("причина", "nguyen nhan, li do");
            tuDien.Add("прощать-простить", "tha thu");
            tuDien.Add("искренне", "chan thanh");
            tuDien.Add("подружиться", "ket ban");
            tuDien.Add("удивительно", "dang ngac nhien");
            tuDien.Add("использовать", "su dung");
            
            // Hoac them/ sua bang indexer[]
            tuDien["преподносить-преподнести"] = "gioi thieu";
            tuDien["надеяться"] = "hy vong";

            // Them phuong thuc de hien thi chu tieng Nga
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Tra cuu tu khoa
            Console.WriteLine($"- надеяться: {tuDien["надеяться"]}");
            Console.WriteLine($"So tu hien co: {tuDien.Count}");
            Console.WriteLine();

            // Tra cuu an toan CONTAINSKEY va TRYGETVALUE 
            if (tuDien.ContainsKey("причина"))
                Console.WriteLine($"- причина: {tuDien["причина"]}");
            else
                Console.WriteLine("Khong tim nghia thay tu nay trong tu dien!!!");

            if (tuDien.TryGetValue("географический", out string nghia))
                Console.WriteLine($" - географический: = {nghia}");
            else
                Console.WriteLine("Khong tim nghia thay tu nay trong tu dien!!!");

            Console.WriteLine();

            // Duyet toan bo tu dien
            foreach (KeyValuePair<string, string> tu in tuDien)
                Console.WriteLine($"- {tu.Key}: {tu.Value}");
            Console.WriteLine();


            // Hoac chi duyet rieng khoa/ rieng gia tri 
            foreach (string key in tuDien.Keys)
                Console.WriteLine($"Tu: {key}");

            foreach (string val in tuDien.Values)
                Console.WriteLine($"Nghia: {val}");

            // Xoa mot tu khoi tu dien 
            tuDien.Remove("любезно");
        }
    }
}
