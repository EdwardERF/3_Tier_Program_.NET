<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RealizarPedido.aspx.cs" Inherits="RealizarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="Contenedor">
            <div class="auto-style4">
                <p>Realizar Pedido<br /></p>
                <p></p>
            </div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style1">
                        <asp:GridView style="margin-left:auto; margin-right:auto" ID="gvMedicamentos" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvMedicamentos_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvMedicamentos_PageIndexChanging" PageSize="6">
                        </asp:GridView>
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:GridView style="margin-left:auto; margin-right:auto" ID="gvSeleccion" runat="server" AllowPaging="True" PageSize="6">
                        </asp:GridView>
                        <div class="auto-style4">
                        <br />
                        Cantidad: <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnCalcularCosto" runat="server" Text="Calcular Costo" OnClick="btnCalcularCosto_Click" />
                        <br />
                        <br />
                            <asp:RequiredFieldValidator ID="ValidatorTxtCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="RequiredFieldValidator" ForeColor="#CC0000">Debe ingresar un numero</asp:RequiredFieldValidator><br />
                            <asp:RegularExpressionValidator ID="RegExpTxtCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="RegularExpressionValidator" ForeColor="#CC0000" ValidationExpression="^\d+$">Solo se permiten numeros</asp:RegularExpressionValidator>
                        <br />
                        <br />
                        <asp:Label ID="lblCostoTotal" runat="server"></asp:Label>
                        </div>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Button ID="btnConfirmar" runat="server" Text="CONFIRMAR PEDIDO" OnClick="btnConfirmar_Click" />
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/BienvenidaCliente.aspx" CausesValidation="False">Volver</asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
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
    </style>
</asp:Content>
