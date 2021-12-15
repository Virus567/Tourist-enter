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
    /// Логика взаимодействия для RowHike.xaml
    /// </summary>
    public partial class RowHike : Window
    {
        private int hikeId;
        public RowHike()
        {
            InitializeComponent();
            
        }
        public void AddSelectedHike(int hikeID)
        {
            Hike.HikeViewAll hikeVeiw = Hike.GetViewAll(hikeID)[0];
            
            AddHikeData(hikeVeiw, hikeID);
           
        }

        public void AddHikeData(Hike.HikeViewAll hv,int hikeID)
        {
            hikeId = hikeID;
            int PeopleAmount = Hike.GetPeopleAmountOfHike(hikeID);
            winRowHike.Title = $" {hv.CompanyName} {hv.StartTime}  — {hv.FinishTime}";
            cmbBoxStatus.Items.Add(hv.Status);
            cmbBoxStatus.SelectedItem = hv.Status;
            cmbBoxRoute.Items.Add(hv.RouteName);
            cmbBoxRoute.SelectedItem = hv.RouteName;
            cmbBoxWayToTravel.Items.Add(hv.WayToTravel);
            cmbBoxWayToTravel.SelectedItem = hv.WayToTravel;
            txtBoxPeopleAmount.Text = $"{PeopleAmount}";
            List<Participant> tmp = Participant.GetParticipantHike(hikeID);
            listInstructors.ItemsSource = Instructor.GetViewHikeInstructor(hikeID);
            List<string> participants = Participant.GetAllName(tmp);
            foreach (string str in participants)
            {
                //rowHikeParticipant.Content += $"{str}\n";
            }
        }

        private void changeInstructorsBtn_Click(object sender, RoutedEventArgs e)
        {
            Instrucors instrucors = new Instrucors(hikeId);
            instrucors.Show();
        }
    }
}
