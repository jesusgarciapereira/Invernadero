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
        public static List<clsTemperaturaConNombreInvernadero> ObtenerListadoTemperaturasConNombreInvernaderoBL()
        {
            return clsListadosTemperaturaConNombreInvernaderoDAL.ObtenerListadoTemperaturasConNombreInvernaderoDAL();
        }
    }
}
