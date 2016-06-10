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
    class ButtonType : ElementType
    {
        private Vector2 Position;
        private SpriteFont Font;
        private Texture2D Texture;
        private string Text;
        private Action Action;

        public ButtonType(Vector2 position, Texture2D texture, string text, SpriteFont font)
        {
            this.Position = position;
            this.Texture = texture;
            this.Text = text;
            this.Font = font;
        }

        public ButtonType(Vector2 position, Texture2D texture, string text, SpriteFont font, Action action)
        {
            this.Position = position;
            this.Texture = texture;
            this.Text = text;
            this.Font = font;
            this.Action = action;
        }

        public GUIElement Visit(Func<EmptyButton, Label, Action, GUIElement> onButton, Func<Vector2, Texture2D, GUIElement> onEmptyButton, Func<Vector2, string, SpriteFont, GUIElement> onLabel)
        {
            return onButton(new EmptyButton(this.Position, this.Texture), new Label(this.Position, this.Text, this.Font), this.Action);
        }
    }
}
