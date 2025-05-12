using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM.Utils.Converters
{
    public class ConverterProgressBarTemperatura : IValueConverter
    {
        /// <summary>
        /// Convierte una temperatura en grados Celsius (de 0 a 50) a un valor normalizado entre 0.0 y 1.0,
        /// para ser usado como valor de progreso en un ProgressBar.
        /// </summary>
        /// <param name="value">Temperatura en grados Celsius (esperada como double).</param>
        /// <param name="targetType">Tipo de destino de la conversión (no utilizado).</param>
        /// <param name="parameter">Parámetro opcional (no utilizado).</param>
        /// <param name="culture">Información cultural (no utilizada).</param>
        /// <returns>Un valor double entre 0.0 y 1.0 que representa el porcentaje de la temperatura.</returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double porcentajeTemperatura = 0;

            if (value != null)
            {
                porcentajeTemperatura = (double)value / 50;
            }

            return porcentajeTemperatura;
        }

        /// <summary>
        /// No implementa conversión inversa porque no es necesaria en este escenario.
        /// </summary>
        /// <param name="value">Valor a convertir de vuelta (no utilizado).</param>
        /// <param name="targetType">Tipo de destino (no utilizado).</param>
        /// <param name="parameter">Parámetro opcional (no utilizado).</param>
        /// <param name="culture">Información cultural (no utilizada).</param>
        /// <returns>El mismo valor recibido, sin conversión.</returns>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
