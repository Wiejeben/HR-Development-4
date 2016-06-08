using Microsoft.Xna.Framework;
using Practical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            return new GUIElementsFactory(elements);
        }
    }
}
