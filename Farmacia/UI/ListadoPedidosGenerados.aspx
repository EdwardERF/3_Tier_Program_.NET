<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoPedidosGenerados.aspx.cs" Inherits="ListadoPedidosGenerados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="auto-style4">
            <div class="auto-style4">
            <p>Listado de Pedidos Generados - Eliminar Pedido<br /></p>
            <p></p>
            </div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:GridView style="margin-left:auto; margin-right:auto" ID="gvListadoPedidos" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvListadoPedidos_SelectedIndexChanged" OnPageIndexChanging="gvListadoPedidos_PageIndexChanging" AllowPaging="True" PageSize="6">
                        </asp:GridView>
                        <br />
                        <asp:Label ID="lblCliente" runat="server"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:GridView style="margin-left:auto; margin-right:auto" ID="gvSeleccion" runat="server" AllowPaging="True" PageSize="6">
                        </asp:GridView>
                        <br />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Pedido" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
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
                        <asp:LinkButton ID="lkVolver" runat="server" PostBackUrl="~/BienvenidaCliente.aspx">Volver</asp:LinkButton>
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
