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
        /// Muestra la vista principal con el formulario de selecci�n de invernadero y fecha.
        /// </summary>
        /// <returns>Vista Index con el ViewModel de selecci�n de invernadero.</returns>
        public IActionResult Index()
        {
            clsSeleccionarInvernaderoVM seleccionInvernadero;

            try
            {
                seleccionInvernadero = new clsSeleccionarInvernaderoVM();
            }
            catch (SqlException e)
            {
                // TODO: Lanzar mensaje de error. Vista Error
                return View("ErrorSql");
            }

            return View(seleccionInvernadero);
        }
        /// <summary>
        /// Retorna a la vista Index desde la vista Details pero con los datos seleccionados anteriormente.
        /// </summary>
        /// <param name="idInvernadero">ID del invernadero seleccionado.</param>
        /// <param name="fecha">Fecha seleccionada.</param>
        /// <returns>Vista Index con datos seleccionados.</returns>
        [HttpPost]
        public IActionResult Index(int idInvernadero, DateTime fecha)
        {
            clsSeleccionarInvernaderoVM seleccionInvernadero;

            try
            {
                seleccionInvernadero = new clsSeleccionarInvernaderoVM();

                // Asignar valores si vienen por par�metro

                // seleccionInvernadero.IdInvernaderoSeleccionado = idInvernadero; Con el ViewBag, esto ser� innecesario
                ViewBag.IdInvernaderoSeleccionado = idInvernadero;

                seleccionInvernadero.FechaSeleccionada = fecha;
            }
            catch (SqlException)
            {
                return View("ErrorSql");
            }

            return View(seleccionInvernadero);
        }

        /// <summary>
        /// Muestra los detalles de las temperaturas registradas para un invernadero en una fecha espec�fica.
        /// </summary>
        /// <param name="idInvernadero">ID del invernadero.</param>
        /// <param name="fecha">Fecha de consulta.</param>
        /// <returns>Vista con los detalles de temperatura o vista de error si no hay datos.</returns>
        public IActionResult Details(int idInvernadero, DateTime fecha)
        {
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
                    return View("ErrorSinDatos");
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
