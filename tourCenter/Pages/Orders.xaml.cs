using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TouristСenterLibrary.Entity;
using System.Linq;

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для Applications.xaml
    /// </summary>
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();
            GetRouteName();
            FillingDataGrid();
        }
        private void CheckActive_Checked(object sender, RoutedEventArgs e)
        {
            CheckInAssembly.IsChecked = false;
            FillingDataGrid();
        }
        private void CheckInAssembly_Checked(object sender, RoutedEventArgs e)
        {
            CheckActive.IsChecked = false;
            FillingDataGrid();
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
            FillingDataGrid();            
        }

        private void CmBoxWayToTravel_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxWayToTravel.Text == "Способ передвижения") CmBoxWayToTravel.Text = "";
            FillingDataGrid();
        }
        public void FillingDataGrid()
        {
            List<Order.OrderView> list = Order.GetView();
            if (selectDate.Text != "")
            {
                DateTime dt = selectDate.SelectedDate.Value;
                list = list.Where(l => l.DateTime == dt.ToString("d")).ToList();
            }
            if(CmBoxRoutes.Text != "")
            {
                list = list.Where(l => l.RouteName == CmBoxRoutes.Text).ToList();
            }
            if(CmBoxWayToTravel.Text != "")
            {
                list = list.Where(l => l.WayToTravel == CmBoxWayToTravel.Text).ToList();
            }
            if((bool)CheckActive.IsChecked)
            {
                list = list.Where(l => l.Status == "Активна").ToList();
            }
            else if ((bool)CheckInAssembly.IsChecked)
            {
                list = list.Where(l => l.Status == "В сборке").ToList();
            }
            if(txtBoxSearch.Text != "")
            {
                list = list.Where(l => l.Client.ToLower().Contains(txtBoxSearch.Text.ToLower())).ToList();
            }
            dgOrder.ItemsSource = list;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            RowOrder rowOrder = new RowOrder(this);
            Order.OrderView selectedOrder = (Order.OrderView)dgOrder.SelectedValue;
            rowOrder.Show();
            rowOrder.AddSelectedOrder(selectedOrder.ID);
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            FillingDataGrid();
        }

        private void CheckInAssembly_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(bool)CheckActive.IsChecked)
                FillingDataGrid();
        }

        private void CheckActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(bool)CheckInAssembly.IsChecked)
                FillingDataGrid();
        }

        private void selectDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FillingDataGrid();
        }

        private void selectDate_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Back)
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
