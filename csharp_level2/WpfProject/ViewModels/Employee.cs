using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.ViewModels
{
    public class Employee
    {
        public Employee(int id, string secondName, string firstName)
        {
            ID = id;
            SecondName = secondName;
            FirstName = firstName;
        }

        public int ID { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        public int DepartmentID { get; set; }

        public string FullName => $"{SecondName} {FirstName} {Patronymic}";
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
    }
}