<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CambioEstadoPedido.aspx.cs" Inherits="CambioEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Contenedor">
        <p>
            Cambio de Estado de Pedido</p>
        <p>
            <asp:GridView style="margin-left:auto; margin-right:auto" ID="gvEstadoPedido" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvEstadoPedido_SelectedIndexChanged" >
            </asp:GridView>
        </p>
        <p>
            <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar Estado" OnClick="btnCambiarEstado_Click" />
        </p>
        <p>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/BienvenidaEmpleado.aspx">Volver</asp:LinkButton>
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .Contenedor {
            display: block;
            justify-content: center;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }
    </style>
</asp:Content>


