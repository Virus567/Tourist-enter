using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TouristСenterLibrary.Entity;
using System.IO;
using ExcelLibrary;

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для RowOrder.xaml
    /// </summary>
    public partial class RowOrder : Window
    {
        private int _orderId;
        private List<Participant> _participants;
        private Client _client;
        private Order.OrderViewAll _orderView;
        private List<Participant> _newPartisipants = new List<Participant>();
        private int _childrenAmount;
        private Orders _ordersPage;

        public RowOrder(Orders orders)
        {
            InitializeComponent();
            _ordersPage = orders;
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
            _client = Client.GetClientByOrderId(_orderId);
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

        public bool IsCorrectData()
        {
            int i;
            return int.TryParse(txtBoxPeopleAmount.Text,out i) &&
                   int.TryParse(txtBoxChildrenAmount.Text, out i) &&
                   txtBoxPeopleAmount.Text!="0" &&
                   Convert.ToInt32(txtBoxPeopleAmount.Text) >= Convert.ToInt32(txtBoxChildrenAmount.Text);
        }

        private void ChangeDataBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = Order.GetOrderByID(_orderId);
            if (ChangeDataBtn.Content == "Сохранить Изменения")
            {
                if (IsCorrectData())
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
                        if (_newPartisipants.Count != 0)
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
                        _ordersPage.FillingDataGrid();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля корректно");
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
                        excel.SetParticipant(_participants,_childrenAmount,_client);
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
                            if (newParticipantsObj.GetLength(0) == Convert.ToInt32(txtBoxPeopleAmount.Text))
                            {
                                for (int i = 1; i <= newParticipantsObj.GetLength(0); i++)
                                {
                                    string Surname = newParticipantsObj[i, 1].ToString();
                                    string Name = newParticipantsObj[i, 2].ToString();
                                    string ClientTelefonNumber = newParticipantsObj[i, 4].ToString();

                                    if (newParticipantsObj[i, 3] != null)
                                    {
                                        string Middlename = newParticipantsObj[i, 3].ToString();
                                        Participant participant = new Participant(Surname, Name, Middlename, ClientTelefonNumber);
                                        _newPartisipants.Add(participant);
                                    }
                                    else
                                    {
                                        Participant participant = new Participant(Surname, Name, ClientTelefonNumber);
                                        _newPartisipants.Add(participant);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Количество людей не совпадает");
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
