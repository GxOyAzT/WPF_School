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
    /// Interaction logic for PageNewTeacher.xaml
    /// </summary>
    public partial class PageNewTeacher : Page
    {
        public PageNewTeacher()
        {
            InitializeComponent();
            resetData();
        }

        private void Click_CreateTeacher(object sender, RoutedEventArgs e)
        {
            Teacher teacher;
            if (CheckBoxAdmPre.IsChecked ?? true)
            {
                teacher = new Teacher(TextBoxFirstName.Text.ToString(), TextBoxLastName.Text.ToString(),
                    TextBoxPesel.Text.ToString(), TextBoxAdress.Text.ToString(), true);
            }
            else
            {
                teacher = new Teacher(TextBoxFirstName.Text.ToString(), TextBoxLastName.Text.ToString(),
                    TextBoxPesel.Text.ToString(), TextBoxAdress.Text.ToString(), false);
            }
            if (db.createNewTeacher(teacher))
            {
                resetData();
            }
            else
            {
                MessageBox.Show("Cannot add this teacher to database.");
            }
        }


        DatabaseConnection db = new DatabaseConnection();
        List<Teacher> teachers = new List<Teacher>();
        void resetData()
        {
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxPesel.Text = "";
            TextBoxAdress.Text = "";
            CheckBoxAdmPre.IsChecked = false;
            teachers = db.getAllTeachers();
            DataGridTeachers.ItemsSource = teachers;
        }
    }
}
