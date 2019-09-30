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

        public static Usuario Logueo(string nomUsu, string pass)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            Usuario oUsu = null;

            oComando.Parameters.AddWithValue("@nomUsu", nomUsu);
            oComando.Parameters.AddWithValue("@pass", pass);

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows) //Si el lector puede leer, quiere decir que la pass es correcta
                {
                    if (PersistenciaCliente.Buscar(nomUsu) != null)
                    {
                        oUsu = PersistenciaCliente.Buscar(nomUsu);
                    }
                    else
                    {
                        oUsu = PersistenciaEmpleado.Buscar(nomUsu);
                    }
                }
                else
                {
                    oUsu = null;
                    throw new Exception("Usuario inexistente");
                }
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
