using Practical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class GUIElementsFactory : Iterator<GUIElementFactory>
    {
        private List<ElementType> elements = new List<ElementType>();
        private int index;

        public GUIElementsFactory(List<ElementType> elements)
        {
            this.elements = elements;
            this.Reset();
        }

        public Option<GUIElementFactory> GetNext()
        {
            if (this.elements.Count() <= this.index) return new None<GUIElementFactory>();

            return new Some<GUIElementFactory>(new GUIElementFactory(this.elements.ElementAt(this.index++)));
        }

        public void Reset()
        {
            this.index = 0;
        }
    }
}
