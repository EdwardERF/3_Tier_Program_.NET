<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoMedicamentosYPedidos.aspx.cs" Inherits="ListadoMedicamentosYPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="auto-style1">
            <div class="auto-style4">
                <p>Listado de Medicamentos y Pedidos<br /></p>
                <p></p>
                Seleccione:
                <asp:DropDownList ID="ddlListadoMedicamento" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
                <br />
                <br />
            </div>
            <div class="auto-style1" id="GV">
                <asp:GridView style="margin-left:auto; margin-right:auto" ID="gvListadoMedicamento" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvListadoMedicamento_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvListadoMedicamento_PageIndexChanging" PageSize="6">
                </asp:GridView>
                <br />
                    <div style="display: flex; justify-content:center; margin-left:auto; margin-right:auto" id="SeccionMostrarPedido">
                        <asp:Label ID="lblSeleccionEstado" runat="server" Text="Seleccione Estado: "></asp:Label>
                        <asp:DropDownList ID="ddlEstadoPedido" runat="server">
                            <asp:ListItem Value="0">Todos</asp:ListItem>
                            <asp:ListItem Value="1">Generados</asp:ListItem>
                            <asp:ListItem Value="2">Enviados</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnMostrarPedidos" runat="server" OnClick="btnMostrarPedidos_Click" Text="Mostrar Pedidos" />
                    </div>
                <br />
                <asp:GridView style="margin-left:auto; margin-right:auto" ID="gvListadoPedidos" runat="server" AllowPaging="True" OnPageIndexChanging="gvListadoPedidos_PageIndexChanging" PageSize="6">
                </asp:GridView>
            </div>
            <div class="auto-style4">
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <br />
                <br />
                <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/BienvenidaEmpleado.aspx">Volver</asp:LinkButton>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
    </style>
</asp:Content>
