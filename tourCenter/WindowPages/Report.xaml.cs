using ExcelLibrary;
using System;
using System.Collections.Generic;
using System.IO;
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
using TouristСenterLibrary.Entity;

namespace tourCenter.WindowPages
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Hike.HikeView> hikes = Hike.GetView();
            if (startDate.Text != "" && finishDate.Text != "")
            {
                DateTime startdt = startDate.SelectedDate.Value;
                DateTime finishdt = finishDate.SelectedDate.Value;
                hikes = hikes.Where(l => DateTime.Parse(l.StartTime) >= startdt && DateTime.Parse(l.StartTime) <= finishdt).ToList();

                using (var excel = new ExcelHelper())
                {
                    try
                    {
                        if (excel.Open(filePath: Path.Combine("D:\\Hike", $"Report.xlsx")))
                        {
                            excel.SetHikes(hikes);
                            excel.Save();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
