using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.ViewModels
{
    public class Department : RegisterItem, INotifyPropertyChanged
    {
        static int _generator;
        public Department()
        {
            ID = ++_generator;
        }
        public Department(string name)
        {
            ID = ++_generator;
            Name = name;
        }

        private string _privateName;
        public string Name
        {
            get => _privateName;
            set
            {
                if (_privateName == value) return;
                _privateName = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}