using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UITask.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UITask.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmployeesList : Page
    {
        public List<Employee> Employees { get; } = new();

        public EmployeeViewModel EmployeeViewModel { get; set; }

        public EmployeesList()
        {
            this.InitializeComponent();
            EmployeeViewModel = EmployeeViewModel.GetDefault(new EmployeeDataProvider());
            EmployeeViewModel.Load();
            EmployeesListView.ItemsSource = EmployeeViewModel.Employees.ToList();
        }
    }
}
