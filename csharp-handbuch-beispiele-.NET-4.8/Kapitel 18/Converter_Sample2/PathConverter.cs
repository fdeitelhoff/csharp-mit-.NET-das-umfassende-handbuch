using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Converter_Sample2
{
    public class PathConverter : IValueConverter
    {
        private string imageDirectory = Directory.GetCurrentDirectory() + @"\Images\";

        public string ImageDirectory
        {
            get => imageDirectory; 
            set => imageDirectory = value; 
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            string imagePath = Path.Combine(ImageDirectory, (string)value + ".jpg");
            return new BitmapImage(new Uri(imagePath));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
