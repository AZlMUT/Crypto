using Cryptons.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для LoginUser.xaml
    /// </summary>
    public partial class LoginUser : Page
    {
        public LoginUser()
        {
            InitializeComponent();
        }

        public string[] getData()
        {
            sinhronizaed();
            if (NameTextBox.Text.Length == 0 || PasswordBox.Password.Length == 0)
            {
                WarningFrame mess = new WarningFrame("Заполните все поля!\n");
                mess.ShowDialog();
                return new string[] {};
            }
            else
            {
                string[] data = new string[] { NameTextBox.Text, GetHash(PasswordBox.Password) };
                return data;
            }
            
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public void Clear()
        {
            NameTextBox.Text = "";
            PasswordBox.Password = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                PasswordBox.Visibility = Visibility.Hidden;
                ShowP.Visibility = Visibility.Visible;
                ShowP.Text = PasswordBox.Password;
            }
            else
            {
                PasswordBox.Visibility = Visibility.Visible;
                ShowP.Visibility = Visibility.Hidden;
                PasswordBox.Password = ShowP.Text;
            }
        }

        void sinhronizaed()
        {
            if (PasswordBox.Visibility != Visibility.Visible)
            {
                PasswordBox.Password = ShowP.Text;
            }
        }
    }
}
