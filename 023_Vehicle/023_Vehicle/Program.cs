using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _023_Vehicle.Program.Vehicle;

namespace _023_Vehicle
{
    internal class Program
    {
        public class Vehicle
        {
            // Cac thuc tinh chung
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public string Color { get; set; }

            // Constructor lop cha 
            public Vehicle(string brand, string model, int year, string color)
            {
                Brand = brand;
                Model = model;
                Year = year;
                Color = color;
            }

            // Virtual cho phep lop con ghi de len phuong thuc nay
            public virtual void Start()
            {
                Console.WriteLine($"{Brand} {Model} dang khoi dong...");
            }

            //Phuong thuc chung
            public void DisplayInfo()
            {
                Console.WriteLine($"Thong tin xe: {Brand} {Model}, Nam: {Year}, Mau sac: {Color} ");
                Console.WriteLine();
            }

            // Lop con Car
            public class Car : Vehicle
            {
                // Thuoc tinh rieng
                public int NumberOfDoors { get; set; }

                public Car(string brand, string model, int years, string color, int doors)
                    : base(brand, model, years, color)
                {
                    NumberOfDoors = doors;
                }

                // Ghi de phuong thuc Start cua lop cha
                public override void Start()
                {
                    Console.WriteLine($"O to {Brand} {Model} hoat dong tot");
                    Console.WriteLine();
                }
            }

            // Lop con Motorcycle
            public class Motorcycle : Vehicle
            {
                public Motorcycle(string brand, string model, int years, string color)
                    : base(brand, model, years, color)
                {
                    // Khong co thuoc tinh rieng
                }

                public override void Start()
                {
                    Console.WriteLine($"Xe may {Brand} {Model} dang su dung on");
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Car car = new Car ("Toyota", "Camry", 2025, "Mau den", 4);

            Motorcycle bike = new Motorcycle ("Honda", "Lead", 2021, "Mau trang");

            car.DisplayInfo();
            bike.DisplayInfo();

            car.Start();
            bike.Start();

            Console.WriteLine($"O to nay co {car.NumberOfDoors} canh");
            Console.WriteLine();

            // Quan he "is-a" giua cha va con, co the khai bao 1 mang Vehicle chua ca Car va Motorcycle
            Vehicle[] garage = new Vehicle[]
            {
                new Car("Toyota", "Camry", 2023, "Đen", 4),
                new Motorcycle("Honda", "Wave", 2022, "Đo"),
                new Car("Mazda", "CX5", 2024, "Trang", 4)
            };

            foreach (Vehicle v in garage)
            {
                v.Start();   //Moi xe tu dong goi phuong thuc Start tuong ung voi loai xe cua no
            }

        }
    }
}
