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

                //if (valReturn == 1)
                //    throw new Exception("Eliminacion exitosa");
                if (valReturn == -1)
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
                    //numero = (int)oReader["numero"];
                    rucMedicamento = (Int64)oReader["rucMedicamento"];
                    codMedicamento = (int)oReader["codMedicamento"];
                    cantidad = (int)oReader["cantidad"];
                    estado = (int)oReader["estado"];

                    Cliente cliente = PersistenciaCliente.Buscar(oCliente);
                    Medicamento oMed = PersistenciaMedicamento.Buscar(rucMedicamento, codMedicamento);

                    oPed = new Pedido(oNum, cliente, oMed, cantidad, estado);
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

            return oPed;
        }

        public static Pedido BuscarXCliente(string oCliente)
        {
            Int64 rucMedicamento;
            int codMedicamento, cantidad, estado, oNum;

            Pedido oPed = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarPedidoXCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cliente", oCliente);

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
                    oNum = (int)oReader["numero"];

                    Cliente cliente = PersistenciaCliente.Buscar(oCliente);
                    Medicamento oMed = PersistenciaMedicamento.Buscar(rucMedicamento, codMedicamento);

                    oPed = new Pedido(oNum, cliente, oMed, cantidad, estado);
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

            return oPed;
        }

        public static Pedido BuscarPorNumero(int oNum)
        {
            Int64 rucMedicamento;
            int codMedicamento, cantidad, estado;
            string oCliente;

            Pedido oPed = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarPedidoXNumero", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numero", oNum);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    oCliente = (string)oReader["cliente"];
                    rucMedicamento = (Int64)oReader["rucMedicamento"];
                    codMedicamento = (int)oReader["codMedicamento"];
                    cantidad = (int)oReader["cantidad"];
                    estado = (int)oReader["estado"];

                    Cliente cliente = PersistenciaCliente.Buscar(oCliente);
                    Medicamento oMed = PersistenciaMedicamento.Buscar(rucMedicamento, codMedicamento);

                    oPed = new Pedido(oNum, cliente, oMed, cantidad, estado);
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

        public static List<Pedido> ListarGeneradosXCliente(string oCliente)
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarGeneradosXCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cliente", oCliente);

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

        public static List<string> ListarNumeroXCliente(string oCliente)
        {
            string Numero;
            List<string> oLista = new List<string>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarNumeroPedidoXCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@cliente", oCliente);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];

                        Numero = Convert.ToString(oNum);

                        oLista.Add(Numero);
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

        public static List<Pedido> ListarPedidosXMedicamento(Int64 oRUC, int oCodigo)
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarPedidosXMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("rucMedicamento", oRUC);
            oComando.Parameters.AddWithValue("codMedicamento", oCodigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];

                        oPed = PersistenciaPedido.BuscarPorNumero(oNum);

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

        public static List<Pedido> ListarPedidosGeneradosXMedicamento(Int64 oRUC, int oCodigo)
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarPedidosGeneradosXMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("rucMedicamento", oRUC);
            oComando.Parameters.AddWithValue("codMedicamento", oCodigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];

                        oPed = PersistenciaPedido.BuscarPorNumero(oNum);

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

        public static List<Pedido> ListarPedidosEnviadosXMedicamento(Int64 oRUC, int oCodigo)
        {
            Pedido oPed;
            List<Pedido> oLista = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarPedidosEnviadosXMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("rucMedicamento", oRUC);
            oComando.Parameters.AddWithValue("codMedicamento", oCodigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oNum = (int)oReader["numero"];

                        oPed = PersistenciaPedido.BuscarPorNumero(oNum);

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
