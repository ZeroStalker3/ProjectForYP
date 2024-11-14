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
        string st;
        string emp;
        int reqId;
        int status;

        public PageIzmenitmaster(Request request)
        {
            InitializeComponent();

            dateload();

            reqId = request.requestID;
            viewtech = Convert.ToString(request.HomeTechType.HomeTechType1);
            proizvodil = Convert.ToString(request.TechModelManufaacturer);
            model = Convert.ToString(request.TechModelName);
            color = Convert.ToString(request.Color.Color1);
            st = (string)request.RequestStatus.RequestStatuse;
            opisanie = (string)request.problemDescryption;

            status = (int)request.id_requestStatys;

            //var emplo = OdbConnectionHelper.entObj.User.Where(x => x.typeId == 2);
            if (request?.User?.F != null)
            {
                string emp = Convert.ToString(request.User.F);

                if (emp != null)
                {
                    foreach (var item in cmbempl.Items)
                    {
                        cmbempl.SelectedItem = item;
                        if (emp == (string)cmbempl.Text)
                        {
                            break;
                        }
                    }

                }
                else
                {
                    cmbempl.SelectedItem = null;
                    // Или пустая строка, если хотите
                }

            }

            //opisanie = Convert.ToString(request.ProblemDescryption.ProblemDescryption1);

            //int indexColor = 0;

            foreach (var item in cmbColor.Items)
            {
                cmbColor.SelectedItem = item;
                if (color == (string)cmbColor.Text)
                {
                    break;
                }

            }

            foreach (var item in cmbTechType.Items)
            {

                cmbTechType.SelectedItem = item;
                if (viewtech == (string)cmbTechType.Text)
                {
                    break;
                }

            }

            foreach (var item in cmbstatus.Items)
            {

                cmbstatus.SelectedItem = item;
                if (st == (string)cmbstatus.Text)
                {
                    break;
                }

            }


            cmbColor.SelectedItem = color;

            //cmbTechType.SelectedIndex = Convert.ToInt32(request.Id_homeTechType) - 1;
            textBoxTecproizvoditel.Text = proizvodil;
            textBoxTechModel.Text = model;
            //MessageBox.Show(Convert.ToString(cmbColor.Items.Equals(color)));
            //cmbdescription.SelectedIndex = Convert.ToInt32(request.id_problemDescryption);
            //cmbstatus.SelectedIndex = Convert.ToInt32(request.id_requestStatys);
            txtrepairParts.Text = request.repairParts;
            cmbdescription.Text = opisanie;

        }

        private void dateload()
        {
            cmbTechType.SelectedValuePath = "Id_HomeTechType";
            cmbTechType.DisplayMemberPath = "HomeTechType1";
            cmbTechType.ItemsSource = OdbConnectionHelper.entObj.HomeTechType.ToList();

            cmbstatus.SelectedValuePath = "Id_RequestStatus";
            cmbstatus.DisplayMemberPath = "RequestStatuse";
            cmbstatus.ItemsSource = OdbConnectionHelper.entObj.RequestStatus.ToList();

            //cmbdescription.SelectedValuePath = "Id_ProblemDescryption";
            //cmbdescription.DisplayMemberPath = "ProblemDescryption1";
            //cmbdescription.ItemsSource = OdbConnectionHelper.entObj.ProblemDescryption.ToList();

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
            requestt.Id_homeTechType = cmbTechType.SelectedIndex + 1;
            requestt.TechModelManufaacturer = textBoxTecproizvoditel.Text;
            requestt.TechModelName = textBoxTechModel.Text;
            requestt.Id_Color = cmbColor.SelectedIndex + 1;
            requestt.problemDescryption = cmbdescription.Text;
            requestt.id_requestStatys = cmbstatus.SelectedIndex + 1;
            requestt.repairParts = txtrepairParts.Text;
            requestt.masterId = (int)cmbempl.SelectedValue;

            if (resulte == MessageBoxResult.Yes)
            {
                MessageBox.Show("Заявка изменена", "Уведомление",
                MessageBoxButton.OK, MessageBoxImage.Information);
                if (status == 2)
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
