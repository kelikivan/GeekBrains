using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelikGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 1000,//Screen.PrimaryScreen.Bounds.Width,
                Height = 700//Screen.PrimaryScreen.Bounds.Height
            };
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}