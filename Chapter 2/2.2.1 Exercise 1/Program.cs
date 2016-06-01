using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1_Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            NaturalNumbers numbers = new NaturalNumbers();
            numbers.GetNext();
            numbers.GetNext();
            numbers.GetNext();
            IOption<int> result = numbers.GetNext();

            Console.WriteLine(result.Visit(
                () => "Nothing",
                x => "The number is " + x.ToString()
            ));

            Console.ReadKey();
        }
    }

    interface IOption<T>
    {
        U Visit<U>(Func<U> onNone, Func<T, U> onSome);
    }

    interface Iterator<T>
    {
        IOption<T> GetNext();
        void Reset();
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

    class IterableList<T> : Iterator<T>
    {
        private List<T> List;
        public IterableList(List<T> list)
        {
            this.List = list;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IOption<T> GetNext()
        {
            if (this.List.Count() <= 0)
            {
                return new None<T>();
            }

            List<T> tmp = this.List;
            this.List.Remove(this.List.First());
            return new Some<T>(tmp.First());
        }
    }

    class NaturalNumbers : Iterator<int>
    {
        private int First = -1;
        private int Current;

        public NaturalNumbers()
        {
            this.Reset();
        }
        
        public IOption<int> GetNext()
        {
            this.Current = (this.Current + 1);
            return new Some<int>(Current);
        }

        public void Reset()
        {
            this.Current = this.First;
        }
    }
}
