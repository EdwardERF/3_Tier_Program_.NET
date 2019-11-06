<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="CSS/Default.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center">
                <strong>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/Logo 2.png" />
                <p></p>
                </strong>
                <table id="Datos" align="center" style="width: 271px">
                    <tr>
                        <td style="width: 347px">Nombre: &nbsp;&nbsp; <asp:TextBox ID="txtNomUsu" runat="server"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="ValidatorTxtNomUsu" runat="server" ControlToValidate="txtNomUsu" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar el nombre de usuario</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 347px">Password:&nbsp;
                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="ValidatorTxtPass" runat="server" ControlToValidate="txtPass" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar la clave</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 347px; height: 21px;">
                            <div id="Botones">
                                <asp:LinkButton ID="lbRegistro" runat="server" PostBackUrl="~/RegistroCliente.aspx" CausesValidation="False">Registrarse</asp:LinkButton>
                                <span style="color: #ff0066">
                                <asp:Button ID="btnLogueo" runat="server" Text="Login" OnClick="btnLogueo_Click" />
                                </span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 347px; height: 21px; text-align: center">
                                <br />
                                <asp:LinkButton ID="lbConsultaEP" runat="server" PostBackUrl="~/ConsultaEstadoPedidos.aspx">Consultar Estado de Pedido</asp:LinkButton>
                            <asp:Label ID="lblError" runat="server" Width="320px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
