using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaMedicamento
    {
        public static void Alta(Medicamento oMed)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@far", oMed.Ruc);
            oComando.Parameters.AddWithValue("@codigo", oMed.Codigo);
            oComando.Parameters.AddWithValue("@nombre", oMed.Nombre);
            oComando.Parameters.AddWithValue("@descripcion", oMed.Descripcion);
            oComando.Parameters.AddWithValue("@precio", oMed.Precio);

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
                else if (valReturn == -1)
                    throw new Exception("Error - Ya existe tal Medicamento");
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

        public static void Modificar(Medicamento oMed)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@far", oMed.Ruc);
            oComando.Parameters.AddWithValue("@codigo", oMed.Codigo);
            oComando.Parameters.AddWithValue("@nombre", oMed.Nombre);
            oComando.Parameters.AddWithValue("@descripcion", oMed.Descripcion);
            oComando.Parameters.AddWithValue("@precio", oMed.Precio);

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
                    throw new Exception("Error - No existe tal Medicamento");
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

        public static void Eliminar(Int64 oRUC, int oCodigo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@far", oRUC);
            oComando.Parameters.AddWithValue("@codigo", oCodigo);

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
                    throw new Exception("Error - No existe Medicamento");
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

        public static Medicamento Buscar(Int64 oRUC, int oCodigo)
        {
            Int64 ruc;
            int codigo, precio;
            string nombre, descripcion;

            Medicamento oMed = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@far", oRUC);
            oComando.Parameters.AddWithValue("@codigo", oCodigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    ruc = (Int64)oReader["ruc"];
                    codigo = (int)oReader["codigo"];
                    precio = (int)oReader["precio"];
                    nombre = (string)oReader["nombre"];
                    descripcion = (string)oReader["descripcion"];

                    Farmaceutica oFar = PersistenciaFarmaceutica.Buscar(ruc);

                    oMed = new Medicamento(oFar, codigo, nombre, descripcion, precio);
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

            return oMed;
        }

        public static List<Medicamento> Listar()
        {
            Medicamento oMed;
            List<Medicamento> oLista = new List<Medicamento>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Int64 ruc = (Int64)oReader["ruc"];

                        Farmaceutica oFar = PersistenciaFarmaceutica.Buscar(ruc);

                        oMed = new Medicamento(oFar, (int)oReader["codigo"], (string)oReader["nombre"], (string)oReader["descripcion"],
                            (int)oReader["precio"]);

                        oLista.Add(oMed);
                    }

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

            return oLista;
        }

        public static List<Medicamento> ListarMedicamentoUnico(Int64 oRUC, int oCodigo)
        {
            Medicamento oMed;
            List<Medicamento> oLista = new List<Medicamento>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarMedicamentoUnico", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ruc", oRUC);
            oComando.Parameters.AddWithValue("@codigo", oCodigo);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if(oReader.HasRows)
                {
                    oReader.Read();

                    Int64 ruc = (Int64)oReader["ruc"];
                    int codigo = (int)oReader["codigo"];
                    string nombre = (string)oReader["nombre"];
                    string descripcion = (string)oReader["descripcion"];
                    int precio = (int)oReader["precio"];

                    Farmaceutica oFar = PersistenciaFarmaceutica.Buscar(ruc);

                    oMed = new Medicamento(oFar, codigo, nombre, descripcion, precio);

                    oLista.Add(oMed);
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

            return oLista;
        }

        public static List<Medicamento> ListarMedicamentosXFarmaceutica(Int64 oRUC)
        {
            Medicamento oMed;
            List<Medicamento> oLista = new List<Medicamento>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarMedicamentosXFarmaceutica", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("ruc", oRUC);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int oCodigo = (int)oReader["codigo"];

                        oMed = PersistenciaMedicamento.Buscar(oRUC, oCodigo);

                        oLista.Add(oMed);
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
