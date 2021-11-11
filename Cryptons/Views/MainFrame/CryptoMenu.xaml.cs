using Cryptons.Views.Crypts;
using Cryptons.Views.Dialogs;
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

namespace Cryptons.Views.MainFrame
{
    /// <summary>
    /// Логика взаимодействия для CryptoMenu.xaml
    /// </summary>
    public partial class CryptoMenu : Page
    {
        public CryptoMenu()
        {
            InitializeComponent();
            ContentView.Content = new EmptyBlock();
        }

        private void OpenForm(object sender, RoutedEventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();
            switch (Convert.ToInt32(tag))
            {
                case 1: ContentView.Content = new Crypt1(); break;
                case 2: ContentView.Content = new Crypt2(); break;
                case 3: ContentView.Content = new Crypt3(); break;
                case 4: ContentView.Content = new Crypt4(); break;
                case 5: ContentView.Content = new Crypt5(); break;
                case 6: ContentView.Content = new Crypt6(); break;
                case 7: ContentView.Content = new Crypt7(); break;
                case 8: ContentView.Content = new Crypt8(); break;
                case 9: ContentView.Content = new SettingForm(); break;
                case 0: ContentView.Content = null; break;
            }
        }

        private void Rendered(object sender, EventArgs e)
        {
            ContentView.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
    }
}
