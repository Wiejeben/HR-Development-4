using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class EmptyButtonType
    {
        private Vector2 p;
        private Texture2D t;

        public EmptyButtonType(Vector2 position, Texture2D texture)
        {
            this.p = position;
            this.t = texture;
        }
    }
}
