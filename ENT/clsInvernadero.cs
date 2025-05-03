using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class clsInvernadero
    {
        #region Atributos
        private int idInvernadero;
        private string nombre;
        #endregion

        #region Propiedades
        public int IdInvernadero
        {
            get { return idInvernadero; }
            set { idInvernadero = value; } // Puede que sí o puede que no
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion

        #region Constructores
        public clsInvernadero()
        {
        }

        public clsInvernadero(int idInvernadero, string nombre)
        {
            this.idInvernadero = idInvernadero;
            this.nombre = nombre;
        }
        #endregion
    }
}
