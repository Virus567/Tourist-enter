using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



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
