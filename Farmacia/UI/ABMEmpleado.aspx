<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMEmpleado.aspx.cs" Inherits="ABMEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <p class="auto-style4">
            Mantenimiento de Empleados</p>
        <p></p>
            <table style="width:100%;">
                <tr>
                    <td>Nombre de Usuario</td>
                    <td class="TablaMedio">
                        <asp:TextBox ID="txtNomUsu" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>Contraseña</td>
                    <td class="TablaMedio">
                        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td>Nombre</td>
                    <td class="TablaMedio">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td>Apellido</td>
                    <td class="TablaMedio">
                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td>Hora Inicio Jornada</td>
                    <td class="TablaMedio">
                        <asp:TextBox ID="txtHoraInicio" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td>Hora Final Jornada</td>
                    <td class="TablaMedio">
                        <asp:TextBox ID="txtHoraFinal" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
                    </td>
                    <td class="TablaMedio">
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="Validadores">
                        <asp:RequiredFieldValidator ID="valtxtnomusu" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtNomUsu">Debe ingresar un nombre de usuario</asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="valtxtpass" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtPass">Debe ingresar una clave</asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="valtxtnombre" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtNombre">Debe ingresar un nombre</asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="valtxtapellido" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtApellido">Debe ingresar un apellido</asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="valtxtHoraInicio" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtHoraInicio">Debe ingresar el inicio de jornada</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegExpTxtHoraInicio" runat="server" ControlToValidate="txtHoraInicio" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9])$">Hora no valida</asp:RegularExpressionValidator><br />
                        <asp:RequiredFieldValidator ID="valtxtHoraFinal" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtHoraFinal">Debe ingresar el final de jornada</asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegExpTxtHoraFinal" runat="server" ControlToValidate="txtHoraFinal" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9])$">Hora no valida</asp:RegularExpressionValidator><br />
                    </td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/BienvenidaEmpleado.aspx" CausesValidation="False">Volver</asp:LinkButton>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                </tr>
            </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 168px;
            height: 31px;
        }
        .TablaMedio {
            width: 300px;
        }
        
        .Validadores {
            display: block;
        }

        .auto-style6 {
            width: 168px;
        }
        
    </style>
</asp:Content>

