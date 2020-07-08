using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.ViewModels;

namespace WpfProject.Presenters
{
    public class DepartmentRegisterPresenter : RegisterBase<Department>
    {
        public DepartmentRegisterPresenter(string connectionString) : base(connectionString)
        {
        }

        protected override void FillItems(string connectionString)
        {
            var items = new List<Department>
            {
                new Department("Разработка ПО"),
                new Department("Тестирование"),
                new Department("Бухгалтерия"),
                new Department("Управление персоналом"),
                new Department("Продажи")
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
