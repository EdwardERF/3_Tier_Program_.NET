using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaEmpleado
    {
        public static void Alta(Empleado oEmp)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", oEmp.nomUsu);
            oComando.Parameters.AddWithValue("@pass", oEmp.pass);
            oComando.Parameters.AddWithValue("@nombre", oEmp.nombre);
            oComando.Parameters.AddWithValue("@apellido", oEmp.apellido);
            oComando.Parameters.AddWithValue("@horaInicio", oEmp.horaInicio);
            oComando.Parameters.AddWithValue("@horaFinal", oEmp.horaFinal);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int valReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (valReturn == 1)
                    throw new Exception("Alta exitosa");
                if (valReturn == -1)
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

        public static void Modificar(Empleado oEmp)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", oEmp.nomUsu);
            oComando.Parameters.AddWithValue("@pass", oEmp.pass);
            oComando.Parameters.AddWithValue("@nombre", oEmp.nombre);
            oComando.Parameters.AddWithValue("@apellido", oEmp.apellido);
            oComando.Parameters.AddWithValue("@horaInicio", oEmp.horaInicio);
            oComando.Parameters.AddWithValue("@horaFinal", oEmp.horaFinal);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int valReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (valReturn == 1)
                    throw new Exception("Modificacion exitosa");
                else if (valReturn == -1)
                    throw new Exception("Error SQL");
                else if (valReturn == -2)
                    throw new Exception("Error - Esta intentando modificar un cliente");
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

        public static void Eliminar(Empleado oEmp)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", oEmp.nomUsu);

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

        public static Empleado Buscar(string nomUsu)
        {
            string pass, nombre, apellido, horaInicio, horaFinal;

            Empleado oEmp = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", nomUsu);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    pass = (string)oReader["pass"];
                    nombre = (string)oReader["nombre"];
                    apellido = (string)oReader["apellido"];
                    horaInicio = (string)oReader["horaInicio"];
                    horaFinal = (string)oReader["horaFinal"];

                    oEmp = new Empleado(nomUsu, pass, nombre, apellido, horaInicio, horaFinal);
                }

                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return oEmp;
        }

        public static Empleado Logueo(string nomUsu, string pass)
        {
            Empleado oEmp = null;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", nomUsu);
            oComando.Parameters.AddWithValue("@pass", pass);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if(oReader.Read())
                {
                    string nombre = (string)oReader["nombre"];
                    string apellido = (string)oReader["apellido"];
                    string horaInicio = (string)oReader["horaInicio"];
                    string horaFinal = (string)oReader["horaFinal"];

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
