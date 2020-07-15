using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;
using System.Runtime.Remoting.Messaging;

namespace Persistencia
{
    public class PersistenciaFarmaceutica
    {
        public static void Alta(Farmaceutica oFar)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaFarmaceutica", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ruc", oFar.ruc);
            oComando.Parameters.AddWithValue("@nombre", oFar.nombre);
            oComando.Parameters.AddWithValue("@correo", oFar.correo);
            oComando.Parameters.AddWithValue("@calle", oFar.calle);
            oComando.Parameters.AddWithValue("@numero", oFar.numero);
            oComando.Parameters.AddWithValue("@apto", oFar.apto);

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
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

        }

        public static void Modificar(Farmaceutica oFar)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarFarmaceutica", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ruc", oFar.ruc);
            oComando.Parameters.AddWithValue("@nombre", oFar.nombre);
            oComando.Parameters.AddWithValue("@correo", oFar.correo);
            oComando.Parameters.AddWithValue("@calle", oFar.calle);
            oComando.Parameters.AddWithValue("@numero", oFar.numero);
            oComando.Parameters.AddWithValue("@apto", oFar.apto);

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

        public static void Eliminar(Farmaceutica oFar)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarFarmaceutica", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ruc", oFar.ruc);

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
                else if (valReturn == -2)
                    throw new Exception("Error - Pedidos asociados a Farmaceutica");
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

        public static Farmaceutica Buscar(Int64 oRUC)
        {
            string nombre, correo, calle;
            int numero, apto;

            Farmaceutica oFar = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarFarmaceutica", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ruc", oRUC);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if(oReader.Read())
                {
                    nombre = (string)oReader["nombre"];
                    correo = (string)oReader["correo"];
                    calle = (string)oReader["calle"];
                    numero = (int)oReader["numero"];

                    if(oReader["apto"] != DBNull.Value)
                    {
                        apto = (int)oReader["apto"];
                    }
                    else
                    {
                        apto = 0;
                    }

                    oFar = new Farmaceutica(oRUC, nombre, correo, calle, numero, apto);
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

            return oFar;
        }

        public static Farmaceutica BuscarXNombre(string Nombre)
        {
            string correo, calle;
            int numero, apto;
            Int64 ruc;

            Farmaceutica oFar = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarFarmaceuticaXNombre", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nombre", Nombre);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    ruc = (Int64)oReader["ruc"];
                    correo = (string)oReader["correo"];
                    calle = (string)oReader["calle"];
                    numero = (int)oReader["numero"];

                    if(oReader["apto"] != DBNull.Value)
                    {
                        apto = (int)oReader["apto"];
                    }
                    else
                    {
                        apto = 1;
                    }

                    oFar = new Farmaceutica(ruc, Nombre, correo, calle, numero, apto);
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

            return oFar;
        }

        public static List<Farmaceutica> ListarFarmaceuticas()
        {
            Farmaceutica oFar;
            Int64 ruc;
            List<Farmaceutica> oLista = new List<Farmaceutica>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarFarmaceuticas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        ruc = (Int64)oReader["ruc"];

                        oFar = PersistenciaFarmaceutica.Buscar(ruc);

                        oLista.Add(oFar);
                    }

                    oReader.Close();
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

            return oLista;
        }
    }
}
