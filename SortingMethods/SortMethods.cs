using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingMethods
{
    partial class Program{
        //1 сортировка пузырьком
        public delegate void SortDelegate(int[] array);

        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
        }

        //2 - сортировка выбором
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = Int32.MaxValue;
                int minIndex = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] <= min)
                    {
                        min = array[j];
                        minIndex = j;
                    }
                }
                if (i < minIndex)
                {
                    int t = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = t;
                }
            }
        }

        //3 - сортировка Шелла
      public  static void ShellsSort(int[] array)
        {
            int step = array.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < array.Length; i++)
                {
                    int value = array[i];
                    for (j = i - step; (j >= 0) && (array[j] > value); j -= step)
                        array[j + step] = array[j];
                    array[j + step] = value;
                }
                step /= 2;
            }
        }
        //сортировка вставками
        public static void InsertionSort(int[] array)
        {
            for (int j = 1; j < array.Length; j++)
            {
                int key = array[j];
                int i = j - 1;
                while (i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i = i - 1;
                }
                array[i + 1] = key;
            }
        }


        //5 быстрая сортировка
        public static void HoareSort(int[] array, int start, int end)
        {
            if (end == start) return;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    var t = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = t;
                    storeIndex++;
                }

            var n = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = n;
            if (storeIndex > start) HoareSort(array, start, storeIndex - 1);
            if (storeIndex < end) HoareSort(array, storeIndex + 1, end);
        }

        public static void HoareSort(int[] array)
        {
            HoareSort(array, 0, array.Length - 1);
        }
    }
}
