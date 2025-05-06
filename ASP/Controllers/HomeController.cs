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
