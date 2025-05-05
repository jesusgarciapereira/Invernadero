using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsTemperaturaConNombreInvernadero : clsTemperatura // ¿hereda? SÍ
    {
        #region Atributos
        private string nombreInvernadero;
        #endregion

        #region Propiedades
        public string NombreInvernadero
        {
            get { return nombreInvernadero; }
        }
        #endregion

        #region Constructores
        public clsTemperaturaConNombreInvernadero()
        {

        }

        // Creo que este Constructor no hace falta
        //public clsTemperaturaConNombreInvernadero(clsTemperatura temperatura)
        //     : base(temperatura.IdInvernadero, temperatura.Fecha, temperatura.Temp1, temperatura.Temp2, temperatura.Temp3, temperatura.Humedad1, temperatura.Humedad2, temperatura.Humedad3)
        //{

        //}

        public clsTemperaturaConNombreInvernadero(clsTemperatura temperatura, string nombreInvernadero)
            : base(temperatura.IdInvernadero, temperatura.Fecha, temperatura.Temp1, temperatura.Temp2, temperatura.Temp3, temperatura.Humedad1, temperatura.Humedad2, temperatura.Humedad3)
        {
            this.nombreInvernadero = nombreInvernadero;
        }
        #endregion
    }

}

