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
using ConsoleSchool.Classes;

namespace School.PagesAdmin
{
    /// <summary>
    /// Interaction logic for PageNewSubject.xaml
    /// </summary>
    public partial class PageNewSubject : Page
    {
        public PageNewSubject()
        {
            InitializeComponent();
            reloadData();
        }

        private void Click_CreateSubject(object sender, RoutedEventArgs e)
        {
            Subject newSubject = new Subject(TextBoxSubjectName.Text.ToString());
            if (db.createNewSubject(newSubject))
            {
                TextBoxSubjectName.Text = "";
                reloadData();
            }
            else MessageBox.Show("This subject exists in databasee or name is incorrect.");
        }

        DatabaseConnection db = new DatabaseConnection();
        void reloadData()
        {
            DataGridSubjects.ItemsSource = db.getAllSubjects();
        }
    }
}
