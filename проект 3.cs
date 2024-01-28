using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] digits = new int[4];

            Console.WriteLine("Введіть чотири цифри:");

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Цифра " + (i + 1) + ": ");
                while (!int.TryParse(Console.ReadLine(), out digits[i]) || digits[i] < 0 || digits[i] > 9)
                {
                    Console.WriteLine("Введіть коректну цифру (від 0 до 9)!");
                    Console.Write("Цифра " + (i + 1) + ": ");
                }
            }

            int result = digits[0] * 1000 + digits[1] * 100 + digits[2] * 10 + digits[3];

            Console.WriteLine("Сформоване число: " + result);
        }
    }
}

