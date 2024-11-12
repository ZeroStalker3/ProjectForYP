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
    /// <summary>
    /// Interaction logic for PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageReg());
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password == "")
            {
                MessageBox.Show("Пароль не введен", "Ошибка"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var userobj = OdbConnectionHelper.entObj.User.FirstOrDefault(x => 
                x.login == LoginTxt.Text && x.passsword == PassBox.Password);

                if (userobj != null)
                {
                    MessageBox.Show("Что-то не так", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else 
                {
                    if (userobj.typeId == 1 || userobj.typeId == 2
                    || userobj.typeId == 3)
                    {
                        MessageBox.Show("Авторизация усешна", "Уведомление"
                        , MessageBoxButton.OK, MessageBoxImage.Information);
                        FrameApp.frmObj.Navigate(new PageMain());
                    }
                    else if (userobj.typeId == 4)
                    {
                        MessageBox.Show("Авторизация успешна", "Уведомление"
                            ,MessageBoxButton.OK, MessageBoxImage.Information);
                        FrameApp.frmObj.Navigate(new PageZakazchik());
                    }
                }
            }
        }

        private void PassBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
