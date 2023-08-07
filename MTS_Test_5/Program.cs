using System;

class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
    }

    static StringWriter writer = new StringWriter();

    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        Console.SetOut(writer);
        ///Минус этого метода - он не дает дальше писать в консоль
        ///Ниже мои другие попытки вернуть вывод в консоль, но все безуспешно...
    }
}

/*
 using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
    }

    static MyStringWriter writer = new MyStringWriter();

    static TextWriter consoleWriter = Console.Out;

    class MyStringWriter : StringWriter 
    {
        public MyStringWriter(): base() 
        {
        
        }

        public override void WriteLine(ReadOnlySpan<char> buffer)
        {
            Console.SetOut(consoleWriter);
            Console.WriteLine("Муха2");
        }
        public override void WriteLine(StringBuilder? value)
        {
            Console.SetOut(consoleWriter);
            Console.WriteLine("Муха3");
        }
    }

    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        Console.SetOut(writer);
    }
}
 */