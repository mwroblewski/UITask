using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UITask
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private static Dictionary<Views, string> AvailablePages => new()
        {
            { Views.NewEmployee, typeof(Pages.NewEmployee).FullName },
            { Views.EmployeesList, typeof(Pages.EmployeesList).FullName }
        };

        private enum Views
        {
            NewEmployee,
            EmployeesList
        }

        public MainWindow()
        {
            this.InitializeComponent();
            Activated += (_, _) => { NavigateToPage(AvailablePages[Views.NewEmployee]); };
        }

        private void ChangePage(NavigationView _, NavigationViewSelectionChangedEventArgs args)
        {
            if ((args.SelectedItem as NavigationViewItem)?.Tag is not string selectedTag)
            {
                return;
            }
            var pageName = AvailablePages[(Views)Enum.Parse(typeof(Views), selectedTag)];
            NavigateToPage(pageName);
        }

        private void NavigateToPage(string withName)
        {
            if (string.IsNullOrEmpty(withName))
            {
                //Could also throw or log
                return;
            }
            var type = Type.GetType(withName);
            if (type is null)
            {
                //Could also throw or log
                return;
            }
            contentFrame.Navigate(type);
        }
    }
}
