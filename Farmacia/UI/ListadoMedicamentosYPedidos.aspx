<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoMedicamentosYPedidos.aspx.cs" Inherits="ListadoMedicamentosYPedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div class="auto-style1">
                Listado de Medicamentos y Pedidos<br />
                Seleccione:
                <asp:DropDownList ID="ddlListadoMedicamento" runat="server">
                </asp:DropDownList>
                <br />
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
    </form>
</body>
</html>
