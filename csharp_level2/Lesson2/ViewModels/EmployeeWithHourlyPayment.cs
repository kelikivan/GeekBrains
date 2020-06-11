using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.ViewModels
{
    public class EmployeeWithHourlyPayment : Employee
    {
        public EmployeeWithHourlyPayment(string fio, int rate) : base(fio)
        {
            Rate = rate;
        }

        public int Rate { get; set; }
        public override double CalculateSalary()
        {
            return 20.8 * 8 * Rate;
        }
    }
}