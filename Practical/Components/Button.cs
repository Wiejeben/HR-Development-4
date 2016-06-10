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
        private EmptyButton EmptyButton;
        private Label Label;
        private Action Action;

        public Button(EmptyButton button, Label label, Action action) : base(button.Position)
        {
            this.EmptyButton = button;
            this.Label = label;
            this.Action = action;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.EmptyButton.Draw(spriteBatch);
            this.Label.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
