using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Cryptons.Views.Dialogs;
using Cryptons.Views.MainFrame;
namespace Cryptons
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Functionals f = Functionals.DB();
        public MainWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.UserType != "Admin")
            {
                ButStatistic.Visibility = Visibility.Hidden;
                ButChan.Content = "Контроль знаний";
            }
            User.Content = Properties.Settings.Default.UserName;
            MyFrame.Content = new EmptyBlock();
        }
        public MainWindow(string[] dataUser)
        {
            InitializeComponent();

            Properties.Settings.Default.UserLogin = dataUser[0];
            Properties.Settings.Default.UserName = dataUser[1];
            Properties.Settings.Default.UserFirstname = dataUser[2];
            Properties.Settings.Default.UserGroup = dataUser[3];
            Properties.Settings.Default.UserType = dataUser[5];
            Properties.Settings.Default.UserId = f.GetId(dataUser[0]);

            if (dataUser[5] != "Admin") 
            { 
                ButStatistic.Visibility = Visibility.Hidden;
                ButChan.Content = "Контроль знаний";
            }
            
            User.Content = Properties.Settings.Default.UserName;
            MyFrame.Content = new EmptyBlock();
        }

        private void MoveForm(object sender, MouseButtonEventArgs e)
        {
            try{ DragMove();}
            catch (Exception a){};
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
        private void MinWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void OpenMain(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new CryptoMenu();
        }

        private void OpenTeori(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new TeoriFrame();
        }

        private void OpenTest(object sender, RoutedEventArgs e)
        {
            if(Properties.Settings.Default.UserType!="Admin") 
                MyFrame.Content = new TestFrame();
            else MyFrame.Content = new AdminFrame();
           
        }

        private void OpenHelp(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new HelpFrame();
        }

        private void OpenInfo(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new StatisticsFrame();
        }

        private void OpenForm(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new EmptyBlock();
        }

        private void OpenUser(object sender, RoutedEventArgs e)
        {
            MyFrame.Content = new UserSettings();
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            Autorization form = new Autorization();
            this.Close();
            form.ShowDialog();
           
        }
    }
}
