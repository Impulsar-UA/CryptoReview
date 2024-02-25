using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CryptoReview.ViewModel
{
    public class ValueSuffixConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is double))
                return value;

            double number = (double)value;

            string suffix = "";
            if (number >= 1_000_000_000)
            {
                number /= 1_000_000_000;
                suffix = "B";
            }
            else if (number >= 1_000_000)
            {
                number /= 1_000_000;
                suffix = "M";
            }
            else if (number >= 1_000)
            {
                number /= 1_000;
                suffix = "K";
            }
            string formattedValue;
            double roundedNumber = Math.Round(number, 4);
            if (value is double doubleValue && doubleValue < 1) { formattedValue = value.ToString().TrimEnd('0'); return formattedValue; }
             formattedValue = roundedNumber.ToString("0.###", CultureInfo.InvariantCulture) + suffix;

            return formattedValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
