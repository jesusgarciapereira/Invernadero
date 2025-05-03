using DAL.Conexion;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsListadosInvernaderosDAL
    {
        #region Métodos
        /// <summary>
        /// Obtiene el listado completo de Invernaderos de la BBDD.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsInvernadero</returns>
        public static List<clsInvernadero> ObtenerListadoInvernaderosDAL()
        {
            // Declaración de variables para la conexión y operaciones con la base de datos
            SqlConnection miConexion;                   // Objeto para la conexión a SQL Server
            SqlCommand miComando = new SqlCommand();    // Objeto para ejecutar comandos SQL
            SqlDataReader miLector;                     // Objeto para leer los resultados de la consulta

            List<clsInvernadero> listadoCompletoInvernaderos = new List<clsInvernadero>();
            clsInvernadero invernadero;

            try
            {
                // Establece la conexión con la base de datos
                miConexion = clsMyConnection.getConnection();

                // Configura el comando SQL que se va a ejecutar (consulta SELECT simple)
                miComando.CommandText = "SELECT * FROM Invernaderos";
                // Asigna la conexión al comando
                miComando.Connection = miConexion;
                // Ejecuta el comando y obtiene un lector de datos
                miLector = miComando.ExecuteReader();

                // Verifica si el lector contiene filas (si hay datos)
                if (miLector.HasRows)
                {
                    // Lee fila por fila mientras haya datos
                    while (miLector.Read())
                    {
                        // Crea un nuevo objeto clsInvernadero usando el constructor que recibe todos los PK
                        // Los cast son necesarios porque el lector devuelve objetos
                        invernadero = new clsInvernadero(
                            (int)miLector["idInvernadero"]
                            );

                        // Asigna el nombre del Invernadero, verificando primero que no sea NULL en la BD
                        if (miLector["nombre"] != DBNull.Value)
                        {
                            invernadero.Nombre = (string)miLector["nombre"];
                        }

                        listadoCompletoInvernaderos.Add(invernadero);
                    }
                }
                // Cierra el lector de datos (importante para liberar recursos)
                miLector.Close();
                // Cierra la conexión a la base de datos usando el método de la clase de conexión
                clsMyConnection.closeConnection(ref miConexion);
            }
            catch (SqlException exSql)
            {
                // Captura excepciones específicas de SQL y las relanza
                throw exSql;
            }

            // Devuelve la lista completa de luchadores obtenida de la base de datos
            return listadoCompletoInvernaderos;
        }
        //public static clsInvernadero ObtenerInvernaderoPorIdDAL(int id)
        //{ // Creo que me hará falta para obtener el nombre (¿o eso será en clsListadosLuchadoresConPuntuacionTotalDAL?)
        //  // TODO: Obtén de la Base de Datos el invernadero correspondiente al id del parámetro
        //}

        #endregion

    }
}
