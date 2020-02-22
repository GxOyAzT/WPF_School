using ConsoleSchool.Classes;
using School.UserControls;
using SchoolHeadmaster.UserControls;
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
using School.Pages;

namespace SchoolHeadmaster.Pages
{
    /// <summary>
    /// Interaction logic for PageLogIn.xaml
    /// </summary>
    public partial class PageLogIn : Page
    {
        DatabaseConnection db = new DatabaseConnection();
        MainWindow MainWindow = new MainWindow();
        public PageLogIn(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            InitializeComponent();
        }

        private void Click_LogIn(object sender, RoutedEventArgs e)
        {
            Account account = new Account(TextBoxUsername.Text.ToString(),
                 PasswordBoxPassword.Password.ToString());
            Account accountResult = db.SearchByUsernamePassword(account);
            if (accountResult.Acc_PerId == -1)
            {
                MessageBox.Show("Username or password is incorrect.");
            }
            else
            {
                List<Teacher> teachers = db.getAllTeachers();
                Teacher teacherResoult = teachers.Find(
                    delegate (Teacher teach)
                    {
                        return teach.PerId == accountResult.Acc_PerId;
                    });
                if (teacherResoult != null)
                {
                    if (teacherResoult.TeaAdminPremission)
                    {
                        if (MessageBox.Show("Do you want to log in as a Administrator?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {
                            MainWindow.loadData();
                            MainWindow.LabelUserName.Content = $"TEACH: {teacherResoult.PerFullName}";
                            MainWindow.FrameMain.Content = new PageBlank();
                            MainWindow.ButtonLogIn.Content = "Log out";
                            MainWindow.FrameUserControl.Content = new PageTeacherControl(this.MainWindow, teacherResoult);
                        }
                        else
                        {
                            MainWindow.loadData();
                            MainWindow.LabelUserName.Content = $"HEAD: {teacherResoult.PerFullName}";
                            MainWindow.FrameMain.Content = new PageBlank();
                            MainWindow.ButtonLogIn.Content = "Log out";
                            MainWindow.FrameUserControl.Content = new PageAdministratorControl(this.MainWindow);
                        }
                    }
                    else
                    {
                        MainWindow.loadData();
                        MainWindow.LabelUserName.Content = $"TEACH: {teacherResoult.PerFullName}";
                        MainWindow.FrameMain.Content = new PageBlank();
                        MainWindow.ButtonLogIn.Content = "Log out";
                        MainWindow.FrameUserControl.Content = new PageTeacherControl(this.MainWindow, teacherResoult);
                    }
                }
                else
                {
                    List<Student> students = db.getAllStudents();
                    Student studentResult = students.Find(
                        delegate (Student stud)
                        {
                            return stud.PerId == accountResult.Acc_PerId;
                        });
                    if (studentResult != null)
                    {
                        MainWindow.loadData();
                        MainWindow.LabelUserName.Content = $"STUD: {studentResult.PerFullName}";
                        MainWindow.FrameMain.Content = new PageBlank();
                        MainWindow.ButtonLogIn.Content = "Log out";
                        MainWindow.FrameUserControl.Content = new PageStudentControl(this.MainWindow, studentResult);
                    }
                }
            }
        }
    }
}
