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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectForYP.pages
{
    //static public class log
    //{
    //    static public string log1 { get; set; }
    //}
    /// <summary>
    /// Interaction logic for PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {

        string lot;
        string pas;
        string seconpas;
        string Phone;
        string f;
        string i;
        string o;

        public PageReg()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            lot = Login.Text;
            pas = Pass.Text;
            seconpas = RepPass.Text;
            Phone = Phon.Text;
            f = familia.Text;
            i = Name.Text;
            o = otchestvo.Text;
            if (pas == seconpas)
            {
                User user = new User()
                {
                    login = lot,
                    passsword = seconpas,
                    typeId = 4,
                    F = f,
                    I = i,
                    O = o,
                    phone = Convert.ToInt64(Phone)
                };
                OdbConnectionHelper.entObj.User.Add(user);
                OdbConnectionHelper.entObj.SaveChanges();
                OdbConnectionHelper.entObj.SaveChangesAsync();
                //FrameApp.frmObj.Navigate(new PageDopInfor());
                MessageBox.Show("Пользователь создан", "Уведомление!",
    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Пароль не совпадает", "Предупреждение!", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Pass_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
