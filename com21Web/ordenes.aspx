<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/infoempresa.master" CodeFile="ordenes.aspx.cs" Inherits="ordenes" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function pop_window(link) {
        var confirmWin = null;
        confirmWin = window.open(link, 'Detalle Orden', 'width=960,height=540');
	    }
        </script>
    <style type="text/css">
    .centrar
    {
        text-align:center;
    }
</style>
   <%-- <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
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
<div class="col-main span9">
<div class="padding-s">
<div class="page-title category-title">
<div style="float: left">
<h1><span id="ctl00_ContentPlaceHolder1_lbltitulo">Mis ordenes</span></h1>
</div>
</div>
<div id="form-validate">
<div class="fieldset">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<asp:Panel ID="pProductSi" runat="server">
<asp:GridView ID="GvCarrito" runat="server" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Orden" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                 Width="100%" ShowHeader="False" 
        AllowPaging="True">
                                <%--<AlternatingRowStyle BackColor="#DCDCDC" />--%>
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <%--<asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Producto" OnClientClick="return confirm('Desea eliminar el producto');" />--%>
                                                        <ol class="products-list" id="products-list">
                                                            <li class="item" style="padding-top: 10px; padding-bottom: 7px; margin-bottom: 5px;">
                                                                <%--<div class="product-image-carrito">
                                                                    <img src='<%# Eval("Ruta") %>' alt='<%# Eval("Titulo") %>'>
                                                                </div>--%>
                                                                <div class="product-shop">
                                                                    <div class="f-fix">
                                                                        <%--<asp:HiddenField ID="hfPrefactura" runat="server" Value='<%# Eval("IdPrefactura")%>' />
                                                                        <asp:HiddenField ID="IdProducto" runat="server" Value='<%# Bind("Id_Producto") %>' />
                                                                        <asp:HiddenField ID="CantidadExt" runat="server" Value='<%# Bind("CantidadExt") %>' />--%>
                                                                        <table>
                                                                            <tr>
                                                                                <td style="vertical-align: middle;">
                                                                                    <h2 class="product-name" style="margin-bottom: 5px; color:#ABCD43; font-size:16px"># Orden:</h2> 
                                                                                </td>
                                                                                <td style="vertical-align: middle;">
                                                                                    <%--<a class="detalleO" onclick="pop_window();" href="detOrden.aspx?T=<%# Eval("IdTransaccion")%>&Cod=<%# Eval("CodUpdate")%>"><div style="color:#000000; font-size:16px; margin-bottom: 5px; margin-left: 5px;"><%# Eval("IdTransaccion")%></div></a>--%>
                                                                                    <a href="detOrden.aspx?T=<%# Eval("IdTransaccion")%>&Cod=<%# Eval("CodUpdate")%>"><div style="color:#000000; font-size:16px; margin-bottom: 5px; margin-left: 5px;"><%# Eval("IdTransaccion")%></div></a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <div class="desc std">
                                                                           <%-- <p><div style="color:#000000; font-size:13px; font-weight:bold;">Fecha/Compra:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblcantidad" runat="server" Text='<%# Eval("Fecha") %>' ForeColor="#ABCD43" Font-Bold="False"></asp:Label></div></p>
                                                                            <p><div style="color:#000000; font-size:13px; font-weight:bold;">Precio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="$" ForeColor="#ABCD43" Font-Bold="False"></asp:Label><asp:Label ID="lblprecio" runat="server" Text='<%# Eval("Precio") %>' ForeColor="#ABCD43" Font-Bold="False"></asp:Label></div></p>
                                                                            <p><div style="color:#000000; font-size:13px; font-weight:bold;">Descuento:&nbsp;<asp:Label ID="Label2" runat="server" Text="$" ForeColor="#ABCD43" Font-Bold="False"></asp:Label><asp:Label ID="lbldescuento" runat="server" Text='<%# Eval("Descuento") %>' ForeColor="#ABCD43" Font-Bold="False"></asp:Label></div></p>--%>
                                                                            <p>
                                                                                <div style="padding-top:4px">
                                                                                    <div style="text-align: center; padding: 5px; float:left;">
                                                                                        <div style="color:#000000; font-size:12px;">Fecha de compra:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblfecha" runat="server" Text='<%# Eval("Fecha") %>' ForeColor="#ABCD43" Font-Bold="False"></asp:Label></div>
                                                                                    </div>
                                                                                    <div style="color:#000000; font-size:12px; font-weight:bold; float:right; background-color:#ABCD43; padding: 5px">TOTAL:&nbsp;<asp:Label ID="Label4" runat="server" Text="$" ForeColor="#ffffff" Font-Bold="true"></asp:Label><asp:Label ID="Label1" runat="server" Text='<%# Eval("Total") %>' ForeColor="#FFFFFF" Font-Bold="true"></asp:Label>
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
</asp:Panel>
<asp:Panel ID="pProductNo" runat="server">
<div id="productosN" runat="server">Usted no tiene ordenes de compras actualmente</div>
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
