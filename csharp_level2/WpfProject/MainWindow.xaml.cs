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
using WpfProject.Controls;

namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Department> Departments = new ObservableCollection<Department>
        {
            new Department("Разработка ПО"),
            new Department("Тестирование"),
            new Department("Бухгалтерия"),
            new Department("Управление персоналом"),
            new Department("Продажи")
        };

        public ObservableCollection<Employee> Employees = new ObservableCollection<Employee>
        {
            new Employee("Келик", "Иван") { BirthDate = new DateTime(1991, 03, 18) },
            new Employee("Иванов", "Петр"),
            new Employee("Смирнов", "Тимофей"),
            new Employee("Донцов", "Антон"),
            new Employee("Белых", "Савва")
        };

        public MainWindow()
        {
            InitializeComponent();

            _dgEmployees.ItemsSource = Employees.ToList();
            _dgDepartments.ItemsSource = Departments;
        }

        private void _btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var w = new EmployeeWindow(Departments);
            bool? isAccepted = w.ShowAdd();
            if (isAccepted != null && (bool)isAccepted)
                Employees.Add(w.CurrentEmployee);
        }

        private void _btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = _dgEmployees.SelectedItem as Employee;
            var w = new EmployeeWindow(Departments);
            bool? isAccepted = w.ShowEdit(selectedEmployee);
            _dgEmployees.Items.Refresh();
            //if (isAccepted != null)
            //    MessageBox.Show("ТЕст");
        }

        private void _btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            var w = new DepartmentWindow();
            bool? isAccepted = w.ShowAdd();
            if (isAccepted != null && (bool)isAccepted)
                Departments.Add(w.CurrentDepartment);
        }

        private void _btnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            Department selectedDepartment = _dgDepartments.SelectedItem as Department;
            var w = new DepartmentWindow();
            bool? isAccepted = w.ShowEdit(selectedDepartment);
            //if (isAccepted != null)
            //    MessageBox.Show("ТЕст");
        }
    }
}
