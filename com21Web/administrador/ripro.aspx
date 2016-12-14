<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ripro.aspx.cs" Inherits="administrador_ripro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="Javascript">
        function printit() {
            if (NS) {
                window.print();
            }
            else {
                var WebBrowser = '<OBJECT ID="WebBrowser1" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>';
                /*ocument.body.insertAdjacentHTML('beforeEnd', WebBrowser); "WebBrowser1.ExecWB(6, 2); //Use a 1 vs. a 2 for a prompting dialog box"*/
                WebBrowser1.outerHTML = "";
            }
        }
</script>


<script type="text/javascript" language="Javascript">
    var NS = (navigator.appName == "Netscape");
    var VERSION = parseInt(navigator.appVersion);
    //    if (VERSION > 3) {
    //        document.write('<form><input type="button" name="Print" onClick="printit()" text /></form>');
    //    }

</script>
</head>
<body onload="printit()">
    <form id="form1" runat="server">
    <div style="width: 90%; margin-right: auto; margin-left: auto">
           <table style="width: 100%; font-family: 'Arvo', serif; font-size: 14px; font-weight: bold;">
               <tr>
                   <td style="padding: 5px; color: #FFFFFF; font-weight: bold; -webkit-border-top-left-radius: 5px; -webkit-border-top-right-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-topright: 5px; border-top-left-radius: 5px; border-top-right-radius: 5px;">
                       <div style="float: left"><img alt="" src="../images/logocom21.jpg" width="100" /></div>
                       <div style="padding: 15px; float: right; color: #000000; font-size: 30px; font-family: 'Arvo', serif;">Reporte de Productos</div>
                   </td>
               </tr>
               <tr>
                   <td style="color: #052B82; font-weight: bold; font-family: 'Arvo', serif; font-size:16px">
                       Busqueda:
                       <asp:Label ID="lblbusqueda" runat="server"></asp:Label>
                   </td>
               </tr>
               <%--<tr>
                   <td>
                       
                       &nbsp;</td>
                   <td>
                       &nbsp;</td>
               </tr>--%>
           </table>
           <table style="width: 100%;">
               <tr>
                   <td>
                    <asp:GridView ID="GvRProductos" runat="server" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Producto" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                Width="100%"
                EmptyDataText="No existen datos para la busqueda seleccionada" PageSize="13">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Producto" ItemStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label> 
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label> 
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Categorias" ItemStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:Label ID="Categoria" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Categoria" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub-Categorias" ItemStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:Label ID="Subcategoria" runat="server" Text='<%# Bind("Subcategoria") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Subcategoria" runat="server" Text='<%# Bind("Subcategoria") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marcas" ItemStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:Label ID="Marca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Marca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            $<asp:Label ID="Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            $<asp:Label ID="Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Ingreso" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#ABCD43" Font-Bold="True" ForeColor="#333333" 
                                    Font-Size="14px" />
                                <PagerStyle BackColor="#999999" Font-Names="Helvetica" 
                                    Font-Size="12px" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" Font-Names="Helvetica" Font-Size="14px" 
                                    ForeColor="Black" />
                            </asp:GridView>
                  </td>
               </tr>
               </table>
       </div>
    </form>
</body>
</html>
