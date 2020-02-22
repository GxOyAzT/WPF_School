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
    /// Interaction logic for PageNewStudent.xaml
    /// </summary>
    public partial class PageNewStudent : Page
    {
        public PageNewStudent()
        {
            InitializeComponent();
            reloadData();
        }

        private void Click_CreateStudent(object sender, RoutedEventArgs e)
        {
            if (comboBoxClasses.SelectedIndex >= 0)
            {
                Class classResult = classes[comboBoxClasses.SelectedIndex];
                Student newStudent = new Student(TextBoxFirstName.Text.ToString(),
                    TextBoxLastName.Text.ToString(), TextBoxPesel.Text.ToString(),
                    TextBoxAdress.Text.ToString(), classResult);
                if (db.createNewStudent(newStudent))
                {
                    reloadData();
                }
                else MessageBox.Show("Can't add this student. Fill data correctly and check if student exists.");
            }
            else MessageBox.Show("Choose class first.");
        }

        DatabaseConnection db = new DatabaseConnection();
        List<Class> classes = new List<Class>();
        void reloadData()
        {
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxPesel.Text = "";
            TextBoxAdress.Text = "";
            classes = db.getAllClasses();
            DataGridStudents.ItemsSource = db.getAllStudents();
            comboBoxClasses.ItemsSource = classes;
        }
    }
}
