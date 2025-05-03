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
        public static List<clsTemperatura> ObtenerListadoTemperaturasBL()
        {
            return clsListadosTemperaturasDAL.ObtenerListadoTemperaturasDAL();
        }
    }
}
