<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RealizarPedido.aspx.cs" Inherits="RealizarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div>
            <div class="auto-style4">
                Realizar Pedido<br />
            </div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:GridView ID="gvMedicamentos" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvMedicamentos_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvMedicamentos_PageIndexChanging">
                        </asp:GridView>
                        <br />
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:GridView ID="gvSeleccion" runat="server">
                        </asp:GridView>
                        <br />
                        Cantidad: <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnCalcularCosto" runat="server" Text="Calcular Costo" OnClick="btnCalcularCosto_Click" />
                        <br />
                        <br />
                        <asp:Label ID="lblCostoTotal" runat="server"></asp:Label>
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
                    <td class="auto-style1">
                        <asp:Button ID="btnConfirmar" runat="server" Text="CONFIRMAR PEDIDO" OnClick="btnConfirmar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
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
                    <td class="auto-style1">
                        <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
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
    </style>
</asp:Content>
