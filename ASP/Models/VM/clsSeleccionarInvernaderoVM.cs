using BL;
using DTO;
using ENT;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace ASP.Models.VM
{
    public class clsSeleccionarInvernaderoVM
    {
        #region Atributos
        private List<clsInvernadero> listadoInvernaderos;
        // Los necesito, pero los puedo evitar con ViewBag en el Controller
        // private int idInvernaderoSeleccionado; 
        // private DateTime fechaSeleccionada;
        #endregion

        #region Propiedades
        public List<clsInvernadero> ListadoInvernaderos
        {
            get { return listadoInvernaderos; }
        }

        // Ya no hacen falta si existen los ViewBag
        //public DateTime FechaSeleccionada
        //{
        //    get { return fechaSeleccionada; }
        //    set
        //    {
        //        fechaSeleccionada = value;
        //    }
        //}

        //public int IdInvernaderoSeleccionado
        //{
        //    get { return idInvernaderoSeleccionado; }
        //    set
        //    {
        //        idInvernaderoSeleccionado = value;
        //    }
        //}

        #endregion

        #region Constructores

        public clsSeleccionarInvernaderoVM()
        {
            // Aquí try-catch no, sino en el Controller
            //try
            //{
                listadoInvernaderos = clsListadosInvernaderosBL.ObtenerListadoInvernaderosBL();
                // Para que aparezca el primero, en la lista de invernaderos
                listadoInvernaderos.Insert(0, new clsInvernadero(0, "--- Seleccione un Invernadero ---"));

                // Seleccionados originalmente, aquí no, sino en el Controller
                // idInvernaderoSeleccionado = listadoInvernaderos[0].IdInvernadero;
                //fechaSeleccionada = DateTime.Now; // Inicialmente es la fecha actual, como pide el ejercicio

            //}
            //catch (SqlException ex)
            //{
            //   // muestraMensaje("Error", "Ha habido un problema en la Base de Datos, vuelva a intentarlo más tarde", "OK");
            //}
        }
        #endregion

    }
}
