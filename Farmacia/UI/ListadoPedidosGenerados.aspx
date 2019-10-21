<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoPedidosGenerados.aspx.cs" Inherits="ListadoPedidosGenerados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="auto-style4">
            <div class="auto-style4">
            Listado de Pedidos Generados - Eliminar Pedido<br />
            </div>
            <table class="auto-style1">
                <tr>
                    <td>Totalidad de Pedidos</td>
                    <td>
                        <asp:GridView ID="gvListadoPedidos" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvListadoPedidos_SelectedIndexChanged">
                        </asp:GridView>
                        <br />
                        <asp:Label ID="lblCliente" runat="server"></asp:Label>
                        <br />
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
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Pedido" OnClick="btnEliminar_Click" />
                        <br />
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

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
    </style>
</asp:Content>
