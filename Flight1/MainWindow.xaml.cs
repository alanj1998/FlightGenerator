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
using System.Windows.Threading;

namespace Flight1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Flight> Arrivals = new List<Flight>();
        static List<Flight> Departures = new List<Flight>();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            GenerateFlights();
            UpdateTime();

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
            string[] timeSplit = lblTime.Content.ToString().Split(':');
            DateTime time = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, int.Parse(timeSplit[0]), int.Parse(timeSplit[1]), int.Parse(timeSplit[2]));
            listBoxDepartures.ItemsSource = null;

            foreach (Flight f in Departures.ToArray())
            {
                if(f.Time < time)
                {
                    Departures.Remove(f);
                    lblCurrentFlight.Content = f.ToString() + " has departed.";
                }
                listBoxDepartures.ItemsSource = Departures;
            }
        }

        private void GenerateFlights()
        {
            Flight[] flights = new Flight[10];
            Departures.Clear();
            Arrivals.Clear();
            for(int i = 0; i < flights.Count(); i++)
            {
                flights[i] = new Flight();
                if(flights[i].Time > DateTime.Now)
                {
                    Departures.Add(flights[i]);
                }
                else
                {
                    Arrivals.Add(flights[i]);
                }
            }
            listBoxArrivals.ItemsSource = null;
            listBoxDepartures.ItemsSource = null;
            listBoxArrivals.ItemsSource = Arrivals;
            listBoxDepartures.ItemsSource = Departures;
        }

        private void btnPopulate_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            GenerateFlights();
            timer.Start();
        }

        private void UpdateTime()
        {
            lblTime.Content = "";
            if(DateTime.Now.Hour < 10)
            {
                lblTime.Content += "0" + DateTime.Now.Hour + ":";
            }
            else
            {
                lblTime.Content += DateTime.Now.Hour.ToString() + ":";
            }

            if(DateTime.Now.Minute < 10)
            {
                lblTime.Content += "0" + DateTime.Now.Minute + ":";
            }
            else
            {
                lblTime.Content += DateTime.Now.Minute.ToString() + ":";
            }

            if(DateTime.Now.Second < 10)
            {
                lblTime.Content += "0" + DateTime.Now.Second;
            }
            else
            {
                lblTime.Content += DateTime.Now.Second.ToString();
            }
        }
    }
}
