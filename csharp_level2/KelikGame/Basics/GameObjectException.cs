using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelikGame
{
    public class GameObjectException : Exception
    {
        public GameObjectException(string message) : base(message)
        {
            MessageBox.Show(base.Message);
        }
    }
}