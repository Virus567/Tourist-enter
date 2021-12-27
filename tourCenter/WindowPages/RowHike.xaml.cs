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
        public RowHike()
        {
            InitializeComponent();
            
        }
        public void AddSelectedHike(int hikeID)
        {
            Hike.HikeViewAll hikeVeiw = Hike.GetViewAllByID(hikeID)[0];
            
            AddHikeData(hikeVeiw, hikeID);
           
        }

        public void AddHikeData(Hike.HikeViewAll hv,int hikeID)
        {
            _hikeView = hv;
            _hikeId = hikeID;
            int peopleAmount = Hike.GetPeopleAmountOfHike(hikeID);
            winRowHike.Title = $" {hv.CompanyName} {hv.StartTime}  — {hv.FinishTime}";
            cmbBoxStatus.Items.Add(hv.Status);
            cmbBoxStatus.SelectedItem = hv.Status;
            cmbBoxRoute.Items.Add(hv.RouteName);
            cmbBoxRoute.SelectedItem = hv.RouteName;
            cmbBoxWayToTravel.Items.Add(hv.WayToTravel);
            cmbBoxWayToTravel.SelectedItem = hv.WayToTravel;
            txtBoxPeopleAmount.Text = $"{peopleAmount}";
            _participants = Participant.GetParticipantsByHike(hikeID);
            listInstructors.ItemsSource = Instructor.GetViewHikeInstructor(hikeID);
        }

        private void changeInstructorsBtn_Click(object sender, RoutedEventArgs e)
        {
            Instrucors instrucors = new Instrucors(_hikeId);
            instrucors.Show();
        }

        private void ExcelLink_Click(object sender, RoutedEventArgs e)
        {
            using (var excel = new ExcelHelper())
            {
                try
                {
                    if (excel.Open(filePath: Path.Combine("D:\\Hike", $"{_hikeView.CompanyName}{_hikeView.StartTime}-{_hikeView.FinishTime}.xlsx")))
                    {
                        excel.SetParticipant(_participants);
                        excel.Save();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
           
        }
    }
}
