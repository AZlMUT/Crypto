using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для AdminFrame.xaml
    /// </summary>
    public partial class AdminFrame : Page
    {
        int select_true = 1;
        Functionals f = Functionals.DB();

        public AdminFrame()
        {
            InitializeComponent();
            loadQuestions();
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        void ClearQuest()
        {
            Quest.Text = "";
            Ansver1.Text = "";
            Ansver2.Text = "";
            Ansver3.Text = "";
            Ansver4.Text = "";
            ListQuest.SelectedItem = 1;
        }
        void Select(string tag)
        {
            if ((string)Ab1.Tag != tag) Ab1.IsChecked = false;
            else if (Ab1.IsChecked == false) Ab1.IsChecked = true;

            if ((string)Ab2.Tag != tag) Ab2.IsChecked = false;
            else if (Ab2.IsChecked == false) Ab2.IsChecked = true;

            if ((string)Ab3.Tag != tag) Ab3.IsChecked = false;
            else if (Ab3.IsChecked == false) Ab3.IsChecked = true;

            if ((string)Ab4.Tag != tag) Ab4.IsChecked = false;
            else if (Ab4.IsChecked == false) Ab4.IsChecked = true;

            select_true = Convert.ToInt32(tag);
            ListQuest.SelectedIndex = Convert.ToInt32(tag) - 1;
        }
        private void SelectItem(object sender, SelectionChangedEventArgs e)
        {
            Select((ListQuest.SelectedIndex+1).ToString());
        }
        private void SelectTrue(object sender, RoutedEventArgs e)
        {
            ToggleButton ob = (ToggleButton)sender;
            Select((string)ob.Tag);
        }

        private void SaveQuestions(object sender, RoutedEventArgs e)
        {
            List<string> li = new List<string>();
            li.Add(Quest.Text);
            li.Add(Ansver1.Text); li.Add(Ansver2.Text);
            li.Add(Ansver3.Text); li.Add(Ansver4.Text);
            if( li[0].Length > 10 && li[1].Length > 1 && li[2].Length > 1)
            {
                if (li[4].Length <= 2) li.RemoveAt(4);
                if (li[3].Length <= 2) li.RemoveAt(3);
                li.Add((select_true-1).ToString());
                if (f.AddQuestion(li)) ClearQuest();
                else MessageBox.Show("Произошла непредвиденная ошибка при сохранении вопроса!");
            }
            else
            {
                MessageBox.Show("Вопрос должен состоянть не менее чем из 10 символов. Также должно быть минимум два ответа!");
            }
            loadQuestions();
        }

        private void OpenFolderDB(object sender, RoutedEventArgs e)
        {
            OpenFileDialog folder = new OpenFileDialog
            {
                Filter = ".mdf|*.mdf",
                Title = "Выберите файл базы данных",
                FileName = "MyDatabase.mdf"
            };
            if ((bool)folder.ShowDialog())
                FolderDB.Text = folder.FileName;
        }

        private void SaveFolderDb(object sender, RoutedEventArgs e)
        {
            string con = FolderDB.Text;
            if (con.Length > 4 && con.IndexOf(".mdf") >= 0)
            {
                string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""" + con + @""";Integrated Security=True;Connect Timeout=30";
                Properties.Settings.Default["MyDatabaseConnectionString"] = connectionStr;
                Properties.Settings.Default.Save(); f.update(); loadQuestions();
                MessageBox.Show("Изменения успешно внесены!");
            }
            else MessageBox.Show("Путь к файлу указан не корректно!");
        }

        private void DeleteQuestions(object sender, RoutedEventArgs e)
        {
            
            if (MessageBox.Show("Вы уверены, что хотите удалить выбраные вопросы?", "Удалить", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                List<int> idDelQuest = new List<int>();
                for (int i = 0; i < Listing.Items.Count; i++)
                {
                    ListBoxItem ob = (ListBoxItem)Listing.Items[i];
                    StackPanel ob0 = (StackPanel)ob.Content;
                    CheckBox ob1 = (CheckBox)ob0.Children[0];
                    if ((bool)ob1.IsChecked)
                        idDelQuest.Add(Convert.ToInt32(ob1.Tag.ToString()));
                }
                for (int i = 0; i < idDelQuest.Count; i++)
                {
                    f.Delete($"Delete from [Question] where id_quest={idDelQuest[i]}");
                }
                loadQuestions();
            }
            
            
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            string uN = UserN.Text; string uF = UserF.Text;
            string uL = UserL.Text; string uP = GetHash(UserP.Password);
            if (f.getIdUser(uL) < 0) f.AddAdmin(uL, uP, uN, uF);
            else MessageBox.Show("При регистрации пользователя произашла ошибка");
        }

        void loadQuestions()
        {
            Listing.Items.Clear();
            List<List<string>> us = f.getListQuest();
            foreach (List<string> i in us)
            {
                ListBoxItem ob = new ListBoxItem();
                ob.Content = createQuest(i[1], i[0]);
                Listing.Items.Add(ob);
            }
        }

        StackPanel createQuest(string i,string id)
        {
            StackPanel stack = new StackPanel();stack.Orientation = Orientation.Horizontal;
            CheckBox checkBox = new CheckBox();checkBox.Margin = new Thickness(10);checkBox.Tag = id;
            TextBlock text = new TextBlock();text.Width = 360;text.VerticalAlignment = VerticalAlignment.Center;
            text.TextWrapping = TextWrapping.Wrap; text.Height = 23;
            text.FontSize = 16; text.Text = i; stack.Children.Add(checkBox); stack.Children.Add(text);
            return stack;
        }

        private void SelectAllQuest(object sender, RoutedEventArgs e)
        {
            bool checking = (bool)SelAll.IsChecked;
            for (int i=0;i< Listing.Items.Count; i++)
            {
                ListBoxItem ob = (ListBoxItem)Listing.Items[i];
                StackPanel ob0 = (StackPanel)ob.Content;
                CheckBox ob1 =  (CheckBox)ob0.Children[0];
                ob1.IsChecked = checking;
            }
        }

        private void OpenEditTeori(object sender, RoutedEventArgs e)
        {
            EditTeory form = new EditTeory();
            form.ShowDialog();
        }
    }

    public class Question
    {
        public CheckBox Check { get; set; }
        public string Quest { get; set; }
    }
}
