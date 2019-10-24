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
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
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
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/BienvenidaEmpleado.aspx">Volver</asp:LinkButton>
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
    </style>
</asp:Content>
