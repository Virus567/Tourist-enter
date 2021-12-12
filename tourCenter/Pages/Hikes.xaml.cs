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

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для Hikes.xaml
    /// </summary>
    public partial class Hikes : Page
    {
        public Hikes()
        {

            InitializeComponent();
            GetDataInGrid();
            GetRouteName();
        }
        public void GetDataInGrid()
        {

            dgHike.ItemsSource = Hike.GetView();
        }

        private void CheckActive_Checked(object sender, RoutedEventArgs e) => CheckInAssembly.IsChecked = false;
        private void CheckInAssembly_Checked(object sender, RoutedEventArgs e) => CheckActive.IsChecked = false;
        public void GetRouteName()
        {
            var routeName = Route.GetNameRoute();
            routeName.Add("Выберите Маршрут");
            CmBoxRoutes.ItemsSource = routeName ;
        }
        private void CmBoxRoutes_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxRoutes.Text == "Выберите Маршрут") CmBoxRoutes.Text = "";
        }
        private void CmBoxWayToTravel_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxWayToTravel.Text == "Способ передвижения") CmBoxWayToTravel.Text = "";

        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            RowHike rowHike = new RowHike();
            Hike.HikeView selectedHike = (Hike.HikeView) dgHike.SelectedValue;
            rowHike.Show();
            rowHike.AddSelectedHike(selectedHike.ID.ToString());
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NewHike newHike = new NewHike();
            newHike.Show();
        }
    }
}
