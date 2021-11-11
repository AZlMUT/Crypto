using Cryptons.Views.Dialogs;
using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для TestFrame.xaml
    /// </summary>
    public partial class TestFrame : Page
    {
        Functionals f = Functionals.DB();
        public TestFrame()
        {
            InitializeComponent();
            loadQuestion();
        }


        Card createQuestion(List<string> lst)
        {
            TextBlock questText = new TextBlock();
            questText.Text = lst[1];
            questText.FontSize = 16;
            questText.TextWrapping = TextWrapping.Wrap;
            questText.Margin = new Thickness(16,16,12,8);



            StackPanel stack = new StackPanel();
            stack.Children.Add(questText);
            for (int i = 2; i < 6; i++)
            {
                RadioButton rad = new RadioButton();
                rad.Content = lst[i]; rad.FontSize = 16;
                rad.Margin = new Thickness(16, 4, 16, 0);
                rad.Style = (Style)this.TryFindResource("MaterialDesignUserForegroundRadioButton");
                
                if (i - 2 == Convert.ToInt32(lst[6])) rad.Tag = "1";
                else rad.Tag = "0";

                if (rad.Content.ToString() != "NULL")
                    stack.Children.Add(rad);
            }
            Separator sep = new Separator();
            sep.Style = (Style)this.TryFindResource("MaterialDesignLightSeparator");
            stack.Children.Add(sep);



            Card quest = new Card();
            quest.Padding = new Thickness(30);
            quest.Background = (Brush)this.TryFindResource("PrimaryHueDarkBrush");
            quest.Foreground = (Brush)this.TryFindResource("PrimaryHueDarkForegroundBrush");
            quest.Margin = new Thickness(30, 30, 30, 0);
            quest.VerticalAlignment = VerticalAlignment.Top;
            quest.Height = Double.NaN;
            quest.Content = stack;
            quest.Tag = lst[0];

            return quest;
        }
        void loadQuestion()
        {
            List<List<string>> lst = f.getQuestions();
            foreach(List<string> i in lst)
            {
                int count = StackQuestion.Children.Count;
                StackQuestion.Children.Insert(count-1, createQuestion(i));
            }
                
        }
        int getRating()
        {
            int sum = 0;
            for(int i=0; i < StackQuestion.Children.Count-1;i++)
            {
                Card card = (Card)StackQuestion.Children[i];
                StackPanel stack = (StackPanel)card.Content;
                for(int j = 1; j < stack.Children.Count-1; j++)
                {
                    
                    RadioButton rad = (RadioButton)stack.Children[j];
                    if ((bool)rad.IsChecked && rad.Tag.ToString() == "1")
                        sum++;
                }
            }
            return sum;
        }

        private void TestDoneClick(object sender, RoutedEventArgs e)
        {

            if (f.GetCount($"select * from [Rating] where id_user={Properties.Settings.Default.UserId}") != 0)
            {
                new WarningFrame("Вы уже проходили этот тест!").ShowDialog();
            }
            else
            {
                int rating = getRating();
                Window testRating = new TestDone(rating, StackQuestion.Children.Count - 1);
                testRating.ShowDialog();
            }
        }
    }
}
