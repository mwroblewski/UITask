using Microsoft.UI.Xaml.Controls;
using UITask.Common;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UITask.Pages
{
    public sealed partial class NewEmployee : Page
    {
        public EmployeeViewModel ViewModel { get; }

        public NewEmployee()
        {
            this.InitializeComponent();
            ViewModel = EmployeeViewModel.GetDefault(new EmployeeDataProvider());
        }
    }
}
