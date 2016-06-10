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
        private ElementType Type;
        
        public GUIElementFactory(ElementType type)
        {
            this.Type = type;
        }

        public GUIElement Load()
        {
            return Type.Visit(
                (emptyButton, label, action)    => new Button(emptyButton, label, action),
                (position, texture)             => new EmptyButton(position, texture),
                (position, label, font)         => new Label(position, label, font)
            );
        }
    }
}
