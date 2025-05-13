using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM.Utils.Converters
{
    public class ConverterProgressBarColorTemperatura : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Color color = Colors.Green;
            double porcentajeTemperatura = 0;

            if (value != null)
            {
                porcentajeTemperatura = (double)value / 50;
            }

            if (porcentajeTemperatura > 0.33 && porcentajeTemperatura <= 0.66)
            {
                color = Colors.Yellow;
            }
            else if (porcentajeTemperatura > 0.66)
            {
                color = Colors.Red;
            }

            return color;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
