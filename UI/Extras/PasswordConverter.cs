using System.Globalization;
using System.Windows.Data;

namespace UI.Extras
{
    public class PasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var passString = (string)value;
            int length = passString.Length;
            string returnPass = new string('*', length);

            return returnPass;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
