using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadosTemperaturasBL
    {
        /// <summary>
        /// Obtiene el listado completo de temperaturas desde la capa DAL.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsTemperatura con las reglas de negocio aplicadas.</returns>
        public static List<clsTemperatura> ObtenerListadoTemperaturasBL()
        {
            return clsListadosTemperaturasDAL.ObtenerListadoTemperaturasDAL();
        }
    }
}
