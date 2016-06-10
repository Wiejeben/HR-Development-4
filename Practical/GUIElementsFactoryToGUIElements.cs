using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practical.Interfaces;

namespace Practical
{
    class GUIElementsFactoryToGUIElements : Iterator<GUIElement>
    {
        private List<Option<GUIElementFactory>> Factory = new List<Option<GUIElementFactory>>();
        private int Index;

        public GUIElementsFactoryToGUIElements(GUIElementsFactory elementsFactory)
        {
            this.Reset();

            Option<GUIElementFactory> elementFactory = elementsFactory.GetNext();

            while (elementFactory.IsSome())
            {
                this.Factory.Add(elementFactory);
                elementFactory = elementsFactory.GetNext();
            }
        }

        public Option<GUIElement> GetNext()
        {
            if (this.Factory.Count() <= this.Index) return new None<GUIElement>();

            Option<GUIElementFactory> currentFactory = this.Factory[this.Index++];

            return currentFactory.Visit<Option<GUIElement>>(
                ()          => new None<GUIElement>(),
                (elememt)   => new Some<GUIElement>(elememt.Load())
            );
        }

        public void Reset()
        {
            this.Index = 0;
        }
    }
}
