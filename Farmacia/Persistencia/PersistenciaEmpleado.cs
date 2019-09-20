using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;
using Logica;

namespace Persistencia
{
    public class PersistenciaEmpleado
    {
        public static void Eliminar(string nomUsu)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", nomUsu);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int valReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (valReturn == 1)
                    throw new Exception("Eliminacion exitosa");
                else if (valReturn == -1)
                    throw new Exception("Error SQL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Empleado Logueo(string nomUsu, string pass)
        {
            string nombre, apellido, horaInicio, horaFinal;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            Empleado oEmp = null;

            oComando.Parameters.AddWithValue("@nomUsu", nomUsu);
            oComando.Parameters.AddWithValue("@pass", pass);

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if(oReader.HasRows)
                {
                    oReader.Read();
                    nombre = (string)oReader["nombre"];
                    apellido = (string)oReader["apellido"];
                    horaInicio = (string)oReader["horaInicio"];
                    horaFinal = (string)oReader["horaFinal"];

                    oEmp = new Empleado(nomUsu, pass, nombre, apellido, horaInicio, horaFinal);
                }

                oReader.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return oEmp;
        }
    }
}
