<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoMedicamentosYPedidos.aspx.cs" Inherits="ListadoMedicamentosYPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="auto-style1">
            <div class="auto-style4">
                Listado de Medicamentos y Pedidos<br />
                Seleccione:
                <asp:DropDownList ID="ddlListadoMedicamento" runat="server">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
                <br />
            </div>
            <div class="auto-style1" id="GV">
                <asp:GridView ID="gvListadoMedicamento" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvListadoMedicamento_SelectedIndexChanged">
                </asp:GridView>
                <br />
                <asp:Label ID="lblSeleccionEstado" runat="server" Text="Seleccione Estado: "></asp:Label>
                <asp:DropDownList ID="ddlEstadoPedido" runat="server">
                    <asp:ListItem Value="0">Todos</asp:ListItem>
                    <asp:ListItem Value="1">Generados</asp:ListItem>
                    <asp:ListItem Value="2">Enviados</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnMostrarPedidos" runat="server" OnClick="btnMostrarPedidos_Click" Text="Mostrar Pedidos" />
                <br />
                <br />
                <asp:GridView ID="gvListadoPedidos" runat="server">
                </asp:GridView>
            </div>
            <div class="auto-style4">
            <br />
            <br />
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
