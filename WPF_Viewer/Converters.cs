using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Viewer
{
    //[ValueConversion(typeof(BinaryReader[]), typeof(System.Windows.Controls.Image))]
    //public class ImgBinaryConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        System.Windows.Controls.Image image = new System.Windows.Controls.Image();
    //        try
    //        {
    //            BitmapImage bi = new BitmapImage();
    //            bi.BeginInit();
    //            bi.CreateOptions = BitmapCreateOptions.None;
    //            bi.CacheOption = BitmapCacheOption.Default;
    //            if (value != null)
    //            {
    //                bi.StreamSource = new MemoryStream(value as byte[]);
    //            }
    //            else 
    //            {
    //                bi.UriSource = new Uri("D:/Documents/Programming/DB_Practicum/WPF_Viewer/a4.gif");
    //                //bi.StreamSource = new FileStream("D:/Documents/Programming/DB_Practicum/WPF_Viewer/a4.gif", FileMode.Open, FileAccess.Read, FileShare.Read);
    //            }
    //            bi.EndInit();
                
    //            image.Source = bi;
    //        }
    //        catch
    //        {
    //            Console.WriteLine("null in converter");
    //            //image.Source = new BitmapImage(new Uri("D:/Documents/Programming/DB_Practicum/WPF_Viewer/noimage.gif"));
    //        }
    //        Console.WriteLine("img in converter");
    //        return image;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return value;
    //    }
    //}

    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime elem = (DateTime)value;
            //return elem.name_opt + " " + elem.surname_opt;
            //return elem.title_pub + ", " + elem.date_pub.ToShortDateString();
            return elem.ToString("dd.MM.yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value.ToString();
            DateTime resultDateTime;

            if (DateTime.TryParse(strValue, out resultDateTime))
            {
                return resultDateTime;
            }

            return value;
        }
    }

    [ValueConversion(typeof(String), typeof(System.Windows.Media.Brush))]
    public class RelationTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((String)(value))
            {
                case "Friends":
                    { return System.Windows.Media.Brushes.Red; }
                case "Colleagues":
                    { return System.Windows.Media.Brushes.Green; }
                case "Relatives":
                    { return System.Windows.Media.Brushes.Purple; }
                default:
                    { return System.Windows.Media.Brushes.Black; }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
