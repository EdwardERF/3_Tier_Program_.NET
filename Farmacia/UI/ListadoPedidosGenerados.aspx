<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoPedidosGenerados.aspx.cs" Inherits="ListadoPedidosGenerados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Listado de Pedidos Generados - Eliminar Pedido<br />
            <table class="auto-style1">
                <tr>
                    <td>Totalidad de Pedidos</td>
                    <td>
                        <asp:GridView ID="gvListadoPedidos" runat="server" AutoGenerateSelectButton="True">
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnVerDetalles" runat="server" Text="Ver Detalles" />
                        <br />
                        <br />
                        <asp:Label ID="lblCliente" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPedidoSeleccionado" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:GridView ID="gvSeleccion" runat="server">
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Pedido" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:LinkButton ID="lkVolver" runat="server">Volver</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
