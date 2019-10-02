using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static void Eliminar(string nomUsu)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarUsuario", oConexion);
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

        public static Usuario Buscar(string nomUsu)
        {
            string pass, nombre, apellido;

            Usuario oUsu = null;

            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", nomUsu);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oParametro);

            try
            {
                Cliente oCli = PersistenciaCliente.Buscar(nomUsu);
                Empleado oEmp = PersistenciaEmpleado.Buscar(nomUsu);

                oConexion.Open();
                oReader = oComando.ExecuteReader();

                int valReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (valReturn == 1) //Si es valor 1, quiere decir que se encontro el usuario
                {
                    pass = (string)oReader["pass"];
                    nombre = (string)oReader["nombre"];
                    apellido = (string)oReader["apellido"];

                    if (oCli != null)
                    {
                        oUsu = new Cliente(nomUsu, pass, nombre, apellido, oCli.dirEntrega, oCli.Telefono);
                    }
                    else
                    {
                        oUsu = new Empleado(nomUsu, pass, nombre, apellido, oEmp.horaInicio, oEmp.horaFinal);
                    }
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

            return oUsu;
        }

        public static Usuario Logueo(string nomUsu, string pass)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", nomUsu);
            oComando.Parameters.AddWithValue("@pass", pass);

            Usuario oUsu = null;

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows) //Si el lector puede leer, quiere decir que la pass es correcta
                {
                    oUsu = PersistenciaUsuario.Buscar(nomUsu);
                }
                else
                {
                    oUsu = null;
                    throw new Exception("Usuario inexistente");
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

            return oUsu;
        }
    }
}
