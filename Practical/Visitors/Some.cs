using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class Some<T> : Interfaces.Option<T>
    {
        private T Value;

        public Some(T value)
        {
            this.Value = value;
        }

        public bool IsNone()
        {
            return false;
        }

        public bool IsSome()
        {
            return true;
        }

        public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
        {
            return onSome(this.Value);
        }
    }
}
