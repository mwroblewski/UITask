using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace UITask.Common.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IEmployeeDataProvider _dataProvider;

        public MainViewModel(IEmployeeDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        public ObservableCollection<EmployeeViewModel> Employees { get; } = new();
        public EmployeeViewModel NewEmployee => EmployeeViewModel.GetDefault(_dataProvider);

        public void Load()
        {
            var employees = _dataProvider.LoadEmployees();
            Employees.Clear();
            foreach (var employee in employees)
            {
                Employees.Add(new EmployeeViewModel(employee, _dataProvider));
            }
        }

        #region move it to abstract base class
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string whichProperty = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(whichProperty));
        }
        #endregion
    }
}
