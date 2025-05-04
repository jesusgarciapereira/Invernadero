
using BL;
using DTO;
using ENT;
using MAUI.Views;
using MAUI.VM.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.VM
{
    public class clsSeleccionarInvernaderoVM
    {
        #region Atributos
        private List<clsInvernadero> listadoInvernaderos;
        private clsInvernadero invernaderoSeleccionado;
        private DateTime fechaSeleccionada;
        private DelegateCommand botonVer;
        #endregion

        #region Propiedades
        public List<clsInvernadero> ListadoInvernaderos
        {
            get { return listadoInvernaderos; }
        }

        public clsInvernadero InvernaderoSeleccionado
        {
            get { return invernaderoSeleccionado; }
            set
            {
                invernaderoSeleccionado = value;
                botonVer.RaiseCanExecuteChanged();
            }
        }

        public DateTime FechaSeleccionada
        {
            get { return fechaSeleccionada; }
            set
            {
                fechaSeleccionada = value;
                botonVer.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand BotonVer
        {
            get { return botonVer; }
        }
        #endregion

        #region Constructores

        public clsSeleccionarInvernaderoVM()
        {
            botonVer = new DelegateCommand(verExecute, habilitarVer);

            try
            {
                listadoInvernaderos = clsListadosInvernaderosBL.ObtenerListadoInvernaderosBL();
                // Para que aparezca el primero, en la lista de invernaderos
                listadoInvernaderos.Insert(0, new clsInvernadero(0, "--- Seleccione un Invernadero ---"));

                // Seleccionados originalmente
                invernaderoSeleccionado = listadoInvernaderos[0];
                fechaSeleccionada = DateTime.Now; // Inicialmente es la fecha actual, como pide el ejercicio
      
            }
            catch (SqlException ex) 
            {
                muestraMensaje("Error", "Ha habido un problema en la Base de Datos, vuelva a intentarlo más tarde", "OK");
            }
        }
        #endregion

        #region Métodos
        private async void muestraMensaje(string titulo, string cuerpo, string boton)
        {
            await Application.Current.MainPage.DisplayAlert(titulo, cuerpo, boton);
        }

        private async void enviaDatosNavigation(clsTemperaturaConNombreInvernadero temperaturasConNombreInvernadero) 
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InvernaderoSeleccionadoPage(temperaturasConNombreInvernadero));
        }

        #endregion

        #region Comandos
        private void verExecute()
        {
            clsTemperaturaConNombreInvernadero temperaturasConNombreInvernadero;

            try
            {
                temperaturasConNombreInvernadero = clsListadosTemperaturaConNombreInvernaderoBL.ObtenerTemperaturasConNombreInvernaderoPorPKBL
                    (invernaderoSeleccionado.IdInvernadero, fechaSeleccionada);

                if (temperaturasConNombreInvernadero != null)
                {
                    enviaDatosNavigation(temperaturasConNombreInvernadero);
                }
                else
                {
                    muestraMensaje("Sin datos" 
                        , "No se encontraron temperaturas correspondientes a la fecha e invernadero seleccionados " +
                        "\n\nPista: Todos los invernaderos tienen registros de temperatura desde el 29 de Abril hasta el 5 de Mayo de 2025"
                        , "OK");                 
                }
            }
            catch (SqlException ex)
            {
                muestraMensaje("Error", "Ha habido un problema en la Base de Datos, vuelva a intentarlo más tarde", "OK");

            }
        }

        private bool habilitarVer()
        {
            bool habilitado = false;

            if (invernaderoSeleccionado != null && invernaderoSeleccionado.IdInvernadero > 0 && fechaSeleccionada <= DateTime.Now)
            {
                habilitado = true;
            }

            return habilitado;

        }
        #endregion
    }
}
