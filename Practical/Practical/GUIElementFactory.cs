using Practical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class GUIElementFactory
    {
        private ElementType type;
        
        public GUIElementFactory(ElementType t)
        {
            this.type = t;
        }

        public GUIElement Load()
        {
            throw new NotImplementedException();
        }
    }
}
