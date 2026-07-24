using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_RandomGuessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tao so bi mat va khai bao bien
            Random random = new Random();           
            int BiMat = random.Next(1, 101);      
            int soLan = 0;                          // so lan doan
            int soDoan;                             // so duoc doan
            bool soDung = false;                    // so duoc nguoi choi doan dung

            Console.WriteLine("Chao mung den voi tro choi doan so ngau nhien");
            Console.WriteLine("Toi da nghi ra mot so tu 1 den 100. Hay doan thu xem!");

            // Tao vong lap chinh cho tro choi
            while (!soDung)
            {
                Console.Write("\b Nhap so ban doan tai day: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out soDoan))
                {
                    Console.WriteLine("Vui long nhap lai so hop le!");
                    continue;                       // bo qua phan con lai, quay LAI DAU vong lap
                }

                soLan++;
                if (soDoan == BiMat)
                {
                    soDung = true;
                    Console.WriteLine($"\n Chuc mung! Ban da doan dung so bi mat {BiMat}");
                    Console.WriteLine($"Ban da doan dung sau {soLan}");
                }

                else if (soDoan < BiMat)
                {
                    Console.WriteLine("So ban can doan LON HON. Hay thu lai");
                }   
                else
                {
                    Console.WriteLine("So ban can doan NHO HON. Hay thu lai");
                }
            }

            // Them gioi han cho tro choi
            int Gioihan = 10;

            Console.WriteLine($"Ban chi co toi da {Gioihan} so lan de doan!!!");
            while (!soDung && soLan < Gioihan)
            {
                Console.WriteLine($" Lan doan {soLan + 1}/{Gioihan}: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out soDoan))
                {
                    Console.WriteLine("Vui long nhap lai so hop le!");
                    continue;                       // bo qua phan con lai, quay LAI DAU vong lap
                }

                soLan++;
                if (soDoan == BiMat)
                {
                    soDung = true;
                    Console.WriteLine($"\n Chuc mung! Ban da doan dung so bi mat {BiMat}");
                    Console.WriteLine($"Ban da doan dung sau {soLan}");
                }

                else if (soDoan < BiMat)
                {
                    Console.WriteLine("So ban can doan LON HON. Hay thu lai");
                }
                else
                {
                    Console.WriteLine("So ban can doan NHO HON. Hay thu lai");
                }
            }
            if (!soDung)
                Console.WriteLine($"\n Het luot! So bi mat la {BiMat}");

        }
        
    }
}