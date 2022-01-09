using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TouristСenterLibrary;

namespace tourCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NewOrder newOrder;
        private Orders orders;
        private Hikes hikes;
       
        public MainWindow()
        {
            ApplicationContext.InitDb();
            InitializeComponent();
            FrameVeiw();
            DefaultPage();
            WindowState = WindowState.Maximized;

        }
        public void FrameVeiw()
        {
            newOrder = new NewOrder();
            orders = new Orders();
            hikes = new Hikes();
         
        }
        public void DefaultPage()
        {
            mainframe.Navigate(newOrder);
            NewOrderBtn.Background = Brushes.Teal;
            NewOrderBtn.Foreground = Brushes.White;
        }

        private void NewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(newOrder);
            NewOrderBtn.Background = Brushes.Teal;
            NewOrderBtn.Foreground = Brushes.White;
            OrderBtn.Background = Brushes.LightGray;
            OrderBtn.Foreground = Brushes.Black;
            HikeBtn.Background = Brushes.LightGray;
            HikeBtn.Foreground = Brushes.Black;
        }
        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(orders);
            orders.FillingDataGrid();
            NewOrderBtn.Background = Brushes.LightGray;
            NewOrderBtn.Foreground = Brushes.Black;
            OrderBtn.Background = Brushes.Teal;
            OrderBtn.Foreground = Brushes.White;
            HikeBtn.Background = Brushes.LightGray; 
            HikeBtn.Foreground = Brushes.Black;
        }
        private void HikeBtn_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(hikes);
            hikes.FillingDataGrid();
            NewOrderBtn.Background = Brushes.LightGray;
            NewOrderBtn.Foreground = Brushes.Black;
            OrderBtn.Background = Brushes.LightGray;
            OrderBtn.Foreground = Brushes.Black;
            HikeBtn.Background = Brushes.Teal;
            HikeBtn.Foreground = Brushes.White;
        }
    }
}
