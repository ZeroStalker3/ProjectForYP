using ProjectForYP.ClassHelper;
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
    /// Interaction logic for PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
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

        }
    }
}
