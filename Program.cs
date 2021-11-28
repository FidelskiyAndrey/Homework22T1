using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework22T1
{
    class Program
    {
        static int n = Convert.ToInt32(Console.ReadLine());
        static int[] array = new int[n];

        public static void MethodRandom()
        {
            Console.WriteLine("Метод подбора случайных чисел в массив начал работу");
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 10);
                Console.WriteLine("Метод подбора сл. чисел {0}",array[i]);
                Thread.Sleep(400);
            }
            Console.WriteLine("Метод подбора случайных чисел в массив закончил работу");
        }

        public static void MethodMax(Task task,object k)
        {
            int f = (int)k;
            Console.WriteLine("Метод подбора максимального значения в массиве начал работу");
            int max = array[0];
            foreach (int a in array)
            {
                if (a > max)
                    max = a;
                Console.WriteLine("Метод маскимального числа {0}", max);
                Thread.Sleep(400);
            }
            Console.WriteLine("Метод подбора максимального значения в массиве закончил работу");
        }

        public static void MethodSumm(Task task, object m)
        {
            int g = (int)m;
            Console.WriteLine("Метод суммы значений в массиве начал работу");
            int sum = array[0];
            for (int i = 0; i < n; i++)
            {
                sum = sum + array[i];
                Console.WriteLine("Метод суммы сл. чисел {0}",sum);
                Thread.Sleep(400);
            }
            Console.WriteLine("Метод суммы значений в массиве закончил работу");
        }

        static void Main(string[] args)
        {
            Action action = new Action(MethodRandom);
            Task task1 = new Task(action);
            Action <Task,object> actionTask = new Action<Task,object>(MethodMax);
            Task task2 = task1.ContinueWith(actionTask,1);
            Action<Task, object> actionTask1 = new Action<Task, object>(MethodSumm);
            Task task3 = task2.ContinueWith(actionTask1,1);
            task1.Start();
            Console.ReadKey();
        }
    }
}
