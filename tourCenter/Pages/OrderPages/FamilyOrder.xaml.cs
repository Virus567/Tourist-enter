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

        private void numberPhone_TextChanged(object sender, TextChangedEventArgs e) //Метод ГОВНА УДАЛИ ЭТО!!!
        {
            //int value;
            //if((!int.TryParse(numberPhone.Text,out value))||numberPhone.Text!="+7")
            //{
            //    numberPhone.Text = numberPhone.Text.Substring(0, numberPhone.Text.Length - 1);
            //}
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
            }
        }
    }
}