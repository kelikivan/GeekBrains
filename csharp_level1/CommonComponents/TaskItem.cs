using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class TaskItem
    {
        public virtual string NameTask { get; set; }
        public virtual void RunTask()
        {
            ConsoleView.SetTitle(NameTask);
        }
    }
}