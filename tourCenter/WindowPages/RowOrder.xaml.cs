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

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для RowOrder.xaml
    /// </summary>
    public partial class RowOrder : Window
    {
        private int orderId;
        public RowOrder()
        {
            InitializeComponent();
        }
        public void AddSelectedOrder(string tmpOrderID)
        {
            int orderID = int.Parse(tmpOrderID);
            List<Order.OrderViewAll> orderView = Order.GetViewAll(orderID);

            AddOrderData(orderView[0], orderID);

        }
        public void AddOrderData(Order.OrderViewAll ov, int orderID)
        {
            orderId = orderID;
            winRowOrder.Title = $"{ov.ApplicationType} заявка: {ov.Client} {ov.StartTime}  — {ov.FinishTime}";
            cmbBoxStatus.Items.Add(ov.Status);
            cmbBoxStatus.SelectedItem = ov.Status;
            cmbBoxRoute.Items.Add(ov.RouteName);
            cmbBoxRoute.SelectedItem = ov.RouteName;
            cmbBoxWayToTravel.Items.Add(ov.WayToTravel);
            cmbBoxWayToTravel.SelectedItem = ov.WayToTravel;
            txtBoxPeopleAmount.Text = $"{ov.PeopleAmount}";
            //List<Participant> tmp = Participant.GetParticipantHike(hikeID);
            //listInstructors.ItemsSource = Instructor.GetHikeInstructor(hikeID);
            //List<string> participants = Participant.GetAllName(tmp);
            //foreach (string str in participants)
            //{
            //rowHikeParticipant.Content += $"{str}\n";
            //}
        }

        private void ExcelLink_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Тут будет Excel!");
        }
    }
}
