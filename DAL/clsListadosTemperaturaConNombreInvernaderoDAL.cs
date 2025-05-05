using DAL.Conexion;
using DTO;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsListadosTemperaturaConNombreInvernaderoDAL
    {
        #region Metodos
        /// <summary>
        /// Obtiene el listado completo de Temperaturas con el nombre del Invernadero de la BBDD.
        /// Pre: Ninguna
        /// Post: Ninguna
        /// </summary>
        /// <returns>Una lista de objetos de tipo clsTemperaturaConNombreInvernadero</returns>
        public static List<clsTemperaturaConNombreInvernadero> ObtenerListadoTemperaturasConNombreInvernaderoDAL()
        {

            // Declaración de variables para la conexión y operaciones con la base de datos
            SqlConnection miConexion;                   // Objeto para la conexión a SQL Server
            SqlCommand miComando = new SqlCommand();    // Objeto para ejecutar comandos SQL
            SqlDataReader miLector;                     // Objeto para leer los resultados de la consulta

            List<clsTemperaturaConNombreInvernadero> listadoCompletoTemperaturasConNombreInvernadero = new List<clsTemperaturaConNombreInvernadero>();
            clsTemperaturaConNombreInvernadero temperaturaConNombreInvernadero;
            clsTemperatura temperatura;
            string nombreInvernadero = "(Sin nombre)";

            try
            {
                // Establece la conexión con la base de datos
                miConexion = clsMyConnection.getConnection();

                // Configura el comando SQL que se va a ejecutar (consulta SELECT simple)
                miComando.CommandText = "SELECT Temperaturas.*, Invernaderos.nombre AS nombreInvernadero FROM Temperaturas " +
                                            "INNER JOIN Invernaderos ON Temperaturas.idInvernadero = Invernaderos.idInvernadero;";
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
                        // Crea un nuevo objeto clsCombate usando el constructor que recibe todos los PK
                        // Los cast son necesarios porque el lector devuelve objetos
                        temperatura = new clsTemperatura(
                            (int)miLector["idInvernadero"],
                            (DateTime)miLector["fecha"]
                            );

                        // Asigna las temp y humedades, verificando primero que no sea NULL en la BD
                        if (miLector["temp1"] != DBNull.Value)
                        {
                            temperatura.Temp1 = (double)(decimal)miLector["temp1"];
                        }

                        if (miLector["temp2"] != DBNull.Value)
                        {
                            temperatura.Temp2 = (double)(decimal)miLector["temp2"];
                        }

                        if (miLector["temp3"] != DBNull.Value)
                        {
                            temperatura.Temp3 = (double)(decimal)miLector["temp3"];
                        }

                        if (miLector["humedad1"] != DBNull.Value)
                        {
                            temperatura.Humedad1 = (int)miLector["humedad1"];
                        }

                        if (miLector["humedad2"] != DBNull.Value)
                        {
                            temperatura.Humedad2 = (int)miLector["humedad2"];
                        }

                        if (miLector["humedad3"] != DBNull.Value)
                        {
                            temperatura.Humedad3 = (int)miLector["humedad3"];
                        }

                        if (miLector["nombreInvernadero"] != DBNull.Value) 
                        {
                            nombreInvernadero = (string)miLector["nombreInvernadero"];
                        }

                        temperaturaConNombreInvernadero = new clsTemperaturaConNombreInvernadero(temperatura, nombreInvernadero);

                        listadoCompletoTemperaturasConNombreInvernadero.Add(temperaturaConNombreInvernadero);

                        // Por si se diera el caso hipotético de que algún nombreInvernadero fuera null, esto evita usar un nombre tomado anteriormente
                        nombreInvernadero = "(Sin nombre)";
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
            return listadoCompletoTemperaturasConNombreInvernadero;
        }

        /// <summary>
        /// Obtiene las Temperaturas con el nombre del Invernadero correspondiente las PK que se le pasa por parámetro
        /// </summary>
        /// <param name="idInvernadero"></param>
        /// <param name="fecha"></param>
        /// <returns>Objeto de tipo clsTemperaturaConNombreInvernadero</returns>
        public static clsTemperaturaConNombreInvernadero ObtenerTemperaturasConNombreInvernaderoPorPKDAL(int idInvernadero, DateTime fecha) 
        {
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            clsTemperaturaConNombreInvernadero temperaturaConNombreInvernadero = null;
            clsTemperatura temperatura;
            string nombreInvernadero = "(Sin nombre)";

            // Recuerda poner el tipo que corresponda (Int, Varchar, Date...)
            miComando.Parameters.Add("@idInvernadero", SqlDbType.Int).Value = idInvernadero;
            miComando.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;

            try
            {
                miConexion = clsMyConnection.getConnection();

                miComando.CommandText = "SELECT Temperaturas.*, Invernaderos.nombre AS nombreInvernadero FROM Temperaturas " +
                                            "INNER JOIN Invernaderos ON Temperaturas.idInvernadero = Invernaderos.idInvernadero " +
                                            "WHERE Temperaturas.idInvernadero = @idInvernadero AND Temperaturas.fecha = @fecha";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        // Lo que va entre los corchetes son los nombres de las columnas de la tabla

                        // Crea un nuevo objeto clsTemperatura usando el constructor que recibe todos los PK
                        // Los cast son necesarios porque el lector devuelve objetos
                        temperatura = new clsTemperatura(
                            (int)miLector["idInvernadero"],
                            (DateTime)miLector["fecha"]
                            );

                        // Asigna las temp y humedades, verificando primero que no sea NULL en la BD
                        if (miLector["temp1"] != DBNull.Value)
                        {
                            temperatura.Temp1 = (double)(decimal)miLector["temp1"];
                        }

                        if (miLector["temp2"] != DBNull.Value)
                        {
                            temperatura.Temp2 = (double)(decimal)miLector["temp2"];
                        }

                        if (miLector["temp3"] != DBNull.Value)
                        {
                            temperatura.Temp3 = (double)(decimal)miLector["temp3"];
                        }

                        if (miLector["humedad1"] != DBNull.Value)
                        {
                            temperatura.Humedad1 = (int)miLector["humedad1"];
                        }

                        if (miLector["humedad2"] != DBNull.Value)
                        {
                            temperatura.Humedad2 = (int)miLector["humedad2"];
                        }

                        if (miLector["humedad3"] != DBNull.Value)
                        {
                            temperatura.Humedad3 = (int)miLector["humedad3"];
                        }

                        if (miLector["nombreInvernadero"] != DBNull.Value)
                        {
                            nombreInvernadero = (string)miLector["nombreInvernadero"];
                        }

                        temperaturaConNombreInvernadero = new clsTemperaturaConNombreInvernadero(temperatura, nombreInvernadero);
                    }
                }
                miLector.Close();
                clsMyConnection.closeConnection(ref miConexion);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return temperaturaConNombreInvernadero;
        }
        #endregion
    }
}

