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
    /// <summary>
    /// Логика взаимодействия для TeamApp.xaml
    /// </summary>
    public partial class TeamOrder : Page
    {
        private object[,] values;
        public TeamOrder()
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
                        if (excel.Open(filename))
                        {
                            values = excel.GetParticipants();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        txtBoxFood.Text += values[i, j].ToString();
                    }
                }

            }
        }
    }
}
