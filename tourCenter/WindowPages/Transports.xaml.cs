using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TouristСenterLibrary.Entity;
using System.Linq;

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для Transports.xaml
    /// </summary>
    public partial class Transports : Window
    {
        private List<Transport.TransportView> _selectedTransport = new List<Transport.TransportView>();
        private List<Transport.TransportView> _hikeTransport = new List<Transport.TransportView>();
        private CheckBox _lastStartCheck;
        private CheckBox _lastFinishCheck;
        private NewHike _newhike;
        private RowHike _rowhike;
        private int _hikeId;
        public Transports(RowHike rowhike,int hikeId)
        {
            _rowhike = rowhike;
            _hikeId = hikeId;
            InitializeComponent();
            GetViewInstrucors(hikeId);

        }
        public Transports(NewHike newHike, List<Transport.TransportView> transports)
        {
            _newhike = newHike;
            _hikeTransport = transports;
            InitializeComponent();
            GetViewInstrucors();
            SaveChangesBtn.Content = "Выбрать Транспорт";

        }
        public void GetViewInstrucors()
        {
            List<Transport.TransportView> list = Transport.GetAllTransport();
            foreach (Transport.TransportView l in list)
            {
                foreach (Transport.TransportView h in _hikeTransport)
                {
                    if (l.CarNumber == h.CarNumber )
                    {
                        l.IsStartBus = h.IsStartBus;
                        l.IsFinishBus = h.IsFinishBus;
                        _selectedTransport.Add(l);
                    }
                }
            }
            TransportList.ItemsSource = list;
        }
        public void GetViewInstrucors(int hikeId)
        {
            List<Transport.TransportView> list = Transport.GetAllTransportWithStartFinishBuses(hikeId);
            _selectedTransport = list.Where(l => l.IsStartBus || l.IsFinishBus).ToList();
            TransportList.ItemsSource = list;
        }


        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveChangesBtn.Content == "Выбрать Транспорт")
            {
                _newhike.SetTransport(_selectedTransport);
                this.Close();
            }
            else
            {
                RouteHike routeHike = RouteHike.GetRouteHikeByHikeID(_hikeId);
                Transport startTransport = new Transport();
                Transport finishTransport = new Transport();
                foreach (var transportView in _selectedTransport)
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
                if (startTransport.CarNumber != null && finishTransport.CarNumber != null)
                {
                   if(!RouteHike.UpdateTransport(routeHike, startTransport.ID, finishTransport.ID))
                    {
                        MessageBox.Show("Ошибка обновления!");
                    }                    
                }
                _rowhike.LoadStartFinishBusesData(_hikeId);
                this.Close();
            }
        }

        private void checkStartBus_Checked(object sender, RoutedEventArgs e)
        {
            Transport.TransportView selectedBus = (Transport.TransportView)TransportList.SelectedValue;
            if (selectedBus != null && !_selectedTransport.Contains(selectedBus))
            {
                selectedBus.IsStartBus = true;
                _selectedTransport.Add(selectedBus);
            }
            else if (_selectedTransport.Contains(selectedBus))
            {
                foreach(var s in _selectedTransport)
                {
                    if (s.CarNumber == selectedBus.CarNumber)
                    {
                        selectedBus.IsStartBus = true;
                        _selectedTransport.Add(s);
                        break;
                    }
                }
            }         
            int selectedStartTransportCount = _selectedTransport.Where(s => s.IsStartBus).Count();
            if (selectedStartTransportCount > 1)
            {
                if (_lastStartCheck != null)
                {
                    _lastStartCheck.IsChecked = false;
                }                
            }
            _lastStartCheck = (CheckBox)sender;

        }
        private void checkFinishBus_Checked(object sender, RoutedEventArgs e)
        {
            Transport.TransportView selectedBus = (Transport.TransportView)TransportList.SelectedValue; 
            if (selectedBus != null && !_selectedTransport.Contains(selectedBus))
            {
                selectedBus.IsFinishBus = true;
                _selectedTransport.Add(selectedBus);
            }
            else if (_selectedTransport.Contains(selectedBus))
            {               
                foreach (var s in _selectedTransport)
                {
                    if (s.CarNumber == selectedBus.CarNumber)
                    {
                        s.IsFinishBus = true;
                        break;
                    }
                }
            }            
            int selectedFinishTransportCount = _selectedTransport.Where(s => s.IsFinishBus).Count();
            if(selectedFinishTransportCount > 1)
            {
                
                if (_lastFinishCheck != null)
                {
                    _lastFinishCheck.IsChecked = false;
                }
            }            
            _lastFinishCheck = (CheckBox)sender;
        }

        private void checkStartBus_Unchecked(object sender, RoutedEventArgs e)
        {
            Transport.TransportView selectedBus = (Transport.TransportView)TransportList.SelectedValue;
            if (selectedBus != null && _selectedTransport.Contains(selectedBus))
            {
                int selectedStartTransportCount = _selectedTransport.Where(s => s.IsStartBus).Count();
                foreach (var s in _selectedTransport)
                {

                    if (s != selectedBus && selectedStartTransportCount>1)
                    {
                        if (s.IsStartBus && s.IsFinishBus)
                        {
                            s.IsStartBus = false;
                            break;
                        }
                        else if (s.IsStartBus)
                        {
                            _selectedTransport.Remove(s);
                            break;
                        }
                    }
                    else if(selectedStartTransportCount == 1)
                    {
                        if (s.IsStartBus && s.IsFinishBus)
                        {
                            s.IsStartBus = false;
                            break;
                        }
                        else if (s.IsStartBus)
                        {
                            _selectedTransport.Remove(s);
                            break;
                        }
                    }
                }

            }
        }
        private void checkFinishBus_Unchecked(object sender, RoutedEventArgs e)
        {
            Transport.TransportView selectedBus = (Transport.TransportView)TransportList.SelectedValue;
            if (selectedBus != null && _selectedTransport.Contains(selectedBus))
            {
                int selectedFinishTransportCount = _selectedTransport.Where(s => s.IsFinishBus).Count();
                foreach (var s in _selectedTransport)
                {
                    if (s != selectedBus && selectedFinishTransportCount>1)
                    {
                        if (s.IsFinishBus && s.IsStartBus)
                        {
                            s.IsFinishBus = false;
                            break;
                        }
                        else if (s.IsFinishBus)
                        {
                            _selectedTransport.Remove(s);
                            break;
                        }
                    }
                    else if(selectedFinishTransportCount == 1)
                    {
                        if (s.IsFinishBus && s.IsStartBus)
                        {
                            s.IsFinishBus = false;
                            break;
                        }
                        else if (s.IsFinishBus)
                        {
                            _selectedTransport.Remove(s);
                            break;
                        }
                    }
                }
            }
        }

    }
}

