using System.Collections.ObjectModel;

namespace UITask.Common.ViewModel
{
    public class EmployeesListViewModel
    {
        private readonly IEmployeeDataProvider _dataProvider;

        public EmployeesListViewModel(IEmployeeDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Load();
        }

        public ObservableCollection<EmployeeViewModel> Employees { get; } = new();

        private void Load()
        {
            //TODO could put some watcher on the file 
            var employees = _dataProvider.LoadEmployees();
            foreach (var employee in employees)
            {
                Employees.Add(new EmployeeViewModel(employee, _dataProvider));
            }
        }
    }
}
