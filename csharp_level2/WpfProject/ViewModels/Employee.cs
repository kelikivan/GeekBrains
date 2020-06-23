using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.ViewModels
{
    public class Employee : INotifyPropertyChanged
    {
        static int _generator;
        public Employee()
        {
            ID = ++_generator;
        }
        public Employee(string lastName, string firstName)
        {
            ID = ++_generator;
            LastName = lastName;
            FirstName = firstName;
        }

        private string _privateLastName;
        private string _privateFirstName;
        private string _privatePatronymic;
        private DateTime? _privateBirthDate;
        private Department _privateDepartment;

        public int ID { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        
        public string LastName
        {
            get => _privateLastName;
            set
            {
                if (_privateLastName == value) return;
                _privateLastName = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get => _privateFirstName;
            set
            {
                if (_privateFirstName == value) return;
                _privateFirstName = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic
        {
            get => _privatePatronymic;
            set
            {
                if (_privatePatronymic == value) return;
                _privatePatronymic = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate
        {
            get => _privateBirthDate;
            set
            {
                if (_privateBirthDate == value) return;
                _privateBirthDate = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Отдел
        /// </summary>
        public Department Department
        {
            get => _privateDepartment;
            set
            {
                if (_privateDepartment == value) return;
                _privateDepartment = value;
                OnPropertyChanged();
            }
        }

        public string FullName => $"{LastName} {FirstName} {Patronymic}";
        public int Age 
        {
            get
            {
                if (BirthDate == null) return 0;
                int age = DateTime.Now.Year - BirthDate.Value.Year;
                if (BirthDate > DateTime.Now.AddYears(-age))
                    age--;
                return age;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}