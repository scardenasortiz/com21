<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/infoproductos.master" CodeFile="detOrden.aspx.cs" Inherits="detOrden" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="js/print.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".printer").bind("click", function () {
                $(".Aimprimir").printArea();
            });
        });

        function imprimirDiv() {
            //Hacemos referencia al área a imprimir
            var div_print = document.getElementById("<%=cuerpo_rpt.ClientID%>");
            //Creamos una nueva página
            var pp = window.open('', div_print, 'width=1100px, height=660px, resizable=no');
            //Añadimos la etiqueta HTML de apertura
            pp.document.writeln('<HTML><HEAD><title>Detalle Transaccion</title><LINK href="Reportes.css"  type="text/css" rel="stylesheet" />')
            pp.document.writeln('</HEAD>')
            //Añadimos el cuerpo de la página HTML
            pp.document.writeln('<body onLoad="window.print();self.close();" oncontextmenu="return true"><table><tr><td style="Width:550px; text-align:left;"><asp:Image ID="logo" runat="server" ImageUrl="~/images/logocom21.jpg" Width="110" /></td><td style="Width:550; text-align:right; font-size:28px; padding-right:30px">Detalle Transaccion</td></tr></table>');
            //Añadimos el formulario
            pp.document.writeln('<form>');
            //Escribimos el área de impresión de la página especificada
            pp.document.writeln(div_print.innerHTML);
            //Cerramos la etiqueta HTML
            pp.document.writeln('</form></body></HTML>');
            pp.document.close();
        }
    </script>
<style type="text/css">
    .centrar
    {
        text-align:center;
    }
</style>
  <%--  <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>

<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:HiddenField ID="hftipo" runat="server" />
<asp:HiddenField ID="hf1" runat="server" />
<div class="col-main span9" style="background-color: #ffffff;">
<div class="padding-s">
<div style="text-align: left"><a href="#" class="printer">
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/images/print_carrito.png" Width="48px" Height="45px" 
        ToolTip="Imprimir" onclick="ImageButton1_Click" /><%--<asp:Image ID="imgBtn_print" runat="server" ImageUrl="~/images/print_carrito.png" Width="48px" Height="45px" ToolTip="Imprimir" />--%></a></div>
<div id="cuerpo_rpt" runat="server" class="Aimprimir">
<div class="page-title category-title">
<div style="float: left">
<h1><span id="ctl00_ContentPlaceHolder1_lbltitulo">Orden de compra</span></h1>
</div>
</div>
<div id="form-validate">
<div class="fieldset">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<asp:Panel ID="pProductSi" runat="server">
<div class="fieldset">
<h2 class="legend" style="font-size: 14px">DATOS DE USUARIO</h2>
<ul class="form-list">
<li class="fields">
<div class="customer-name">
<div class="field name-firstname">
<label for="firstname" class="required">Nombres</label>
<div class="input-boxs">
<asp:Label ID="lblnombres" runat="server" CssClass="input-text required-entry"></asp:Label>
</div>
</div>
<div class="field name-lastname">
<label for="lastname" class="required">Apellidos</label>
<div class="input-boxs">
<asp:Label ID="lblapellidos" runat="server" CssClass="input-text required-entry"></asp:Label>
</div>
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required">Forma de Pago</label>
<div class="input-boxs">
<asp:Label ID="lblformaP" runat="server" CssClass="input-text required-entry"></asp:Label>
</div>
</div>
</li>
</ul>
</div>
<asp:Panel ID="pEnvioAct" runat="server">
<div class="fieldset">
<h2 class="legend" style="font-size: 14px">DATOS DE ENVIO</h2>
<ul class="form-list">
<li class="fields">
<div class="customer-name">
<div class="field name-firstname">
<label for="firstname" class="required">Nombre de Contacto</label>
<div class="input-boxs">
<asp:Label ID="lblnombreenvio" runat="server" CssClass="input-text required-entry"></asp:Label>
</div>
</div>
<div class="field name-lastname">
<label for="lastname" class="required">Teléfono</label>
<div class="input-boxs">
<asp:Label ID="lbltelefonoenvio" runat="server" CssClass="input-text required-entry"></asp:Label>
</div>
</div>
</div>
</li>
<li>
<div class="fields name-firstname">
<label for="email_address" class="required">Dirección</label>
<div class="input-boxs">
<asp:Label ID="direccion" runat="server" CssClass="legend input-text required-entry" ForeColor="#666666"></asp:Label>
</div>
</div>
</li>
</ul>
</div>
</asp:Panel>
<asp:GridView ID="GvCarrito" runat="server" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdPrefactura" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                 Width="100%" ShowHeader="False">
                                <%--<AlternatingRowStyle BackColor="#DCDCDC" />--%>
                                <Columns>
                                    <%--<asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar categorias" onclick="refresh_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select"
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Productos" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="SubirImagen" runat="server" CommandName="Edit" Height="20px" ImageUrl="~/images/64_upload.png" style="margin:2px;" 
                                                ToolTip="Subir Imagenes para Producto" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Producto" runat="server" 
                                                Value='<%# Bind("Id_Producto") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Producto" runat="server" 
                                                Value='<%# Bind("Id_Producto") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Producto" ItemStyle-HorizontalAlign="Center">
                                        
                                        <EditItemTemplate>
                                            <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Ingreso" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
                                   </asp:TemplateField>--%>
                                   <%--<asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImagenesPro" runat="server" CommandName="Edit" 
                                                Height="20px" ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_gallery.png" style="margin:2px;" 
                                                ToolTip="Imagenes Producto" OnClientClick="return confirm('Desea agregar más imagenes del producto');" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <%--<asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Producto" OnClientClick="return confirm('Desea eliminar el producto');" />--%>
                                                        <ol class="products-list" id="products-list">
                                                            <li class="item" style="padding-top: 10px; padding-bottom: 7px; margin-bottom: 5px;">
                                                                <div class="product-image-carrito">
                                                                    <img src='<%# Eval("Ruta") %>' alt='<%# Eval("Titulo") %>'>
                                                                </div>
                                                                <div class="product-shop">
                                                                    <div class="f-fix">
                                                                        <asp:HiddenField ID="hfPrefactura" runat="server" Value='<%# Eval("IdPrefactura")%>' />
                                                                        <asp:HiddenField ID="IdProducto" runat="server" Value='<%# Bind("Id_Producto") %>' />
                                                                        <h2 class="product-name" style="margin-bottom: 5px; color:#ABCD43; font-weight:bold;">
                                                                            <%# Eval("Titulo") %>
                                                                        </h2>
                                                                        <div class="desc std">
                                                                            <p><div style="color:#000000; font-size:13px; font-weight:bold;">Cantidad:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblcantidad" runat="server" Text='<%# Eval("Cantidad") %>' ForeColor="#ABCD43" Font-Bold="False"></asp:Label></div></p>
                                                                            <p><div style="color:#000000; font-size:13px; font-weight:bold;">Precio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="$" ForeColor="#ABCD43" Font-Bold="False"></asp:Label><asp:Label ID="lblprecio" runat="server" Text='<%# Eval("Precio") %>' ForeColor="#ABCD43" Font-Bold="False"></asp:Label></div></p>
                                                                            <p><div style="color:#000000; font-size:13px; font-weight:bold;">Descuento:&nbsp;<asp:Label ID="Label2" runat="server" Text="$" ForeColor="#ABCD43" Font-Bold="False"></asp:Label><asp:Label ID="lbldescuento" runat="server" Text='<%# Eval("Descuento") %>' ForeColor="#ABCD43" Font-Bold="False"></asp:Label></div></p>
                                                                            <p>
                                                                                <div style="padding-top:4px">
                                                                                    <div style="text-align: center; padding: 5px; float:left;">
            
                                                                                    </div>
                                                                                    <div style="color:#000000; font-size:13px; font-weight:bold; float:right; background-color:#ABCD43; padding: 5px">TOTAL:&nbsp;<asp:Label ID="Label4" runat="server" Text="$" ForeColor="#ffffff" Font-Bold="true"></asp:Label><asp:Label ID="Label1" runat="server" Text='<%# Eval("Total") %>' ForeColor="#FFFFFF" Font-Bold="true"></asp:Label>
                                                                                    </div>
                                                                                </div>
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </li>
                                                        </ol>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#ABCD43" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#999999" Font-Names="Helvetica" 
                                    Font-Size="12px" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#ffffff" Font-Names="Helvetica" Font-Size="14px" 
                                    ForeColor="Black" />
                            </asp:GridView>
<div class="cart">
<div class="cart-collaterals" style="padding-top: 10px">
<div class="wrapper">
<div class="grid_custom_2">
<asp:Panel ID="pSinCosto" runat="server">
<div class="totals">
<table id="shopping-cart-totals-table">
<colgroup><col>
<col width="1">
</colgroup>
<tfoot>
<tr>
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
<strong>Total a Pagar</strong>
</td>
<td style="" class="a-right">
<strong>$<span id="total" runat="server" class="price" style="font-size:16px"></span></strong>
</td>
</tr>
</tfoot>
<tbody>
<tr>
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
Subtotal </td>
<td style="" class="a-right">
$<span id="subtotal" runat="server" class="price" style="font-size:16px"></span> </td>
</tr>
<tr style="border-bottom: 1px solid #606060;">
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
Iva </td>
<td style="" class="a-right">
$<span  id="iva" runat="server" class="price" style="font-size:16px"></span> </td>
</tr>
<tr style="border-bottom: 1px solid #606060;">
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
Descuento </td>
<td style="" class="a-right">
$<span  id="descuentos" runat="server" class="price" style="font-size:16px"></span> </td>
</tr>
</tbody>
</table>
</div>
</asp:Panel>
<asp:Panel ID="pConCosto" runat="server">
<div class="totals">
<table id="shopping-cart-totals-table">
<colgroup><col>
<col width="1">
</colgroup>
<tfoot>
<tr>
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
<strong>Total a Pagar</strong>
</td>
<td style="" class="a-right">
<strong>$<span id="sTotCosto" runat="server" class="price" style="font-size:16px"></span></strong>
</td>
</tr>
</tfoot>
<tbody>
<tr>
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
Subtotal </td>
<td style="" class="a-right">
$<span id="sSubCosto" runat="server" class="price" style="font-size:16px"></span> </td>
</tr>
<tr style="border-bottom: 1px solid #606060;">
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
Iva </td>
<td style="" class="a-right">
$<span  id="sIvaCosto" runat="server" class="price" style="font-size:16px"></span> </td>
</tr>
<tr style="border-bottom: 1px solid #606060;">
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
Descuento </td>
<td style="" class="a-right">
$<span  id="sDescCosto" runat="server" class="price" style="font-size:16px"></span> </td>
</tr>
<tr style="border-bottom: 1px solid #606060;">
<td style="font-size: 13px;
line-height: 17px;
color: #fff;
text-transform: uppercase;
vertical-align: middle;
width: 50%;" class="a-left" colspan="1">
Costo envio </td>
<td style="" class="a-right">
$<span  id="sCostoEnv" runat="server" class="price" style="font-size:16px"></span> </td>
</tr>
</tbody>
</table>
</div>
</asp:Panel>
</div>
</div>
</div>
</div>
</asp:Panel>
<asp:Panel ID="pProductNo" runat="server">
<div id="productosN" runat="server"></div>
</asp:Panel>
</ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</div>
</div>
</div>
<asp:Panel ID="pnlProgress" runat="server" Style="display: none; width: 200px; background-color: #E2E2E2; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;"
        Width="44px">
        <div style="padding-right: 8px; padding-left: 8px; padding-bottom: 8px; padding-top: 8px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;">
            <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; height: 50px;">
                <tbody>
                    <tr>
                       <td style="text-align: center">
                           <asp:Image ID="Image2" runat="server" ImageUrl="~/images/loadinfo.net1.gif" />
                       </td> 
                    </tr>
                    <tr>
                    <td style="white-space: nowrap; text-align: center; font-family: verdana; font-size: 10px;">
                            <span class="Datos" 
                                style="font-size: 10px; font-family: Talo; font-weight:bold; color: #000000;"> POR FAVOR ESPERE, PROCESANDO...</span>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </asp:Panel>
    <ajaxtoolkit:modalpopupextender ID="mpeProgress" runat="server" BackgroundCssClass="modalBackground"
        DropShadow="true" PopupControlID="pnlProgress" 
        TargetControlID="pnlProgress">
    </ajaxtoolkit:modalpopupextender>
</ContentTemplate>
</asp:UpdatePanel>
<div class="col-right sidebar span3">
<div class="block block-layered-nav">
<div class="block-content">
<asp:Image ID="Image1" runat="server" ImageUrl="~/images/publi.jpg" Width="100%" />
</div>
</div>
<div class="block block-layered-nav">
<div class="block-title">
<strong><span>Facebook</span></strong>
</div>
<div class="block-content">
<iframe src="//www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2Fpages%2FCOM-21-SA%2F166410506765758&amp;width=250&amp;height=365&amp;show_faces=true&amp;colorscheme=light&amp;stream=false&amp;border_color&amp;header=false&amp;appId=330721080316666" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:100%; height:395px;" allowTransparency="true"></iframe>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<script type="text/javascript">

    Sys.Net.WebRequestManager.add_invokingRequest(onInvoke);
    Sys.Net.WebRequestManager.add_completedRequest(onComplete);

    function onInvoke(sender, args) {
        $find('<%= mpeProgress.ClientID %>').show();
    }

    function onComplete(sender, args) {
        $find('<%= mpeProgress.ClientID %>').hide();
    }

    function pageUnload() {
        Sys.Net.WebRequestManager.remove_invokingRequest(onInvoke);
        Sys.Net.WebRequestManager.remove_completedRequest(onComplete);
    }

    </script>

</asp:Content>
