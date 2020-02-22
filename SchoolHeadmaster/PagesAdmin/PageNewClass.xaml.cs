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
    /// Interaction logic for PageNewClass.xaml
    /// </summary>
    public partial class PageNewClass : Page
    {
        public PageNewClass()
        {
            InitializeComponent();
            reloadData();
        }

        private void Click_CreateClass(object sender, RoutedEventArgs e)
        {
            Class newClass = new Class(TextBoxClassName.Text.ToString());
            if (db.createNewClass(newClass))
            {
                TextBoxClassName.Text = "";
                reloadData();
            }
            else MessageBox.Show("");
        }

        DatabaseConnection db = new DatabaseConnection();
        void reloadData()
        {
            DataGridClasses.ItemsSource = db.getAllClasses();
        }
    }
}
