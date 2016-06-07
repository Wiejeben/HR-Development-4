using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class LabelType
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
    }
}
