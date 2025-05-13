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
        /// Convierte un valor de humedad entero (0-100) a un valor double normalizado (0.0 - 1.0)
        /// para ser usado como valor de progreso en un ProgressBar.
        /// Pre: El value del parámetro debe ser un int
        /// Post: El valor devuelto debe ser un double
        /// </summary>
        /// <param name="value">El valor de humedad recibido (esperado como int).</param>
        /// <param name="targetType">El tipo de destino de la conversión (no usado).</param>
        /// <param name="parameter">Parámetro adicional para la conversión (no usado).</param>
        /// <param name="culture">Información de cultura para la conversión (no usada).</param>
        /// <returns>Un valor double entre 0.0 y 1.0 que representa el porcentaje de humedad.</returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double porcentajeHumedad = 0;

            if (value != null)
            {
                // No puedo hacer un cast directamente a double por que el value recibido (es decir, la humedad) es un int
                // El cast lo hare a int y luego lo divido por un número decimal para que convertirlo a double
                porcentajeHumedad = (int)value / 100.0;
            }
            return porcentajeHumedad;
        }

        /// <summary>
        /// No implementa la conversión inversa ya que no es necesaria en este contexto.
        /// </summary>
        /// <param name="value">Valor a convertir de vuelta (no se usa).</param>
        /// <param name="targetType">Tipo de destino de la conversión inversa (no usado).</param>
        /// <param name="parameter">Parámetro adicional para la conversión inversa (no usado).</param>
        /// <param name="culture">Información de cultura para la conversión inversa (no usada).</param>
        /// <returns>El mismo valor recibido, sin conversión.</returns>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
