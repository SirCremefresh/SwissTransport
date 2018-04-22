using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SwissTransportView
{
    class ToTime : IValueConverter
    {
        /*convert date string to time hh:mm*/
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime time = DateTime.Parse((string)value);
            return time.ToString("HH:mm");
        }

        /*not needed*/
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
