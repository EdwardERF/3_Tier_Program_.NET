<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CambioEstadoPedido.aspx.cs" Inherits="CambioEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="Contenedor">
        <p>
            Cambio de Estado de Pedido</p>
        <p>
            <asp:GridView style="margin-left:auto; margin-right:auto" ID="gvEstadoPedido" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvEstadoPedido_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvEstadoPedido_PageIndexChanging" PageSize="6" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="Pedido.numero" HeaderText="Numero" />
                    <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="oMed.Codigo" HeaderText="Cod. Medicamento" />
                    <asp:BoundField DataField="oMed.Ruc" HeaderText="RUC Medicamento" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </p>
        <p>
            <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar Estado" OnClick="btnCambiarEstado_Click" OnClientClick="return confirm('¿Cambiar Estado?');" />
            <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
        </p>
        <p style="display: flex; margin-left:auto; margin-right:auto; text-align: left; justify-content: center">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/BienvenidaEmpleado.aspx">Volver</asp:LinkButton>
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .Contenedor {
            display: block;
            justify-content: center;
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }
    </style>
</asp:Content>


