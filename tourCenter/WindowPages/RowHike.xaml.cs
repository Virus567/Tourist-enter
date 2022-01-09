using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using TouristСenterLibrary.Entity;
using ExcelLibrary;
using System.Linq;

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для RowHike.xaml
    /// </summary>
    public partial class RowHike : Window
    {
        private int _hikeId;
        private List<Participant> _participants;
        private Hike.HikeViewAll _hikeView;
        private int _childrenAmount;
        private Hikes _hikesPage;
        public RowHike(Hikes hikes)
        {
            InitializeComponent();
            _hikesPage = hikes;
            
        }
        public void AddSelectedHike(int hikeId)
        {
            Hike.HikeViewAll hikeVeiw = Hike.GetViewAllByID(hikeId)[0];
            AddHikeData(hikeVeiw, hikeId);          
        }

        public void AddHikeData(Hike.HikeViewAll hv,int hikeId)
        {
            _hikeView = hv;
            _hikeId = hikeId;
            int peopleAmount = Hike.GetPeopleAmountOfHike(hikeId);
            winRowHike.Title = $" {hv.CompanyName} {hv.StartTime}  — {hv.FinishTime}";
            cmbBoxStatus.Items.Add(hv.Status);
            cmbBoxStatus.SelectedItem = hv.Status;
            cmbBoxRoute.Items.Add(hv.RouteName);
            cmbBoxRoute.SelectedItem = hv.RouteName;
            cmbBoxWayToTravel.Items.Add(hv.WayToTravel);
            cmbBoxWayToTravel.SelectedItem = hv.WayToTravel;
            txtBoxPeopleAmount.Text = $"{peopleAmount}";
            _childrenAmount = hv.ChildrenAmount;
            _participants = Participant.GetParticipantsByHike(hikeId);
            AddInstructorsData(hikeId);
            AddStartFinishBusesData(hikeId);
        }

        private void ChangeInstructorsBtn_Click(object sender, RoutedEventArgs e)
        {
            Instrucors instrucors = new Instrucors(this,_hikeId);
            instrucors.Show();
        }
        private void ChangeTransportBtn_Click(object sender, RoutedEventArgs e)
        {
            Transports transports = new Transports(this,_hikeId);
            transports.Show();
        }

        private void ChangeStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            Hike hike = Hike.GetHikeByID(_hikeId);
            if (ChangeStatusBtn.Content == "Сохранить Изменения")
            {
                if (hike.Status != cmbBoxStatus.SelectedItem.ToString())
                {
                    hike.Status = cmbBoxStatus.SelectedItem.ToString();
                    if (hike.Status == "Завершен")
                    {
                        foreach(var order in hike.OrdersList)
                        {
                            order.Status = Order.GetDescriptionByEnum(Order.EnumStatus.сompleted);
                            Order.Update(order);
                        }
                    }
                    if (hike.Status == "Отменен")
                    {
                        foreach (var order in hike.OrdersList)
                        {
                            order.Status = Order.GetDescriptionByEnum(Order.EnumStatus.canceled);
                            Order.Update(order);
                        }
                    }

                    Hike.Update(hike);
                    MessageBox.Show("Статус успешно изменен!");
                    cmbBoxStatus.Items.Clear();
                    cmbBoxStatus.Items.Add(hike.Status);
                    cmbBoxStatus.SelectedItem = hike.Status;
                    _hikesPage.FillingDataGrid();
                }
                ChangeStatusBtn.Content = "Изменить Статус";
            }
            else
            {
                var oldStatus = cmbBoxStatus.SelectedItem;
                if(oldStatus.ToString() != "Отменен" && oldStatus.ToString() != "Завершен")
                {
                    cmbBoxStatus.Items.Remove(oldStatus);
                    foreach (var i in Hike.GetPossibleStatuses(hike.Status))
                    {
                        cmbBoxStatus.Items.Add(i);
                    }
                    ChangeStatusBtn.Content = "Сохранить Изменения";
                    cmbBoxStatus.SelectedItem = oldStatus.ToString();
                    cmbBoxStatus.IsDropDownOpen = true;
                }   
            }
        }
        private void ChangeDataBtn_Click(object sender, RoutedEventArgs e)
        {
            Hike hike = Hike.GetHikeByID(_hikeId);
            if (ChangeDataBtn.Content == "Сохранить Изменения")
            {
                if (hike.Route.Name != cmbBoxRoute.SelectedItem.ToString() || 
                    hike.OrdersList.FirstOrDefault().WayToTravel != cmbBoxWayToTravel.SelectedItem.ToString())
                {
                    var oldRoute = cmbBoxRoute.SelectedItem;
                    var oldWayToTravel = cmbBoxWayToTravel.SelectedItem;
                    hike.Route = Route.GetRouteByRouteName(oldRoute.ToString());
                    foreach (var order in hike.OrdersList)
                    {
                        if (oldRoute != hike.Route)
                        {
                            order.Route = hike.Route;
                            order.FinishTime = order.StartTime.AddDays(Route.GetDaysAmountByRouteName(hike.Route.Name) - 1);
                        }
                        order.WayToTravel = oldWayToTravel.ToString();
                        Order.Update(order);
                    }
                    Hike.Update(hike);
                    MessageBox.Show("Данные успешно изменены!");
                }
                ChangeDataBtn.Content = "Изменить данные";
                cmbBoxRoute.Items.Clear();
                cmbBoxWayToTravel.Items.Clear();
                AddSelectedHike(_hikeId);
            }
            else
            {
                if(hike.Status != "Отменен" && hike.Status != "Завершен")
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
                    ChangeDataBtn.Content = "Сохранить Изменения";
                    cmbBoxRoute.SelectedItem = oldRoute.ToString();
                    cmbBoxWayToTravel.SelectedItem = oldWayToTravel.ToString();
                }
                else
                {
                    MessageBox.Show("Невозможно изменить данные\n завершенного или отмененного похода");
                }
            }
        }
        public void AddInstructorsData(int hikeId)
        {
            listInstructors.ItemsSource = Instructor.GetFullNameInstructorsByHikeID(hikeId);
        }
        public void AddStartFinishBusesData(int hikeId)
        {
            RouteHike routeHike = RouteHike.GetRouteHikeByHikeID(hikeId);
            var startBus = Transport.GetTransportViewByID(routeHike.StartBus.ID);
            var finishBus = Transport.GetTransportViewByID(routeHike.FinishBus.ID);
            txtBoxCarNumberStart.Text = startBus.CarNumber;
            txtBoxSeatsOfAmountStart.Text = startBus.SeatCount.ToString();
            txtBoxCarNumberFinish.Text = finishBus.CarNumber;
            txtBoxSeatsOfAmountFinish.Text = finishBus.SeatCount.ToString();
        } 
        private void ExcelLink_Click(object sender, RoutedEventArgs e)
        {
            using (var excel = new ExcelHelper())
            {
                try
                {
                    if (excel.Open(filePath: Path.Combine("D:\\Hike", $"{_hikeView.CompanyName}{_hikeView.StartTime}-{_hikeView.FinishTime}.xlsx")))
                    {
                        excel.SetParticipant(_participants,_childrenAmount);
                        excel.SetEquipment(Hike.GetHikeByID(_hikeId));
                        excel.Save();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
           
        }

        
    }
}
