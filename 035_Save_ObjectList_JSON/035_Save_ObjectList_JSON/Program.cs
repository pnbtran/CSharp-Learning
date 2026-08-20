
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace _035_Save_ObjectList_JSON
{
    internal class Program
    {
        public class Student
        {
            public string IDStudent { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string ClassSt { get; set; }

            public Student() { }

            public Student(string idStudent, string name, int age, string classSt)
            {
                IDStudent = idStudent;
                Name = name;
                Age = age;
                ClassSt = classSt;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"- Ma so sinh vien: {IDStudent}");
                Console.WriteLine($"- Ho va ten: {Name}");
                Console.WriteLine($"- Tuoi: {Age}");
                Console.WriteLine($"- Lop: {ClassSt}");
                Console.WriteLine();
            }
        }

        static void SaveListStudent(List<Student> ListStudent, string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(ListStudent, options);

                File.WriteAllText(filePath, jsonString);

                Console.WriteLine($"- Da luu danh sach sinh vien vào file: {filePath}");
                Console.WriteLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Loi khi luu file: {ex.Message}");
            }
        }

        public static List<Student> ReadListStudent(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} khong ton tai");
                    return new List<Student>();
                }

                string jsonString = File.ReadAllText(filePath);

                List<Student> ListStudent =JsonSerializer.Deserialize<List<Student>>(jsonString);

                Console.WriteLine($"- Da doc danh sach sinh vien tu file: {filePath}");
                return ListStudent ?? new List<Student>();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Loi khi doc file: {ex.Message}");
                return new List<Student>();
            }
        }

        // Phuonwg thuc kiem tra file co ton tai du lieu khong 
        public static bool CheckFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"- File {filePath} khong ton tai");
                return false;
            }

            FileInfo FileInfo = new FileInfo(filePath); 

            if (FileInfo.Length == 0)
            {
                Console.WriteLine($"- File {filePath} rong!"); 
                return false;
            }

            return true; 
        }

        // Xu li file JSON khong hop le
        public static List<Student> ReadStudentListSave (string filePath)
        {
            if (!CheckFile(filePath))
            {
                return new List<Student>(); 
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);

                List<Student> listStudent = JsonSerializer.Deserialize<List<Student>>(jsonString); 

                if (listStudent == null || listStudent.Count == 0)
                {
                    Console.WriteLine("File JSON khong chua du lieu hop le.");
                    return new List<Student>(); 
                }

                return listStudent; 
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"- Loi dinh dang JSON: {jsonEx.Message}");
                return new List<Student>(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"- Loi khac: {ex.Message}");
                return new List<Student>(); 
            }
        }

        static void Main(string[] args)
        {
            List<Student> ListStudent = new List<Student>();

            ListStudent.Add(new Student("SV2026200801", "Nguyen Van A", 20, "KTXD2024"));
            ListStudent.Add(new Student("SV2026200802", "Phan Thi B", 20, "KTXD2024"));
            ListStudent.Add(new Student("SV2026200803", "Trinh Van C", 20, "KTXD2023"));
            ListStudent.Add(new Student("SV2026200804", "Bui Ngoc D", 20, "KTXD2023"));
            ListStudent.Add(new Student("SV2026200805", "Ly Nguyen E", 20, "KTXD2025"));
            ListStudent.Add(new Student("SV2026200806", "Duong Van F", 20, "KTXD2025"));

            Console.WriteLine("DANH SACH SINH VIEN");
            foreach (var St in ListStudent)
            {
                St.ShowInfo();
            }

            string filePath = "students.json";

            SaveListStudent(ListStudent, filePath);

            if (CheckFile(filePath))
            {
                // Goi phuong thuc doc JSON
                List<Student> listStudent = ReadStudentListSave(filePath);

                // Hien thi ket qua sau Deserialize
                Console.WriteLine("\nDANH SACH DOC TU FILE JSON"); 
                foreach (var student in listStudent)
                {
                    student.ShowInfo(); 
                }
            }

            Console.WriteLine($"- Duong dan day du: {Path.GetFullPath(filePath)}");
            Console.WriteLine();
        }
    }
}