using System.Collections.Generic;
using System.Windows;
using TouristСenterLibrary.Entity;

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
                InstructorGroup instructorGroup = InstructorGroup.GetInstructorGroupByHikeID(_hikeId);
                instructorGroup.InstructorsList.RemoveAll(i=> instructorGroup.Hike.ID ==_hikeId);
                foreach (var instructorView in _selectedInstructors)
                {                 
                    Instructor instructor = Instructor.GetInstructorByID(instructorView.ID);
                    instructorGroup.InstructorsList.Add(instructor);
                }
                InstructorGroup.Update(instructorGroup);
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
