using Cryptons.Views.Dialogs;
using MaterialDesignThemes.Wpf;
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
    public partial class UserSettings : Page
    {
        Functionals f = Functionals.DB();
        public UserSettings()
        {
            InitializeComponent();

            //UserAvatar.Source = new BitmapImage(new Uri(Properties.Settings.Default.UserAvatar));

            NameTextBox.Text = Properties.Settings.Default.UserName;

            FirstnameTextBox.Text = Properties.Settings.Default.UserFirstname;

            LoginTextBox.Text = Properties.Settings.Default.UserLogin;

            GroupBox.Text = Properties.Settings.Default.UserGroup;

            if (Properties.Settings.Default.UserType != "Student")
                GroupBox.Visibility = Visibility.Hidden;
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = GetHash(PasswordBox.Password);
            string name = NameTextBox.Text;
            string firstname = FirstnameTextBox.Text;
            string goup = GroupBox.Text;

            if (f.GetCount($"select * from [User] where login='{login}'")==0)
            {
                if (login.Length > 0)
                    f.UpdateUser("login", login, Properties.Settings.Default.UserId);
            }
            else if(login != Properties.Settings.Default.UserLogin)
                new WarningFrame("Логин не был изменен, так как пользователь под таким ником уже существует!").ShowDialog();


            if (password.Length >= 6) f.UpdateUser("password", password, Properties.Settings.Default.UserId);
            else if(password.Length!=0) new WarningFrame("Пароль должен состоять не меннее чем из 6 символов!").ShowDialog();


            if (name.Length > 1) f.UpdateUser("username", name, Properties.Settings.Default.UserId);
            else new WarningFrame("Введите полное имя!").ShowDialog();

            if (firstname.Length > 1) f.UpdateUser("firstname", firstname, Properties.Settings.Default.UserId);
            else new WarningFrame("Введите фамилию!").ShowDialog();

            if (goup.Length > 4) f.UpdateUser("groupes", goup, Properties.Settings.Default.UserId);


        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}
