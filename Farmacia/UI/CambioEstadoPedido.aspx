<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CambioEstadoPedido.aspx.cs" Inherits="CambioEstadoPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style1">
            Cambio de Estado de Pedido</p>
        <p>
            <asp:GridView ID="gvEstadoPedido" runat="server" AutoGenerateSelectButton="True">
            </asp:GridView>
        </p>
        <p>
            <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar Estado" />
        </p>
        <p class="auto-style1">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
        <p class="auto-style1">
            <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
        </p>
    </form>
</body>
</html>
