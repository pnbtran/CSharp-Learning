using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _026_InterfaceIAnimal
{
    internal class Program
    { 
        // Khai bao interface 1: Biet an, ngu, keu
        public interface IAnimal
        {
            void MakeSound();
            void Eat(string food);
            void Sleep();

            string Name { get; set; }
            int Age { get; set; }
            string Species { get; }
        }

        // Khai bao Interface 2: biet choi 
        public interface IPet 
        {
            void Play();
        }

        public class Dog : IAnimal, IPet
        {
            public string Name { get; set; }
            public int Age { get; set; }

            // Thuoc tinh chi doc và luon tra ve gia trị: Dog 
            public string Species => "Con cho"; 

            // Thuoc tinh cua rieng Dog
            public string Breed { get; set; } 

            public Dog(string name, int age, string breed)
            {
                Name = name;
                Age = age;
                Breed = breed;
            }

            // BAT BUOC cac phuong thuc Interface (phia tren)
            public void MakeSound() => Console.WriteLine($"{Name} sua: Gau Gau!");
            public void Eat(string food) => Console.WriteLine($"{Name} an {food} ngon lanh!");
            public void Sleep() => Console.WriteLine($"{Name} dang nam ngu... Zzz");

            public void Play() => Console.WriteLine($"{Name} vay duoi choi vui ve =))"); 

            // Phuong thuc rieng 
            public void Fetch(string item) => Console.WriteLine($"{Name} chay di lay {item}!");
        }

        public class Cat : IAnimal, IPet
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Species => "Con meo";
            public string Color { get; set; }

            public Cat (string name, int age, string color)
            {
                Name = name;
                Age = age;
                Color = color;
            }

            public void MakeSound() => Console.WriteLine($"{Name} keu: Meo Meo!!!");
            public void Eat(string food) => Console.WriteLine($"{Name} an {food} nhe nhang...");
            public void Sleep() => Console.WriteLine($"{Name} cuon tron ngu tren tham... Zzz");

            public void Play() => Console.WriteLine($"{Name} chay di gheo cho =)))");

            public void ClimbTree() => Console.WriteLine($"{Name} thich leo cay");
        }

        static void Main(string[] args)
        {
            // Mang kieu Interface, chua ca cho va meo 
            IAnimal[] Animal =
            {
                new Dog ("Lycky", 3, "Husky"),
                new Cat ("Mew", 2, "Tam the"),
                new Dog ("Ki", 5, "Corgi")
            };

            foreach (IAnimal con in Animal) 
            {
                Console.WriteLine($"- {con.Name} ({con.Species}), {con.Age} tuoi.");
                con.MakeSound();
                con.Eat("thuc an");
                con.Sleep();

                if (con is IPet pet)
                {
                    pet.Play();
                }
          
                Console.WriteLine();
            }
        }
    }
}