using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical.Interfaces
{
    interface ElementType
    {
        GUIElement Visit(Func<EmptyButton, Label, Action, GUIElement> OnButton, Func<Vector2, Texture2D, GUIElement> OnEmptyButton, Func<Vector2, string, SpriteFont, GUIElement> OnLabel);
    }
}
