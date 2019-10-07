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

        public static void CambioEstadoPedido(int oNum)
        {
            PersistenciaPedido.CambioEstadoPedido(oNum);
        }

        public static List<Pedido> ListarTodo(string oCliente)
        {
            return PersistenciaPedido.ListarTodo(oCliente);
        }

        public static List<Pedido> ListarGenerados(string oCliente)
        {
            return PersistenciaPedido.ListarGenerados(oCliente);
        }

        public static List<Pedido> ListarEnviados(string oCliente)
        {
            return PersistenciaPedido.ListarEnviados(oCliente);
        }

        public static List<Pedido> ListarGeneradosYEnviados(string oCliente)
        {
            List<Pedido> oLista = new List<Pedido>();
            oLista.AddRange(ListarGenerados(oCliente));
            oLista.AddRange(ListarEnviados(oCliente));

            return oLista;
        }

        public static List<Pedido> ListarEntregados(string oCliente)
        {
            return PersistenciaPedido.ListarEntregados(oCliente);
        }

        public static List<Pedido> ListarPedidosXMedicamento(Int64 oRUC, int oCodigo, string oCliente)
        {
            return PersistenciaPedido.ListarPedidosXMedicamento(oRUC, oCodigo, oCliente);
        }
    }
}
