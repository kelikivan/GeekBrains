using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfProject.ViewModels;

namespace WpfProject.Presenters
{
    public abstract class RegisterBase<TRegisterItem> : INotifyPropertyChanged
        where TRegisterItem : RegisterItem
    {
        protected RegisterBase(string connectionString)
        {
            Items = new ObservableCollection<TRegisterItem>();
            FillItems(connectionString);
        }

        private TRegisterItem _selectedItem;

        /// <summary>
        /// Список для отображения
        /// </summary>
        public ObservableCollection<TRegisterItem> Items { get; private set; }
    
        /// <summary>
        /// выбранный элемент списка
        /// </summary>
        public TRegisterItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == value) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        protected abstract void FillItems(string connectionString);
        public abstract void AddItem();
        public abstract void EditItem();
        public abstract void DeleteItem();
        public Action EditItemAccepted { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}