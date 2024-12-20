using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU_KIE_GUI_BCS22090031_FinalTest.Converters
{
    public class ValueToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double sliderValue)
            {
                if (sliderValue >= 0 && sliderValue <= 39)
                    return "Failed";
                else if (sliderValue >= 40 && sliderValue <= 79)
                    return "Passed";
                else if (sliderValue >= 80 && sliderValue <= 100)
                    return "Excellent";
            }
            return "Unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
