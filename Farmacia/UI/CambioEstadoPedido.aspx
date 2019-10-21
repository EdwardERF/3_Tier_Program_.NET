<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CambioEstadoPedido.aspx.cs" Inherits="CambioEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <p class="auto-style4">
            Cambio de Estado de Pedido</p>
        <p>
            <asp:GridView ID="gvEstadoPedido" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvEstadoPedido_SelectedIndexChanged">
            </asp:GridView>
        </p>
        <p>
            <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar Estado" OnClick="btnCambiarEstado_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
   
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
    </style>
</asp:Content>
