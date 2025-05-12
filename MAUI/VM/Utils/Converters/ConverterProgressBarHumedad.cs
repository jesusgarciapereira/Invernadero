using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM.Utils.Converters
{
    public class ConverterProgressBarHumedad : IValueConverter
    {
        /// <summary>
        /// Función que recive y convierte un valor entre 0 y 100 y devuelve un float entre 0 y 1
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double humedad = 0;

            if (value != null)
            {
                humedad = (double)value / 100.0;
            }
            return humedad;
        }

        /// <summary>
        /// Retornamos el mismo valor porque no necesitamos ninguna conversión de vuelta
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
