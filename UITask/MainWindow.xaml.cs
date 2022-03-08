using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UITask.Common;
using UITask.Common.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace UITask
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }

        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel(new EmployeeDataProvider());
            Activated += LoadMainViewModelData;
        }

        private void LoadMainViewModelData(object _, WindowActivatedEventArgs unneeded)
        {
            ViewModel.Load();
            NavigateToPage(AvailablePages[Views.NewEmployee]);
        }

        private void ChangeView(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine((sender as ListView).SelectedValue);
        }

        private void nvSample5_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
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
    }
}
