using Practical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class FormLoader
    {
        private List<ElementType> elements;

        public FormLoader(List<ElementType> elements)
        {
            this.elements = elements;
        }

        public GUIElementsFactory Load()
        {
            throw new NotImplementedException();
        }
    }
}
