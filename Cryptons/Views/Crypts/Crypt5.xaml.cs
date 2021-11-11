using System;
using System.Windows.Interop;
using System.Collections.Generic;
using System.Drawing;
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
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Win32;

namespace Cryptons.Views.Crypts
{
    /// <summary>
    /// Логика взаимодействия для Crypt5.xaml
    /// </summary>
    public partial class Crypt5 : Page
    {
        public Crypt5()
        {
            InitializeComponent();
        }
        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }
        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string qrtext = text_do.Text; //считываем текст из TextBox'a
                QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
                Bitmap qrcode = encoder.Encode(qrtext); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
                QR_Code.Source = Bitmap2BitmapImage(qrcode); // pictureBox выводит qrcode как изображение.
            }
            catch
            {

            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                QRCodeDecoder decoder = new QRCodeDecoder(); // создаём "раскодирование изображения"
                BitmapImage bitly = QR_Code.Source as BitmapImage;
                text_do.Text = (decoder.decode(new QRCodeBitmapImage(BitmapImage2Bitmap(bitly))));
            }
            catch { text_do.Text = "Не удалось расшифровать изображение!"; }
            
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog load = new OpenFileDialog();
                load.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
                load.ShowDialog();
                QR_Code.Source = (new ImageSourceConverter()).ConvertFromString("file://" + load.FileName) as ImageSource;
                //QR_Code.Source = 
            }
            catch
            {

            }


        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog(); // save будет запрашивать у пользователя, место, в которое он захочет сохранить файл. 
                save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp"; //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию. В данном случае выбираем форматы изображений. Записывается так: "название_формата_в обозревателе|*.расширение_формата")
                save.ShowDialog();
                if (save.FileName.Length > 0) //если пользователь нажимает в обозревателе кнопку "Сохранить".
                {
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)QR_Code.Source));
                    using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                        encoder.Save(stream);
                }
            }
            catch { }
        }
    }
}
