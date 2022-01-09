using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
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
            FillingDataGrid();
            GetRouteName();
        }
        private void CheckInAssembly_Checked(object sender, RoutedEventArgs e) 
        {
            CheckOnRoute.IsChecked = false;
            FillingDataGrid();
        }
        private void CheckOnRoute_Checked(object sender, RoutedEventArgs e)
        {
            CheckInAssembly.IsChecked = false;
            FillingDataGrid();
        }
            
        public void GetRouteName()
        {
            var routeName = Route.GetNameRoute();
            routeName.Add("Выберите Маршрут");
            CmBoxRoutes.ItemsSource = routeName ;
        }

        public void FillingDataGrid()
        {
            List<Hike.HikeView> list = Hike.GetView();
            if (selectDate.Text != "")
            {
                DateTime dt = selectDate.SelectedDate.Value;
                list = list.Where(l => l.StartTime == dt.ToString("d")).ToList();
            }
            if (CmBoxRoutes.Text != "") 
            {
                list = list.Where(l => l.RouteName == CmBoxRoutes.Text).ToList();
            }
            if (CmBoxWayToTravel.Text != "")
            {
                list = list.Where(l => l.WayToTravel == CmBoxWayToTravel.Text).ToList();
            }
            if ((bool)CheckOnRoute.IsChecked)
            {
                list = list.Where(l => l.Status == "На маршруте").ToList();
            }
            else if ((bool)CheckInAssembly.IsChecked)
            {
                list = list.Where(l => l.Status == "В сборке").ToList();
            }
            if (txtBoxSearch.Text != "")
            {
                list = list.Where(l => l.CompanyName.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();
            }
            dgHike.ItemsSource = list;
        }

        private void CmBoxRoutes_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxRoutes.Text == "Выберите Маршрут") CmBoxRoutes.Text = "";
            FillingDataGrid();

        }
        private void CmBoxWayToTravel_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxWayToTravel.Text == "Способ передвижения") CmBoxWayToTravel.Text = "";
            FillingDataGrid();

        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            RowHike rowHike = new RowHike(this);
            Hike.HikeView selectedHike = (Hike.HikeView) dgHike.SelectedValue;
            rowHike.Show();
            rowHike.AddSelectedHike(selectedHike.ID);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NewHike newHike = new NewHike(this);
            newHike.Show();
        }
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            FillingDataGrid();
        }

        private void CheckOnRoute_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CheckInAssembly.IsChecked == false)
                FillingDataGrid();
        }

        private void CheckInAssembly_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CheckOnRoute.IsChecked == false)
                FillingDataGrid();
        }
        private void selectDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillingDataGrid();
        }

        private void selectDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
                FillingDataGrid();
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillingDataGrid();
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            FillingDataGrid();
        }
    }
}
