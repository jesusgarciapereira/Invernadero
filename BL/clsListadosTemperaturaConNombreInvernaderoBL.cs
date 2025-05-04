using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadosTemperaturaConNombreInvernaderoBL
    {
        /// <summary>
        /// Obtiene el listado completo de temperaturas con nombre de invernadero desde la capa DAL.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsTemperaturaConNombreInvernadero con las reglas de negocio aplicadas.</returns>
        public static List<clsTemperaturaConNombreInvernadero> ObtenerListadoTemperaturasConNombreInvernaderoBL()
        {
            return clsListadosTemperaturaConNombreInvernaderoDAL.ObtenerListadoTemperaturasConNombreInvernaderoDAL();
        }

        /// <summary>
        /// Obtiene las Temperaturas con el nombre del Invernadero correspondiente las PK que se le pasa por parámetro desde la capa DAL.
        /// </summary>
        /// <param name="idInvernadero"></param>
        /// <param name="fecha"></param>
        /// <returns>Objeto de tipo clsTemperaturaConNombreInvernadero con las reglas de negocio aplicadas</returns>
        public static clsTemperaturaConNombreInvernadero ObtenerTemperaturasConNombreInvernaderoPorPKBL(int idInvernadero, DateTime fecha)
        {
            return clsListadosTemperaturaConNombreInvernaderoDAL.ObtenerTemperaturasConNombreInvernaderoPorPKDAL(idInvernadero, fecha);
        }
    }
}
