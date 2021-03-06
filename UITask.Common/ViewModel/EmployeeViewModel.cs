using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UITask.Common
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly Employee _employee;
        private readonly IEmployeeDataProvider _dataProvider;

        public static EmployeeViewModel GetDefault(IEmployeeDataProvider dataProvider) 
        {
            return new EmployeeViewModel(new Employee
            {
                FirstName = "John",
                LastName = "Smith",
                Salary = 10000,
                IsDeveloper = true,
                Sex = Sex.Male
            },
            dataProvider);
        }

        public EmployeeViewModel(Employee employee, IEmployeeDataProvider dataProvider)
        {
            _employee = employee;
            _dataProvider = dataProvider;
        }

        public EmployeeViewModel NewEmployee => GetDefault(_dataProvider);

        public string FirstName
        {
            get => _employee.FirstName;
            set
            {
                if (_employee.FirstName == value)
                {
                    return;
                }
                _employee.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string LastName
        {
            get => _employee.LastName;
            set
            {
                if (_employee.LastName == value)
                {
                    return;
                }
                _employee.LastName = value;
                RaisePropertyChanged();
            }
        }

        public decimal Salary
        {
            get => _employee.Salary;
            set
            {
                if (_employee.Salary == value)
                {
                    return;
                }
                _employee.Salary = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => _employee.IsDeveloper;
            set
            {
                if (_employee.IsDeveloper == value)
                {
                    return;
                }
                _employee.IsDeveloper = value;
                RaisePropertyChanged();
            }
        }

        public Sex Sex
        {
            get => _employee.Sex;
            set
            {
                if (_employee.Sex == value)
                {
                    return;
                }
                _employee.Sex = value;
                RaisePropertyChanged();
            }
        }

        public bool IsValid =>
            string.IsNullOrWhiteSpace(_employee.FirstName) == false && 
            string.IsNullOrWhiteSpace(_employee.LastName) == false && 
            _employee.Salary >= 0;
        

        public void Save()
        {
            _dataProvider.SaveEmployee(_employee);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string whichProperty = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(whichProperty));
        }
    }
}
