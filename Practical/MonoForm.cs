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
        private readonly GraphicsDeviceManager Graphics;
        private readonly Form WinForm;
        private SpriteBatch SpriteBatch;
        private string _Title = string.Empty;
        private Size _Size;
        private Microsoft.Xna.Framework.Color BackColor;
        private Icon _WindowIcon;
        private List<GUIElement> Controls;
        private GUIElementsFactory ControlFactories;

        public event EventHandler SizeChanged;

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;

                // Apply title to window
                this.Window.Title = value;
            }
        }

        public Size Size
        {
            get
            {
                return this._Size;
            }
            set
            {
                this._Size = value;

                // Apply size to window
                this.Graphics.PreferredBackBufferWidth = value.Width;
                this.Graphics.PreferredBackBufferHeight = value.Height;
                this.Graphics.ApplyChanges();

                this.SizeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Icon WindowIcon
        {
            get
            {
                return this._WindowIcon;
            }
            set
            {
                this._WindowIcon = value;

                // Apply icon to window
                ((System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(this.Window.Handle)).Icon = value;
            }
        }

        public void setBackColor(System.Drawing.Color color)
        {
            this.BackColor = new Microsoft.Xna.Framework.Color(color.R, color.G, color.B, color.A);
        }

        public MonoForm(Form WinForm) : base()
        {
            this.WinForm = WinForm;
            this.Graphics = new GraphicsDeviceManager(this);
            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = true;
            this.Content.RootDirectory = "Content";

            // Set event listener
            this.Window.ClientSizeChanged += this.Window_ClientSizeChanged;
        }

        protected override void LoadContent()
        {
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            base.LoadContent();
            Fonts.Arial = Content.Load<SpriteFont>("Arial");
        }

        protected override void Update(GameTime gameTime)
        {
            List<ElementType> elements = new List<ElementType>();
            this.Controls = new List<GUIElement>();

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
                if (control is System.Windows.Forms.Button)
                {
                    elements.Add(new ButtonType(
                        position,
                        new Texture2D(this.GraphicsDevice, control.Width, control.Height),
                        control.Text,
                        Fonts.Arial
                    ));
                }
            }

            FormLoader formLoader = new FormLoader(elements);
            this.ControlFactories = formLoader.Load();
            GUIElementsFactoryToGUIElements adapter = new GUIElementsFactoryToGUIElements(this.ControlFactories);

            Option<GUIElement> currentAdapter = adapter.GetNext();

            while (currentAdapter.IsSome())
            {
                this.Controls.Add(currentAdapter.Visit(() => null, value => value));
                currentAdapter = adapter.GetNext();
            }

            foreach (var control in this.Controls)
            {
                control.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Overwrite with background color
            GraphicsDevice.Clear(this.BackColor);

            base.Draw(gameTime);

            // Draw controls
            SpriteBatch.Begin();
            foreach (var control in this.Controls)
            {
                control.Draw(SpriteBatch);
            }

            SpriteBatch.End();
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.Window.ClientBounds.Width != this.Size.Width || this.Window.ClientBounds.Height != this.Size.Height)
                this.Size = new Size(this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);
        }
    }
}
