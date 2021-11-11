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

namespace Cryptons.Views.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для InfoFrame.xaml
    /// </summary>
    public partial class InfoFrame : Window
    {
        public InfoFrame(string mess)
        {
            InitializeComponent();
            Mess.Text = mess;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
