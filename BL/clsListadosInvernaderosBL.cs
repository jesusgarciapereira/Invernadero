using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadosInvernaderosBL
    {
        /// <summary>
        /// Obtiene el listado completo de invernaderos desde la capa DAL.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsInvernadero con las reglas de negocio aplicadas.</returns>
        public static List<clsInvernadero> ObtenerListadoInvernaderosBL()
        {
            return clsListadosInvernaderosDAL.ObtenerListadoInvernaderosDAL();
        }
    }
}
