using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        class Task
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public List<Task> SubTasks { get; set; } = new List<Task>();
        }

        static List<Task> tasks = new List<Task>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Додати завдання");
                Console.WriteLine("2. Додати підзавдання");
                Console.WriteLine("3. Редагувати завдання");
                Console.WriteLine("4. Видалити завдання");
                Console.WriteLine("5. Переглянути список завдань та статуси");
                Console.WriteLine("6. Вийти");

                int choice = GetIntInput("Оберіть опцію:");

                switch (choice)
                {
                    case 1:
                        AddTask();
                        break;

                    case 2:
                        AddSubTask();
                        break;

                    case 3:
                        EditTask();
                        break;

                    case 4:
                        DeleteTask();
                        break;

                    case 5:
                        ViewTasks();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Task newTask = new Task();

            Console.Write("Введіть назву завдання: ");
            newTask.Title = Console.ReadLine();

            Console.Write("Введіть опис завдання: ");
            newTask.Description = Console.ReadLine();

            tasks.Add(newTask);
            Console.WriteLine("Завдання додано успішно.");
        }

        static void AddSubTask()
        {
            ViewTasks();

            int parentIndex = GetIntInput("Введіть індекс батьківського завдання:");

            if (parentIndex >= 0 && parentIndex < tasks.Count)
            {
                Task newSubTask = new Task();

                Console.Write("Введіть назву підзавдання: ");
                newSubTask.Title = Console.ReadLine();

                Console.Write("Введіть опис підзавдання: ");
                newSubTask.Description = Console.ReadLine();

                tasks[parentIndex].SubTasks.Add(newSubTask);
                Console.WriteLine("Підзавдання додано успішно.");
            }
            else
            {
                Console.WriteLine("Невірний індекс завдання. Перевірте введені дані.");
            }
        }

        static void EditTask()
        {
            ViewTasks();

            int index = GetIntInput("Введіть індекс завдання, яке потрібно відредагувати:");

            if (index >= 0 && index < tasks.Count)
            {
                Console.Write("Введіть нову назву завдання: ");
                tasks[index].Title = Console.ReadLine();

                Console.Write("Введіть новий опис завдання: ");
                tasks[index].Description = Console.ReadLine();

                Console.WriteLine("Завдання відредаговано успішно.");
            }
            else
            {
                Console.WriteLine("Невірний індекс завдання. Перевірте введені дані.");
            }
        }

        static void DeleteTask()
        {
            ViewTasks();

            int index = GetIntInput("Введіть індекс завдання, яке потрібно видалити:");

            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Завдання видалено успішно.");
            }
            else
            {
                Console.WriteLine("Невірний індекс завдання. Перевірте введені дані.");
            }
        }

        static void ViewTasks()
        {
            Console.WriteLine("Список завдань та їх статусів:");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine(i + ". " + tasks[i].Title + " - " + tasks[i].Description);

                if (tasks[i].SubTasks.Count > 0)
                {
                    Console.WriteLine("   Підзавдання:");

                    for (int j = 0; j < tasks[i].SubTasks.Count; j++)
                    {
                        Console.WriteLine("   - " + tasks[i].SubTasks[j].Title + " - " + tasks[i].SubTasks[j].Description);
                    }
                }
            }

            Console.WriteLine();
        }

        static int GetIntInput(string message)
        {
            int input;

            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out input));

            return input;
        }

    }
}
