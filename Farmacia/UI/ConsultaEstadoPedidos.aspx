<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaEstadoPedidos.aspx.cs" Inherits="ConsultaEstadoPedidos" %>

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
        <div class="auto-style1">
            Consulta de Estado de Pedido<br />
            <table style="width:100%;">
                <tr>
                    <td>Número de Pedido</td>
                    <td>
                        <asp:TextBox ID="txtNumPedido" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Button" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
