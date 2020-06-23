using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProject.ViewModels;

namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Department> Departments = new ObservableCollection<Department>
        {
            new Department(1, "Разработка ПО"),
            new Department(2, "Тестирование"),
            new Department(3, "Бухгалтерия"),
            new Department(4, "Управление персоналом"),
            new Department(5, "Продажи")
        };

        public ObservableCollection<Employee> Employees = new ObservableCollection<Employee>
        {
            new Employee(1, "Келик", "Иван") { BirthDate = new DateTime(1991, 03, 18) },
            new Employee(2, "Иванов", "Петр"),
            new Employee(3, "Смирнов", "Тимофей"),
            new Employee(4, "Донцов", "Антон"),
            new Employee(5, "Белых", "Савва")
        };

        public MainWindow()
        {
            InitializeComponent();

            _dgEmployees.ItemsSource = Employees;
            _dgDepartments.ItemsSource = Departments;
        }
    }
}
