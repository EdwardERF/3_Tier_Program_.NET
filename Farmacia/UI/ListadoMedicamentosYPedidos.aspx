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
                <asp:Button ID="btnTodos" runat="server" Text="Todos" OnClick="btnTodos_Click" />
                <asp:Button ID="btnGenerados" runat="server" Text="Generados" />
                <asp:Button ID="btnEntregados" runat="server" Text="Entregados" />
                <br />
            </div>
            <div class="auto-style1" id="GV">
                <asp:GridView ID="gvListadoMedicamento" runat="server">
                </asp:GridView>
            </div>
            <div class="auto-style1">
            <br />
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
                <br />
                <br />
                <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
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
