using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class None<T> : Interfaces.Option<T>
    {
        public bool isNone()
        {
            return true;
        }

        public bool isSome()
        {
            return false;
        }

        public U Visit<U>(Func<U> OnNone, Func<T, U> OnSome)
        {
            return OnNone();
        }
    }
}
