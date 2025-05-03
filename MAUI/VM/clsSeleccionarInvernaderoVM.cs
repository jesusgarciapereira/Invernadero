using BL;
using ENT;
using MAUI.VM.Utils;
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
        private clsInvernadero invernaderoElegido;
        private DateTime fechaSeleccionada;
        private DelegateCommand botonVer;
        #endregion

        #region Propiedades
        public List<clsInvernadero> ListadoInvernaderos
        {
            get { return listadoInvernaderos; }
        }

        public clsInvernadero InvernaderoElegido
        {
            get { return invernaderoElegido; }
            set
            {
                invernaderoElegido = value;
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
            listadoInvernaderos = clsListadosInvernaderosBL.ObtenerListadoInvernaderosBL();
            fechaSeleccionada = DateTime.Now; // Inicialmente es la fecha actual, como pide el ejercicio
            botonVer = new DelegateCommand(verExecute
                //, habilitarVer
                );
        }
        #endregion

        #region Métodos
        private async void muestraMensaje(string titulo, string cuerpo, string boton)
        {
            await Application.Current.MainPage.DisplayAlert(titulo, cuerpo, boton);
        }
        #endregion

        #region Comandos
        private void verExecute()
        {
            // TODO: Acciones y mensajes necesarios para ver el Invernadero
        }


        //private bool habilitarVer()
        //{
        //    // TODO: Acciones necesarias para habilitar el Boton

        //}
        #endregion
    }
}
