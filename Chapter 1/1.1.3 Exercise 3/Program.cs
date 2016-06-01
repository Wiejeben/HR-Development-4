using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._3_Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPrettyPrinterIOptionVisitor visitor = new IntPrettyPrinterIOptionVisitor();
            IOption<int> number = new Some<int>(5);
            IOption<int> number_2 = new None<int>();

            Console.WriteLine(number.Visit(visitor));
            Console.WriteLine(number_2.Visit(visitor));

            Console.ReadKey();
        }
    }

    interface IOption<T>
    {
        U Visit<U>(IOptionVisitor<T, U> visitor);
    }

    interface IOptionVisitor<T, U>
    {
        U OnSome(T input);
        U OnNone();
    }

    class Some<T> : IOption<T>
    {
        public T value;

        public Some(T input)
        {
            this.value = input;
        }

        public U Visit<U>(IOptionVisitor<T, U> visitor)
        {
            return visitor.OnSome(this.value);
        }
    }

    class None<T> : IOption<T>
    {
        public U Visit<U>(IOptionVisitor<T, U> visitor)
        {
            return visitor.OnNone();
        }
    }

    class IntPrettyPrinterIOptionVisitor : IOptionVisitor<int, string>
    {
        public string OnNone()
        {
            return "I am nothing ...";
        }

        public string OnSome(int input)
        {
            return input.ToString();
        }
    }
}
