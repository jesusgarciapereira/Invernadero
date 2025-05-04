using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM
{
    public class InvernaderoSeleccionadoVM
    {
        #region Atributos
        private clsTemperaturaConNombreInvernadero temperaturasDeInvernadero;
        #endregion

        #region Propiedades
        public clsTemperaturaConNombreInvernadero TemperaturasDeInvernadero
        {
            get { return temperaturasDeInvernadero; }
        }
        #endregion

        #region Constructores
        public InvernaderoSeleccionadoVM() 
        { 
        
        }

        public InvernaderoSeleccionadoVM(clsTemperaturaConNombreInvernadero temperaturasDeInvernadero)
        {
            this.temperaturasDeInvernadero = temperaturasDeInvernadero;
        }
        #endregion
    }
}
