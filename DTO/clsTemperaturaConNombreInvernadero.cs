using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsTemperaturaConNombreInvernadero : clsTemperatura // ¿hereda? creo que sí
    {
        private string nombreInvernadero;

        public string NombreInvernadero
        {
            get { return nombreInvernadero; }
        }

        public clsTemperaturaConNombreInvernadero()
        {

        }

        public clsTemperaturaConNombreInvernadero(clsTemperatura temperatura, string nombreInvernadero)
            : base(temperatura.IdInvernadero, temperatura.Fecha, temperatura.Temp1, temperatura.Temp2, temperatura.Temp3, temperatura.Humedad1, temperatura.Humedad2, temperatura.Humedad3)
        {
            this.nombreInvernadero = nombreInvernadero;
        }
    }

}

