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
        private List<Option<GUIElement>> factory;
        private int index;
        private Option<GUIElementsFactory> currentFactory;

        public GUIElementsFactoryToGUIElements(GUIElementsFactory ef)
        {

        }

        public Option<GUIElement> GetNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
