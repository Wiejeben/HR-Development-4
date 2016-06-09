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
        protected Vector2 position;

        public GUIElement(Vector2 p)
        {
            this.position = p;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public virtual void Update(float dt)
        {
            
        }
    }
}
