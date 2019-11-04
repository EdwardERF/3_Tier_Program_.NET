<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaEstadoPedidos.aspx.cs" Inherits="ConsultaEstadoPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="auto-style1">
            <div class="auto-style4">
            <p>Consulta de Estado de Pedido<br /></p>
            <p></p>
            </div>
            <table style="width:100%;">
                <tr>
                    <td>Sus pedidos</td>
                    <td>
                        <asp:DropDownList ID="ddlPedidos" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/BienvenidaCliente.aspx">Volver</asp:LinkButton>
        </div>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style4 {
        text-align: center;
    }
</style>
</asp:Content>
