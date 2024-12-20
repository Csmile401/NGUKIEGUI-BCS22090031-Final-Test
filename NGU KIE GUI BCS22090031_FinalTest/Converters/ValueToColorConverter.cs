using System.Globalization;


namespace NGU_KIE_GUI_BCS22090031_FinalTest.Converters
{
    public class ValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double sliderValue)
            {
                if (sliderValue >= 0 && sliderValue <= 39)
                    return Colors.Red;
                else if (sliderValue >= 40 && sliderValue <= 79)
                    return Colors.Gray;
                else if (sliderValue >= 80 && sliderValue <= 100)
                    return Colors.Green;
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
