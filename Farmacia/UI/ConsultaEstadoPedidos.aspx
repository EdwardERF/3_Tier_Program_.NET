<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaEstadoPedidos.aspx.cs" Inherits="ConsultaEstadoPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="auto-style1">
            <div class="auto-style4">
            Consulta de Estado de Pedido<br />
            </div>
            <table style="width:100%;">
                <tr>
                    <td>Número de Pedido</td>
                    <td>
                        <asp:TextBox ID="txtNumPedido" runat="server"></asp:TextBox>
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
            <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
        </div>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
    </style>
</asp:Content>
