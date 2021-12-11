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


namespace tourCenter
{
    /// <summary>
    /// Логика взаимодействия для NewApplication.xaml
    /// </summary>
    public partial class NewOrder : Page
    {
        private Page teamOrder;
        private Page familyOrder;
        public NewOrder()
        {
            InitializeComponent();
            FrameVeiw();
            DefaultPage();
        }
        public void DefaultPage()
        {
            newAppFrame.Navigate(teamOrder);
            TeamAppBtn.Background = Brushes.Teal;
            TeamAppBtn.Foreground = Brushes.White;
        }

        public void FrameVeiw()
        {
            teamOrder = new TeamOrder();
            familyOrder = new FamilyOrder();
        }
        private void TeamAppBtn_Click(object sender, RoutedEventArgs e)
        {
            newAppFrame.Navigate(teamOrder);
            TeamAppBtn.Background = Brushes.Teal;
            TeamAppBtn.Foreground = Brushes.White;
            FamilyAppBtn.Background = Brushes.LightGray;
            FamilyAppBtn.Foreground = Brushes.Black;
        }

        private void FamilyAppBtn_Click(object sender, RoutedEventArgs e)
        {
            newAppFrame.Navigate(familyOrder);
            TeamAppBtn.Background = Brushes.LightGray;
            TeamAppBtn.Foreground = Brushes.Black;
            FamilyAppBtn.Background = Brushes.Teal;
            FamilyAppBtn.Foreground = Brushes.White;
        }
            
    }
}
