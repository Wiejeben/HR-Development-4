using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Practical.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class LabelType : ElementType
    {
        private Vector2 Position;
        private string Text;
        private SpriteFont Font;

        public LabelType(Vector2 position, string text, SpriteFont font)
        {
            this.Position = position;
            this.Text = text;
            this.Font = font;
        }

        public GUIElement Visit(Func<EmptyButton, Label, Action, GUIElement> onButton, Func<Vector2, Texture2D, GUIElement> onEmptyButton, Func<Vector2, string, SpriteFont, GUIElement> onLabel)
        {
            return onLabel(this.Position, this.Text, this.Font);
        }
    }
}
