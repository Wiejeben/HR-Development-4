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
    class EmptyButtonType : ElementType
    {
        private Vector2 Position;
        private Texture2D Texture;

        public EmptyButtonType(Vector2 position, Texture2D texture)
        {
            this.Position = position;
            this.Texture = texture;
        }

        public GUIElement Visit(Func<EmptyButton, Label, Action, GUIElement> onButton, Func<Vector2, Texture2D, GUIElement> onEmptyButton, Func<Vector2, string, SpriteFont, GUIElement> onLabel)
        {
            return onEmptyButton(this.Position, this.Texture);
        }
    }
}
