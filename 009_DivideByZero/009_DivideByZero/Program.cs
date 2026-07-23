using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_DivideByZero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Try catch - bat nhieu loi
            Console.WriteLine("Nhap so bi chia: ");
            string input = Console.ReadLine();
            try
            {
                int soBichia = int.Parse(input);
                int Ketqua = soBichia / 0;
                Console.WriteLine($" Ket qua: {Ketqua}");
            }

            catch (DivideByZeroException)
            {
                Console.WriteLine("Loi khong the chia cho 0!");
            }

            catch (FormatException)
            {
                Console.WriteLine("Loi: Ban can nhao mot so!"); 
            }
            // bat moi loi con lai (can dat cuoi)
            catch (Exception ex)
            { 
                Console.WriteLine($" Chi tiet: {ex.Message}");
            }

            // Khoi finally luon chay 
            finally
            {
                Console.WriteLine("Khoi FINALLY LUON CHAY - don dep tai nguyen");
            }
        }
    }
}
