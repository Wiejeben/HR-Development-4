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
        private Vector2 p;
        private string t;
        private SpriteFont f;

        public LabelType(Vector2 position, string text, SpriteFont font)
        {
            this.p = position;
            this.t = text;
            this.f = font;
        }

        public GUIElement Visit(Func<EmptyButton, Label, Action, GUIElement> OnButton, Func<Vector2, Texture2D, GUIElement> OnEmptyButton, Func<Vector2, string, SpriteFont, GUIElement> OnLabel)
        {
            return OnLabel(p, t, f);
        }
    }
}
