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

        public EmptyButton(Vector2 p, Texture2D t) : base(p)
        {
            this.texture = t;
            this.position = p;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Output sprite with rectangle
            base.Draw(spriteBatch);
        }

    }
}
