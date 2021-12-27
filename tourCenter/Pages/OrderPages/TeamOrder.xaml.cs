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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TouristСenterLibrary.Entity;
using TouristСenterLibrary;
using ExcelLibrary;
using System.IO;
using System.Text.RegularExpressions;

namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для TeamApp.xaml
    /// </summary>
    public partial class TeamOrder : Page
    {
        private object[,] _newParticipantsObj;
        private List<Participant> newPartisipants = new List<Participant>();
        public TeamOrder()
        {
            InitializeComponent();
            GetRouteName();
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

            if (StartDate.Text != "" && CmBoxRoutes.Text != "")
            {
                int days = int.Parse(StartDate.Text.Substring(0, 2));
                string monthAndYear = StartDate.Text.Substring(2, 8);
                FinishDate.Text = (days + Route.GetDaysAmountByRouteName(CmBoxRoutes.Text) - 1).ToString() + monthAndYear;
            }
        }
        private void CmBoxWayToTravel_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxWayToTravel.Text == "Способ передвижения") CmBoxWayToTravel.Text = "";

        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xlsx";
            dlg.Filter = "Text documents (.xlsx)|*.xlsx";
            Nullable<bool> result = dlg.ShowDialog();

            
            if (result == true)
            {             
                string filename = dlg.FileName;
                txtBoxFileName.Text = filename;
                txtBoxFileName.FontSize = 12;

                using (var excel = new ExcelHelper())
                {
                    try
                    {
                        if (excel.OpenNewExcel(filename))
                        {
                            _newParticipantsObj = excel.GetParticipants();
                        }

                        for (int i = 1; i <= _newParticipantsObj.GetLength(0); i++)
                        { 
                            
                            Participant participant = new Participant()
                            {
                                Surname = _newParticipantsObj[i, 1].ToString(),
                                Name = _newParticipantsObj[i, 2].ToString(),
                                Middlename = _newParticipantsObj[i, 3].ToString(),
                                ClientTelefonNumber = _newParticipantsObj[i, 4].ToString()
                            };
                            newPartisipants.Add(participant);
                        }

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

            }
        }

        private void numberPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            if (numberPhone.Text.Length == 0)
            {
                numberPhone.Text = "+7";
                numberPhone.SelectionStart = numberPhone.Text.Length;
            }

        }

        private void numberPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string t = numberPhone.Text;
            if (t.Length == 0)
            {
                numberPhone.SelectionStart = numberPhone.Text.Length;
            }
            if (t.Length >= 12)
            {
                e.Handled = true;
            }
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }
        private void numberPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        public bool IsCorrectData()
        {
            return txtBoxNameOfCompany.Text != "" &&
                   txtBoxFullName.Text != "" &&
                   numberPhone.Text != "" &&
                   peopleAmount.Value != 0 &&
                   CmBoxRoutes.Text != "" &&
                   CmBoxWayToTravel.Text != "" &&
                   StartDate.Text != "" &&
                   FinishDate.Text != "";
        }

        private void StartDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if(StartDate.Text!="" && CmBoxRoutes.Text != "")
            {
                int days = int.Parse(StartDate.Text.Substring(0, 2));
                string monthAndYear = StartDate.Text.Substring(2, 8);
                FinishDate.Text = (days + Route.GetDaysAmountByRouteName(CmBoxRoutes.Text) - 1).ToString() + monthAndYear;
            }           
        }

        private string[] GetSplitFullName(string fullName)
        {
            fullName = Regex.Replace(fullName, "[ ]+", " ");
            return  fullName.Split(' ');

        }

        private string GetStringFoodlFeatures()
        {
            string str;
            if ((bool)CheckMeat.IsChecked)
            {
                str = "Есть Вегетарианцы\n";
            }
            else
            {
                str = "Вегетарианцев нет\n";
            }
            if ((bool)CheckSugar.IsChecked)
            {
                str += "Есть Диабетики\n";
            }
            else
            {
                str += "Диабетиков нет\n";
            }
            str += txtBoxFood.Text;
            return str;
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (IsCorrectData())
            {
                try
                {
                    var fullName = GetSplitFullName(txtBoxFullName.Text);
                    
                    Client client = new Client()
                    {
                        NameOfCompany = txtBoxNameOfCompany.Text,
                        Surname = fullName[0],
                        Name = fullName[1],
                        Middlename = fullName[2],
                        ClientTelefonNumber = numberPhone.Text,
                        PeopleAmount = Convert.ToInt32(peopleAmount.Value),
                        ChildrenAmount = Convert.ToInt32(childrenAmount.Value)
                    };
               
                    foreach(Participant p in newPartisipants)
                    {
                        p.Client = client;
                        ContextManager.db.Participant.Add(p);
                    }

                    Order order = new Order()
                    {
                        ApplicationType = ApplicationType.GetTeamType(),
                        Route = Route.GetRouteByRouteName(CmBoxRoutes.Text),
                        Employee = Employee.GetEmployeeById(1),
                        Client = client,
                        WayToTravel = CmBoxWayToTravel.Text,
                        FoodlFeatures = GetStringFoodlFeatures(),
                        EquipmentFeatures = txtBoxEquipment.Text,
                        StartTime = (DateTime)StartDate.SelectedDate,
                        FinishTime = (DateTime)FinishDate.SelectedDate,
                        HermeticBagAmount = Convert.ToInt32(persHermeticBagAmount.Value),
                        IndividualTentAmount = Convert.ToInt32(persTentAmount.Value),                     
                        Status = "Активна"
                    };
                    ContextManager.db.Client.Add(client);
                    ContextManager.db.Order.Add(order);
                    ContextManager.db.SaveChanges();
                    MessageBox.Show("Заявка добавлена!");
                }
                catch(Exception ex) { MessageBox.Show("Ошибка добавления! " + ex.Message); }               
            }
            else
            {
                MessageBox.Show("Заполните поля корректно");
            }
        }
    }
}
