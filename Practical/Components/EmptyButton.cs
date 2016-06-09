using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class EmptyButton : GUIElement
    {
        private Texture2D texture;
        private Vector2 scale;
        private bool is_blocked;
        private bool waiting_for_up;
        private float count_down;
        private float max_count_down;
        public Vector2 position;
        private Color color;

        public EmptyButton(Vector2 p, Texture2D t) : base(p)
        {
            this.texture = t;
            this.position = p;
            this.color = new Color(235, 235, 235);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, this.position, Color.DarkBlue);

            Color[] data = new Color[this.texture.Width * this.texture.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = this.color;
            this.texture.SetData(data);
            
            spriteBatch.Draw(this.texture, this.position, this.color);
            base.Draw(spriteBatch);
        }

    }
}
