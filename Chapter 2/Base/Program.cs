using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface Option<T>
    {

    }

    interface GolfIterator<T>
    {
        void First();
        void Next();
        bool IsDone();
        T CurrentItem();
    }

    interface Iterator<T>
    {
        Option<T> GetNext();
        void Reset();
    }

    interface TraditionalIterator<T>
    {
        bool MoveNext();
        T Current();
    }


}
