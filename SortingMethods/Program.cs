using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingMethods
{
    partial class Program
    {
        private static readonly Random random = new Random();


        public static void Main()
        {
            int arrayDimention = Int32.Parse(Console.ReadLine());
            int[] array = GenerateArray(arrayDimention);

            int[] arrayForBubbleSort = new int[arrayDimention];
            for (int i = 0; i < array.Length; ++i)
                arrayForBubbleSort[i] = array[i];

            Console.WriteLine("Массив до сортировки:");
            WriteArray(arrayForBubbleSort);
            TimeCheck(array, BubbleSort, "пузырьком");


            int[] arrayForSelectionSort = new int[arrayDimention];
            for (int i = 0; i < array.Length; ++i)
                arrayForSelectionSort[i] = array[i];
            Array.Copy(array, arrayForSelectionSort, 0);

            TimeCheck(array, SelectionSort, "выбором");

            int[] arrayForShellsSort = new int[arrayDimention];
            for (int i = 0; i < array.Length; ++i)
                arrayForShellsSort[i] = array[i];

            TimeCheck(array, ShellsSort, "Шелла-Хиббарда");

            int[] arrayForInsertionSort = new int[arrayDimention];
            for (int i = 0; i < array.Length; ++i)
                arrayForInsertionSort[i] = array[i];

            TimeCheck(array, InsertionSort, "вставками");

            int[] arrayForHoareSort = new int[arrayDimention];
            for (int i = 0; i < array.Length; ++i)
                arrayForHoareSort[i] = array[i];

            TimeCheck(array, HoareSort, "быстрой");
        }

        public static void WriteArray(int[] array)
        {
            foreach (int e in array)
                Console.Write(e + ";");
            Console.WriteLine();
        }

        public static void TimeCheck(int[] array, SortDelegate sort, string name)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            sort(array);
            timer.Stop();
            Console.WriteLine($"Массив после сортировки {name}:");
            foreach (int e in array)
                Console.Write(e + ",");
            Console.WriteLine();
            Console.WriteLine("Время работы алгоритма: " + timer.ElapsedMilliseconds);
        }

        private static int[] GenerateArray(int length)
        {
            var array = new int[length];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(100);
            return array;
        }
    }
}
