using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace MTS_Test_2
{

    class Program
    {
        static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;
        class Number
        {
            readonly int _number;
            public Number(int number)
            {
                _number = number;
            }
            public override string ToString()
            {
                return _number.ToString(_ifp);
            }

            //Для сложения 2 чисел
            public static Number operator +(Number a, Number b)
            {
                return new Number(a._number + b._number);
            }

            //Для сложения числа и строки, возврат - строка, так как в Main требуется строка.
            public static string operator +(Number a, string b)
            {
                return (a._number + Convert.ToInt32(b)).ToString();
            }
            //Аналог public static string operator +(Number a, string b), но поменял местами 1 и 2 аргументы
            //Для сложения строки и числа, возврат - строка, так как в Main требуется строка.
            public static string operator +(string b, Number a)
            {
                return (a._number + Convert.ToInt32(b)).ToString();
            }
        }
        static void Main(string[] args)
        {
            int someValue1 = 10;
            int someValue2 = 5;
            string result = new Number(someValue1) + someValue2.ToString(_ifp);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}