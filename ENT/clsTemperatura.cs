using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class clsTemperatura
    {
        #region Atributos
        private int idInvernadero;
        private DateTime fecha;
        // Necesito que todos estos acepten un posible null
        private double? temp1; // Sólo una cifra decimal (ºC)
        private double? temp2;
        private double? temp3;
        private int? humedad1; // Un porcentaje
        private int? humedad2;
        private int? humedad3;
        #endregion

        #region Propiedades
        public int IdInvernadero
        {
            get { return idInvernadero; }
            set { idInvernadero = value; } // Para ASP sí lo necesito
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; } // Para ASP sí lo necesito
        }

        public double? Temp1
        {
            get { return temp1; }
            set { temp1 = value; }
        }

        public double? Temp2
        {
            get { return temp2; }
            set { temp2 = value; }
        }

        public double? Temp3
        {
            get { return temp3; }
            set { temp3 = value; }
        }

        public int? Humedad1
        {
            get { return humedad1; }
            set { humedad1 = value; }
        }

        public int? Humedad2
        {
            get { return humedad2; }
            set { humedad2 = value; }
        }

        public int? Humedad3
        {
            get { return humedad3; }
            set { humedad3 = value; }
        }
        #endregion

        #region Constructores
        public clsTemperatura()
        {
            // this.fecha = DateTime.Now; // Creo que aquí no, sino en fechaSeleccionada del VM
        }

        public clsTemperatura(int idInvernadero, DateTime fecha)
        {
            this.idInvernadero = idInvernadero;
            this.fecha = fecha;
        }

        public clsTemperatura(int idInvernadero, DateTime fecha, double? temp1, double? temp2, double? temp3, int? humedad1, int? humedad2, int? humedad3)
        {
            this.idInvernadero = idInvernadero;
            this.fecha = fecha;
            this.temp1 = temp1;
            this.temp2 = temp2;
            this.temp3 = temp3;
            this.humedad1 = humedad1;
            this.humedad2 = humedad2;
            this.humedad3 = humedad3;
        }
        #endregion
    }
}
