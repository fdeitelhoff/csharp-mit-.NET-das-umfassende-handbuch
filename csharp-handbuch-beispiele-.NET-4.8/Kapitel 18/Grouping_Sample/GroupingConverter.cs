using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Grouping_Sample
{
    public class GroupingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var context = new NorthwindEntities();
            var result = context.Categories
                .Where(cat => cat.CategoryID == (int)value)
                .Select(cat => new { cat.CategoryName }).Single();
            return result.CategoryName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
