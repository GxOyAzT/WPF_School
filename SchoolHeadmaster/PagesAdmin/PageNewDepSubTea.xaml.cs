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
    /// Interaction logic for PageDepSubTea.xaml
    /// </summary>
    public partial class PageNewDepSubTea : Page
    {
        DatabaseConnection db = new DatabaseConnection();
        List<Subject> subjects = new List<Subject>();
        List<Teacher> teachers = new List<Teacher>();
        List<Teacher> teachersResults = new List<Teacher>();
        List<DepSubTea> depSubTeas = new List<DepSubTea>();

        public PageNewDepSubTea()
        {
            subjects = db.getAllSubjects();
            teachers = db.getAllTeachers();
            depSubTeas = db.getAllDepSubTeas();
            InitializeComponent();
            ComboBoxSubjects.ItemsSource = subjects;
            ComboBoxSubjects.SelectedIndex = 0;
            reloadData();
        }

        private void ComboBox_SelectionChanged_Subject(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxSubjects.SelectedIndex >= 0)
            {
                int subjectId = subjects[ComboBoxSubjects.SelectedIndex].SubId;
                teachersResults = new List<Teacher>();
                teachersResults.AddRange(teachers);
                foreach (DepSubTea depSubTea in depSubTeas)
                {
                    if (depSubTea._SubId == subjectId)
                    {
                        Teacher teacherResult = teachers.Find(
                            delegate (Teacher teach)
                            {
                                return teach.TeaId == depSubTea._TeaId;
                            });
                        teachersResults.Remove(teacherResult);
                    }
                }
                ComboBoxTeachers.ItemsSource = null;
                ComboBoxTeachers.ItemsSource = teachersResults;
            }
        }

        private void Click_NewDependence(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSubjects.SelectedIndex >= 0 & ComboBoxTeachers.SelectedIndex >= 0)
            {
                if (db.createNewDepSubTea(new DepSubTea(subjects[ComboBoxSubjects.SelectedIndex].SubId,
                    teachersResults[ComboBoxTeachers.SelectedIndex].TeaId)))
                {
                    ComboBoxSubjects.SelectedIndex = 0;
                    ComboBoxTeachers.ItemsSource = null;
                    depSubTeas = db.getAllDepSubTeas();
                    reloadData();
                }
                else MessageBox.Show("This dependence exists.");
            }
            else MessageBox.Show("You have to choose Subject and Teacher first.");
        }

        void reloadData()
        {
            DataGridDepSubTeas.ItemsSource = db.getAllDepSubTeas();
        }
    }
}
