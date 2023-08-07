using System.Diagnostics.Metrics;
using System;

namespace MTS_Test_3
{

    //Возможно ли реализовать такой метод выполняя перебор значений перечисления только 1 раз?
    //Да, возможно

    static class Program
    {
        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <returns></returns>
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength) 
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (tailLength == null || tailLength < 0) throw new ArgumentOutOfRangeException(nameof(tailLength));

            int length = enumerable.Count();
            
            if (tailLength > length) 
            {
                tailLength = length;
            }

            int qLenght = length - tailLength.Value + 1;

            var queue = new Queue<T>(qLenght);

            int? tail;
            foreach (T item in enumerable)
            {
                queue.Enqueue(item);
                if(queue.Count == qLenght) 
                {
                    queue.Dequeue();
                    tail = --tailLength;
                }
                else
                {
                    tail = null;
                }
                yield return (item, tail);
            }
        }


        static void Main(string[] args)
        {
            List<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var res = EnumerateFromTail(ints, 5);
            foreach (var (num, tail) in res)
            {
                Console.WriteLine($"{num}, {tail}");
            }
        }
    }
}