using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpfProject.ViewModels;

namespace WpfProject.Controls
{
    /// <summary>
    /// Interaction logic for DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
    {
        public Department CurrentDepartment { get; set; }
        public DepartmentWindow()
        {
            InitializeComponent();
        }

        public bool? ShowAdd()
        {
            CurrentDepartment = new Department();
            _mainGrid.DataContext = CurrentDepartment;
            return ShowDialog();
        }
        public bool? ShowEdit(Department department)
        {
            CurrentDepartment = department;
            _mainGrid.DataContext = CurrentDepartment;
            return ShowDialog();
        }

        private void _btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void _btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
