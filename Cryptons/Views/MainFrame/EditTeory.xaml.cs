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

namespace Cryptons.Views.MainFrame
{
    /// <summary>
    /// Логика взаимодействия для EditTeory.xaml
    /// </summary>
    public partial class EditTeory : Window
    {
        Functionals f = Functionals.DB();
        public EditTeory()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string img = (Images.Text.Length > 0) ? Images.Text : "0";
            List<string> data = new List<string>();
            data.Add(Headers.Text);
            data.Add(Body.Text);
            data.Add(img);
            f.AddInfo(data);
            Headers.Text = "";
            Body.Text = "";
            MessageBox.Show("Материал успешно сохранен!");
        }

        private void MinWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {

        }
    }
}
