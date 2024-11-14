using ProjectForYP.ClassHelper;
using ProjectForYP.DatabaseHelper;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProjectForYP.pages
{
    /// <summary>
    /// Interaction logic for PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {

        string surname;
        string name;
        string middlename;
        string description;
        string model;
        string proizvodil;
        string techtype;
        string colortech;
        string statusc;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public PageMain()
        {
            InitializeComponent();
            GridList.ItemsSource = OdbConnectionHelper.entObj.Request.Where(x => x.id_requestStatys == 3).ToList();
            allrequest.ItemsSource = OdbConnectionHelper.entObj.Request.ToList();
            GridList1.ItemsSource = OdbConnectionHelper.entObj.Request.Where(x => x.id_requestStatys == 2).ToList();

            SetTimer();
            SetTimer1();
        }

        private void SetTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private async void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            GridList.ItemsSource = OdbConnectionHelper.entObj.Request.Where(x => x.id_requestStatys == 3).ToList();
            GridList1.ItemsSource = OdbConnectionHelper.entObj.Request.Where(x => x.id_requestStatys == 2).ToList();

            donerequest.Text = $"Количество выполненых: {Convert.ToString(OdbConnectionHelper.entObj.Request.Where(x => x.id_requestStatys == 2).Count())}";
            workrequest.Text = $"Количество в работе: {Convert.ToString(OdbConnectionHelper.entObj.Request.Where(x => x.id_requestStatys == 1).Count())}";
            newrequest.Text = $"Количество новых: {Convert.ToString(OdbConnectionHelper.entObj.Request.Where(x => x.id_requestStatys == 3).Count())}";

        }

        private void SetTimer1()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick1);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        private async void dispatcherTimer_Tick1(object sender, EventArgs e)
        {
            allrequest.ItemsSource = OdbConnectionHelper.entObj.Request.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageIzmenitmaster((sender as Button).DataContext as Request));
        }

        private void Createe_Click(object sender, RoutedEventArgs e)
        {

            //System.DateTime date1 = System.DateTime.Now;
            //System.DateTime date2 = new System.DateTime(2023, 11, 14);
            //System.TimeSpan timeSpan = date1.Subtract(date2);
            //MessageBox.Show(Convert.ToString((date2 - date1).TotalDays));

            Request request = (Request)(sender as Button).DataContext;
            MessageBox.Show($"Количество дней: {Convert.ToString(Math.Round(((DateTime)request.completionDate - (DateTime)request.startDate).TotalDays))}\n Используемые детали: {request.repairParts}", "Отчет"
                , MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}