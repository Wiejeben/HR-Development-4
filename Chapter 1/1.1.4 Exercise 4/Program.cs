using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._4_Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            IOption<int> number = new Some<int>(5);

            Console.WriteLine(number.Visit<string>(
                () => "I am none...",
                x => x.ToString()
            ));

            Console.ReadKey();
        }

        interface IOption<T>
        {
            U Visit<U>(Func<U> onNone, Func<T, U> onSome);
        }

        class Some<T> : IOption<T>
        {
            private T Value;

            public Some(T value)
            {
                this.Value = value;
            }

            public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
            {
                return onSome(this.Value);
            }
        }

        class None<T> : IOption<T>
        {
            public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
            {
                return onNone();
            }
        }
    }
}
