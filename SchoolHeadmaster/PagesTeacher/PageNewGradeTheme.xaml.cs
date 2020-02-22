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
    /// Interaction logic for PageNewGradeTheme.xaml
    /// </summary>
    public partial class PageNewGradeTheme : Page
    {
        public PageNewGradeTheme(DepClaSubTea depClaSubTea)
        {
            InitializeComponent();
            DepClaSubTea = depClaSubTea;
            LabelDepClaSubTea.Content = $"{DepClaSubTea.ClaName} - {DepClaSubTea.SubName} - {DepClaSubTea.TeaName}";
            reloadData();
        }

        private void Click_CreateNewGradeTheme(object sender, RoutedEventArgs e)
        {
            if (TextBoxGradeName.Text.Length > 0 & TextBoxGradeName.Text.Length <= 10)
            {
                if (ComboBoxClaSub.SelectedIndex >= 0)
                {
                    if (db.createNewGradeTheme(new GradeTheme(TextBoxGradeName.Text.ToString(),
                        GradeThemesCanRetake[ComboBoxClaSub.SelectedIndex].GthId, DepClaSubTea)))
                    {
                        TextBoxGradeName.Text = "";
                    }
                }
                else
                {
                    if (db.createNewGradeTheme(new GradeTheme(TextBoxGradeName.Text.ToString(), DepClaSubTea)))
                    {
                        TextBoxGradeName.Text = "";
                    }
                }
                reloadData();
            }
            else MessageBox.Show("Grade name has to be from 1 to 20 chars.");
            
        }
        private void TextBoxGradeName_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(dc.chechIfGthExistsByName(new GradeTheme(TextBoxGradeName.Text.ToString()), GradeThemes))
            {
                TextBoxGradeName.Text = "";
                MessageBox.Show("This grade already exists.");
            }
        }

        void reloadData()
        {
            GradeThemes = (from gradetheme in db.getAllGradeThemes()
                           where gradetheme.Gth_DepCSTid == DepClaSubTea.DepCSTid
                           select gradetheme).ToList();
            GradeThemesCanRetake = new List<GradeTheme>();
            GradeThemesCanRetake.AddRange(GradeThemes);

            foreach (GradeTheme gradeTheme in GradeThemes)
                foreach (GradeTheme gradeTheme1 in GradeThemes)
                    if (gradeTheme.GthId == gradeTheme1.GthRetake_GthId)
                    {
                        GradeThemesCanRetake.Remove(gradeTheme);
                        break;
                    }

            ComboBoxClaSub.ItemsSource = GradeThemesCanRetake;
            DataGridGradeThemes.ItemsSource = GradeThemes;
        }

        DatabaseConnection db = new DatabaseConnection();
        DataCorrectness dc = new DataCorrectness();
        DepClaSubTea DepClaSubTea = new DepClaSubTea();
        List<GradeTheme> GradeThemes = new List<GradeTheme>();
        List<GradeTheme> GradeThemesCanRetake = new List<GradeTheme>();
    }
}
