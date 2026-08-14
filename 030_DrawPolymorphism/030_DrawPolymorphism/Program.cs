
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _030_DrawPolymorphism
{
    internal class Program
    {
        public abstract class Shape
        {
            public abstract void Draw();

            public abstract double GetArea(); // Abstract method co gia tri tra ve 

            public void DisplayInfo() => Console.WriteLine("Day la mot hinh hoc."); 
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }
            public Circle (double radius) { Radius = radius; }

            public override void Draw()
            {
                Console.WriteLine($"Ve HINH TRON ban kinh {Radius}");
            }

            public override double GetArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        public class Square : Shape
        {
            public double Side { get; set; }
            public Square (double side) { Side = side; }

            public override void Draw()
            {
                Console.WriteLine($"Ve HINH VUONG canh {Side}");
            }

            public override double GetArea()
            {
                return Side * Side;
            }
        }

        public class Triangle : Shape
        {
            public double Base { get; set; }
            public double Height { get; set; }
            public Triangle (double @base, double height) 
            {
                Base = @base; 
                Height = height; 
            }

            public override void Draw()
            {
                Console.WriteLine("Ve HINH TAM GIAC");
            }

            public override double GetArea()
            {
                return 0.5 * Base * Height;
            }
        }

        static void Main(string[] args)
        {
            // Mang chua cac hinh khac nhau nhung chung class Shape
            Shape[] geometry =
            {
                new Circle(5),
                new Square (4),
                new Triangle(3,4)
            };

            Console.WriteLine("Ve tat ca cac hinh theo yeu cau");
            foreach (Shape shape in geometry)
            {
                shape.Draw(); 
            }
            Console.WriteLine();

            Shape[] geometryA = { new Circle(5), new Square(4), new Circle(2) , new Triangle(4,6) };

            Console.WriteLine("Tinh dien tich cac hinh theo yeu cau");
            foreach (Shape shape in geometryA)
            {
                Console.WriteLine($"- {shape.GetType().Name} co dien tich: {shape.GetArea():F2}");
            }

            double sumArea = geometryA.Sum(g => g.GetArea());
            Console.WriteLine($"- Tong dien tich: {sumArea:F2}");

            var shapeBig = geometryA.Where(g => g.GetArea() > 20);
            Console.WriteLine($"- So hinh co dien tich > 20: {shapeBig.Count()}");  

        }
    }
}