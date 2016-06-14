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

        public event EventHandler SizeChanged;
        bool ChangeSizeFromWinForm = false;

        public WinFormToMonoGame(Form winForm)
        {
            this.WinForm = winForm;
            this.MonoForm = new MonoForm(this.WinForm);

            // Apply event handlers
            this.MonoForm.SizeChanged += this.MonoForm_SizeChanged;
            this.WinForm.ClientSizeChanged += this.WinForm_SizeChanged;

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

        private void WinForm_SizeChanged(object sender, EventArgs e)
        {
            // prevent double trigger
            this.ChangeSizeFromWinForm = true;
            this.MonoForm.Size = this.WinForm.ClientSize;
        }

        private void MonoForm_SizeChanged(object sender, EventArgs e)
        {
            if (!this.ChangeSizeFromWinForm)
                this.WinForm.ClientSize = this.MonoForm.Size;
            this.ChangeSizeFromWinForm = false;

            SizeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
