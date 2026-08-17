using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Tracing;

namespace _033_CountWord
{
    internal class Program
    {
        class WordCounter
        {
            public static void Run()
            {
                Console.WriteLine("CHUONG TRINH DEM SO TU TU FILE CO SAN");
                Console.WriteLine("=====================================");

                bool continueRunning = true; 

                while (continueRunning)
                {
                    Console.WriteLine("\n1. Dem so tu trong file");
                    Console.WriteLine("2. Thoat chuong trinh");
                    Console.Write("Chon chu nang (1-2): "); 

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            CountWordsInFile();
                            break;

                        case "2":
                            continueRunning = false;
                            Console.WriteLine("Cam on vi da su dung chuong trinh");
                            break;

                        default:
                            Console.WriteLine("Lua chon khong hop le. Vui long chon lai");
                            break; 
                    }
                }
            }
            static void CountWordsInFile()
            {
                Console.WriteLine("- Nhap duong dan File can doc: ");
                string filePath = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(filePath))
                {
                    Console.WriteLine("Duong dan khong duoc de trong!");
                    return;
                }

                try
                {
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"- File: '{filePath}' khong ton tai!");
                        return;
                    }

                    string content = File.ReadAllText(filePath);

                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.WriteLine("- File rong");
                        return;
                    }

                    // Tach tu voi nhieu ki tu phuc tap 
                    char[] separators = GetSeparators();
                    string[] words = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    Console.WriteLine($"KET QUA: ");
                    Console.WriteLine($"- Tong so tu: {words.Length}");
                    Console.WriteLine($"- Tong so ki tu: {content.Length}");
                    Console.WriteLine($"- Tong so dong van ban: {content.Split('\n').Length}");
                    Console.WriteLine();

                    // Dem tu cu the va tan suat 
                    Console.Write("Nhap tu can dem: ");
                    string targetWord = Console.ReadLine().Trim().ToLower();

                    int count = 0;

                    foreach (string word in words)
                    {
                        if (word.ToLower() == targetWord)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"- Tu '{targetWord}' xuat hien {count} lan.");

                    // Thong ke tan suat xuat hien 
                    Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

                    foreach (string word in words)
                    {
                        string cleanedWord = word.ToLower();
                        if (wordFrequency.ContainsKey(cleanedWord))
                        {
                            wordFrequency[cleanedWord]++;
                        }

                        else
                        {
                            wordFrequency[cleanedWord] = 1;
                        }
                    }

                    //Hien thi 10 tu xuat hien nhieu nhat 
                    var topWords = wordFrequency.OrderByDescending(pair => pair.Value).Take(10);
                    Console.WriteLine("\n10 tu xuat hien nhieu nhat: ");

                    foreach (var pair in topWords)
                    {
                        Console.WriteLine($" {pair.Key}: {pair.Value} lan.");
                    }

                    // Hien thi 10 tu dau tien neu co
                    if (words.Length > 0)
                    {
                        Console.WriteLine("\n10 tu dau tien cua file:");
                        for (int i = 0; i < Math.Min(10, words.Length); i++)
                        {
                            Console.WriteLine($" {i + 1}. {words[i]}");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Da xay ra loi: {ex.Message}");
                }
            }

            static char[] GetSeparators()
            {
                return new char[]
                {
                    ' ', '\t', '\n', '\r',                  // Khoang trang va ki tu xuong dong
                    ',', '.', ';', ':',                     // Dau cau
                    '!', '?', '"', '\'',
                    '(', ')', '[', ']', '{', '}',           // Dau ngoac
                    '-', '_', '+', '=',                     // Ki tu dac biet
                    '*', '/', '\\','|',
                    '<', '>'                                // Ki tu so sanh
                };
            }

        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            WordCounter.Run();


            // CHO NAY LA NHAP DE LAM QUEN CU PHAP MOI
            Console.WriteLine("CHO NAY LA NHAP DE LAM QUEN CU PHAP MOI");
            // Duong dan den file can doc
            string filePath = "sample.txt";

            try
            {
                // Kiem tra file ton tai 
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} khong ton tai!");
                    Console.WriteLine();
                    return;
                }
                string content = File.ReadAllText(filePath);

                // KIEM TRA FILE RONG
                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("FILE RONG!");
                    Console.WriteLine();
                    return;
                }

                // Tach chuoi thanh cac tu 
                // Su dung Split()
                char[] separators = new char[] { ' ', '\t', '\n', '\r', ',', '.', ';', ':', '!', '?' };
                string[] words1 = content.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                // Dem so tu 
                int wordCount = words1.Length;

                // HIEN THI KET QUA
                Console.WriteLine($"KET QUA DEM TU");
                Console.WriteLine($"- File: {filePath}");
                Console.WriteLine($"- Tong so tu: {wordCount}");
                Console.WriteLine($"- Tong so ki tu: {content.Length}");
                Console.WriteLine();

                // Thong ke them
                Console.WriteLine("\nTHONG KE CHI TIET");
                Console.WriteLine($"- So dong van ban: {content.Split('\n').Length}");
                Console.WriteLine();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("LOI: Khong co quyen truy cap vao file!");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"LOI IO: {ex.Message}!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"LOI KHONG XAC DINH: {ex.Message}!");
            }
        }
    }
}
