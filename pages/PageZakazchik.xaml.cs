using ProjectForYP.ClassHelper;
using ProjectForYP.DatabaseHelper;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ProjectForYP.pages
{
    /// <summary>
    /// Interaction logic for PageZakazchik.xaml
    /// </summary>
    public partial class PageZakazchik : Page
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
        int idclient;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public PageZakazchik(User user)
        {
            InitializeComponent();

            TextBoxName.Text = user.I;
            texboxMiddleName.Text = user.O;
            textBoxsurName.Text = user.F;
            textBoxPhone.Text = Convert.ToString(user.phone);
            idclient = user.UserId;

            dateload();
            SetTimer();

        }

        private void SetTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GridList.ItemsSource = OdbConnectionHelper.entObj.Request.Where(x => x.clientID == idclient).ToList();
        }


        private void dateload()
        {
            cmbTechType.SelectedValuePath = "Id_HomeTechType";
            cmbTechType.DisplayMemberPath = "HomeTechType1";
            cmbTechType.ItemsSource = OdbConnectionHelper.entObj.HomeTechType.ToList();

            //cmbstatus.SelectedValuePath = "Id_RequestStatus";
            //cmbstatus.DisplayMemberPath = "RequestStatuse";
            //cmbstatus.ItemsSource = OdbConnectionHelper.entObj.RequestStatus.ToList();

            //cmbdescription.SelectedValuePath = "Id_ProblemDescryption";
            //cmbdescription.DisplayMemberPath = "ProblemDescryption1";
            //cmbdescription.ItemsSource = OdbConnectionHelper.entObj.ProblemDescryption.ToList();

            cmbColor.SelectedValuePath = "Id_Color";
            cmbColor.DisplayMemberPath = "Color1";
            cmbColor.ItemsSource = OdbConnectionHelper.entObj.Color.ToList();

            GridList.ItemsSource = OdbConnectionHelper.entObj.Request.Where(x => x.clientID == idclient).ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
            && (!textBoxPhone.Text.Contains(".")
            && textBoxPhone.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void textBoxPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            surname = textBoxsurName.Text;
            name = TextBoxName.Text;
            middlename = texboxMiddleName.Text;
            description = Convert.ToString(cmbdescription.Text);
            model = textBoxTechModel.Text;
            proizvodil = textBoxTecproizvoditel.Text;
            techtype = Convert.ToString(cmbTechType.SelectedValue);
            colortech = Convert.ToString(cmbColor.SelectedValue);
            Int64 phone = Convert.ToInt64(textBoxPhone.Text);

            //ProblemDescryption problemDescryption = new ProblemDescryption()
            //{
            //    ProblemDescryption1 = description
            //};

            Request request = new Request()
            {
                startDate = DateTime.Now,
                Id_homeTechType = Convert.ToInt32(techtype),
                TechModelManufaacturer = proizvodil,
                TechModelName = model,
                Id_Color = Convert.ToInt32(colortech),
                id_requestStatys = 3,
                problemDescryption = description ,
                completionDate = null,
                clientID = idclient
            };

            var resulte = MessageBox.Show("Оставить заявку?", "Уведомление",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (resulte == MessageBoxResult.Yes)
            {
                MessageBox.Show("Заявка оставлена", "Уведомление",
                MessageBoxButton.OK, MessageBoxImage.Information);
                OdbConnectionHelper.entObj.Request.Add(request);
                OdbConnectionHelper.entObj.SaveChanges();
            }
            else
            {
                MessageBox.Show("Заявка отменена", "Уведомление", MessageBoxButton.OK , MessageBoxImage.Stop);
            }

        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            //textBoxsurName.Clear();
            //texboxMiddleName.Clear();
            //TextBoxName.Clear();
            //textBoxPhone.Clear();
            cmbColor.SelectedItem = null;
            //cmbstatus.SelectedItem = null;
            cmbTechType.SelectedItem = null;
            textBoxTecproizvoditel.Clear();
            textBoxTechModel.Clear();
            cmbdescription.Clear();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageIzmenit((sender as Button).DataContext as Request));
        }
    }
}