<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaEstadoPedidos.aspx.cs" Inherits="ConsultaEstadoPedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="CSS/ConsultaEstadoPedidos.css" rel="stylesheet" type="text/css" />
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
            <div>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/Logo 2.png" />
            </div>
            <div class="Titulo">
            <p>Consulta de Estado de Pedido<br /></p>
            </div>
            <table id="Tabla" style="width:100%;">
                <tr>
                    <td>Sus pedidos</td>
                    <td>
                        <asp:TextBox ID="txtNumPedido" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                </tr>
            </table>
                <asp:RequiredFieldValidator ID="ValidatorTxtNumPedido" runat="server" ControlToValidate="txtNumPedido" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar un numero</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegExpTxtNumPedido" runat="server" ControlToValidate="txtNumPedido" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^\d+$">Solo se permiten numeros</asp:RegularExpressionValidator>
            <br />
                <div style="display: flex; justify-content: center" id="ContenedorMSG">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>
            <br />
            <br />
            <asp:LinkButton ID="lbVolver" runat="server" OnClick="lbVolver_Click">Volver</asp:LinkButton>
        </div>
    </form>
</body>
</html>
