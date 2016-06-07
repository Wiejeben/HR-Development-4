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
        private Vector2 position;

        public GUIElement(Vector2 p)
        {
            this.position = p;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(float dt)
        {
            throw new NotImplementedException();
        }
    }
}
