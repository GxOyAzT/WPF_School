using ConsoleSchool.Classes;
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

namespace School.PagesStudent
{
    /// <summary>
    /// Interaction logic for PageGrades.xaml
    /// </summary>
    public partial class PageGrades : Page
    {
        public PageGrades(Student student, Subject subject)
        {
            InitializeComponent();
            Student = student;
            Subject = subject;
            Grades = db.getFullGradesInfoFilteredSubIdStuId(subject.SubId, student.StuId);
            DataGridGrades.ItemsSource = Grades;
        }
        DatabaseConnection db = new DatabaseConnection();
        Student Student = new Student();
        List<Grade> Grades = new List<Grade>();
        Subject Subject = new Subject();
    }
}
