<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroCliente.aspx.cs" Inherits="RegistroCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="CSS/RegistroCliente.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">

        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="auto-style3">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/Logo 2.png" />
                <br />
                Registro de Cliente<br />
            <p></p>
            </div>
                <table id="Tabla" style="width:100%;">
                    <tr>
                        <td>Nombre de Usuario</td>
                        <td>
                            <asp:TextBox ID="txtNomUsu" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>Contraseña</td>
                        <td>
                            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Nombre</td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Apellido</td>
                        <td>
                            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Direccion de Entrega</td>
                        <td>
                            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Telefono</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style4"></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5"></td>
                        <td class="auto-style5">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style5"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:LinkButton ID="lbVolver" runat="server" OnClick="lbVolver_Click">Volver</asp:LinkButton>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
        </div>
    </form>
</body>
</html>