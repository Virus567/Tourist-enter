using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TouristСenterLibrary.Entity;
using ExcelLibrary;
using System.Text.RegularExpressions;

namespace tourCenter
{

    public partial class FamilyOrder : Page
    {
        private List<Participant> _newPartisipants = new List<Participant>();
        public FamilyOrder()
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
                DateTime startDate = Convert.ToDateTime(StartDate.Text);
                DateTime finishDate = startDate.AddDays(Route.GetDaysAmountByRouteName(CmBoxRoutes.Text) - 1);
                FinishDate.Text = finishDate.ToString();
            }
        }
        private void CmBoxWayToTravel_LostMouseCapture(object sender, MouseEventArgs e)
        {
            if (CmBoxWayToTravel.Text == "Способ передвижения") CmBoxWayToTravel.Text = "";

        }

        private void NumberPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NumberPhone.Text.Length == 0)
            {
                NumberPhone.Text = "+7";
                NumberPhone.SelectionStart = NumberPhone.Text.Length;
            }

        }

        private void CheckSpaceDown_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void CheckCorrectAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string t = textBox.Text;
            if (t.Length >= 2)
            {
                e.Handled = true;
            }
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        public bool IsCorrectData()
        {
            bool isCorrectPeopleAmount = true;
            if(childrenAmount.Text != "")
            {
                isCorrectPeopleAmount = Convert.ToInt32(peopleAmount.Text) >= Convert.ToInt32(childrenAmount.Text);
            }

            return txtBoxFullName.Text != "" &&
                   NumberPhone.Text != "" &&
                   peopleAmount.Text != "" &&
                   CmBoxRoutes.Text != "" &&
                   CmBoxWayToTravel.Text != "" &&
                   StartDate.Text != "" &&
                   FinishDate.Text != "" &&
                   peopleAmount.Text != "0" &&
                   (DateTime)StartDate.SelectedDate <= (DateTime)FinishDate.SelectedDate &&
                   isCorrectPeopleAmount;
        }

        private string GetStringFoodlFeatures()
        {
            string foodlFeatures;
            if ((bool)CheckMeat.IsChecked)
            {
                foodlFeatures = "Есть Вегетарианцы\n";
            }
            else
            {
                foodlFeatures = "Вегетарианцев нет\n";
            }
            if ((bool)CheckSugar.IsChecked)
            {
                foodlFeatures += "Есть Диабетики\n";
            }
            else
            {
                foodlFeatures += "Диабетиков нет\n";
            }
            foodlFeatures += txtBoxFood.Text;
            return foodlFeatures;
        }

        private string[] GetSplitFullName(string fullName)
        {
            fullName = Regex.Replace(fullName, "[ ]+", " ");
            return fullName.Split(' ');
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
                            object[,] newParticipantsObj = excel.GetParticipants();

                            for (int i = 1; i <= newParticipantsObj.GetLength(0); i++)
                            {
                                string Surname = newParticipantsObj[i, 1].ToString();
                                string Name = newParticipantsObj[i, 2].ToString();
                                string Middlename = newParticipantsObj[i, 3].ToString();
                                string ClientTelefonNumber = newParticipantsObj[i, 4].ToString();

                                User user;
                                if (User.IsHasUser(ClientTelefonNumber))
                                {
                                    user = User.GetUserByPhoneNumber(ClientTelefonNumber);
                                }
                                else
                                {
                                    if (Middlename != null)
                                    {
                                        user = new User(null, Surname, Name, Middlename, ClientTelefonNumber);
                                    }
                                    else
                                    {
                                        user = new User(null, Surname, Name, ClientTelefonNumber);
                                    }                                   
                                }

                                Participant participant = new Participant(user, true, true);
                                _newPartisipants.Add(participant);


                            }
                        }
                        
                    }
                    catch (Exception ex) { MessageBox.Show("Некорректный файл!\n" + ex.Message); }
                }
            }
        }
        private void numberPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string t = NumberPhone.Text;
            if (t.Length == 0)
            {
                NumberPhone.SelectionStart = NumberPhone.Text.Length; 
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

        public void CorrectNullFields()
        {
            if (peopleAmount.Text == "") peopleAmount.Text = "0";
            if (childrenAmount.Text == "") childrenAmount.Text = "0";
            if (persHermeticBagAmount.Text == "") persHermeticBagAmount.Text = "0";
            if (persTentAmount.Text == "") persTentAmount.Text = "0";
        }

        private void numberPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void StartDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (StartDate.Text != "" && CmBoxRoutes.Text != "")
            {
                DateTime startDate = Convert.ToDateTime(StartDate.Text);
                DateTime finishDate = startDate.AddDays(Route.GetDaysAmountByRouteName(CmBoxRoutes.Text) - 1);
                FinishDate.Text = finishDate.ToString();
            }
        }

        public void ClearFields()
        {
            txtBoxFullName.Text = "";
            NumberPhone.Text = "";
            peopleAmount.Text = "";
            childrenAmount.Text = "";
            CheckMeat.IsChecked = false;
            CheckSugar.IsChecked = false;
            CmBoxRoutes.Text = "";
            CmBoxWayToTravel.Text = "";
            StartDate.Text = "";
            FinishDate.Text = "";
            txtBoxFood.Text = "";
            txtBoxEquipment.Text = "";
            persTentAmount.Text = "";
            persHermeticBagAmount.Text = "";
            txtBoxFileName.Text = "";
            txtBoxFileName.FontSize = 16;
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {

            if (IsCorrectData())
            {
                try
                {                   
                    var fullName = GetSplitFullName(txtBoxFullName.Text.Trim());
                    CorrectNullFields();
                    int peopleCount = Convert.ToInt32(peopleAmount.Text);
                    int childrenCount = Convert.ToInt32(childrenAmount.Text);
                    User user;
                    if (User.IsHasUser(NumberPhone.Text))
                    {
                        user = User.GetUserByPhoneNumber(NumberPhone.Text);
                    }
                    else
                    {
                        if (fullName.Length > 2)
                        {
                            user = new User(null, fullName[0], fullName[1], fullName[2], NumberPhone.Text);
                        }
                        else
                        {
                            user = new User(null, fullName[0], fullName[1], NumberPhone.Text);
                        }
                    }
                    

                    TouristGroup group = new TouristGroup(user, peopleCount, childrenCount);

                    if (_newPartisipants.Count != 0)
                    {
                        if (_newPartisipants.Count == group.PeopleAmount)
                        {
                            foreach (Participant p in _newPartisipants)
                            {
                                group.ParticipantsList.Add(p);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Количество людей не совпадает!\n Заявка будет добавелна без участников!");
                        }
                    }

                    Order order = new Order()
                    {
                        ApplicationType = ApplicationType.GetFamilyType(),
                        Route = Route.GetRouteByRouteName(CmBoxRoutes.Text),
                        Employee = Employee.GetEmployeeById(1),
                        TouristGroup = group,
                        WayToTravel = CmBoxWayToTravel.Text,
                        FoodlFeatures = GetStringFoodlFeatures(),
                        EquipmentFeatures = txtBoxEquipment.Text,
                        StartTime = (DateTime)StartDate.SelectedDate,
                        FinishTime = (DateTime)FinishDate.SelectedDate,
                        HermeticBagAmount = Convert.ToInt32(persHermeticBagAmount.Text),
                        IndividualTentAmount = Convert.ToInt32(persTentAmount.Text),
                        Status = "Активна"
                    };
                    TouristСenterLibrary.Entity.TouristGroup.Add(group);                  
                    Order.Add(order);
                    MessageBox.Show("Заявка добавлена!");
                    ClearFields();
                }
                catch (Exception ex) { MessageBox.Show("Ошибка добавления!\n" + ex.Message); }
            }
            else
            {
                MessageBox.Show("Заполните поля корректно");
            }
        }

    }
}