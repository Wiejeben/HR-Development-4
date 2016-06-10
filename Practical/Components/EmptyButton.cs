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
        private Texture2D Texture;
        private Vector2 Scale;
        private bool IsBlocked;
        private bool WaitingForUp;
        private float CountDown;
        private float MaxCountDown;
        public Vector2 Position;
        private Color Color;

        public EmptyButton(Vector2 position, Texture2D texture) : base(position)
        {
            this.Texture = texture;
            this.Position = position;
            this.Color = new Color(235, 235, 235);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, this.position, Color.DarkBlue);

            Color[] data = new Color[this.Texture.Width * this.Texture.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = this.Color;
            this.Texture.SetData(data);
            
            spriteBatch.Draw(this.Texture, this.Position, this.Color);
            base.Draw(spriteBatch);
        }

    }
}
