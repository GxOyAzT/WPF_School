using School.PagesAdmin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolHeadmaster.UserControls
{
    /// <summary>
    /// Interaction logic for PageAdministratorControl.xaml
    /// </summary>
    public partial class PageAdministratorControl : Page
    {
        MainWindow MainWindow = new MainWindow();
        public PageAdministratorControl(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            InitializeComponent();
        }

        private void Click_CreateSubject(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageNewSubject();
        }

        private void Click_CreateClass(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageNewClass();
        }

        private void Click_CreateTeacher(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageNewTeacher();
        }

        private void Click_CreateStudent(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageNewStudent();
        }



        private void Click_CreateDepClaSubTea(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageNewDepClaSubTea();
        }

        private void Click_CreateDepSubTea(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageNewDepSubTea();
        }
    }
}
