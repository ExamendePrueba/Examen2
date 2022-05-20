<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examen.aspx.cs" Inherits="Examen.Examen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>
        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }

        function consultaDom() {
            document.getElementById("<%=btn.ClientID%>").click();
            return false;
        }

        function validaCampos() {
            if (document.getElementById("<%=txtEstado.ClientID%>").value == "" ||
                document.getElementById("<%=txtMunicipio.ClientID%>").value == "" ||
                document.getElementById("<%=txtColonia.ClientID%>").value == "") {
                alert("Faltan datos por capturar.");
            }else{
                alert("Los datos están completos.");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dvVehiculo">
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblTitulo1"><h2>Vehículo</h2></asp:Label>
                </td>
            </tr>
            <tr><td colspan="2"><hr /></td></tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Marca:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlMarca" AutoPostBack="True" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="SubMarca:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSubmarca" AutoPostBack="True" OnSelectedIndexChanged="ddlSubmarca_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Modelo:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlModelo" AutoPostBack="True" OnSelectedIndexChanged="ddlModelo_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Descripción:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlDesc"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
        <br /><br />
    <hr />
    <div id="dvDomicilio">
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="Label1"><h2>Domicilio</h2></asp:Label>
                </td>
            </tr>
            <tr><td colspan="2"><hr /></td></tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Código Postal:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCP" MaxLength="5" onKeyPress="return soloNumeros(event);" onblur="consultaDom();"> </asp:TextBox>
                    <asp:Button ID="btn" runat="server" OnClick="btn_Click" style="display:none;"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Estado:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEstado"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Municipio:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMunicipio" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Colonia:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtColonia" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <input type="button" id="btnValida" onclick="validaCampos()" value="Validar"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
