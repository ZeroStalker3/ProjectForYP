using ProjectForYP.ClassHelper;
using ProjectForYP.DatabaseHelper;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

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


        public PageMain()
        {
            InitializeComponent();

            dateload();
        }

        private void dateload()
        {
            cmbTechType.SelectedValuePath = "Id_HomeTechType";
            cmbTechType.DisplayMemberPath = "HomeTechType1";
            cmbTechType.ItemsSource = OdbConnectionHelper.entObj.HomeTechType.ToList();

            cmbstatus.SelectedValuePath = "Id_RequestStatus";
            cmbstatus.DisplayMemberPath = "RequestStatuse";
            cmbstatus.ItemsSource = OdbConnectionHelper.entObj.RequestStatus.ToList();

            cmbColor.SelectedValuePath = "Id_Color";
            cmbColor.DisplayMemberPath = "Color1";
            cmbColor.ItemsSource = OdbConnectionHelper.entObj.Color.ToList();
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
            name = textBoxsurName.Text;
            middlename = textBoxsurName.Text;
            description = textBoxdescription.Text;
            model = textBoxTechModel.Text;
            proizvodil = textBoxTecproizvoditel.Text;
            techtype = Convert.ToString(cmbTechType.SelectedValue);
            colortech = Convert.ToString(cmbColor.SelectedValue);
            statusc = Convert.ToString(cmbstatus.SelectedValue);
            int phone = Convert.ToInt32(textBoxPhone.Text);

            User user = new User
            {
                F = surname,
                I = name,
                O = middlename,
                phone = phone,

            };
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            textBoxsurName.Clear();
            texboxMiddleName.Clear();
            TextBoxName.Clear();
            textBoxPhone.Clear();
            cmbColor.SelectedItem = null;
            cmbstatus.SelectedItem = null;
            cmbTechType.SelectedItem = null;
            textBoxTecproizvoditel.Clear();
            textBoxTechModel.Clear();
            textBoxdescription.Clear();
        }
    }
}