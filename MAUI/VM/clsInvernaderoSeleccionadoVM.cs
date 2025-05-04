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
        private double progessTemp1;
        private double progessTemp2;
        private double progessTemp3;
        private double progessHumedad1;
        private double progessHumedad2;
        private double progessHumedad3;
        #endregion

        #region Propiedades
        public clsTemperaturaConNombreInvernadero TemperaturasDeInvernadero
        {
            get { return temperaturasDeInvernadero; }
        }

        public double ProgessTemp1
        {
            get { return progessTemp1; }
        }
        public double ProgessTemp2
        {
            get { return progessTemp2; }
        }
        public double ProgessTemp3
        {
            get { return progessTemp3; }
        }
        public double ProgessHumedad1
        {
            get { return progessHumedad1; }
        }
        public double ProgessHumedad2
        {
            get { return progessHumedad2; }
        }
        public double ProgessHumedad3
        {
            get { return progessHumedad3; }
        }
        #endregion

        #region Constructores
        public InvernaderoSeleccionadoVM()
        {

        }

        public InvernaderoSeleccionadoVM(clsTemperaturaConNombreInvernadero temperaturasDeInvernadero)
        {
            this.temperaturasDeInvernadero = temperaturasDeInvernadero;

            if (temperaturasDeInvernadero.Temp1 != null)
            {
                this.progessTemp1 = (double)temperaturasDeInvernadero.Temp1 / 50.0;
            }

            if (temperaturasDeInvernadero.Temp2 != null)
            {
                this.progessTemp2 = (double)temperaturasDeInvernadero.Temp2 / 50.0;
            }

            if (temperaturasDeInvernadero.Temp3 != null)
            {
                this.progessTemp3 = (double)temperaturasDeInvernadero.Temp3 / 50.0;
            }

            if (temperaturasDeInvernadero.Humedad1 != null)
            {
                this.progessHumedad1 = (double)temperaturasDeInvernadero.Humedad1 / 100.0;
            }

            if (temperaturasDeInvernadero.Humedad2 != null)
            {
                this.progessHumedad2 = (double)temperaturasDeInvernadero.Humedad2 / 100.0;
            }

            if (temperaturasDeInvernadero.Humedad3 != null)
            {
                this.progessHumedad3 = (double)temperaturasDeInvernadero.Humedad3 / 100.0;
            }

            

        }
        #endregion
    }
}
