<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
        <div>
            <div style="text-align: center">
                <strong>
                <br />
                Farmacia UnaFarm<br />
                <br />
                </strong>
                <table align="center" style="width: 271px">
                    <tr>
                        <td style="width: 347px">Nombre: &nbsp;&nbsp; <asp:TextBox ID="txtNomUsu" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 347px">Password:&nbsp;
                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" style="width: 347px; height: 21px;"><span style="color: #ff0066">
                            <asp:Button ID="btnLogueo" runat="server" Text="Login" OnClick="btnLogueo_Click" />
                            </span></td>
                    </tr>
                    <tr>
                        <td style="width: 347px; height: 21px; text-align: center">
                            <asp:Label ID="lblError" runat="server" Width="320px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
