using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть перше число:");
        double number = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введiть відсоток:");
        double percentage = Convert.ToDouble(Console.ReadLine());

        double result = CalculatePercentage(number, percentage);

        Console.WriteLine("Результат: " + result);
    }

    static double CalculatePercentage(double number, double percentage)
    {
        return (number * percentage) / 100;
    }
}


