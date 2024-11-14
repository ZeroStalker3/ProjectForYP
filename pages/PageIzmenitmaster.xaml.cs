using ProjectForYP.ClassHelper;
using ProjectForYP.DatabaseHelper;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectForYP.pages
{
    /// <summary>
    /// Interaction logic for PageIzmenitmaster.xaml
    /// </summary>
    public partial class PageIzmenitmaster : Page
    {
        string viewtech;
        string proizvodil;
        string model;
        string color;
        string opisanie;
        int reqId;

        public PageIzmenitmaster(Request request)
        {
            InitializeComponent();

            dateload();

            reqId = request.requestID;
            viewtech = Convert.ToString(request.HomeTechType.HomeTechType1);
            proizvodil = Convert.ToString(request.TechModelManufaacturer);
            model = Convert.ToString(request.TechModelName);
            color = Convert.ToString(request.Color.Color1);
            opisanie = Convert.ToString(request.ProblemDescryption.ProblemDescryption1);

            int indexColor = 0;

            foreach (var item in cmbColor.Items)
            {

                cmbColor.SelectedItem = item;
                if (color == (string)cmbColor.Text)
                {
                    break;
                }

            }


            cmbColor.SelectedItem = color;

            cmbTechType.SelectedIndex = Convert.ToInt32(request.Id_homeTechType) - 1;
            textBoxTecproizvoditel.Text = proizvodil;
            textBoxTechModel.Text = model;
            //MessageBox.Show(Convert.ToString(cmbColor.Items.Equals(color)));
            cmbdescription.SelectedIndex = Convert.ToInt32(request.id_problemDescryption);
            cmbstatus.SelectedIndex = Convert.ToInt32(request.id_requestStatys);
            txtrepairParts.Text = request.repairParts;

        }

        private void dateload()
        {
            cmbTechType.SelectedValuePath = "Id_HomeTechType";
            cmbTechType.DisplayMemberPath = "HomeTechType1";
            cmbTechType.ItemsSource = OdbConnectionHelper.entObj.HomeTechType.ToList();

            cmbstatus.SelectedValuePath = "Id_RequestStatus";
            cmbstatus.DisplayMemberPath = "RequestStatuse";
            cmbstatus.ItemsSource = OdbConnectionHelper.entObj.RequestStatus.ToList();

            cmbdescription.SelectedValuePath = "Id_ProblemDescryption";
            cmbdescription.DisplayMemberPath = "ProblemDescryption1";
            cmbdescription.ItemsSource = OdbConnectionHelper.entObj.ProblemDescryption.ToList();

            cmbColor.SelectedValuePath = "Id_Color";
            cmbColor.DisplayMemberPath = "Color1";
            cmbColor.ItemsSource = OdbConnectionHelper.entObj.Color.ToList();

            cmbempl.SelectedValuePath = "UserId";
            cmbempl.DisplayMemberPath = "F";
            cmbempl.ItemsSource = OdbConnectionHelper.entObj.User.Where(x => x.typeId == 2).ToList();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var resulte = MessageBox.Show("Изменить заявку?", "Уведомление",
    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            var requestt = OdbConnectionHelper.entObj.Request.Find(reqId);
            requestt.Id_homeTechType = cmbTechType.SelectedIndex;
            requestt.TechModelManufaacturer = textBoxTecproizvoditel.Text;
            requestt.TechModelName = textBoxTechModel.Text;
            requestt.Id_Color = cmbColor.SelectedIndex;
            requestt.id_problemDescryption = cmbdescription.SelectedIndex;
            requestt.id_requestStatys = cmbstatus.SelectedIndex;
            requestt.repairParts = txtrepairParts.Text;

            if (resulte == MessageBoxResult.Yes)
            {
                MessageBox.Show("Заявка изменена", "Уведомление",
                MessageBoxButton.OK, MessageBoxImage.Information);
                if (requestt.id_requestStatys == 2)
                { requestt.completionDate = DateTime.Now; OdbConnectionHelper.entObj.SaveChangesAsync(); }
                else { OdbConnectionHelper.entObj.SaveChangesAsync(); }
            }
            else
            {
                MessageBox.Show("Изменения отменены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
