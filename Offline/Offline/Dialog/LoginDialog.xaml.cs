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
using System.Windows.Shapes;

namespace Offline.Dialog
{
    /// <summary>
    /// LoginDialog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginDialog : Window
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
          
            loading.Visibility = Visibility.Visible;
       
            loading.Visibility = Visibility.Hidden;
            this.DialogResult = true;
        }
        private void PSWFind_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Register_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window win = new SignUpDialog();
            win.ShowDialog();
        }
    }
}
