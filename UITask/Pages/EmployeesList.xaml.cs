using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Linq;
using UITask.Common;
using UITask.Common.ViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UITask.Pages
{
    public sealed partial class EmployeesList : Page
    {
        public List<Employee> Employees { get; } = new();

        public EmployeesListViewModel ViewModel { get; set; }

        public EmployeesList()
        {
            this.InitializeComponent();
            ViewModel = new EmployeesListViewModel(new EmployeeDataProvider());
            EmployeesListView.ItemsSource = ViewModel.Employees;
        }
    }
}
