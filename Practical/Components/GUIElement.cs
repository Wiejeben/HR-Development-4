using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Practical
{
    class GUIElement : Interfaces.Component
    {
        protected Vector2 Position;

        public GUIElement(Vector2 position)
        {
            this.Position = position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
