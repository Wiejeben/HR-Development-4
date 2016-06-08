using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Practical.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private List<GUIElement> controls = new List<GUIElement>();
        private GUIElementsFactory controlFactories;

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

        public MonoForm(Form WinForm, Action<SpriteBatch> onDraw) : base()
        {
            this.onDraw = onDraw;
            this.graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;

            // Generate list with elements
            List<ElementType> elements = new List<ElementType>();

            foreach (Control control in WinForm.Controls)
            {
                Vector2 position = new Vector2(control.Location.X, control.Location.Y);

                if (control is System.Windows.Forms.Label)
                {
                    elements.Add(new LabelType(
                        position,
                        control.Text,
                        Fonts.Arial
                    ));
                }

                //if (control is System.Windows.Forms.Button)
                //{
                //    elements.Add(new ButtonType(
                //        position,
                //        new Texture2D(GraphicsDevice, 1, 1),
                //        control.Text,
                //        Fonts.Ariel
                //    ));
                //}
            }

            // Create new form
            FormLoader formLoader = new FormLoader(elements);

            // Implement Type elements
            this.controlFactories = formLoader.Load();

            // Convert to GUIElement
            GUIElementsFactoryToGUIElements adapter = new GUIElementsFactoryToGUIElements(this.controlFactories);

            Option<GUIElement> currentAdapter = adapter.GetNext();

            while(currentAdapter.isSome())
            {
                this.controls.Add(currentAdapter.Visit(() => null, (el) => el));
                currentAdapter = adapter.GetNext();
            }
            Console.WriteLine("test");
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            Fonts.Arial = Content.Load<SpriteFont>("Arial");
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Overwrite with background color
            GraphicsDevice.Clear(this.backColor);

            //spriteBatch.Begin();
            //spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
