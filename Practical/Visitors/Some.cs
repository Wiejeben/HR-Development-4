using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class Some<T> : Interfaces.Option<T>
    {
        private T v;

        public Some(T value)
        {
            this.v = value;
        }

        public bool isNone()
        {
            return false;
        }

        public bool isSome()
        {
            return true;
        }

        public U Visit<U>(Func<U> OnNone, Func<T, U> OnSome)
        {
            return OnSome(this.v);
        }
    }
}
