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
using System.Linq;

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для Instrucors.xaml
    /// </summary>
    public partial class Instrucors : Window
    {
        private List<Instructor.InstructorView> selectedInstructors = new List<Instructor.InstructorView>();
        private List<Instructor.InstructorView> hikeInstructors = new List<Instructor.InstructorView>();
        public Instrucors(int hikeId)
        {
            hikeInstructors = Instructor.GetHikeInstructor(hikeId);
            InitializeComponent();
            GetViewInstrucors();

        }
        public void GetViewInstrucors()
        {           
            List<Instructor.InstructorView> list = Instructor.GetInstructors();

            foreach (Instructor.InstructorView l in list)
            {
                foreach(Instructor.InstructorView h in hikeInstructors)
                    if (l.Surname == h.Surname && l.Name == h.Name && l.Middlename == h.Middlename)
                    {
                        l.InHike = true;
                        selectedInstructors.Add(l);
                    }

            }
            InstrucorsList.ItemsSource = list;
        }


        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            //привязка похода к инструктору(Добавление записей в InstructorGroup)
            this.Close();
        }


        private void checkInstructor_Checked(object sender, RoutedEventArgs e)
        {
            Instructor.InstructorView selectedInstructor = (Instructor.InstructorView)InstrucorsList.SelectedValue;
            if (selectedInstructor != null && !selectedInstructors.Contains(selectedInstructor))
            {
                selectedInstructors.Add(selectedInstructor);
            }           
        }

        private void checkInstructor_Unchecked(object sender, RoutedEventArgs e)
        {
            Instructor.InstructorView selectedInstructor = (Instructor.InstructorView)InstrucorsList.SelectedValue;
            if (selectedInstructor != null && selectedInstructors.Contains(selectedInstructor))
            {
                selectedInstructors.Remove(selectedInstructor);
            }
        }
    }    
}
