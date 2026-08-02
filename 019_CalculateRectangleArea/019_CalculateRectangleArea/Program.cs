using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _019_CalculateRectangleArea
{
    internal class Program
    {
        // TAO CLASS RECTANGLE
        public class Rectangle
        {
            public double Width;
            public double Height;
           
            // Tao constructor 
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public double CalculateArea()
            {
                return Width * Height;
            }
            public double CalculatePerimeter()
            {
                return 2 * (Width + Height);
            }
        }
                
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(6.3, 3.2);

            double area = rect.CalculateArea();
            Console.WriteLine($" Dien tich HCN: {area}");

            double perimeter = rect.CalculatePerimeter();
            Console.WriteLine($" Chu vi HCN: {perimeter}");
        }
    }
}
