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
        private List<ElementType> Elements;
        private int Index;

        public GUIElementsFactory(List<ElementType> elements)
        {
            this.Elements = elements;
            this.Reset();
        }

        public Option<GUIElementFactory> GetNext()
        {
            if (this.Elements.Count() <= this.Index) return new None<GUIElementFactory>();

            GUIElementFactory factory = new GUIElementFactory(this.Elements[this.Index++]);
            return new Some<GUIElementFactory>(factory);
        }

        public void Reset()
        {
            this.Index = 0;
        }
    }
}
