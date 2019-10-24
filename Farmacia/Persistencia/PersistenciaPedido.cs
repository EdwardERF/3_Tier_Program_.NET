using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaPedido
    {
        public static void Alta(Pedido oPed)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaPedido", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cliente", oPed.cliente);
            oComando.Parameters.AddWithValue("@rucMedicamento", oPed.rucMedicamento);
            oComando.Parameters.AddWithValue("@codMedicamento", oPed.codMedicamento);
            oComando.Parameters.AddWithValue("@cantidad", oPed.cantidad);

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

        public static void Eliminar(int oNum)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarPedido", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numero", oNum);

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
                    throw new Exception("Error - No existe tal Pedido");
                else if (valReturn == -2)
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

        public static Pedido Buscar(string oCliente, int oNum)
        {
            Int64 rucMedicamento;
            int codMedicamento, cantidad, estado;

            Pedido oPed = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarPedido", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cliente", oCliente);
            oComando.Parameters.AddWithValue("@numero", oNum);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    rucMedicamento = (Int64)oReader["rucMedicamento"];
                    codMedicamento = (int)oReader["codMedicamento"];
                    cantidad = (int)oReader["cantidad"];
                    estado = (int)oReader["estado"];

                    oPed = new Pedido(oNum, oCliente, rucMedicamento, codMedicamento, cantidad, estado);                }

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

            return oPed;
        }

        public static void CambioEstadoPedido(int oNum)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("CambioEstadoPedido", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numero", oNum);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int valReturn = (int)oComando.Parameters["@Retorno"].Value;

                if (valReturn == 1)
                    throw new Exception("Cambio de Estado exitoso");
                else if (valReturn == -1)
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

        public static List<Pedido> ListarTodo(string oCliente)
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarTodo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("cliente", oCliente);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];

                        oPed = PersistenciaPedido.Buscar(oCliente, oNum);

                        oLista.Add(oPed);
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

        public static List<Pedido> ListarGenerados()
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarGenerados", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];
                        string oCliente = (string)oReader["cliente"];

                        oPed = PersistenciaPedido.Buscar(oCliente, oNum);

                        oLista.Add(oPed);
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

        public static List<Pedido> ListarEnviados()
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarEnviados", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];
                        string oCliente = (string)oReader["cliente"];

                        oPed = PersistenciaPedido.Buscar(oCliente, oNum);

                        oLista.Add(oPed);
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

        public static List<Pedido> ListarEntregados(string oCliente)
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarEntregados", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("cliente", oCliente);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];

                        oPed = PersistenciaPedido.Buscar(oCliente, oNum);

                        oLista.Add(oPed);
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

        public static List<Pedido> ListarPedidosXMedicamento(Int64 oRUC, int oCodigo, string oCliente)
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarPedidosXMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("rucMedicamento", oRUC);
            oComando.Parameters.AddWithValue("codMedicamento", oCodigo);
            oComando.Parameters.AddWithValue("cliente", oCliente);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];

                        oPed = PersistenciaPedido.Buscar(oCliente, oNum);

                        oLista.Add(oPed);
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
