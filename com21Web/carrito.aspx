<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/infocarrito.master" CodeFile="carrito.aspx.cs" Inherits="carrito" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
    .centrar
    {
        text-align:center;
    }
    .ok
    {
        padding:5px 5px 5px 5px;
        background-color:#b2f6b3;
        border:1px solid #439c44;
        vertical-align:middle;
        font-size:14px;
        font-weight:bold;
    }
    .no
    {
        padding:5px 5px 5px 5px;
        background-color:#f9a4a4;
        border:1px solid #a40606;
        vertical-align:middle;
        font-size:14px;
        font-weight:bold;
    }
</style>
   

<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:HiddenField ID="hftipo" runat="server" />
<asp:HiddenField ID="hf1" runat="server" />
<div class="col-main span9">
<div class="padding-s">
<div class="page-title category-title">
<div style="float: left">
<h1><span id="ctl00_ContentPlaceHolder1_lbltitulo">Orden de compra</span></h1>
</div>
<div style="float:right">
<asp:LinkButton ID="lbcancelar" runat="server" onclick="lbcancelar_Click" Visible="false">CANCELAR COMPRA</asp:LinkButton>
</div>
</div>
<div id="form-validate">
<div class="fieldset">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<asp:Panel ID="pProductSi" runat="server">
<div id="ClasesAdd" runat="server" visible="false" style="height:40px;">
<asp:Image ID="imgMensaje" runat="server" Width="36px" Height="36px" />&nbsp;&nbsp;<asp:Label ID="pMensaje" runat="server"></asp:Label>
</div>
    <asp:HiddenField ID="contadorCant" runat="server" />
<asp:GridView ID="GvCarrito" runat="server" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdPrefactura" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                 Width="100%" ShowHeader="False"
                                onrowdeleting="GvCarrito_RowDeleting" 
                                
        onselectedindexchanged="GvCarrito_SelectedIndexChanged" 
        onrowcommand="GvCarrito_RowCommand">
                                <%--<AlternatingRowStyle BackColor="#DCDCDC" />--%>
                                <Columns>
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
                                                                        <asp:HiddenField ID="CantidadExt" runat="server" Value='<%# Bind("CantidadExt") %>' />
                                                                        <asp:HiddenField ID="DescuentoVal" runat="server" Value='<%# Bind("DescuentoPro") %>' />
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
                                                                                        <asp:ImageButton ID="img1" runat="server" ImageUrl="~/images/cart_remove.png" Width="25" Height="25" CommandName="Select" ToolTip="Eliminar producto del carrito" OnClientClick="return confirm('Desea eliminar items del producto digite una cantidad, caso contrario se eliminará todo el producto');" CommandArgument="Eliminar" />&nbsp;
                                                                                        <asp:ImageButton ID="img2" runat="server" ImageUrl="~/images/cart_add.png" Width="25" Height="25" CommandName="Select" ToolTip="Agrega items del producto al carrito" OnClientClick="return confirm('Desea agregar los items al carrito');" CommandArgument="Agregar" />&nbsp;<label for="qty" style="font-size: 12px">Cantidad:</label>
    <asp:TextBox ID="txtcantidad" runat="server" CssClass="input-text qty centrar" MaxLength="5" ForeColor="Black" Text="0"></asp:TextBox>
    <ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender1"
           runat="server"
           TargetControlID="txtcantidad"
           FilterType="Numbers" />
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
<ul class="checkout-types" style="padding-top:10px; padding-bottom:10px">
<li> 
<asp:Button ID="btncomprarSC" runat="server" Text="Comprar" 
        CssClass=" button btn-proceed-checkout btn-checkout btncurve" Width="100" 
        Height="35" BackColor="#ABCD43" ForeColor="#ffffff" Font-Bold="true" 
        Visible="false" onclick="btncomprarSC_Click"></asp:Button>
<asp:Button ID="btnsiguienteSC" runat="server" Text="Siguiente" 
        CssClass=" button btn-proceed-checkout btn-checkout btncurve" Width="100" 
        Height="35" BackColor="#ABCD43" ForeColor="#ffffff" Font-Bold="true" 
        onclick="btnsiguienteSC_Click"></asp:Button>
</li>
</ul>
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
<ul class="checkout-types" style="padding-top:10px; padding-bottom:10px">
<li> 
<asp:Button ID="btncomprarCC" runat="server" Text="Comprar" 
        CssClass=" button btn-proceed-checkout btn-checkout btncurve" Width="100" 
        Height="35" BackColor="#ABCD43" ForeColor="#ffffff" Font-Bold="true" 
        Visible="false" onclick="btncomprarCC_Click"></asp:Button>
<asp:Button ID="btnsiguienteCC" runat="server" Text="Siguiente" 
        CssClass=" button btn-proceed-checkout btn-checkout btncurve" Width="100" 
        Height="35" BackColor="#ABCD43" ForeColor="#ffffff" Font-Bold="true" 
        onclick="btnsiguienteCC_Click"></asp:Button>
</li>
</ul>
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

