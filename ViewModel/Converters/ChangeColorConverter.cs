using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptoReview.ViewModel
{
    public class ChangeColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null )
                return Brushes.White;

            string changeValue = values[0].ToString();

            if (changeValue == null)
                return Brushes.White;

            if (changeValue.StartsWith("-"))
                return Brushes.Red;
            else if(changeValue.StartsWith("-+"))
                return Brushes.White;
            else
                return Brushes.Green;
            

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
