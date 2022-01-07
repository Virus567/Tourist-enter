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
using ExcelLibrary;
using TouristСenterLibrary;
using System.Linq;

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
        private List<Participant> _newPartisipants = new List<Participant>();
        private int _childrenAmount;

        public RowOrder()
        {
            InitializeComponent();
        }
        public void AddSelectedOrder(int orderID)
        {
            Order.OrderViewAll orderView = Order.GetViewAllByID(orderID);

            AddOrderData(orderView, orderID);
        }
        public void AddOrderData(Order.OrderViewAll ov, int orderID)
        {
            _orderId = orderID;
            _orderView = ov;
            _childrenAmount = ov.ChildrenAmount;
            winRowOrder.Title = $"{ov.ApplicationType} заявка: {ov.Client} {ov.StartTime}  — {ov.FinishTime}";
            cmbBoxStatus.Items.Add(ov.Status);
            cmbBoxStatus.SelectedItem = ov.Status;
            cmbBoxRoute.Items.Add(ov.RouteName);
            cmbBoxRoute.SelectedItem = ov.RouteName;
            cmbBoxWayToTravel.Items.Add(ov.WayToTravel);
            cmbBoxWayToTravel.SelectedItem = ov.WayToTravel;
            txtBoxPeopleAmount.Text = $"{ov.PeopleAmount}";
            txtBoxChildrenAmount.Text = $"{_childrenAmount}";             
            _participants = Participant.GetParticipantsByOrder(_orderId);
            if(File.Exists(Path.Combine("D:\\Order", $"{ov.Client}{ov.StartTime}-{ov.FinishTime}.xlsx")))
            {
                txtBoxFileName.Text = Path.Combine("D:\\Order", $"{ov.Client}{ov.StartTime}-{ov.FinishTime}.xlsx");
                BrowseBtn.Content = "Выбрать другой файл";
                txtBoxFileName.FontSize = 12;
            }
            txtBoxEquipment.Text = $"Количество индивидуальных палаткок: {ov.IndividualTentAmount}\n";
            txtBoxEquipment.Text += $"Количество индивидуальных гермомешков: {ov.HermeticBagAmount}\n";
            txtBoxEquipment.Text += ov.EquipmentFeatures;
            txtBoxFood.Text = ov.FoodlFeatures;

            if (ov.IsListParticipants)
            {
                txtBoxFileName.FontSize = 12;
                txtBoxFileName.Text = Path.Combine("D:\\Order", $"{ov.Client}{ov.StartTime}-{ov.FinishTime}.xlsx");
                BrowseBtn.Content = "Выбрать другой Файл";
            }
        }

        private void ChangeDataBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = Order.GetOrderByID(_orderId);
            if (ChangeDataBtn.Content == "Сохранить Изменения")
            {
                if (order.Route.Name != cmbBoxRoute.SelectedItem.ToString()
                    || order.WayToTravel != cmbBoxWayToTravel.SelectedItem.ToString()
                    || order.Client.ChildrenAmount != Convert.ToInt32(txtBoxChildrenAmount.Text)
                    || order.Client.PeopleAmount != Convert.ToInt32(txtBoxPeopleAmount.Text)
                    || txtBoxFileName.Text != "")
                {
                    var oldRoute = cmbBoxRoute.SelectedItem;
                    var oldWayToTravel = cmbBoxWayToTravel.SelectedItem;
                    order.Route = Route.GetRouteByRouteName(oldRoute.ToString());
                    if (oldRoute != order.Route)
                    {
                        order.FinishTime = order.StartTime.AddDays(Route.GetDaysAmountByRouteName(order.Route.Name) - 1);
                    }
                    order.WayToTravel = oldWayToTravel.ToString();
                    order.Client.ChildrenAmount = Convert.ToInt32(txtBoxChildrenAmount.Text);
                    order.Client.PeopleAmount = Convert.ToInt32(txtBoxPeopleAmount.Text);
                    if(_newPartisipants.Count != 0)
                    {
                        order.Client.ParticipantsList.RemoveAll(p => p.Client == order.Client);
                        foreach (var p in _newPartisipants)
                        {
                            order.Client.ParticipantsList.Add(p);
                        }
                    }
                    Client.Update(order.Client);
                    Order.Update(order);
                    MessageBox.Show("Данные успешно изменены!");
                }
                ChangeDataBtn.Content = "Изменить данные";
                cmbBoxRoute.Items.Clear();
                cmbBoxWayToTravel.Items.Clear();
                txtBoxChildrenAmount.IsReadOnly = true;
                txtBoxPeopleAmount.IsReadOnly = true;
                AddSelectedOrder(_orderId);
            }
            else
            {
                if(order.Status!= "Отменена" && order.Status != "Завершена")
                {
                    var oldRoute = cmbBoxRoute.SelectedItem;
                    var oldWayToTravel = cmbBoxWayToTravel.SelectedItem;

                    cmbBoxRoute.Items.Remove(oldRoute);
                    cmbBoxWayToTravel.Items.Remove(oldWayToTravel);
                    foreach (var i in Route.GetNameRoute())
                    {
                        cmbBoxRoute.Items.Add(i);
                    }
                    cmbBoxWayToTravel.Items.Add("Байдарки");
                    cmbBoxWayToTravel.Items.Add("Рафты");
                    txtBoxChildrenAmount.IsReadOnly = false;
                    txtBoxPeopleAmount.IsReadOnly = false;
                    ChangeDataBtn.Content = "Сохранить Изменения";
                    cmbBoxRoute.SelectedItem = oldRoute.ToString();
                    cmbBoxWayToTravel.SelectedItem = oldWayToTravel.ToString();
                }
                else
                {
                    MessageBox.Show("Невозможно изменить данные\n завершенной или отмененной заявки");
                }
                
            }

        }

        private void ExcelLink_Click(object sender, RoutedEventArgs e)
        {
            using (var excel = new ExcelHelper())
            {
                try
                {
                    if (excel.Open(filePath: Path.Combine("D:\\Order", $"{_orderView.Client}{_orderView.StartTime}-{_orderView.FinishTime}.xlsx")))
                    {
                        excel.SetParticipant(_participants,_childrenAmount);
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
                            object[,] newParticipantsObj = excel.GetParticipants();
                            for (int i = 1; i <= newParticipantsObj.GetLength(0); i++)
                            {
                                Participant participant = new Participant()
                                {
                                    Surname = newParticipantsObj[i, 1].ToString(),
                                    Name = newParticipantsObj[i, 2].ToString(),
                                    Middlename = newParticipantsObj[i, 3].ToString(),
                                    ClientTelefonNumber = newParticipantsObj[i, 4].ToString()
                                };
                                _newPartisipants.Add(participant);
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            ChangeDataBtn.Content = "Сохранить Изменения";
        }

        private void CheckSpaceDown_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void CheckCorrectAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string t = textBox.Text;
            if (t.Length >= 2)
            {
                e.Handled = true;
            }
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }
    }
}
