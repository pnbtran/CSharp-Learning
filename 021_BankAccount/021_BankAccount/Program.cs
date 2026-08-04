using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _021_BankAccount
{
    internal class Program
    {
        public class BankAccount
        {
            public string AccountNumbers { get; set; }
            public string AccountHolder { get; set; }

            // Doc tu do (get public), nhung chi cho phep sua tu ben trong class (set private)
            public decimal balance { get; private set; }

            public BankAccount(string accountNumbers, string accountHolder, decimal initial)
            {
                AccountNumbers = accountNumbers;
                AccountHolder = accountHolder;
                balance = initial;
            }

            // Chi cho DOC so du, khong cho sua 
            public decimal Getbalance()
            {
                return balance;
            }

            // Gui tien 
            public void Deposite (decimal amount)
            {
                if (amount < 0)
                {
                    Console.WriteLine("So tien gui phai LON HON 0!");
                    return;
                }

                balance += amount;
                Console.WriteLine();
                Console.WriteLine("GD GUI TIEN DA THUC HIEN THANH CONG!");
                Console.WriteLine($"So tien GD: + {amount:N0} VND.");
                Console.WriteLine($"So du cuoi: {balance:N0} VND");
            }

            //Rut tien
            public void Withdraw (decimal amount)
            {
                if (amount < 0)
                {
                    Console.WriteLine("So tien can rut phai lon hon 0!");
                    return;
                }

                if (amount > balance)
                {
                    Console.WriteLine("So du khong du thuc hien giao dich!");
                    return;
                }

                balance -= amount;
                Console.WriteLine();
                Console.WriteLine("GD RUT TIEN DA THUC HIEN THANH CONG!");
                Console.WriteLine($"So tien GD: - {amount:N0} VND.");
                Console.WriteLine($"So du cuoi: {balance:N0} VND");
            }

            static void ShowMenu(BankAccount acc)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("KTC Smart E-banking");
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine($"So TK: {acc.AccountNumbers}");
                Console.WriteLine($"Ten KH: {acc.AccountHolder}");
                Console.WriteLine($"So du hien tai: {acc.Getbalance():N0} VND");
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine("1. Gui tien");
                Console.WriteLine("2. Rut tien");
                Console.WriteLine("3. Xem so du");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("-----------------------------------------");
                Console.Write("Nhap lua chon: ");
            }

            static decimal InputMoney()
            {
                Console.Write("Nhap so tien: ");

                return decimal.Parse(Console.ReadLine());
            } 

            static void RunBank(BankAccount acc)
            {
                while (true)
                {
                    ShowMenu(acc);

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            decimal money = InputMoney();
                            acc.Deposite(money);
                            break;

                        case 2:
                            decimal money1 = InputMoney();
                            acc.Withdraw(money1);
                            break;

                        case 3:
                            Console.WriteLine($"So du cuoi: {acc.Getbalance():N0} VND");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("LUA CHON KHONG HOP LE! VUI LONG THU LAI!");
                            break;

                    }
                    Console.WriteLine();
                }
            }

            static void Main(string[] args)
            {
                BankAccount acc = new BankAccount("8867822896", "Nguyen An Khue", 10000000);

                RunBank(acc);
            }
        }
    }
}