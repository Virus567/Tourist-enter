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
using System.Windows.Shapes;
using TouristСenterLibrary.Entity;
using System.Linq;

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для NewHike.xaml
    /// </summary>
    public partial class NewHike : Window
    {
        public NewHike()
        {
            InitializeComponent();
            GetDataInGrid();
            GetRouteName();
        }
        public void GetDataInGrid()
        {
            dgOrders.ItemsSource = Order.GetView().Where(e => e.Status == "Активна"); ;
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
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            RowOrder rowOrder = new RowOrder();
            Order.OrderView selectedOrder = (Order.OrderView)dgOrders.SelectedValue;
            rowOrder.Show();
            rowOrder.AddSelectedOrder(selectedOrder.ID.ToString());
        }

        private void addOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Order.OrderView selectedOrder = (Order.OrderView)dgOrders.SelectedValue;
            if (txtBoxStartDate.Text == "")
                GetOrderData(selectedOrder);         

            if (!dgOrdersForHike.Items.Contains(selectedOrder) && IsСorrectOrder(selectedOrder)) //|| !IsTeamOrder(selectedOrder)
            {
                dgOrdersForHike.Items.Add(selectedOrder);
                if (txtBoxPeopleAmount.Text == "0")
                    txtBoxPeopleAmount.Text = selectedOrder.PeopleAmount.ToString();
                else
                {
                    int tmp = int.Parse(txtBoxPeopleAmount.Text);
                    tmp += selectedOrder.PeopleAmount;
                    txtBoxPeopleAmount.Text = tmp.ToString();
                }
            }
            //else if (IsTeamOrder(selectedOrder))
            //{
            //    dgOrdersForHike.Items.Add(selectedOrder);
            //    txtBoxPeopleAmount.Text = selectedOrder.PeopleAmount.ToString();
            //    addOrderBtn.IsEnabled = true;
            //}
               
       }

        //private bool IsTeamOrder(Order.OrderView order)
        //{
        //    int orderId = order.ID;
        //    Order tmpOrder = Order.GetOrderByID(orderId);
        //    return tmpOrder.Client.NameOfCompany != null;
        //}

        private bool IsСorrectOrder(Order.OrderView order)
        {
            Order.OrderViewAll o = Order.GetViewAll(order.ID)[0];
            return txtBoxStartDate.Text == o.StartTime &&
                   txtBoxRoute.Text == o.RouteName &&
                   txtBoxWayToTravel.Text == o.WayToTravel;
        }

        private void GetOrderData(Order.OrderView tmpOrder)
        {
            Order.OrderViewAll order = Order.GetViewAll(tmpOrder.ID)[0];
            txtBoxStartDate.Text = order.StartTime;
            txtBoxFinishDate.Text = order.FinishTime;
            txtBoxRoute.Text = order.RouteName;
            
            txtBoxWayToTravel.Text = order.WayToTravel;

        }
    }    
}
