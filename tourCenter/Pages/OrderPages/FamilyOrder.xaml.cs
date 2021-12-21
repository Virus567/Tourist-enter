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
using TouristСenterLibrary.Entity;
using TouristСenterLibrary;
using System.IO;

namespace tourCenter
{

    public partial class FamilyOrder : Page
    {
        private object[,] _newParticipantsObj;
        public FamilyOrder()
        {
            InitializeComponent();
            GetRouteName();

        }
        public void GetRouteName()
        {
            var routeName = Route.GetNameRoute();
            routeName.Add("Выберите Маршрут");
            CmBoxRoutes.ItemsSource = routeName;
        }
        private void CmBoxRoutes_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxRoutes.Text == "Выберите Маршрут") CmBoxRoutes.Text = "";
            if (StartDate.Text != "" && CmBoxRoutes.Text != "")
            {
                int days = int.Parse(StartDate.Text.Substring(0, 2));
                string monthAndYear = StartDate.Text.Substring(2, 8);
                FinishDate.Text = (days + Route.GetDaysAmountByRouteName(CmBoxRoutes.Text) - 1).ToString() + monthAndYear;
            }
        }
        private void CmBoxWayToTravel_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxWayToTravel.Text == "Способ передвижения") CmBoxWayToTravel.Text = "";

        }

        private void numberPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            if (numberPhone.Text.Length == 0)
            {
                numberPhone.Text = "+7";
            }

        }

        
        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Text documents (.xlsx)|*.xlsx";
            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {
                string filename = dlg.FileName;
                txtBoxFileName.Text = filename;
                txtBoxFileName.FontSize = 12;
                using (var excel = new ExcelHelper())
                {
                    try
                    {
                        if (excel.OpenNewExcel(filename))
                        {
                            _newParticipantsObj = excel.GetParticipants();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }
        private void numberPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string t = numberPhone.Text;
            if (t.Length == 0)
            {
                numberPhone.SelectionStart = numberPhone.Text.Length; 
            }
            if (t.Length >= 12)
            {
                e.Handled = true; 
            }
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true; 
            }
        }
        private void numberPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void StartDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (StartDate.Text != "" && CmBoxRoutes.Text != "")
            {
                int days = int.Parse(StartDate.Text.Substring(0, 2));
                string monthAndYear = StartDate.Text.Substring(2, 8);
                FinishDate.Text = (days + Route.GetDaysAmountByRouteName(CmBoxRoutes.Text) - 1).ToString() + monthAndYear;
            }
        }

    }
}