<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebVentas.aspx.cs" Inherits="AppWebVentas.WebVentas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 85px;
        }
        .auto-style4 {
            height: 26px;
            width: 85px;
        }
        .auto-style5 {
            width: 85px;
            height: 30px;
        }
        .auto-style6 {
            height: 30px;
        }
        .auto-style7 {
            width: 826px;
            height: 30px;
        }
        .auto-style8 {
            width: 826px;
        }
        .auto-style9 {
            height: 26px;
            width: 826px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           &nbsp;<br />
            &nbsp;<br />
              &nbsp;<br />
            <br />
        </div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">
           <label>Nombre:</label></td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6"> 
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <label>Apellido</label></td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                    </td>
                    <td> 
                        <asp:Button ID="btnListar" runat="server" Text="Listar Todo" OnClick="btnListar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
              <label>Dni:</label> </td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2"> 
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <label>Comision:</label></td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="ddlComision" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td> 
                        <asp:Button ID="btnTraerPorId" runat="server" Text="Traer por id" OnClick="btnTraerPorId_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
             <label>Id:</label></td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                    </td>
                    <td> 
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnTraerPorComision" runat="server" Text="Traer Por Comision" Width="121px" OnClick="btnTraerPorComision_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:GridView ID="gridVendedores" runat="server" Width="489px">
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    </form>
</body>
</html>
