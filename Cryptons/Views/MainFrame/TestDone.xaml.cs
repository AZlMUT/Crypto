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
    /// Логика взаимодействия для TestDone.xaml
    /// </summary>
    public partial class TestDone : Window
    {
        Functionals f = Functionals.DB();
        public TestDone(int rating, int count)
        {
            InitializeComponent();
            Student.Content = $"{Properties.Settings.Default.UserName} {Properties.Settings.Default.UserFirstname}";
            Verno.Content += $"{rating}";
            NeVerno.Content += $"{count - rating}";

            double i20 = count / 5;
            
            int ball = 2;

            if (rating >= (i20 * 3)) ball = 3;
            if (rating >= (i20 * 3.5)) ball = 4;
            if (rating >= (i20 * 4)) ball = 5;

            Rating.Content += $"{ball}";
            RatingBar.Value = (int)ball;
            f.SaveTest(rating);
        }

        private void OkayClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
