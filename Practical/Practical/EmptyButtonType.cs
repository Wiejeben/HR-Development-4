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
        private Vector2 p;
        private Texture2D t;

        public EmptyButtonType(Vector2 position, Texture2D texture)
        {
            this.p = position;
            this.t = texture;
        }

        public GUIElement Visit(Func<EmptyButton, Label, Action, GUIElement> OnButton, Func<Vector2, Texture2D, GUIElement> OnEmptyButton, Func<Vector2, string, SpriteFont, GUIElement> OnLabel)
        {
            return OnEmptyButton(p, t);
        }
    }
}
