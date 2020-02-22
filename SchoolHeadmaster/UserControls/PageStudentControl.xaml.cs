using ConsoleSchool.Classes;
using School.Pages;
using School.PagesStudent;
using SchoolHeadmaster;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace School.UserControls
{
    /// <summary>
    /// Interaction logic for PageStudentControl.xaml
    /// </summary>
    public partial class PageStudentControl : Page
    {
        public PageStudentControl(MainWindow mainWindow, Student student)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            Student = student;
            List<DepClaSubTea> depClaSubTeasBaseOnStudents = new List<DepClaSubTea>();
            depClaSubTeasBaseOnStudents = (from dep in db.getAllDepClaSubTeas()
                                          where dep._ClaId == Student.StuClass.ClaId
                                          select dep).ToList();

            foreach (Subject subject in db.getAllSubjects())
                foreach (DepClaSubTea depClaSubTea in depClaSubTeasBaseOnStudents)
                    if(depClaSubTea._SubId == subject.SubId)
                    {
                        Subjects.Add(subject);
                        break;
                    }
            ComboBoxSubjects.ItemsSource = Subjects;
        }

        DatabaseConnection db = new DatabaseConnection();
        MainWindow MainWindow = new MainWindow();
        Student Student = new Student();
        List<Subject> Subjects = new List<Subject>();

        private void ComboBox_SelectionChanged_Subjects(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSubjects.SelectedIndex >= 0)
                MainWindow.FrameMain.Content = new PageGrades(Student, Subjects[ComboBoxSubjects.SelectedIndex]);
        }

        private void Click_ChangePassword(object sender, RoutedEventArgs e)
        {
            MainWindow.FrameMain.Content = new PageChangePassword(Student.PerId);
        }
    }
}
