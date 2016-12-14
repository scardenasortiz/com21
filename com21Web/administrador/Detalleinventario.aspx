<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="Detalleinventario.aspx.cs" Inherits="administrador_Detalleinventario" %>


<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="js/printDetInv.js"></script> 
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
        pp.document.writeln('<HTML><HEAD><title>Detalle Inventario</title><LINK href=Reportes.css  type="text/css" rel="stylesheet" />')
        pp.document.writeln('</HEAD>')
        //Añadimos el cuerpo de la página HTML
        pp.document.writeln('<body onLoad="window.print();self.close();" oncontextmenu="return false"><table><tr><td style="Width:550px; text-align:left;"><asp:Image ID="logo" runat="server" ImageUrl="~/images/logocom21.jpg" Width="110" /></td><td style="Width:550; text-align:right; font-size:28px; padding-right:30px">Detalle Inventario</td></tr></table>');
        //Añadimos el formulario
        pp.document.writeln('<form>');
        //Escribimos el área de impresión de la página especificada
        pp.document.writeln(div_print.innerHTML);
        //Cerramos la etiqueta HTML
        pp.document.writeln('</form></body></HTML>');
        pp.document.close();
    }
    </script>
    <link rel="stylesheet" type="text/css" href="../css/stylespanel/styles.css" />
<script type="text/javascript" >
    $(function () {
        $('.dragbox')
	.each(function () {
	    $(this).hover(function () {
	        $(this).find('h2').addClass('collapse');
	    }, function () {
	        $(this).find('h2').removeClass('collapse');
	    })
		.find('h2').hover(function () {
		    $(this).find('.configure').css('visibility', 'visible');
		}, function () {
		    $(this).find('.configure').css('visibility', 'hidden');
		})
		.click(function () {
		    $(this).siblings('.dragbox-content').toggle();
		})
		.end()
		.find('.configure').css('visibility', 'hidden');
	});
        $('.column').sortable({
            connectWith: '.column',
            handle: 'h2',
            cursor: 'move',
            placeholder: 'placeholder',
            forcePlaceholderSize: true,
            opacity: 0.4,
            stop: function (event, ui) {
                $(ui.item).find('h2').click();
                var sortorder = '';
                $('.column').each(function () {
                    var itemorder = $(this).sortable('toArray');
                    var columnId = $(this).attr('id');
                    sortorder += columnId + '=' + itemorder.toString() + '&';
                });
                //alert('SortOrder: '+sortorder);
                /*Pass sortorder variable to server using ajax to save state*/
            }
        })
	.disableSelection();
    });

    function script2() {
        //document.getElementById("imgLOAD").style.display = "none";
        return confirm("Desea eliminar el usuario.");


    }
</script>
<%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
    
   <div class="demoarea" style="margin-left: 5px">
       
       <div style="width: 90%; margin-right: auto; margin-left: auto; text-align:right;">
          <table style="width:100%"><tr><td style="text-align:left;">
              <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/regresar_A.png" 
                  runat="server" Height="33px" ToolTip="Regresar" 
                  Width="33px" onclick="ImageButton1_Click" /></td>
              <td style="text-align:right;">
                  <asp:DropDownList ID="ddlfiltrar" runat="server" Height="24px" Width="150px" 
                      CssClass="bordebotones">
                      <asp:ListItem Value="2">Carga Inicial</asp:ListItem>
                      <asp:ListItem Value="0">Compra</asp:ListItem>
                      <asp:ListItem Value="1">Venta</asp:ListItem>
                  </asp:DropDownList>
              </td>
              <td style="width:35px">
                  <asp:ImageButton ID="IBProducto" runat="server" Height="33px" 
                                       ImageUrl="~/images/find.png" onclick="IBProducto_Click" 
                      Width="33px" /></td><td style="width:35px">
          <a href="#" class="printer">
                                            <asp:Image ID="imgBtn_print" runat="server" 
                      ImageUrl="~/images/print.png" Width="33px" Height="33px" />
                                        </a>
          </td></tr></table>
       </div>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
       <asp:HiddenField ID="idBuscar" runat="server" Value="0"/>
       <div id="cuerpo_rpt" class="Aimprimir" runat="server" style="width: 90%; margin-right: auto; margin-left: auto">
           <table style="width: 100%; font-family: 'Arvo', serif; font-size: 14px; font-weight: bold;">
               <tr>
                   <td colspan="3" 
                       style="padding: 5px; background-color: #ABCD43; color: #FFFFFF; font-weight: bold; -webkit-border-top-left-radius: 5px; -webkit-border-top-right-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-topright: 5px; border-top-left-radius: 5px; border-top-right-radius: 5px;">
                       <div style="font-size: 20px; color: #333333; font-weight: bold;">Com21 S.A</div>Servicio en Telecomunicaciones</td>
               </tr>
               <tr>
                   <td rowspan="3" style="padding-left: 5px" width="155">
                       <asp:Image ID="imgRuta" runat="server" Height="120px" Width="140px" />
                   </td>
                   <td colspan="2" style="color: #052B82; font-weight: bold">
                       <asp:Label ID="lbltitulo" runat="server" Font-Bold="True" Font-Size="19px"></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td colspan="2">
                       <table style="width:100%;">
                           <tr>
                               <td style="width:10%;">
                                 <div style="padding: 5px; width: 130px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                 Categorias:
                                 </div>
                               </td>
                               <td style="width:30%;">
                                   <asp:Label ID="lblCategoria" runat="server" Font-Bold="True" 
                                       ForeColor="#052B82"></asp:Label>
                               </td>
                               <td style="width:10%;">
                                  <div style="padding: 5px; width: 130px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                  Sub-Categoria:
                                  </div>
                               </td>
                               <td style="width:30%;">
                                <asp:Label ID="lblsubcategoria" runat="server" Font-Bold="True" 
                                       ForeColor="#052B82"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                 <div style="padding: 5px; width: 130px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                 Marca:
                                 </div>
                               </td>
                               <td>
                                   <asp:Label ID="lblmarca" runat="server" Font-Bold="True" ForeColor="#052B82"></asp:Label>
                               </td>
                               <td>
                                <div style="padding: 5px; width: 130px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                Precio Compra:
                                </div>
                               </td>
                               <td>
                                   <asp:Label ID="lblpreciocompra" runat="server" ForeColor="#052B82"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                 <div style="padding: 5px; width: 130px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                       Cantidad Inicial:
                       </div>
                               </td>
                               <td>
                                   <asp:Label ID="lblcantidadini" runat="server" ForeColor="#052B82"></asp:Label>
                               </td>
                               <td>
                                   <div style="padding: 5px; width: 130px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Precio Inicial:
                                   </div>
                               </td>
                               <td>
                                   <asp:Label ID="lblprecionini" runat="server" ForeColor="#052B82"></asp:Label>
                               </td>
                           </tr>
                       </table>
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
                   <asp:Panel ID="pInvetS" runat="server">
           <table style="width: 100%;">
               <tr>
                   <td style="text-align: right">
                       </td>                  
               </tr>
               <tr>
                   <td>
                       <asp:GridView ID="GvRProductos" runat="server" CssClass="Productos" 
                           AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Inventario" 
                           EmptyDataText="No existen datos para la busqueda seleccionada" 
                           EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                           onpageindexchanging="GvRProductos_PageIndexChanging" Width="100%">
                           <AlternatingRowStyle BackColor="#DCDCDC" />
                           <Columns>
                               <asp:TemplateField>
                                   <HeaderTemplate>
                                       <asp:ImageButton ID="refresh" runat="server" Height="20px" 
                                           ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" 
                                           onclick="refresh_Click" style="margin:2px;" ToolTip="Cargar categorias" />
                                   </HeaderTemplate>
                                   <ItemTemplate>
                                       <asp:HiddenField ID="Id_Inventario" runat="server" 
                                           Value='<%# Bind("Id_Inventario") %>' />
                                       <asp:HiddenField ID="Id_Producto" runat="server" 
                                           Value='<%# Bind("Id_Producto") %>' />
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Producto" ItemStyle-HorizontalAlign="Left">
                                   <EditItemTemplate>
                                       <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Left" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Precio Compra" 
                                   ItemStyle-HorizontalAlign="Center">
                                   <EditItemTemplate>
                                       $<asp:Label ID="PrecioCompra" runat="server" Text='<%# Bind("PrecioCompra") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       $<asp:Label ID="PrecioCompra" runat="server" Text='<%# Bind("PrecioCompra") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Fecha Registro" 
                                   ItemStyle-HorizontalAlign="Center">
                                   <EditItemTemplate>
                                       <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Tipo" 
                                   ItemStyle-HorizontalAlign="Center">
                                   <EditItemTemplate>
                                       <asp:Label ID="IdentificadorCV" runat="server" Text='<%# Bind("IdentificadorCV") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="IdentificadorCV" runat="server" Text='<%# Bind("IdentificadorCV") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Cantidad Nueva" 
                                   ItemStyle-HorizontalAlign="Center">
                                   <EditItemTemplate>
                                       <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Precio Nuevo" 
                                   ItemStyle-HorizontalAlign="Center">
                                   <EditItemTemplate>
                                       $<asp:Label ID="Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       $<asp:Label ID="Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="SubTotal" 
                                   ItemStyle-HorizontalAlign="Right">
                                   <EditItemTemplate>
                                       $<asp:Label ID="Subtotal" runat="server" Text='<%# Bind("Subtotal") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       $<asp:Label ID="Subtotal" runat="server" Text='<%# Bind("Subtotal") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                           </Columns>
                           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                           <HeaderStyle BackColor="#ABCD43" Font-Bold="True" Font-Size="14px" 
                               ForeColor="#333333" />
                           <PagerStyle BackColor="#999999" Font-Names="Helvetica" Font-Size="12px" 
                               ForeColor="Black" HorizontalAlign="Center" />
                           <RowStyle BackColor="#EEEEEE" Font-Names="Helvetica" Font-Size="14px" 
                               ForeColor="Black" />
                       </asp:GridView>
                   </td>
               </tr>
               <tr>
                   <td style="text-align: right">
                       <table style="width:100%; font-family: 'Arvo', serif;">
                           <tr>
                               <td style="text-align: right">
                                   <div style="padding: 5px; width: 106px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px; float: right; font-size: 14px;">
                                       Total Compras:
                                   </div>
                               </td>
                               <td style="padding-right: 20px;" width="85px">
                                   <asp:Label ID="lbltotalC" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td style="text-align: right">
                                   <div style="padding: 5px; width: 90px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px; float: right; font-size: 14px;">
                                       Total Ventas:
                                   </div>
                               </td>
                               <td style="padding-right: 20px;" width="85px">
                                   <asp:Label ID="lbltotalV" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td style="text-align: right">
                                   <div style="padding: 5px; width: 77px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px; float: right; font-size: 14px;">
                                       Total Final:
                                   </div>
                               </td>
                               <td style="padding-right: 20px;" width="85px">
                                   <asp:Label ID="lbltotalCV" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label>
                               </td>
                           </tr>
                       </table>
                   </td>
               </tr>
           </table>
           </asp:Panel>                       
           <asp:Panel ID="pInvetN" runat="server">
               <table style="border: 1px solid #666666; width: 100%; border-spacing: 0px;">
                   <tr>
                       <td style="width: 14%; font-weight: bold; text-align: center; font-size: 14px; color: #333333; background-color: #ABCD43; height: 26px; border-spacing: 0px;">
                           Producto</td>
                       <td style="width: 14%; font-weight: bold; text-align: center; font-size: 14px; color: #333333; background-color: #ABCD43; height: 30px;">
                           Precio Compra</td>
                       <td style="width: 14%; font-weight: bold; text-align: center; font-size: 14px; color: #333333; background-color: #ABCD43; height: 30px;">
                           Fecha Registro</td>
                       <td style="width: 14%; font-weight: bold; text-align: center; font-size: 14px; color: #333333; background-color: #ABCD43; height: 30px;">
                           Tipo</td>
                       <td style="width: 14%; font-weight: bold; text-align: center; font-size: 14px; color: #333333; background-color: #ABCD43; height: 30px;">
                           Cantidad Nueva</td>
                       <td style="width: 14%; font-weight: bold; text-align: center; font-size: 14px; color: #333333; background-color: #ABCD43; height: 30px;">
                           Precio Nuevo</td>
                       <td style="width: 14%; font-weight: bold; text-align: center; font-size: 14px; color: #333333; background-color: #ABCD43; height: 30px;">
                           SubTotal</td>
                   </tr>
                   <tr>
                       <td colspan="7" style="height: 20px; padding: 5px">
                        <div style="font-size: 12px">NO SE REALIZADO PEDIDO ADICIONALES DEL PRODUCTO SELECCIONADO</div>
                       </td>
                   </tr>
               </table>
           </asp:Panel>
                   </td>
               </tr>
           </table>
       </div>
        <br />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="IBProducto" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
    <asp:Panel ID="pnlProgress" runat="server" Style="display: none; width: 500px; background-color: white"
        Width="44px">
        <div style="padding-right: 8px; padding-left: 8px; padding-bottom: 8px; padding-top: 8px">
            <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; height: 50px;">
                <tbody>
                    <tr>
                       <td style="text-align: center">
                           <asp:Image ID="Image2" runat="server" ImageUrl="~/images/image_415382.gif" />
                       </td> 
                    </tr>
                    <tr>
                    <td style="white-space: nowrap; text-align: center; font-family: verdana; font-size: 12px;">
                            <span class="Datos" 
                                style="font-size: 12px; font-family: Talo; font-weight:bold; color: #000000;">&nbsp;&nbsp; POR FAVOR ESPERE, PROCESANDO...</span>
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
