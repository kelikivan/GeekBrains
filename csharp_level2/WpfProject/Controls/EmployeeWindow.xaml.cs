﻿using System;
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
using System.Windows.Shapes;
using WpfProject.ViewModels;

namespace WpfProject.Controls
{
    /// <summary>
    /// Interaction logic for DepartmentWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public Employee CurrentEmployee { get; set; } 
        public EmployeeWindow(ObservableCollection<Department> departments)
        {
            InitializeComponent();
            _cbDepartments.ItemsSource = departments.ToList();
        }

        public bool? ShowAdd()
        {
            CurrentEmployee = new Employee();
            _mainGrid.DataContext = CurrentEmployee;
            return ShowDialog();
        }
        public bool? ShowEdit(Employee employee)
        {
            CurrentEmployee = employee;
            _mainGrid.DataContext = CurrentEmployee;
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