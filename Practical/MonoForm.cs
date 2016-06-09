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
        private readonly Form WinForm;
        private SpriteBatch spriteBatch;
        private string title = string.Empty;
        private Size size;
        private Microsoft.Xna.Framework.Color backColor;
        private Icon windowIcon;
        private List<GUIElement> controls;
        private GUIElementsFactory controlFactories;

        public event EventHandler SizeChanged;

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

                this.SizeChanged?.Invoke(this, EventArgs.Empty);
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

        public MonoForm(Form WinForm) : base()
        {
            this.WinForm = WinForm;
            this.graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = false;
            Content.RootDirectory = "Content";

            // Set event listener
            this.Window.ClientSizeChanged += Window_ClientSizeChanged;
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            base.LoadContent();
            Fonts.Arial = Content.Load<SpriteFont>("Arial");
        }

        protected override void Update(GameTime gameTime)
        {
            List<ElementType> elements = new List<ElementType>();
            this.controls = new List<GUIElement>();

            foreach (Control control in this.WinForm.Controls)
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

                // TODO: Implement button
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

            FormLoader formLoader = new FormLoader(elements);
            this.controlFactories = formLoader.Load();
            GUIElementsFactoryToGUIElements adapter = new GUIElementsFactoryToGUIElements(this.controlFactories);

            Option<GUIElement> currentAdapter = adapter.GetNext();

            while (currentAdapter.isSome())
            {
                this.controls.Add(currentAdapter.Visit(() => null, (el) => el));
                currentAdapter = adapter.GetNext();
            }

            //foreach (var control in this.controls)
            //{
            //    //control.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            //}
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Overwrite with background color
            GraphicsDevice.Clear(this.backColor);

            base.Draw(gameTime);

            // Draw controls
            spriteBatch.Begin();
            foreach (var control in this.controls)
            {
                control.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(this.graphics.GraphicsDevice.PresentationParameters.Bounds);
            // TODO: Get current window width
            //if (this.graphics.GraphicsDevice.Viewport.Width != this.Size.Width || this.graphics.GraphicsDevice.Viewport.Height != this.Size.Height)
            //    this.Size = new Size(graphics.GraphicsDevice.Viewport.Width, this.graphics.PreferredBackBufferHeight);
        }
    }
}
