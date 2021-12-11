using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page newOrder;
        private Page orders;
        private Page hikes;
       
        public MainWindow()
        {
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
            NewOrderBtn.Background = Brushes.LightGray;
            NewOrderBtn.Foreground = Brushes.Black;
            OrderBtn.Background = Brushes.LightGray;
            OrderBtn.Foreground = Brushes.Black;
            HikeBtn.Background = Brushes.Teal;
            HikeBtn.Foreground = Brushes.White;
        }
    }
}
