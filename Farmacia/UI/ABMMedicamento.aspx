<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMMedicamento.aspx.cs" Inherits="ABMMedicamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <p class="auto-style4">
            Mantenimiento de Medicamentos</p>
        <table style="width:100%;">
            <tr>
                <td>RUC</td>
                <td>
                    <asp:TextBox ID="txtRucMedicamento" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td>Codigo</td>
                <td>
                    <asp:TextBox ID="txtCodMedicamento" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txtNombreMed" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Descripcion</td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Precio</td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
                </td>
                <td>
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                </td>
                <td>
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CausesValidation="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="Validadores">
                    <asp:RequiredFieldValidator ID="valtxtRucMedicamento" runat="server" ControlToValidate="txtRucMedicamento" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar un RUC</asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegExpTxtRucMedicamento" runat="server" ControlToValidate="txtRucMedicamento" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^\d+$">RUC: solo se permiten numeros</asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="valtxtCodMedicamento" runat="server" ControlToValidate="txtCodMedicamento" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar un Codigo de Medicamento</asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegExpTxtCodMedicamento" runat="server" ControlToValidate="txtCodMedicamento" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^\d+$">Codigo: solo se permiten numeros</asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="valtxtnombremed" runat="server" ControlToValidate="txtNombreMed" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar un nombre</asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="valtxtdescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar una descripcion</asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="valtxtprecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar un precio</asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegExpTxtPrecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^\d+$">Precio: solo se permiten numeros</asp:RegularExpressionValidator><br />
                </td>
                <td class="auto-style2"></td>
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
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/BienvenidaEmpleado.aspx" CausesValidation="False">Volver</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            height: 31px;
        }
        .Validadores {
            display: block;
        }
    </style>
</asp:Content>
