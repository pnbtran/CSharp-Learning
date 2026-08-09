using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _025_Shape
{
    internal class Program
    {
        public class Shape
        {
            public string Color { get; set; }
            public bool IsFilled { get; set; }

            public Shape()
            {
                Color = "green";
                IsFilled = true;
            }

            public Shape (string color, bool isFilled)
            {
                Color = color;
                IsFilled = isFilled;
            }

            public virtual double GetArea() => 0;
            public virtual double GetPerimeter() => 0;

            public override string ToString()
                => $"Hinh mau {Color}, {(IsFilled ? "to day" : "rong")}";
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }

            public Circle(double radius, string color, bool isFilled)
                : base(color, isFilled)
            {
                Radius = radius;
            }

            public override double GetArea() => Math.PI * Radius * Radius;
            public override double GetPerimeter() => 2 * Math.PI * Radius;

            public override string ToString()
                => $"Hinh tron co ban kinh: {Radius} ({base.ToString()})";
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Length { get; set; }

            public Rectangle(double w, double l, string color, bool isFilled)
                : base(color, isFilled)
            {
                Width = w;
                Length = l;
            }

            public override double GetArea() => Width * Length;
            public override double GetPerimeter() => 2 * (Width + Length);
        }

        static void Main(string[] args)
        {
            Shape[] shapes =
            {
                new Circle (5, "mau huong", true),
                new Rectangle (4, 6, "xanh duong", false),
                new Circle (2, "mau vang", true)
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"{shape} - co dien tich: {shape.GetArea():F2}");
            }
        }
    }
}
