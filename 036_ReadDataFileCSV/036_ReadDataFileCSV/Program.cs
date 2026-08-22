using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.FileIO;

namespace _036_ReadDataFileCSV
{
    internal class Program 
    {
        // PHUONG PHAP 1 - Phan tich cot 
        public static void ReadAndParseCSV(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isFirstLine = true;

                while ((line = reader.ReadLine()) != null)
                {

                    // Bo qua dong trong
                    if (String.IsNullOrWhiteSpace(line))
                        continue;

                    // Tach gia tri bang dau phay 
                    // (do file .csv đang quy dinh phan thap phan duoc the hien bang dau cham)
                    string[] values = line.Split(',');

                    if (isFirstLine)
                    {
                        Console.WriteLine("- Tieu de cot:");

                        for (int i = 0; i < values.Length; i++)
                        {
                            Console.WriteLine($"    Cot {i + 1}: {values[i]}");
                        }

                        isFirstLine = false;
                        Console.WriteLine("\n- Tiet dien tinh toan va thong tin vat lieu:");
                    }
                    else
                    {
                        Console.WriteLine($"    {values[0]} - {values[1]},{values[2]} ={values[4]}{values[3]}.");
                    }
                }
            }
        }

        // PHUONG PHAP 2 - Su dung TextFieldParser 
        public static void ReadCSVWithTextFieldParser(string filePath1)
        {
            using (TextFieldParser parser = new TextFieldParser(filePath1)) 
            {
                // Xac dinh loai file la phan cach 
                parser.TextFieldType = FieldType.Delimited; 

                // Dat ki tu phan cach la dau cham phay
                // (do file .csv đang quy dinh phan thap phan duoc the hien bang dau phay)
                parser.SetDelimiters(";");

                // Bo qua dong khoang trang
                parser.TrimWhiteSpace = true;

                // Doc tieu de 
                string[] headerFields = parser.ReadFields();
                Console.WriteLine("- Tieu de: " + string.Join(" | ", headerFields));

                Console.WriteLine("\n- Chi tiet thong so dau vao:");

                // Doc du lieu tu dong du lieu 
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields != null && fields.Length == 5)
                    {
                        var DataInput = new
                        {
                            STT = fields[0],
                            Dailuong = fields[1],
                            Kihieu = fields[2],
                            Donvi = fields[3],
                            Giatri = fields[4]
                        };

                        Console.WriteLine($"    {DataInput.STT} - {DataInput.Dailuong}, {DataInput.Kihieu} = {DataInput.Giatri} {DataInput.Donvi}");
                    }
                }
            }
        }


        // PHUONG PHAP 3 - Su dung OOP
        public class InputData
        {
            public int STT { get; set; }
            public string Dailuong { get; set; }
            public string Kihieu { get; set; }
            public string Donvi { get; set; }
            public double Giatri { get; set; }

            public InputData(int stt, string dailuong, string kihieu, string donvi, double giatri)
            {
                STT = stt;
                Dailuong = dailuong;
                Kihieu = kihieu;
                Donvi = donvi;
                Giatri = giatri;
            } 

            /*
            public void ShowInfo()
            {
                Console.WriteLine($"    {STT} - {Dailuong}, {Kihieu} = {Giatri} {Donvi}"); 
            }
            */

            public bool IsValid()
            {
                if (STT <= 0)
                    return false;

                if (string.IsNullOrWhiteSpace(Dailuong))
                    return false;

                if (string.IsNullOrWhiteSpace(Kihieu))
                    return false;

                if (string.IsNullOrWhiteSpace(Donvi))
                    return false;

                if (Giatri < 0)
                    return false;

                return true;
            }
        }

        // CLASS TIET DIEN - CO SO DE TINH TOAN 
        public class Section
        {
            public double Lw { get; set; }
            public double tw { get; set; }
            public double hw { get; set; }
            public double Br { get; set; }
            public double As { get; set; }
            public double Rb { get; set; }
            public double Rs { get; set; }
            public double a { get; set; }

            // Dien tich tiet dien vach = Dai vach x Rong vach 
            public double GetAreaWall()
            {
                return (Lw/1000)  * (tw/1000) ;
            }

            // Dien tich vung vien = Dai bien x Rong bien 
            public double GetAreaPier()
            {
                return (Br/1000) * (tw/1000);
            }

            // Do manh vach  = Chieu dai tinh toan L0 / Chieu cao vach (Gia thuyet L0 = 0,5L)
            public double SlendernessRatio()
            {
                double L0 = 0.5 * Lw;
                return L0 / hw;
            }

            // Ham luong thep bien = (Dien tich cot thep thiet ke As x 100) / [(Rong vach - chieu day be tong bao ve - 1/2 dk thep doc) x Dai bien]
            public double SteelPercentage()
            {
                double Ar = Br * (tw - a - 16/2);

                // Dien tich cot thep thiet ke (sau bo tri tinh dc) DV: mm2 
                As = 36.2*100; 

                return (As / Ar) * 100;
            }

            // Ham luong thep gioi han  = [0.5833 x (Cuong do nen be tong Rb/ Cuong do nen cot thep Rs) ] x 100 
            public double SteelPercentageMax()
            {
                return 0.5833 *(Rb / Rs) * 100;
            }

            // Method doc du lieu tu CSV
            public static List<InputData> ReadInputDataFromCSV(string filePath)
            {
                List<InputData> inputDataList = new List<InputData>();

                // Console.WriteLine($"FILE DANG DOC: {filePath}");
                // Console.WriteLine($"FILE TON TAI: {File.Exists(filePath)}");

                string[] lines = File.ReadAllLines(filePath);

                // DUNG KIEM TRA GIA TRI DOC DUOC
                //Console.WriteLine($"- So dong doc duoc: {lines.Length}");

                for (int i = 1; i < lines.Length; i++)
                {
                    //Console.WriteLine($"    + Dong: {i}: [{lines[i]}]");

                    string[] values = lines[i].Split(',');

                    //Console.WriteLine($"    + So cot: {values.Length}");

                    if (values.Length >= 5)
                    {
                        int stt = int.Parse(values[0].Trim());
                        string dailuong = values[1].Trim();
                        string kihieu = values[2].Trim();
                        string donvi = values[3].Trim();
                        double giatri = double.Parse(values[4].Trim());

                        InputData data = new InputData(
                            stt,
                            dailuong,
                            kihieu,
                            donvi,
                            giatri
                        );

                        inputDataList.Add(data);
                    }
                }

                //Console.WriteLine($"-  InputData TAO DUOC: {inputDataList.Count}");
                return inputDataList;
            }

            // Method xuat du lieu CSV tao Section de tinh toan 
            public static Section CreateSection(List<InputData> inputDataList)
            {
                Section section = new Section();

                foreach (InputData data in inputDataList)
                {
                    switch (data.Kihieu)
                    {
                        case "Lw":
                            section.Lw = data.Giatri;
                            break;

                        case "tw":
                            section.tw = data.Giatri;
                            break;

                        case "hw":
                            section.hw = data.Giatri;
                            break;

                        case "Bl=Br":
                            section.Br = data.Giatri;
                            break;

                        case "a":
                            section.a = data.Giatri;
                            break;

                        case "As":
                            section.As = data.Giatri;
                            break;

                        case "Rs":
                            section.Rs = data.Giatri;
                            break;

                        case "Rb":
                            section.Rb = data.Giatri;
                            break;
                    }
                }

                return section;
            }
        }

        static void Main(string[] args)
        {

            // PHUONG PHAP 1 - Doc bang StreamReader 
            Console.WriteLine("PHUONG PHAP 1 - Doc bang StreamReader");
            string filePath = @"D:\003_CSharp\Notebook\036_ReadDataFileCSV\Data1.csv"; 

            try
            {
                // Doc tat ca cac dong
                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine("- Du lieu tu file CSV:");

                // Duyet tung dong va in ra data
                foreach (string line in lines)
                {
                    Console.WriteLine($"    {line}");
                }
                Console.WriteLine();
            }

            catch(FileNotFoundException)
            {
                Console.WriteLine("Loi: Khong tim thay file."); 
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Loi: {ex.Message}."); 
            }

            ReadAndParseCSV(filePath);
            Console.WriteLine(); 


            // PHUONG PHAP 2 - Su dung TextFieldParser 
            Console.WriteLine("PHUONG PHAP 2 - Su dung TextFieldParser");

            string filePath1 = @"D:\003_CSharp\Notebook\036_ReadDataFileCSV\Data2.csv";

            ReadCSVWithTextFieldParser(filePath1);
            Console.WriteLine();



            // PHUONG PHAP 3 - Su dung OOP
            Console.WriteLine("PHUONG PHAP 3 - Su dung OOP");

            // Xu li file CSV, dung chung file CSV PP1 
            // Doc CSV PP1 -> List<InputData>
            string filePath3 = filePath;

            List<InputData> inputDataList = Section.ReadInputDataFromCSV(filePath3);

            // KIEM TRA MAPPING GIA TRI
            
            Console.WriteLine($"- So luong InputData: {inputDataList.Count}");
            foreach (InputData data in inputDataList)
            { 
                Console.WriteLine($"    KEY = [{data.Kihieu}] | VALUE = {data.Giatri}");
            }
            

            // Hien thi / kiem tra object
            foreach (InputData data in inputDataList)
            {
                
                if (!data.IsValid())
                {
                    Console.WriteLine("Du lieu khong hop le!");
                }
            }

            // Tao Section
            Section section = Section.CreateSection(inputDataList);

            // In ket qua tinh 
            Console.WriteLine("\n- TINH TOAN SO BO:");
            Console.WriteLine($"    + Dien tich tiet dien ngan (toan vach), Aw: {section.GetAreaWall():F2} m2");
            Console.WriteLine($"    + Dien tich tiet dien ngang (vung bien), Ar: {section.GetAreaPier():F2} m2");
            Console.WriteLine($"    + Do manh vach, L0/Hw: {section.SlendernessRatio():F2}");
            Console.WriteLine($"    + Ham luong cot thep bien, uy-req: {section.SteelPercentage():F2} %");
            Console.WriteLine($"    + Ham luong cot thep toi han, uy-max: {section.SteelPercentageMax():F2} %");
        }
    }
}