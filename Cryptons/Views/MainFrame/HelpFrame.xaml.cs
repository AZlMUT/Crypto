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
using Cryptons.Views.HelpFrame;

namespace Cryptons.Views.MainFrame
{
    /// <summary>
    /// Логика взаимодействия для HelpFrame.xaml
    /// </summary>
    public partial class HelpFrame : Page
    {

        public HelpFrame()
        {
            InitializeComponent();
            frame1.Content = new Help1();
            frame2.Content = new Help2();
            frame3.Content = new Help3();
            frame4.Content = new Help4();
            frame5.Content = new Help5();
            frame6.Content = new Help6();
            frame7.Content = new Help7();
            frame8.Content = new Help8();
        }
    }
}
