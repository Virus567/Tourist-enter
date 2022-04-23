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
    /// Логика взаимодействия для NewHike.xaml
    /// </summary>
    public partial class NewHike : Window
    {
        private List<Order.OrderView> _selectedOrders = new List<Order.OrderView>();
        private List<Instructor.InstructorView> _selectedInstructors = new List<Instructor.InstructorView>();
        private List<Transport.TransportView> _selectedTransport = new List<Transport.TransportView>();
        private Hikes _hikes;
        public NewHike(Hikes hikes)
        {
            _hikes = hikes;
            InitializeComponent();
            FillingDataGrid();
            GetRouteName();
            VisibleTxtBoxes(0);
        }
        private void FillingDataGrid()
        {
            List<Order.OrderView> list = Order.GetView();
            if (selectDate.Text != "")
            {
                DateTime dt = selectDate.SelectedDate.Value;
                list = list.Where(l => l.DateTime == dt.ToString("d")).ToList();
            }
            if (CmBoxRoutes.Text != "")
            {
                list = list.Where(l => l.RouteName == CmBoxRoutes.Text).ToList();
            }
            if (CmBoxWayToTravel.Text != "")
            {
                list = list.Where(l => l.WayToTravel == CmBoxWayToTravel.Text).ToList();
            }
            dgOrders.ItemsSource = list.Where(e => e.Status == "Активна");
        }
        
        public void VisibleTxtBoxes(int value)
        {
            txtBoxStartDate.Opacity = value;
            txtBoxFinishDate.Opacity = value;
            txtBoxRoute.Opacity = value;
            txtBoxWayToTravel.Opacity = value;
            label_.Opacity = value;
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

        private void addOrderBtn_Click(object sender, RoutedEventArgs e) //заявки могут быть объеденены только если все заявки семейные
        {
            try
            {
                Order.OrderView selectedOrder = (Order.OrderView)dgOrders.SelectedValue;
                if(selectedOrder != null)
                {
                    if (selectedOrder.IsListParticipants)
                    {
                        if (txtBoxStartDate.Text == "")
                            GetOrderData(selectedOrder);
                        if (!dgOrdersForHike.Items.Contains(selectedOrder) && IsСorrectOrder(selectedOrder) && !IsTeamOrder(selectedOrder))
                        {
                            dgOrdersForHike.Items.Add(selectedOrder);
                            _selectedOrders.Add(selectedOrder);
                            int peopleAmount = int.Parse(txtBoxPeopleAmount.Text);
                            peopleAmount += selectedOrder.PeopleAmount;
                            txtBoxPeopleAmount.Text = peopleAmount.ToString();
                            int childrenAmount = int.Parse(txtBoxChildrenAmount.Text);
                            childrenAmount += selectedOrder.ChildrenAmount;
                            txtBoxChildrenAmount.Text = childrenAmount.ToString();

                        }
                        else if (IsTeamOrder(selectedOrder) && txtBoxPeopleAmount.Text == "0")
                        {
                            dgOrdersForHike.Items.Add(selectedOrder);
                            _selectedOrders.Add(selectedOrder);
                            txtBoxPeopleAmount.Text = selectedOrder.PeopleAmount.ToString();
                            addOrderBtn.IsEnabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("У выбранной заявки не добавлены участники");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали заявку!");
                }       
            }
            catch
            {
                MessageBox.Show("Вы не выбрали заявку!");
            }
        }

        private bool IsTeamOrder(Order.OrderView order)
        {
            return order.ApplicationTypeName == "Корпоративная";
        }

        private bool IsСorrectOrder(Order.OrderView order)
        {
            Order.OrderViewAll o = Order.GetViewAllByID(order.ID);
            return txtBoxStartDate.Text == o.StartTime &&
                   txtBoxRoute.Text == o.RouteName &&
                   txtBoxWayToTravel.Text == o.WayToTravel;
        }

        private void GetOrderData(Order.OrderView tmpOrder)
        {
            Order.OrderViewAll order = Order.GetViewAllByID(tmpOrder.ID);
            txtBoxStartDate.Text = order.StartTime;
            txtBoxFinishDate.Text = order.FinishTime;
            txtBoxRoute.Text = order.RouteName;
            txtBoxWayToTravel.Text = order.WayToTravel;
            VisibleTxtBoxes(100);
        }

        private void ClearOrderData()
        {
            txtBoxStartDate.Text = "";
            txtBoxFinishDate.Text = "";
            txtBoxRoute.Text = "";
            txtBoxWayToTravel.Text = "";
            VisibleTxtBoxes(0);
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

        public void SetInstructors(List<Instructor.InstructorView> instructors)
        {
            _selectedInstructors = instructors;
        }
        public void SetTransport(List<Transport.TransportView> transports)
        {
            _selectedTransport = transports;
        }

        private void SelectInstructorsBtn_Click(object sender, RoutedEventArgs e)
        {
            Instrucors instrucors = new Instrucors(this, _selectedInstructors);
            instrucors.Show();
        }
        private void SelectTransportBtn_Click(object sender, RoutedEventArgs e)
        {
            Transports transports = new Transports(this, _selectedTransport);
            transports.Show();
        }

        private void CommitHikeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedOrders.Count != 0 && _selectedInstructors.Count!=0 && _selectedTransport.Count!=0)
            {
                try
                {
                    Route route = Route.GetRouteByRouteName(_selectedOrders.FirstOrDefault().RouteName);
                    Hike hike = new Hike(route, Hike.GetDescriptionByEnum(Hike.EnumStatus.inAssembly));                    
                    Hike.Add(hike);

                    foreach (var orderView in _selectedOrders)
                    {
                        Order order = Order.GetOrderByID(orderView.ID);
                        order.Hike = hike;
                        order.Status = Order.GetDescriptionByEnum(Order.EnumStatus.inAssembly);
                        Order.Update(order);
                    }
                    Hike.SetEquipmentForHike(hike);
                    Hike.Update(hike);
                    InstructorGroup instructorGroup = new InstructorGroup();
                    instructorGroup.Hike = hike;
                    foreach (var instructorView in _selectedInstructors)
                    {
                        Instructor instructor = Instructor.GetInstructorByID(instructorView.ID);
                        instructorGroup.InstructorsList.Add(instructor);
                    }        
                    InstructorGroup.Add(instructorGroup);
                    Transport startTransport = new Transport();
                    Transport finishTransport = new Transport();
                    foreach(var transportView in _selectedTransport)
                    {
                        if (transportView.IsStartBus)
                        {
                            startTransport = Transport.GetTransportByID(transportView.ID);
                        }
                        if (transportView.IsFinishBus)
                        {
                            finishTransport = Transport.GetTransportByID(transportView.ID);
                        }
                    }
                    if(startTransport.CarNumber!=null && finishTransport.CarNumber != null)
                    {
                        RouteHike routeHike = new RouteHike(route, startTransport, finishTransport, hike);
                        if (!RouteHike.Add(routeHike))
                        {
                            MessageBox.Show("Ошибка добавления!");
                        };
                    }

                    MessageBox.Show("Поход успешно добавлен!");
                    _selectedOrders.Clear();
                    dgOrdersForHike.Items.Clear();
                    ClearOrderData();
                    _hikes.FillingDataGrid();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка добавления!\n", ex.Message);
                }
                
            }
            else if(_selectedOrders.Count == 0)
            {
                MessageBox.Show("Оформить поход невозможно!\n Вы не выбрали ни одной заявки");
            }
            else if(_selectedInstructors.Count == 0)
            {
                MessageBox.Show("Выберите инструкторов для похода!");
            }
            else
            {
                MessageBox.Show("Выберите транспорт для похода!");
            }
        }
    }    
}
