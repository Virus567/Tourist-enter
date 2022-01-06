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
        private List<Instructor.InstructorView> _selectedInstructors = new List<Instructor.InstructorView>();
        private List<Instructor.InstructorView> _hikeInstructors = new List<Instructor.InstructorView>();
        private NewHike _newhike;
        private int _hikeId;
        private RowHike _rowhike;
        public Instrucors(RowHike rowhike, int hikeId)
        {
            _rowhike = rowhike;
            _hikeId = hikeId;
            _hikeInstructors = Instructor.GetInstructorViewsByHikeID(hikeId);
            InitializeComponent();
            GetViewInstrucors();

        }
        public Instrucors(NewHike newHike, List<Instructor.InstructorView> instructors)
        {
            _newhike = newHike;
            _hikeInstructors = instructors;
            InitializeComponent();
            GetViewInstrucors();
            SaveChangesBtn.Content = "Выбрать Инструкторов";

        }
        public void GetViewInstrucors()
        {           
            List<Instructor.InstructorView> list = Instructor.GetInstructors();

            foreach (Instructor.InstructorView l in list)
            {
                foreach(Instructor.InstructorView h in _hikeInstructors)
                    if (l.Surname == h.Surname && l.Name == h.Name && l.Middlename == h.Middlename)
                    {
                        l.InHike = true;
                        _selectedInstructors.Add(l);
                    }

            }
            InstrucorsList.ItemsSource = list;
        }


        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            if(SaveChangesBtn.Content == "Выбрать Инструкторов")
            {
                _newhike.SetInstructors(_selectedInstructors);
                this.Close();
            }
            else
            {
                List<InstructorGroup> instructorsGroup = InstructorGroup.GetInstructorGroupByHikeID(_hikeId);
                
                foreach (var ig in instructorsGroup)
                {
                    InstructorGroup.Remove(ig);//удались пожалуйста!
                }
                foreach (var instructorView in _selectedInstructors)
                {
                    List<Instructor.InstructorView> hikeInstructors = Instructor.GetInstructorViewsByHikeID(_hikeId);
                   
                    Instructor instructor = Instructor.GetInstructorByID(instructorView.ID);
                    InstructorGroup instructorGroup = new InstructorGroup();
                    instructorGroup.Hike = Hike.GetHikeByID(_hikeId);
                    instructorGroup.Instructor = instructor;
                    InstructorGroup.Add(instructorGroup);

                    
                }
                _rowhike.AddInstructorsData(_hikeId);
                this.Close();
            }
            
        }


        private void checkInstructor_Checked(object sender, RoutedEventArgs e)
        {
            Instructor.InstructorView selectedInstructor = (Instructor.InstructorView)InstrucorsList.SelectedValue;
            if (selectedInstructor != null && !_selectedInstructors.Contains(selectedInstructor))
            {
                _selectedInstructors.Add(selectedInstructor);
            }           
        }

        private void checkInstructor_Unchecked(object sender, RoutedEventArgs e)
        {
            Instructor.InstructorView selectedInstructor = (Instructor.InstructorView)InstrucorsList.SelectedValue;
            if (selectedInstructor != null && _selectedInstructors.Contains(selectedInstructor))
            {
                _selectedInstructors.Remove(selectedInstructor);
            }
        }
    }    
}
