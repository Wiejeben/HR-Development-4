using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create Windows Form
            Form1 winForm = new Form1();
            winForm.Show();

            // Convert to MonoGame
            WinFormToMonoGame monoForm = new WinFormToMonoGame(winForm);
            monoForm.Show();
        }
    }
}
