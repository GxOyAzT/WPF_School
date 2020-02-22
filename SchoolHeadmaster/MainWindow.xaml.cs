using SchoolHeadmaster.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleSchool.Classes;
using School.UserControls;
using School.Pages;

namespace SchoolHeadmaster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseConnection db = new DatabaseConnection();
        List<Teacher> teachers = new List<Teacher>();
        List<Subject> subjects = new List<Subject>();
        List<Class> classes = new List<Class>();
        List<Student> students = new List<Student>();
        List<DepClaSubTea> depClaSubTeas = new List<DepClaSubTea>();
        List<GradeTheme> gradeThemes = new List<GradeTheme>();
        List<Grade> grades = new List<Grade>();

        public void loadData()
        {
            teachers = db.getAllTeachers();
            subjects = db.getAllSubjects();
            classes = db.getAllClasses();
            students = db.getAllStudents();
            depClaSubTeas = db.getAllDepClaSubTeas();
            gradeThemes = db.getAllGradeThemes();
            grades = db.getAllGrades();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_LogIn(object sender, RoutedEventArgs e)
        {
            if (ButtonLogIn.Content.ToString() == "Log in")
            {
                FrameMain.Content = new PageLogIn(this);
            }
            else
            {
                LabelUserName.Content = "";
                FrameMain.Content = new PageBlank();
                ButtonLogIn.Content = "Log in";
                FrameUserControl.Content = new PageBlankControl();
            }
        }
    }
}