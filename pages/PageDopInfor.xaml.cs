using ProjectForYP.DatabaseHelper;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectForYP.pages
{
    /// <summary>
    /// Логика взаимодействия для PageDopInfor.xaml
    /// </summary>
    public partial class PageDopInfor : Page
    {
        string f;
        string i;
        string o;
        Int64 ph;
        int useri;
        string p;

        public PageDopInfor()
        {
            InitializeComponent();

            //////var lot = log.log1;
            ////var useri = OdbConnectionHelper.entObj.User.Find(lot);
            //loq.Text = useri.login;
            //p = useri.passsword;
        }

        private void Nex_Click(object sender, RoutedEventArgs e)
        {
            f = familia.Text;
            i = Name.Text;
            o = otchestvo.Text;
            ph = Convert.ToInt64(Phon.Text);

            var userid = OdbConnectionHelper.entObj.User.Find(useri);
            userid.F = f;
            userid.I = i;
            userid.O = o;
            userid.phone = ph;
            OdbConnectionHelper.entObj.SaveChangesAsync();
            OdbConnectionHelper.entObj.SaveChanges();
            MessageBox.Show($"Данные добавлены: Фамилия: {f},\n Имя: {i},\n Отчество: {o},\n Телефон: {ph},\n  Логин: {loq.Text},\n  Пароль: {p}");
        }
    }
}
