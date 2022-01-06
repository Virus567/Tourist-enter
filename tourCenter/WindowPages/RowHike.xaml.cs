using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TouristСenterLibrary.Entity;
using ExcelLibrary;
using TouristСenterLibrary;


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
        public RowHike()
        {
            InitializeComponent();
            
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
                        excel.Save();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
           
        }

        
    }
}
