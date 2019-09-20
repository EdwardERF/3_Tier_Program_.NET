<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMFarmaceutica.aspx.cs" Inherits="ABMFarmaceutica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 31px;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="ABMFarmaceutica" runat="server">
        <div>
            <div class="auto-style3">
                Mantenimiento de Farmaceuticas<br />
            </div>
            <table style="width:100%;">
                <tr>
                    <td>RUC</td>
                    <td>
                        <asp:TextBox ID="txtRuc" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>Nombre&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtNomFar" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Correo</td>
                    <td>
                        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Calle</td>
                    <td>
                        <asp:TextBox ID="txtCalle" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Numero</td>
                    <td>
                        <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Apto</td>
                    <td>
                        <asp:TextBox ID="txtApto" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAlta" runat="server" Text="Alta" />
                    </td>
                    <td>
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
                    </td>
                    <td>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
