namespace MTS_Test_4
{
    class Program
    {
        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            if (inputStream == null) throw new ArgumentNullException(nameof(inputStream));
            if (sortFactor < 0) throw new ArgumentOutOfRangeException(nameof(sortFactor));
            if (maxValue < 0 || maxValue > 2000) throw new ArgumentOutOfRangeException(nameof(maxValue));
            if (sortFactor > maxValue) throw new ArgumentOutOfRangeException(nameof(sortFactor));
            ///1 вариант, обычная сортировка: 
            ///скорость работы 0(n log n)
            ///память 0(1)
            /*Array.Sort(inputStream);
            return inputStream;*/
            ///2 вариант сортировка подсчетом (так как числа не превышают 2000, то можно создать массив для подсчета чисел)
            ///скорость работы 0(n)
            ///память 0(k) k=2000
            /*int[] ints = new int[maxValue + 1];
            //O(n)
            foreach (int i in inputStream)
            {
                ints[i]++;
            }

            //O(1)
            int len = inputStream.Count();

            //O(n)
            for (int i = 0; i <= maxValue; i++)
            {
                if (ints[i] > 0)
                {
                    for (int j = 0; j < ints[i]; j++)
                    {
                        yield return i;
                    }
                }
            }*/
            ///3 вариант, сортировка с фактором упорядоченности
            ///скорость работы O(n)
            ///Память O(sortFactor) sortFactor <= maxValue

            int[] counts = new int[sortFactor + 1];

            int min = 0;
            int max = -1;

            foreach (int x in inputStream)
            {
                counts[x % (sortFactor + 1)]++;

                if (x >= max + sortFactor || x > max)
                {
                    for (int i = min; i <= x - sortFactor; i++)
                    {
                        int index = i % (sortFactor + 1);
                        while (counts[index] > 0)
                        {
                            yield return i;
                            counts[index]--;
                        }
                    }

                    min = x - sortFactor + 1 > 0 ? x - sortFactor + 1 : 0;
                    max = x;
                }
            }

            for (int i = min; i <= max; i++)
            {
                int index = i % (sortFactor + 1);
                while (counts[index] > 0)
                {
                    yield return i;
                    counts[index]--;
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> ints = new List<int>() { 100, 2, 1000, 4, 5, 6 };
            Program p = new Program();
            var res = p.Sort(ints, 1000, 2000);
            foreach(int i in res) 
            {
                Console.WriteLine(i);
            }
        }
    }
}