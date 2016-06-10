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
        private string Text;
        private SpriteFont Font;

        public Label(Vector2 position, string text, SpriteFont font) : base(position)
        {
            this.Text = text;
            this.Font = font;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.Font, this.Text, this.Position, Color.Black, 0f, Vector2.Zero, 0.65f, SpriteEffects.None, 0f);
            base.Draw(spriteBatch);
        }
    }
}
