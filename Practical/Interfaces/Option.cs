using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical.Interfaces
{
    interface Option<T>
    {
        U Visit<U>(Func<U> OnNone, Func<T,U> OnSome);
        Boolean isSome();
        Boolean isNone();
    }
}
