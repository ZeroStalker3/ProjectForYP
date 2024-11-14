using ProjectForYP.ClassHelper;
using ProjectForYP.DatabaseHelper;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectForYP.pages
{
    /// <summary>
    /// Interaction logic for PageIzmenit.xaml
    /// </summary>
    public partial class PageIzmenit : Page
    {

        string viewtech;
        string proizvodil;
        string model;
        string color;
        string opisanie;
        int reqId;

        public PageIzmenit(Request request)
        {
            InitializeComponent();

            reqId = request.requestID;
            viewtech = Convert.ToString(request.HomeTechType.HomeTechType1);
            proizvodil = Convert.ToString(request.TechModelManufaacturer);
            model = Convert.ToString(request.TechModelName);
            color = Convert.ToString(request.Color.Color1);
            opisanie = Convert.ToString(request.problemDescryption);

            cmbTechType.SelectedIndex = Convert.ToInt32(request.Id_homeTechType);
            textBoxTecproizvoditel.Text = proizvodil;
            textBoxTechModel.Text = model;
            cmbColor.SelectedIndex = Convert.ToInt32(request.Id_Color);
            cmbdescription.Text = (string)request.problemDescryption;

            dateload();

            foreach (var item in cmbTechType.Items)
            {

                cmbTechType.SelectedItem = item;
                if (viewtech == (string)cmbTechType.Text)
                {
                    break;
                }

            }

            foreach (var item in cmbColor.Items)
            {

                cmbColor.SelectedItem = item;
                if (color == (string)cmbColor.Text)
                {
                    break;
                }

            }
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
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var resulte = MessageBox.Show("Изменить заявку?", "Уведомление",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            var requestt = OdbConnectionHelper.entObj.Request.Find(reqId);
            requestt.Id_homeTechType = cmbTechType.SelectedIndex + 1;
            requestt.TechModelManufaacturer = textBoxTecproizvoditel.Text;
            requestt.TechModelName = textBoxTechModel.Text;
            requestt.Id_Color = cmbColor.SelectedIndex + 1;
            requestt.problemDescryption = cmbdescription.Text;

            if (resulte == MessageBoxResult.Yes)
            {
                MessageBox.Show("Заявка изменена", "Уведомление",
                MessageBoxButton.OK, MessageBoxImage.Information);
                OdbConnectionHelper.entObj.SaveChangesAsync();
            }
            else
            {
                MessageBox.Show("Изменения отменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}
