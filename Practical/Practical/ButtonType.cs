using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class ButtonType
    {
        private Vector2 position;
        private SpriteFont font;
        private Texture2D texture;
        private string text;
        private Action action;

        public ButtonType(Vector2 position, Texture2D texture, string text, SpriteFont font)
        {
            this.position = position;
            this.texture = texture;
            this.text = text;
            this.font = font;
        }

        public ButtonType(Vector2 position, Texture2D texture, string text, SpriteFont font, Action action)
        {
            this.position = position;
            this.texture = texture;
            this.text = text;
            this.font = font;
            this.action = action;
        }
    }
}
