onsole.ReadLine();

if (inputNumber.Length != 6)
{
    Console.WriteLine("Помилка: Введіть шестизначне число.");
    return;
}

Console.WriteLine("Введіть номери розрядів для заміни (наприклад, 1 6):");
string[] inputIndices = Console.ReadLine().Split(' ');

if (inputIndices.Length != 2)
{
    Console.WriteLine("Поusing System;
using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть шестизначне число:");
            string inputNumber = Cмилка: Введіть два номери розрядів.");
                return;
        }

        int index1, index2;
            if (!int.TryParse(inputIndices[0], out index1) || !int.TryParse(inputIndices[1], out index2))
            {
                Console.WriteLine("Помилка: Введіть коректні номери розрядів.");
                return;
            }

            if (index1< 1 || index1> 6 || index2< 1 || index2> 6)
            {
                Console.WriteLine("Помилка: Номери розрядів повинні бути від 1 до 6.");
                return;
            }

char temp = inputNumber[index1 - 1];
char[] charArray = inputNumber.ToCharArray();
charArray[index1 - 1] = charArray[index2 - 1];
charArray[index2 - 1] = temp;

string result = new string(charArray);
Console.WriteLine("Результат: " + result);
        }
    }
 }


