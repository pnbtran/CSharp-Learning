using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _018_OOP_Person
{
    internal class Program
    {
        // TAO CLASS PERSON
        public class Person
        {
            public string Name {get; set;}  
            public int Age {get; set;}  

            public string Address {get; set;}
        }

        static void Main(string[] args)
        {
            Person person1 = new Person();       // Tao object từ class Person
            person1.Name = "Nguyen Van A";       // gan thuoc tinh Name
            person1.Age = 25;
            person1.Address = "TP Ho Chi Minh";

            Console.WriteLine($"Ten: {person1.Name}");
            Console.WriteLine($"Tuoi: {person1.Age}");
            Console.WriteLine($"Dia chi: {person1.Address}");

            Console.WriteLine(" ");

            // Tao them doi tuong Person khac
            Person person2 = new Person();
            person2.Name = "Tran Thi B";
            person2.Age = 30;
            person2.Address = "Thu do Ha Noi";
            Console.WriteLine($"{person2.Name} - {person2.Age} tuoi - {person2.Address}");
        }
    }
}