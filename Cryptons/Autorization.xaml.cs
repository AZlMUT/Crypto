using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Cryptons.Views.Dialogs;
using Cryptons.Views.MainFrame;
namespace Cryptons
{


    public partial class Autorization : Window
    {
        LoginUser login = new LoginUser();
        RegestrationUser rege = new RegestrationUser();
        bool flagRegen = false; Functionals f = Functionals.DB();

        public Autorization(){
            Properties.Settings.Default["MyDatabaseConnectionString"] = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() + @"\MyDatabase.mdf;Integrated Security=True;Connect Timeout=30";
            InitializeComponent();
            DataFrame.Content = login;
            Functionals f = Functionals.DB();
            f.update();
        }
        private void MoveForm(object sender, MouseButtonEventArgs e){try{DragMove();} catch (Exception a){}}
        private void Button_Click(object sender, RoutedEventArgs e) {this.Close();}



        private void Logined(object sender, RoutedEventArgs e) //Нажатие кнопки Вход или Регистрация
        {
            if (flagRegen)//Если открыто окно регистрации
            {
                string[] data = rege.getData();
                if(data.Length > 0) //Если все поля заполнены коректно
                {
                    f.Add(data[0], data[1], data[2], data[3], data[4]);
                    login.Clear();
                    DataFrame.Content = login;
                    Regen.Visibility = Visibility.Visible;
                    Done.Margin = new Thickness(Margin.Left, 178, Margin.Right, Margin.Bottom);
                    Done.Content = "Войти"; flagRegen = false;
                }
            }
            else //Если открыто окно входа
            {
                string[] data = login.getData();
                if (data.Length>0)
                {
                    if(loginned(data[0], data[1]).Length > 0)
                    {
                        MainWindow wind = new MainWindow(loginned(data[0], data[1]));
                        this.Close();
                        wind.ShowDialog();
                    }
                }
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Regen.Visibility = Visibility.Hidden;
            rege.Clear();
            DataFrame.Content = rege;
            Done.Margin = new Thickness(Margin.Left, 300, Margin.Right, Margin.Bottom);
            Done.Content = "Создать аккаунт"; flagRegen = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            login = new LoginUser();
            DataFrame.Content = login;
            Regen.Visibility = Visibility.Visible;
            Done.Margin = new Thickness(Margin.Left, 178, Margin.Right, Margin.Bottom);
            Done.Content = "Войти"; flagRegen = false;
        }



        string[] loginned(string login, string password)
        {
            int id = checkUser(login, password);
            if (id != -1)
            {
                return getDataUser(id);
            }
            else
            {
                InfoFrame mess = new InfoFrame("Логин или пароль введены не верно");
                mess.ShowDialog();
                return new string[] { };
            }
        }
        int checkUser(string login, string password)
        {
            if (f.getPassword(login) == password)
                return f.getIdUser(login);
            return -1;
        }
        string[] getDataUser(int userID)
        {
            string userL, userN, userF, UserG, userAvatar, userT;

            userL = f.GetString("[User]","login","id_user",userID);
            userN = f.GetString("[User]", "username", "id_user", userID);
            userF = f.GetString("[User]", "firstname", "id_user", userID);
            UserG = f.GetString("[User]", "groupes", "id_user", userID);
            userAvatar = f.GetString("[User]", "avatar", "id_user", userID);
            userT = f.GetString("[User]", "usertype", "id_user", userID);

            return new string[] { userL, userN, userF, UserG, userAvatar, userT };
        }

        private void MinWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
