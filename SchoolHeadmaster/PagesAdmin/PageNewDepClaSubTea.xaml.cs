using ConsoleSchool.Classes;
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

namespace School.PagesAdmin
{
    /// <summary>
    /// Interaction logic for PageNewDependence.xaml
    /// </summary>
    public partial class PageNewDepClaSubTea : Page
    {
        DatabaseConnection db = new DatabaseConnection();
        List<Class> classes = new List<Class>();
        List<Subject> subjects = new List<Subject>();
        List<Subject> subjectsResults = new List<Subject>();
        List<Teacher> teachers = new List<Teacher>();
        List<Teacher> teachersResults = new List<Teacher>();
        List<DepClaSubTea> depClaSubTeas = new List<DepClaSubTea>();
        List<DepSubTea> depSubTeas = new List<DepSubTea>();
        void reloadData()
        {
            DataGridDepClaSubTeas.ItemsSource = db.getAllDepClaSubTeas();
        }

        public PageNewDepClaSubTea()
        {
            classes = db.getAllClasses();
            subjects = db.getAllSubjects();
            teachers = db.getAllTeachers();
            depClaSubTeas = db.getAllDepClaSubTeas();
            depSubTeas = db.getAllDepSubTeas();
            InitializeComponent();
            reloadData();
            ComboBoxClasses.ItemsSource = classes;
            ComboBoxTeachers.ItemsSource = teachers;
        }

        private void Click_NewDependence(object sender, RoutedEventArgs e)
        {
            if (ComboBoxClasses.SelectedIndex >= 0 & ComboBoxSubjects.SelectedIndex >= 0 &
                ComboBoxTeachers.SelectedIndex >= 0)
            {
                DepClaSubTea newDepClaSubTea = new DepClaSubTea(
                    classes[ComboBoxClasses.SelectedIndex].ClaId,
                    subjectsResults[ComboBoxSubjects.SelectedIndex].SubId,
                    teachersResults[ComboBoxTeachers.SelectedIndex].TeaId);
                if (db.createDependenceClassSubjectTeacher(newDepClaSubTea))
                {
                    ComboBoxClasses.ItemsSource = null;
                    ComboBoxTeachers.ItemsSource = null;
                    ComboBoxSubjects.ItemsSource = null;
                    ComboBoxClasses.ItemsSource = classes;
                    reloadData();
                }
                else MessageBox.Show("Dependence exists in database.");
            }
            else MessageBox.Show("You have to choose class and subject and teacher.");
        }

        private void ComboBox_SelectionChanged_Class(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxClasses.SelectedIndex >= 0)
            {
                Class selectedClass = classes[ComboBoxClasses.SelectedIndex];
                List<int> subjectsUsedBeforeIds = new List<int>();
                foreach (DepClaSubTea depClaSubTea in depClaSubTeas)
                    if (depClaSubTea._ClaId == selectedClass.ClaId)
                        subjectsUsedBeforeIds.Add(depClaSubTea._SubId);

                subjectsResults = new List<Subject>();
                subjectsResults.AddRange(subjects);
                foreach (Subject subject in subjects)
                {
                    foreach (int index in subjectsUsedBeforeIds)
                    {
                        if (subject.SubId == index)
                            subjectsResults.Remove(subject);
                    }
                }
                ComboBoxSubjects.ItemsSource = null;
                ComboBoxTeachers.ItemsSource = null;
                ComboBoxSubjects.ItemsSource = subjectsResults;
            }
        }

        private void ComboBox_SelectionChanged_Subject(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxSubjects.SelectedIndex >= 0)
            {
                int subjectId = subjectsResults[ComboBoxSubjects.SelectedIndex].SubId;
                teachersResults = new List<Teacher>();
                foreach (DepSubTea depSubTea in depSubTeas)
                {
                    if (depSubTea._SubId == subjectId)
                    {
                        Teacher teacherResult = teachers.Find(
                            delegate (Teacher teach)
                            {
                                return teach.TeaId == depSubTea._TeaId;
                            });
                        teachersResults.Add(teacherResult);
                    }
                }
                ComboBoxTeachers.ItemsSource = null;
                ComboBoxTeachers.ItemsSource = teachersResults;
            }
        }
    }
}
