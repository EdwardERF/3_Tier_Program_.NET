using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPedido
    {
        public static void Alta(Pedido oPed)
        {
            PersistenciaPedido.Alta(oPed);
        }

        public static void Eliminar(int oNum)
        {
            PersistenciaPedido.Eliminar(oNum);
        }

        public static Pedido Buscar(string oCliente, int oNum)
        {
            Pedido oPed = PersistenciaPedido.Buscar(oCliente, oNum);
            return oPed;
        }

        public static Pedido BuscarXCliente(string oCliente)
        {
            Pedido oPed = PersistenciaPedido.BuscarXCliente(oCliente);
            return oPed;
        }

        public static void CambioEstadoPedido(int oNum)
        {
            PersistenciaPedido.CambioEstadoPedido(oNum);
        }

        public static List<Pedido> ListarTodo(string oCliente)
        {
            return PersistenciaPedido.ListarTodo(oCliente);
        }

        public static List<Pedido> ListarGenerados()
        {
            return PersistenciaPedido.ListarGenerados();
        }

        public static List<Pedido> ListarGeneradosXCliente(string oCliente)
        {
            return PersistenciaPedido.ListarGeneradosXCliente(oCliente);
        }

        public static List<string> ListarNumeroXCliente(string oCliente)
        {
            return PersistenciaPedido.ListarNumeroXCliente(oCliente);
        }

        public static List<Pedido> ListarEnviados()
        {
            return PersistenciaPedido.ListarEnviados();
        }

        public static List<Pedido> ListarGeneradosYEnviados()
        {
            List<Pedido> oLista = new List<Pedido>();
            oLista.AddRange(ListarGenerados());
            oLista.AddRange(ListarEnviados());

            return oLista;
        }

        public static List<Pedido> ListarEntregados(string oCliente)
        {
            return PersistenciaPedido.ListarEntregados(oCliente);
        }

        public static List<Pedido> ListarPedidosXMedicamento(Int64 oRUC, int oCodigo)
        {
            return PersistenciaPedido.ListarPedidosXMedicamento(oRUC, oCodigo);
        }

        public static List<Pedido> ListarPedidosGeneradosXMedicamento(Int64 oRUC, int oCodigo)
        {
            return PersistenciaPedido.ListarPedidosGeneradosXMedicamento(oRUC, oCodigo);
        }

        public static List<Pedido> ListarPedidosEnviadosXMedicamento(Int64 oRUC, int oCodigo)
        {
            return PersistenciaPedido.ListarPedidosEnviadosXMedicamento(oRUC, oCodigo);
        }
    }
}
