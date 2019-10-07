<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CambioEstadoPedido.aspx.cs" Inherits="CambioEstadoPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
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
    </form>
</body>
</html>
