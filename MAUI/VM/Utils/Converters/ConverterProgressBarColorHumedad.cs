using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM.Utils.Converters
{
    public class ConverterProgressBarColorHumedad : IValueConverter
    {
        /// <summary>
        /// Convierte un valor de humedad en un color representando su nivel.
        /// </summary>
        /// <param name="value">Valor de humedad como entero (0–100).</param>
        /// <param name="targetType">Tipo de destino (no se usa).</param>
        /// <param name="parameter">Parámetro opcional (no se usa).</param>
        /// <param name="culture">Información de cultura (no se usa).</param>
        /// <returns>Un color: verde (≤33%), amarillo (34–66%), o rojo (>66%).</returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Color color = Colors.Green;
            double porcentajeHumedad = 0;

            if (value != null)
            {
                // No puedo hacer un cast directamente a double por que el value recibido (es decir, la humedad) es un int
                // El cast lo hare a int y luego lo divido por un número decimal para que convertirlo a double
                porcentajeHumedad = (int)value / 100.0;
            }

            if (porcentajeHumedad > 0.33 && porcentajeHumedad <= 0.66) 
            { 
                color = Colors.Yellow; 
            }
            else if(porcentajeHumedad > 0.66)
            {
                color = Colors.Red;
            }

            return color;
        }

        /// <summary>
        /// Retorna el valor sin cambios (conversión inversa no implementada).
        /// </summary>
        /// <param name="value">Valor original.</param>
        /// <param name="targetType">Tipo de destino (no se usa).</param>
        /// <param name="parameter">Parámetro opcional (no se usa).</param>
        /// <param name="culture">Información de cultura (no se usa).</param>
        /// <returns>El mismo valor recibido.</returns>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
