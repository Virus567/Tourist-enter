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
    /// Логика взаимодействия для Instrucors.xaml
    /// </summary>
    public partial class Instrucors : Window
    {
        List<string> selectedInstructors = new List<string>();
        List<string> hikeInstructors = new List<string>();
        public Instrucors()
        {
            InitializeComponent();
            GetViewInstrucors();

        }
        public void GetViewInstrucors()
        {
            
            InstrucorsList.ItemsSource = Instructor.GetViewInstrucors();
        }
        public List<string> SetHikeInstructors(int hikeId)
        {
            hikeInstructors = Instructor.GetHikeInstructor(hikeId);
            return hikeInstructors;
            
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            //привязка похода к инструктору(Добавление записей в InstructorGroup)
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            selectedInstructors.Add(checkBox.Content.ToString());
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var uncheckedBox = (CheckBox)sender;
            if (selectedInstructors.Contains(uncheckedBox.Content.ToString()))
            {
                selectedInstructors.Remove(uncheckedBox.Content.ToString());
            }
        }

        private void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            var check = (CheckBox)sender;
            if (hikeInstructors.Contains(check.Content.ToString()))
            {
                check.IsChecked = true;
            }

        }
    }    
}
