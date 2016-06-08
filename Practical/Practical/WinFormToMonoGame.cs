using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practical.Interfaces;
using Microsoft.Xna.Framework;

namespace Practical
{
    class WinFormToMonoGame
    {
        private Form WinForm;
        private MonoForm MonoForm;
        private List<GUIElement> controls;
        private GUIElementsFactory controlFactories;

        public WinFormToMonoGame(Form winForm)
        {
            this.WinForm = winForm;
            this.MonoForm = new MonoForm(this.WinForm, onDraw);

            // Transfer WinForm properties to MonoForm
            this.MonoForm.Title = this.WinForm.Name;
            this.MonoForm.Size = this.WinForm.ClientSize;
            this.MonoForm.WindowIcon = this.WinForm.Icon;
            this.MonoForm.setBackColor(this.WinForm.BackColor);
        }

        public void Show()
        {
            this.MonoForm.Run();
        }

        public void onDraw(SpriteBatch spriteBatch)
        {
            //foreach (var control in this.controls)
            //{
            //    contro
            //}
        }
    }
}
