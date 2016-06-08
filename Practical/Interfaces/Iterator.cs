using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical.Interfaces
{
    interface Iterator<T>
    {
        Option<T> GetNext();
        void Reset();
    }
}
