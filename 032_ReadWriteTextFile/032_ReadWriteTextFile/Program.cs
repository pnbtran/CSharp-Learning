using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace _032_ReadWriteTextFile
{
    internal class Program
    {
        class TodoManager
        {
            public const string FileName = "todo.txt"; 

            public static void Run()
            {
                while (true)
                {
                    Console.WriteLine("\nQUAN LY CONG VIEC");
                    Console.WriteLine("1. Xem danh sach cong viec");
                    Console.WriteLine("2. Them cong viec moi");
                    Console.WriteLine("3. Xoa tat ca cong viec");
                    Console.WriteLine("4. Thoat");
                    Console.Write("Chon chuc nang (1-4): "); 

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ViewTodos();
                            break;
                        case "2":
                            AddTodo();
                            break;
                        case "3":
                            ClearTodos();
                            break;
                        case "4":
                            Console.WriteLine("Tam biet nhe!");
                            return;
                        default:
                            Console.WriteLine("Lua chon khong hop le");
                            break;

                    }
                }
            }

            static void ViewTodos()
            {
                if (File.Exists(TodoManager.FileName))
                {
                    string[] todos = File.ReadAllLines(TodoManager.FileName);
                    if (todos.Length == 0)
                    {
                        Console.WriteLine("Danh sach cong viec trong.");
                    }
                    else
                    {
                        Console.WriteLine("\nDANH SACH CONG VIEC:");
                        for (int i = 0; i < todos.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {todos[i]}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Chua co cong viec nao");
                }
            }

            static void AddTodo()
            {
                Console.Write("Nhap cong viec moi:");
                string newTodo = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newTodo))
                {
                    File.AppendAllText(TodoManager.FileName, newTodo + "\n");
                    Console.WriteLine("Da them cong viec thanh cong!");
                }
                else
                {
                    Console.WriteLine("Cong viec khong duoc de trong!");
                }
            }

            static void ClearTodos()
            {
                if (File.Exists(TodoManager.FileName))
                {
                    File.WriteAllText(TodoManager.FileName, string.Empty);
                    Console.WriteLine("Da xoa tat ca cong viec!");
                }
                else
                {
                    Console.WriteLine("Khong co cong viec de xoa!");
                }
            }
        }


        static void Main(string[] args)
        {
            TodoManager.Run();

            string importantfilePath = "important_data.txt";

            try
            {
                //Thu doc FILE
                string content1 = File.ReadAllText(importantfilePath);
                Console.WriteLine("Doc file thanh cong");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Loi: Khong tim thay file {importantfilePath}");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Loi: Thu muc khong ton tai"); 
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Loi: Duong dan qua dai"); 
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Loi: Khong co quyen truy cap file");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Loi IO: {ex.Message}"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi khong xac dinh: {ex.Message}"); 
            }
            finally
            {
                Console.WriteLine("Ket thuc xu li file"); 
            }

            // LAM QUEN THUAT TOAN - KHONG PHAI CODE CUA CHUONG TRINH CHINH 
            Console.WriteLine();
            Console.WriteLine("Doan nay la CODE NHAP");
            try
            {
                // Doc toan bo noi dung File 
                string contentR = File.ReadAllText("data.txt");
                Console.WriteLine("Noi dung File: ");
                Console.WriteLine(contentR);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Khong tim thay file data.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }

            string filePath = "students.txt";

            // Kiem tra File co toan tai khong
            if (File.Exists(filePath))
            {
                // Doc tat ca cac dong
                string[] lines = File.ReadAllLines(filePath);

                Console.WriteLine("Danh sach sinh vien: ");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {lines[i]}");
                }
                Console.WriteLine($"- Tong so sinh vien: {lines.Length}");
            }
            else
            {
                Console.WriteLine($"File {filePath} khong ton tai.");
            }

            // Ghi toan bo noi dung
            string fileName = "output.txt";
            string content = "Xin chao, day là noi dung duoc ghi vao file.\n";

            // Lenh: Yeu cau ghi toan bo
            File.WriteAllText(fileName, content);

            Console.WriteLine($"Da ghi noi dung vao file {fileName}");

            // Kiem tra bang cach doc lai 
            string readContent = File.ReadAllText(fileName);
            Console.WriteLine("\nNoi dung file vua ghi:");
            Console.WriteLine(readContent);

            string[] countries =
            {
                "Viet Nam",
                "Lien bang Nga",
                "Nhat Ban",
                "Trung Quoc",
                "Phap"
            };

            // Lenh: Yeu cau ghi mang vao file
            File.WriteAllLines("countries.txt", countries);

            Console.WriteLine("Da ghi danh sach vao quoc gia file.");

            // Doc va hien thi de kiem tra 
            Console.WriteLine("\nNoi dung file countries.txt:");
            foreach (string line in File.ReadLines("countries.txt"))
            {
                Console.WriteLine($"- {line}");
            }

            // Them noi dung vao file co san
            string logFile = "log.txt";

            //Ghi log dau tien 
            File.WriteAllText(logFile, "[INFO] Chuong trinh bat dau\n");

            //Them cac log khac 
            File.AppendAllText(logFile, $"[INFO] Thoi gian: {DateTime.Now}\n");
            File.AppendAllText(logFile, "[INFO] Thao tac doc file thanh cong\n");
            File.AppendAllText(logFile, "[INFO] Chuong trinh ket thuc\n");

            Console.WriteLine("Da ghi log vao file: ");
            Console.WriteLine(File.ReadAllText(logFile)); 
        }
    }
}
