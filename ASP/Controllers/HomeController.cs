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
            clsSeleccionarInvernaderoVM seleccionInvernadero;

            try
            {
                seleccionInvernadero = new clsSeleccionarInvernaderoVM();
                ViewBag.FechaInicial = DateTime.Now;
            }
            catch (SqlException e)
            {
                // TODO: Lanzar mensaje de error. Vista Error
                return View("ErrorSql");
            }

            return View(seleccionInvernadero);
        }

        /// <summary>
        /// Muestra los detalles de las temperaturas registradas para un invernadero en una fecha específica.
        /// </summary>
        /// <param name="idInvernadero">ID del invernadero.</param>
        /// <param name="fecha">Fecha de consulta.</param>
        /// <returns>Vista con los detalles de temperatura o de nuevo la Vista Index si no hay datos.</returns>
        [HttpPost]
        public IActionResult Index(int idInvernadero, DateTime fecha)
        {
            ViewBag.MostrarError = false;
            clsTemperaturaConNombreInvernadero invernaderoSeleccionado;

            try
            {
                invernaderoSeleccionado = clsListadosTemperaturaConNombreInvernaderoBL.ObtenerTemperaturasConNombreInvernaderoPorPKBL
                    (idInvernadero, fecha);

                if (invernaderoSeleccionado != null)
                {
                    return View(invernaderoSeleccionado);
                }
                else
                {
                    clsSeleccionarInvernaderoVM seleccionInvernadero = new clsSeleccionarInvernaderoVM();

                    ViewBag.IdInvernaderoInicial = idInvernadero;
                    ViewBag.FechaInicial = fecha;
                    ViewBag.MostrarError = true;

                    return View("Index", seleccionInvernadero);
                    // A lo mejor no envío otra vista
                    //return View("ErrorSinDatos");
                }

            }
            catch (SqlException e)
            {
                // TODO: Lanzar mensaje de error. Vista Error
                return View("ErrorSql");
            }


        }

    }
}
