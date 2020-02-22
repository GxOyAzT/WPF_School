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

namespace School.PagesTeacher
{
    /// <summary>
    /// Interaction logic for PageManageGrades.xaml
    /// </summary>
    public partial class PageManageGrades : Page
    {
        public PageManageGrades(DepClaSubTea depClaSubTea)
        {
            DepClaSubTea = depClaSubTea;
            InitializeComponent();
            reloadData();
        }

        void reloadData()
        {
            Students = (from student in db.getAllStudents()
                       where student.StuClass.ClaId == DepClaSubTea._ClaId
                       select student).ToList();

            GradeThemes = (from gradetheme in db.getAllGradeThemes()
                           where gradetheme.Gth_DepCSTid == DepClaSubTea.DepCSTid
                           select gradetheme).ToList();

            Grades = db.getFullGradesInfoFilteredDepClaSubTea(DepClaSubTea.DepCSTid);
            List<GradeTheme> GradeThemeLoop = new List<GradeTheme>();
            GradeThemeLoop.AddRange(GradeThemes);
            foreach(GradeTheme gradeTheme in GradeThemeLoop)
            {
                int count = (from grade in Grades
                             where grade.GthId == gradeTheme.GthId
                             select grade).Count();
                if (count == Students.Count) GradeThemes.Remove(gradeTheme);
            }
            ComboBoxGradeThemes.ItemsSource = GradeThemes;
            ComboBoxStudent.ItemsSource = null;
            DataGridStudentsGrades.ItemsSource = Grades;
            //foreach (Grade grade in Grades)
            //    foreach (Student student in Students) 
            //        if(grade.Gra_StuId == student.StuId)
            //        {
            //            student.StuGrades.Add(grade);
            //            break;
            //        }
            if (ComboBoxGrade.Items.Count == 0) for(int i = 1; i <=6; i++) ComboBoxGrade.Items.Add(i);
        }
        private void SelectionChanged_GradeThemes(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxGradeThemes.SelectedIndex >= 0)
            {
                Grades = (from grade in Grades
                          where grade.GthId == GradeThemes[ComboBoxGradeThemes.SelectedIndex].GthId
                          select grade).ToList();

                List<Student> studentLoop = new List<Student>();
                studentLoop.AddRange(Students);
                foreach (Student student in studentLoop)
                    foreach (Grade grade in Grades)
                        if (student.StuId == grade.Gra_StuId)
                        {
                            Students.Remove(student);
                            break;
                        }
                ComboBoxStudent.ItemsSource = Students;
            }
        }
        private void CLick_CreateGrade(object sender, RoutedEventArgs e)
        {
            if (ComboBoxGrade.SelectedIndex >= 0 & ComboBoxGradeThemes.SelectedIndex >= 0 & ComboBoxStudent.SelectedIndex >= 0)
            {
                int grade = ComboBoxGrade.SelectedIndex + 1;
                Grade newGrade = new Grade(Students[ComboBoxStudent.SelectedIndex].StuId, 
                    grade,
                    GradeThemes[ComboBoxGradeThemes.SelectedIndex].GthId);
                db.createNewGrade(newGrade);
                reloadData();
            }
            else MessageBox.Show("You have to choose grade title, student and grade.");
        }

        List<Student> Students = new List<Student>();
        List<Grade> Grades = new List<Grade>();
        List<GradeTheme> GradeThemes = new List<GradeTheme>();
        DatabaseConnection db = new DatabaseConnection();
        DepClaSubTea DepClaSubTea = new DepClaSubTea();
    }
}
