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
        public static List<clsInvernadero> ObtenerListadoInvernaderosBL()
        {
            return clsListadosInvernaderosDAL.ObtenerListadoInvernaderosDAL();
        }
    }
}
