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

namespace School.Pages
{
    /// <summary>
    /// Interaction logic for PageChangePassword.xaml
    /// </summary>
    public partial class PageChangePassword : Page
    {
        int PerId;
        DatabaseConnection db = new DatabaseConnection();
        public PageChangePassword(int perId)
        {
            InitializeComponent();
            PerId = perId;
        }

        private void Click_ButtonChangePassword(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxNewPass.Password.ToString().Length >= 8)
            {
                if (PasswordBoxNewPass.Password.ToString() == PasswordBoxRepPass.Password.ToString())
                {
                    db.changePassword(PerId, PasswordBoxNewPass.Password.ToString());
                    PasswordBoxNewPass.Password = null;
                    PasswordBoxRepPass.Password = null;

                }
                else MessageBox.Show("Passwords are not the same.");
            }
            else MessageBox.Show("Password must contain at least 8 characters.");
            
        }
    }
}
