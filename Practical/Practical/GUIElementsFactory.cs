using Practical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class GUIElementsFactory : Iterator<GUIElementsFactory>
    {
        private List<ElementType> elements;
        private int index;

        public GUIElementsFactory(List<ElementType> elements)
        {
            this.elements = elements;
        }

        public Option<GUIElementsFactory> GetNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
