<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMFarmaceutica.aspx.cs" Inherits="ABMFarmaceutica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="Contenedor">
            <div class="auto-style4">
                <p>Mantenimiento de Farmaceuticas<br /></p>
                <p></p>
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
                    <td class="auto-style5">
                        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"></td>
                    <td class="Validadores">
                        <asp:RequiredFieldValidator ID="valtxtruc" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtRuc">Debe ingresar un RUC</asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegExpTxtRuc" runat="server" ControlToValidate="txtRuc" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^\d+$">RUC: solo se permiten numeros</asp:RegularExpressionValidator><br />
                        <asp:RequiredFieldValidator ID="valtxtnombre" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtNomFar">Debe ingresar un nombre</asp:RequiredFieldValidator><br />
                        <asp:RequiredFieldValidator ID="valtxtcorreo" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtCorreo">Debe ingresar un correo</asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegExpTxtCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">Email no valido</asp:RegularExpressionValidator><br />
                        <asp:RequiredFieldValidator ID="valtxtcalle" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtCalle">Debe ingresar una calle</asp:RequiredFieldValidator><br />
                        <asp:RequiredFieldValidator ID="valtxtnumero" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000" ControlToValidate="txtNumero">Debe ingresar un numero</asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegExpTxtNumero" runat="server" ControlToValidate="txtNumero" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^\d+$">Precio: solo se permiten numeros</asp:RegularExpressionValidator><br />
                    </td>
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
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/BienvenidaEmpleado.aspx" CausesValidation="False">Volver</asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
        .Contenedor {
            display: block;
            justify-content: center;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }
        .auto-style5 {
            height: 101px;
        }
        .Validadores {
            display: block;
        }
    </style>
</asp:Content>
