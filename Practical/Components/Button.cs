using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.button.Draw(spriteBatch);
            this.label.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
