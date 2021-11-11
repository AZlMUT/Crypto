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
    /// Логика взаимодействия для TeoriFrame.xaml
    /// </summary>
    public partial class TeoriFrame : Page
    {

        Functionals f = Functionals.DB();
        List<List<string>> infos;
        public TeoriFrame()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            infos = f.getListInfo();
            Listing.Children.Clear();
            foreach(List<string> i in infos)
                Listing.Children.Add(GetGroupBox(i[0],i[1],i[2]));
        }

        GroupBox GetGroupBox(string header,string text, string img)
        {
            GroupBox box = new GroupBox();
            box.Style = Application.Current.TryFindResource("MaterialDesignCardGroupBox") as Style;
            ColorZoneAssist.SetMode(box, ColorZoneMode.SecondaryMid);
            box.Header = GetHeader(header);
            box.Content = GetBody(text,img);
            box.Margin = new Thickness(0, 0, 0, 20);
            return box;
        }

        StackPanel GetHeader(string header)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;

            PackIcon icon = new PackIcon();
            icon.Kind = PackIconKind.InfoCircle;
            icon.Width = 32; icon.Height = 32; icon.Foreground = Brushes.White;
            icon.VerticalAlignment = VerticalAlignment.Center;
            ColorZoneAssist.SetMode(icon, ColorZoneMode.SecondaryMid);

            TextBlock text = new TextBlock();
            text.Margin = new Thickness(8,0,0,0);
            text.VerticalAlignment = VerticalAlignment.Center;
            text.Text = header; text.Foreground = Brushes.White;
            text.Style = Application.Current.TryFindResource("MaterialDesignSubtitle1TextBlock") as Style;
            ColorZoneAssist.SetMode(text, ColorZoneMode.SecondaryMid);

            panel.Children.Add(icon);
            panel.Children.Add(text);

            return panel;
        }

        StackPanel GetBody(string text, string img)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;

            TextBlock textBlock = new TextBlock();
            textBlock.Margin = new Thickness(8, 0, 0, 0); textBlock.FontSize = 20;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Text = text; textBlock.TextWrapping = TextWrapping.Wrap;
            if(img == "0") textBlock.Width = 880;
            else textBlock.Width = 640;
            panel.Children.Add(textBlock); 

            if (img != "0")
            {
                Image icon = new Image();
                icon.Source = new BitmapImage(new Uri(img));
                icon.Width = 280;
                panel.Children.Add(icon);
            }
            
            return panel;
        }
    }
}
