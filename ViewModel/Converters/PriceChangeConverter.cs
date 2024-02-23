using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CryptoReview.ViewModel
{
    public class PriceChangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is double))
                return "";

            double numericValue = (double)value;
            string formattedValue = Math.Round(numericValue, 2).ToString("+#0.00;-#0.00", CultureInfo.InvariantCulture);

            return formattedValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
