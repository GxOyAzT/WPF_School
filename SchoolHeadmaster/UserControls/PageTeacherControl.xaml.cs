using ConsoleSchool.Classes;
using School.Classes;
using SchoolHeadmaster;
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
using School.PagesTeacher;
using School.Pages;

namespace School.UserControls
{
    /// <summary>
    /// Interaction logic for PageTeacherControl.xaml
    /// </summary>
    public partial class PageTeacherControl : Page
    {
        public PageTeacherControl(MainWindow mainWindow, Teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
            MainWindow = mainWindow;
            reloadData();
        }

        private void ComboBox_SelectionChanged_ClaSub(object sender, SelectionChangedEventArgs e)
        {
            buttonsVisibilityVisible();
        }
        private void Click_NewGradeTheme(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClaSub.SelectedIndex >= 0)
                MainWindow.FrameMain.Content = new PageNewGradeTheme(DepClaSubTeas[ComboBoxClaSub.SelectedIndex]);
            else MessageBox.Show("Choose class and subject first.");
        }
        private void Click_NewGrade(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageManageGrades(DepClaSubTeas[ComboBoxClaSub.SelectedIndex]);
        }

        void reloadData()
        {
            DepClaSubTeas = fd.FilterDepClaSubTeaByTeaId(db.getAllDepClaSubTeas(),Teacher.TeaId);
            ComboBoxClaSub.ItemsSource = DepClaSubTeas;
            buttonsVisibilityHidden();
        }
        void buttonsVisibilityHidden()
        {
            ButtonNewGrade.Visibility = Visibility.Hidden;
            ButtonNewGradeTheme.Visibility = Visibility.Hidden;
        }
        void buttonsVisibilityVisible()
        {
            ButtonNewGrade.Visibility = Visibility.Visible;
            ButtonNewGradeTheme.Visibility = Visibility.Visible;
        }

        Teacher Teacher = new Teacher();
        DatabaseConnection db = new DatabaseConnection();
        FilterData fd = new FilterData();
        List<DepClaSubTea> DepClaSubTeas = new List<DepClaSubTea>();
        MainWindow MainWindow = new MainWindow();

        private void Click_ChangePassword(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageChangePassword(Teacher.PerId);
        }
    }
}
