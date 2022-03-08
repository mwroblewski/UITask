using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITask.Common.ViewModel
{
    public class EmployeesListViewModel
    {
        private readonly IEmployeeDataProvider _dataProvider;

        public EmployeesListViewModel(IEmployeeDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public ObservableCollection<EmployeeViewModel> Employees { get; } = new();

        public EmployeeViewModel SelectedEmployee { get; set; }

        public void Load()
        {
            //TODO could put some watcher on the file 
            var employees = _dataProvider.LoadEmployees();
            //Employees.Clear();
            foreach (var employee in employees)
            {
                Employees.Add(new EmployeeViewModel(employee, _dataProvider));
            }
        }
    }
}
