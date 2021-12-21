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
using TouristСenterLibrary.Entity;
using System.IO;
using TouristСenterLibrary;


namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для RowOrder.xaml
    /// </summary>
    public partial class RowOrder : Window
    {
        private int _orderId;
        private List<Participant> _participants;
        private Order.OrderViewAll _orderView;
        private object[,] _newParticipantsObj;
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
            _orderId = orderID;
            _orderView = ov;
            winRowOrder.Title = $"{ov.ApplicationType} заявка: {ov.Client} {ov.StartTime}  — {ov.FinishTime}";
            cmbBoxStatus.Items.Add(ov.Status);
            cmbBoxStatus.SelectedItem = ov.Status;
            cmbBoxRoute.Items.Add(ov.RouteName);
            cmbBoxRoute.SelectedItem = ov.RouteName;
            cmbBoxWayToTravel.Items.Add(ov.WayToTravel);
            cmbBoxWayToTravel.SelectedItem = ov.WayToTravel;
            txtBoxPeopleAmount.Text = $"{ov.PeopleAmount}";
            _participants = Participant.GetParticipantOrder(_orderId);
            
        }

        private void ExcelLink_Click(object sender, RoutedEventArgs e)
        {
            using (var excel = new ExcelHelper())
            {
                try
                {
                    if (excel.Open(filePath: Path.Combine("D:\\Order", $"{_orderView.Client}{_orderView.StartTime}-{_orderView.FinishTime}.xlsx")))
                    {
                        excel.SetParticipant(_participants);
                        excel.Save();
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            ChengeBtn.Content = "Сохранить изменения";
        }
    }
}
