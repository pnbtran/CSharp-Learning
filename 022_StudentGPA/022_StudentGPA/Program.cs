using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _022_StudentGPA
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public string StudentID { get; set; }
            public double MathScore { get; set; }
            public double PhysicsScore { get; set; }
            public double ChemistryScore { get; set; }


            public Student()
            {
                Name = "Chua co ten";
                StudentID = "0000000";
            }

            public Student (string name, string studentID, double mathScore, double physicsScore, double chemistryScore)
            {
                Name = name;
                StudentID = studentID;
                MathScore = mathScore;
                PhysicsScore = physicsScore;
                ChemistryScore = chemistryScore;
            }

            public double CalculateGPA()
            {
                return (MathScore + PhysicsScore + ChemistryScore) / 3.0;
            }

            public string Rank()
            {
                double gpa = CalculateGPA();

                if (gpa >= 9) return "Xuat sac";
                if (gpa >= 8) return "Gioi";
                if (gpa >= 7) return "Kha";
                if (gpa >= 5) return "Trung binh";
                return "Yeu";
            }

            public void Show()
            {
                Console.WriteLine($"Ten: {Name}");
                Console.WriteLine($"Ma sinh vien: {StudentID}");
                Console.WriteLine($"Diem Toan: {MathScore:F2}");
                Console.WriteLine($"Diem Ly: {PhysicsScore:F2}");
                Console.WriteLine($"Diem Hoa: {ChemistryScore:F2}");
                Console.WriteLine($"Diem trung binh: {CalculateGPA():F2}");
                Console.WriteLine($"Xep loai: {Rank()}");
                Console.WriteLine();
            }

            public static Student FindGPAMax(Student[] listSt)
            {
                Student topSt = listSt[0];

                foreach (Student sv in listSt)
                {
                    if (sv.CalculateGPA() > topSt.CalculateGPA())
                    {
                        topSt = sv;
                    }
                }

                return topSt;
            }
        }
        
        static void Main(string[] args)
        {
            Student sv1 = new Student("Nguyen Van A", "SV01", 9.0, 8.5, 9.5);
            Student sv2 = new Student("Tran Thi B", "SV02", 7.0, 8.0, 6.5);
            Student sv3 = new Student("Le Van C", "SV03", 5.5, 4.5, 8.0);
            Student sv4 = new Student("Phan Thi D", "SV04", 5.0, 2.5, 7.8);
            Student sv5 = new Student("Duong Van E", "SV05", 3.5, 8.0, 9.5);

            Student[] classSt = { sv1, sv2, sv3, sv4, sv5 };                                                                                 

            Console.WriteLine("Danh sach sinh vien");
            foreach (Student sv in classSt)                
            {
                sv.Show();
            }

            Student top1 = Student.FindGPAMax(classSt);
            Console.WriteLine(
                             $"Sinh vien co diem GPA cao nhat: {top1.Name} voi GPA: {top1.CalculateGPA():F2}");
        }
    }
}