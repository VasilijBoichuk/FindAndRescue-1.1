namespace FindAndRescue.Converters
{
    public class StreetNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<string> streetNames)
            {
                return string.Join(", ", streetNames);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // Not needed for this scenario
        }
    }
}
