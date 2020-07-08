using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.ViewModels;

namespace WpfProject.Presenters
{
    public class EmployeeRegisterPresenter : RegisterBase<Employee>
    {
        public EmployeeRegisterPresenter(string connectionString) : base(connectionString) 
        { 
        }

        protected override void FillItems(string connectionString)
        {
            var items = new List<Employee>
            {
                new Employee("Келик", "Иван") { BirthDate = new DateTime(1991, 03, 18) },
                new Employee("Иванов", "Петр"),
                new Employee("Смирнов", "Тимофей"),
                new Employee("Донцов", "Антон"),
                new Employee("Белых", "Савва")
            };
            items.ForEach(item => Items.Add(item));
        }

        public override void AddItem()
        {
            throw new NotImplementedException();
        }

        public override void DeleteItem()
        {
            throw new NotImplementedException();
        }

        public override void EditItem()
        {
            throw new NotImplementedException();
        }
    }
}
