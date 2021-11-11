using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptons.Views.MainFrame
{
    /// <summary>
    /// Логика взаимодействия для StatisticsFrame.xaml
    /// </summary>
    public partial class StatisticsFrame : Page
    {
        List<User> rating = new List<User>();
        Functionals f = Functionals.DB();
        public StatisticsFrame()
        {
            InitializeComponent();
            string[] s = new[] { "", "", "" };
            loadUser(s);
            dataUser.ItemsSource = rating;
            DataContext = this;

        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }



        void mes(string s) { MessageBox.Show(s); }
        void loadUser(string[] sql)
        {
            List<List<string>> us = f.getRating();
            List<string> labels = new List<string>();
            ChartValues<double> val = new ChartValues<double>();
            foreach (List<string> i in us)
            {
                bool flag1 = false, flag2 = true, flag3 = true;
                if (sql[0] != "")
                {
                    if (i[0].IndexOf(sql[0]) >= 0) flag1 = true;
                    else if (i[1].IndexOf(sql[0]) >= 0) flag1 = true;
                }else flag1 = true;

                if (sql[1] != "")
                    if (i[2].IndexOf(sql[1]) < 0) flag2 = false;

                if (sql[2] != "")
                    if(i[3].IndexOf(sql[2])<0)flag3 = false;
                
                if (flag1 && flag2 && flag3)
                {
                    rating.Add(new User { Name = i[1] + ' ' + i[0], Group = i[2], Rating = i[3] });
                    labels.Add(i[0] + ' ' + i[1]);
                    val.Add(Convert.ToDouble(i[3]));
                }
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "-",
                    Values = val
                }
            };
            Labels = labels.ToArray();
            Formatter = value => value.ToString("N");
        }
        void Update()
        {
            string x1 = Stud.Text, x2 = Grou.Text, x3 = Rat.Text;
            string[] sql = new[] {x1,x2,x3};
            rating.Clear();
            loadUser(sql);
            dataUser.ItemsSource = null;
            dataUser.ItemsSource = rating;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stud.Text = "";
            Grou.Text = "";
            Rat.Text = "";
            Update();
        }

        private void Stud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Grou_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Rat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Stud_KeyUp(object sender, KeyEventArgs e)
        {
            Update();
        }

        private void Rat_KeyUp(object sender, KeyEventArgs e)
        {
            Update();
        }

        private void Rat_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Update();
        }

        private void Grou_Selected(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DelTwo(object sender, RoutedEventArgs e)
        {
            Functionals.DB().Delete("DELETE FROM [RATING] where [Rating].rating < 3");
            Update();
        }
    }


    public class User
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Rating { get; set; }
    }
}
