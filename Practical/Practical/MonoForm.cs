using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical
{
    class MonoForm : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly Action<SpriteBatch> onDraw;
        private SpriteBatch spriteBatch;
        private string title = string.Empty;
        private Size size;
        private Microsoft.Xna.Framework.Color backColor;
        private Icon windowIcon;

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;

                // Apply title to window
                this.Window.Title = value;
            }
        }

        public Size Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;

                // Apply size to window
                this.graphics.PreferredBackBufferWidth = value.Width;
                this.graphics.PreferredBackBufferHeight = value.Height;
                this.graphics.ApplyChanges();
            }
        }

        public Icon WindowIcon
        {
            get
            {
                return this.windowIcon;
            }
            set
            {
                this.windowIcon = value;

                // Apply icon to window
                ((System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(this.Window.Handle)).Icon = value;
            }
        }

        public void setBackColor(System.Drawing.Color color)
        {
            this.backColor = new Microsoft.Xna.Framework.Color(color.R, color.G, color.B, color.A);
        }

        public MonoForm(Action<SpriteBatch> onDraw) : base()
        {
            this.onDraw = onDraw;
            this.graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            // Overwrite with background color
            GraphicsDevice.Clear(this.backColor);

            spriteBatch.Begin();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
