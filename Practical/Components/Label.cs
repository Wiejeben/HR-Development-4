using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class Label : GUIElement
    {
        private string text;
        private SpriteFont font;

        public Label(Vector2 p, string t, SpriteFont f) : base(p)
        {
            this.text = t;
            this.font = f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, this.text, this.position, Color.Black, 0f, Vector2.Zero, 0.65f, SpriteEffects.None, 0f);
            base.Draw(spriteBatch);
        }
    }
}
