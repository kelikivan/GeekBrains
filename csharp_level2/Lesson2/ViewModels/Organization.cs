using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.ViewModels
{
    public class Organization
    {
        public Organization()
        {
            Employees = new Employee[]
            {
                new EmployeeWithFixedPayment("Иванов Иван Иванович", 50000),
                new EmployeeWithHourlyPayment("Токарев Тимофей Павлович", 450),
                new EmployeeWithFixedPayment("Сергеев Иван Иванович", 65000),
                new EmployeeWithHourlyPayment("Манукян Армен Самвелович", 550),
            };
        }
        Employee[] Employees { get; set; }

        public void ShowEmployeeList()
        {
            Array.Sort(Employees);
            foreach (var empl in Employees)
                Console.WriteLine(empl.ToString());
        }
    }
}
