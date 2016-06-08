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
        private List<Option<GUIElementFactory>> factory = new List<Option<GUIElementFactory>>();
        private int index;
        private Option<GUIElementFactory> currentFactory;

        public GUIElementsFactoryToGUIElements(GUIElementsFactory ef)
        {
            this.Reset();

            Option<GUIElementFactory> elementFactory = ef.GetNext();

            while (elementFactory.isSome())
            {
                this.factory.Add(new Some<GUIElementFactory>(elementFactory.Visit(() => null, (el) => el)));
                elementFactory = ef.GetNext();
            }
        }

        public Option<GUIElement> GetNext()
        {
            if (this.factory.Count() <= this.index) return new None<GUIElement>();

            this.currentFactory = this.factory.ElementAt(this.index++);
            
            if (currentFactory.isSome())
            {
                return new Some<GUIElement>(currentFactory.Visit(() => null, (el) => el.Load()));
            }
            
            return new None<GUIElement>();
        }

        public void Reset()
        {
            this.index = 0;
        }
    }
}
