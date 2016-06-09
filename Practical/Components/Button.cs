using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class Button : GUIElement
    {
        private EmptyButton button;
        private Label label;
        private Action action;

        public Button(EmptyButton button, Label label, Action action) : base(button.position)
        {
            this.button = button;
            this.label = label;
            this.action = action;
        }
    }
}
