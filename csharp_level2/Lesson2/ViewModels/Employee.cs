using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.ViewModels
{
    public abstract class Employee : IComparable
    {
        protected Employee(string fio)
        {
            FIO = fio;
        }
        public string FIO { get; private set; }
        public abstract double CalculateSalary();

        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is Employee)) return 1;
            return FIO.CompareTo((obj as Employee).FIO);
        }

        public override string ToString()
        {
            return $"{FIO} - средняя з/п: {CalculateSalary(),2}";
        }
    }
}