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
    /// Логика взаимодействия для RegestrationUser.xaml
    /// </summary>
    public partial class RegestrationUser : Page
    {
        Functionals f = Functionals.DB();
        public RegestrationUser()
        {
            InitializeComponent();
        }

        void ShowError()
        {
            if(UserL.Text.Length==0)
            {
                new WarningFrame("Введите логин!").ShowDialog();
                return;
            }

            if (UserP.Password.Length < 6)
            {
                new WarningFrame("Пароль должен состоять не менее чем из 6 симовлов!").ShowDialog();
                return;
            }

            if (UserN.Text.Length == 0)
            {
                new WarningFrame("Введите ваше имя!").ShowDialog();
                return;
            }

            if (UserF.Text.Length == 0)
            {
                new WarningFrame("Введите вашу фамилию!").ShowDialog();
                return;
            }

            if (UserF.Text.Length == 0)
            {
                new WarningFrame("Выберите группу в которой вы учитесь!").ShowDialog();
                return;
            }

        }
        public string[] getData()
        {
            
            string[] data = new string[] 
            { 
                UserL.Text,
                GetHash(UserP.Password),
                UserN.Text,
                UserF.Text,
                UserG.Text
            };
            if (CorectLogin(UserL.Text)) return data;
            else { ShowError(); return new string[] { }; }
        }
        public void Clear()
        {
            UserL.Text = "";
            UserP.Password = "";
            UserN.Text = "";
            UserF.Text = "";
            UserG.Text = "";
        }
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        bool CorectLogin(string login)
        {
            sinhronizaed();
            if(UserP.Password != UserP1.Password)
            {
                new WarningFrame("Пароли не совпадают").ShowDialog();
                return false;
            }
            if (UserL.Text.Length < 3 ||
                UserP.Password.Length < 6 ||
                UserN.Text.Length < 2 ||
                UserF.Text.Length < 2 ||
                UserG.Text.Length < 4) return false;
            if (login.Length > 0)
            {
                if (f.GetCount($"select * from [User] where login = '{login}'") == 0) return true; 
            }
            new WarningFrame("Пользователь под таким логином уже существует. Пожалуйста введите другой логин!").ShowDialog();
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(UserP.Visibility == Visibility.Visible)
            {
                UserP.Visibility = Visibility.Hidden;
                ShowP.Visibility = Visibility.Visible;
                ShowP.Text = UserP.Password;
            }
            else
            {
                UserP.Visibility = Visibility.Visible;
                ShowP.Visibility = Visibility.Hidden;
                UserP.Password = ShowP.Text;
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (UserP1.Visibility == Visibility.Visible)
            {
                UserP1.Visibility = Visibility.Hidden;
                ShowP1.Visibility = Visibility.Visible;
                ShowP1.Text = UserP1.Password;
            }
            else
            {
                UserP1.Visibility = Visibility.Visible;
                ShowP1.Visibility = Visibility.Hidden;
                UserP1.Password = ShowP1.Text;
            }
        }

        public void sinhronizaed()
        {
            if (UserP.Visibility != Visibility.Visible)
            {
                UserP.Password = ShowP.Text;
            }

            if (UserP1.Visibility != Visibility.Visible)
            {
                UserP1.Password = ShowP1.Text;
            }
        }
    }
}
