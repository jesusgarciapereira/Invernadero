using ASP.Models;
using ASP.Models.VM;
using BL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Muestra la vista principal con el formulario de selección de invernadero y fecha.
        /// </summary>
        /// <returns>Vista Index con el ViewModel de selección de invernadero.</returns>
        public IActionResult Index()
        {
            IActionResult accion;
            clsSeleccionarInvernaderoVM seleccionInvernadero = null;

            try
            {
                seleccionInvernadero = new clsSeleccionarInvernaderoVM();

                accion = View(seleccionInvernadero);
            }
            catch (SqlException e)
            {
                // TODO: Lanzar mensaje de error. Vista Error
                accion = View("ErrorSql");
            }

            return accion;
        }



        /// <summary>
        /// Muestra los detalles de las temperaturas registradas para un invernadero en una fecha específica.
        /// </summary>
        /// <param name="idInvernadero">ID del invernadero.</param>
        /// <param name="fecha">Fecha de consulta.</param>
        /// <returns>Vista con los detalles de temperatura o de nuevo la Vista Index si no hay datos.</returns>
        [HttpPost] // Significa que ha entrado en un input type="submit"
        public IActionResult Index(int idInvernadero, DateTime fecha)
        {
            IActionResult accion;
            // La Verdad, así no me gusta, que no hagas nada si no seleccionas invernadero vale pero lo demás...
            ViewBag.MostrarError = false;
            clsTemperaturaConNombreInvernadero invernaderoSeleccionado;

            try
            {
                if (idInvernadero != 0)
                {
                    // ¿Comprueba si la fecha está?

                    invernaderoSeleccionado = clsListadosTemperaturaConNombreInvernaderoBL.ObtenerTemperaturasConNombreInvernaderoPorPKBL
                        (idInvernadero, fecha);

                    if (invernaderoSeleccionado != null)
                    {
                        accion = View("Details", invernaderoSeleccionado);
                    }
                    else
                    {
                        clsSeleccionarInvernaderoVM seleccionInvernadero = new clsSeleccionarInvernaderoVM();

                        seleccionInvernadero.IdInvernaderoSeleccionado = idInvernadero;
                        seleccionInvernadero.FechaSeleccionada = fecha;

                        ViewBag.MostrarError = true;

                        accion = View(seleccionInvernadero);
                        // A lo mejor no envío otra vista
                        //return View("ErrorSinDatos");
                    }
                }
                else 
                {
                    clsSeleccionarInvernaderoVM seleccionInvernadero = new clsSeleccionarInvernaderoVM();

                    seleccionInvernadero.IdInvernaderoSeleccionado = idInvernadero;
                    seleccionInvernadero.FechaSeleccionada = fecha;

                    ViewBag.MostrarError = true;

                    accion =  View(seleccionInvernadero);
                }
            }
            catch (SqlException e)
            {
                // TODO: Lanzar mensaje de error. Vista Error
                accion = View("ErrorSql");
            }

            return accion;
        }
        /// <summary>
        /// Vuelve a la Vista Index pero con los datos que habíamos seleccionado anteriormente
        /// </summary>
        /// <param name="idInvernadero">ID del invernadero.</param>
        /// <param name="fecha">Fecha de consulta.</param>
        /// <returns>Vista Index con los datos seleccionados anteriormente</returns>
        public IActionResult Details(int idInvernadero, DateTime fecha)
        {
            IActionResult accion;
            clsSeleccionarInvernaderoVM seleccionInvernadero = null;

            try
            {
                seleccionInvernadero = new clsSeleccionarInvernaderoVM();

                seleccionInvernadero.IdInvernaderoSeleccionado = idInvernadero;
                seleccionInvernadero.FechaSeleccionada = fecha;

                accion = View("Index", seleccionInvernadero);
            }
            catch (SqlException e)
            {
                // TODO: Lanzar mensaje de error. Vista Error
                accion = View("ErrorSql");
            }

            return accion;
        }
    }
}
