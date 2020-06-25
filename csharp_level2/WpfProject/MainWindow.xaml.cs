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
using WpfProject.Presenters;

namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string ConnectionString = Properties.Settings.Default.ConnectionString;
        private EmployeeRegisterPresenter EmployeesPresenter { get; set; }
        private DepartmentRegisterPresenter DepartmentsPresenter { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            InitializeDepartments();
            InitializeEmployees();
        }

        private void InitializeDepartments()
        {
            DepartmentsPresenter = new DepartmentRegisterPresenter(ConnectionString);

            _btnAddDepartment.Click += (sender, e) =>
            {
                var w = new DepartmentWindow();
                bool? isAccepted = w.ShowAdd();
                if (isAccepted != null && (bool)isAccepted)
                    DepartmentsPresenter.Items.Add(w.CurrentDepartment);
            };

            DepartmentsPresenter.EditItemAccepted = () => { _dgDepartments.Items.Refresh(); };
            _btnEditDepartment.Click += (sender, e) =>
            {
                DepartmentsPresenter.SelectedItem = _dgDepartments.SelectedItem as Department;
                var w = new DepartmentWindow();
                bool? isAccepted = w.ShowEdit(DepartmentsPresenter.SelectedItem);
                DepartmentsPresenter.EditItemAccepted?.Invoke();
            };

            _dgDepartments.ItemsSource = DepartmentsPresenter.Items;
        }

        private void InitializeEmployees()
        {
            EmployeesPresenter = new EmployeeRegisterPresenter(ConnectionString);

            _btnAddEmployee.Click += (sender, e) =>
            {
                var w = new EmployeeWindow(DepartmentsPresenter.Items);
                bool? isAccepted = w.ShowAdd();
                if (isAccepted != null && (bool)isAccepted)
                    EmployeesPresenter.Items.Add(w.CurrentEmployee);
            };

            EmployeesPresenter.EditItemAccepted = () => { _dgEmployees.Items.Refresh(); };
            _btnEditEmployee.Click += (sender, e) =>
            {
                EmployeesPresenter.SelectedItem = _dgEmployees.SelectedItem as Employee;
                var w = new EmployeeWindow(DepartmentsPresenter.Items);
                bool? isAccepted = w.ShowEdit(EmployeesPresenter.SelectedItem);
                EmployeesPresenter.EditItemAccepted?.Invoke();
            };

            _dgEmployees.ItemsSource = EmployeesPresenter.Items;
        }
    }
}
