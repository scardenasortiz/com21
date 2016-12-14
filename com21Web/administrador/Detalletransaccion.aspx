<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="Detalletransaccion.aspx.cs" Inherits="administrador_Detalletransaccion" %>


<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="js/printDetTran.js"></script> 
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
          <table style="width:100%"><tr><td style="text-align:left;"><asp:HiddenField ID="hfact" runat="server" />
              <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/regresar_A.png" 
                  runat="server" Height="33px" onclick="ImageButton1_Click" ToolTip="Regresar" 
                  Width="33px" />
              </td><td style="width:35px">
              &nbsp;</td><td style="width:35px">
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
           <table style="width: 100%; font-family: 'Arvo', serif; font-size: 11px; font-weight: normal;">
               <tr>
                   <td 
                       
                       style="padding: 5px; background-color: #ABCD43; color: #FFFFFF; font-weight: bold; -webkit-border-top-left-radius: 5px; -webkit-border-top-right-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-topright: 5px; border-top-left-radius: 5px; border-top-right-radius: 5px;">
                       <div style="font-size: 20px; color: #333333; font-weight: bold;">Com21 S.A</div>Servicio en Telecomunicaciones</td>
               </tr>
               <tr>
                   <td>
                       <table style="width:100%;">
                           <tr>
                               <td style="width:11%;">
                                   <div style="padding: 3px 5px 3px 5px; width: 125px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Nombres:
                                   </div>
                               </td>
                               <td style="width:39%;">
                                   <asp:Label ID="lblnombres" runat="server" Font-Bold="True" ForeColor="Black" 
                                       Font-Size="12px"></asp:Label>
                               </td>
                               <td style="width:11%;">
                                   <div style="padding: 3px 5px 3px 5px; width: 100px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Apellidos:
                                   </div>
                               </td>
                               <td style="width:39%;">
                                   <asp:Label ID="lblapellidos" runat="server" Font-Bold="True" 
                                       ForeColor="#000000" Font-Size="12px"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td style="width:10%;">
                                   <div style="padding: 3px 5px 3px 5px; width: 125px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Usuario:
                                   </div>
                               </td>
                               <td style="width:30%;">
                                   <asp:Label ID="lblusuario" runat="server" Font-Bold="True" ForeColor="#000000" Font-Size="12px"></asp:Label>
                               </td>
                               <td style="width:10%;">
                                   <div style="padding: 3px 5px 3px 5px; width: 100px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Correo:
                                   </div>
                               </td>
                               <td style="width:30%;">
                                   <asp:Label ID="lblcorreo" runat="server" Font-Bold="True" ForeColor="#000000" Font-Size="12px"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <div style="padding: 3px 5px 3px 5px; width: 125px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Telefono:
                                   </div>
                               </td>
                               <td>
                                   <asp:Label ID="lbltelefono" runat="server" Font-Bold="True" Font-Size="12px" ForeColor="#000000"></asp:Label>
                               </td>
                               <td>
                                   <div style="padding: 3px 5px 3px 5px; width: 100px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Celular:
                                   </div>
                               </td>
                               <td>
                                   <asp:Label ID="lblcelular" runat="server" ForeColor="#000000" Font-Size="12px" Font-Bold="True"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <div style="padding: 3px 5px 3px 5px; width: 125px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Direccion:
                                   </div>
                               </td>
                               <td>
                                   <asp:Label ID="lbldireccion" runat="server" ForeColor="#000000" Font-Size="12px" Font-Bold="True"></asp:Label>
                               </td>
                               <td>
                                    
                                   <div style="padding: 3px 5px 3px 5px; width: 100px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Forma Pago:
                                   </div>
                                    
                               </td>
                               <td>
                                   <asp:Label ID="lblformaP" runat="server" Font-Bold="True" Font-Size="12px" ForeColor="#000000"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td>
                                   <div style="padding: 3px 5px 3px 5px; width: 125px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Facturado/Entregado:
                                   </div>
                               </td>
                               <td>
                                   <asp:CheckBox ID="cbfacturado" runat="server" />
                                   &nbsp;&nbsp;
                                   <asp:LinkButton ID="lblguardar" runat="server" Font-Bold="True" 
                                       Font-Size="13px" ForeColor="#666666" onclick="lblguardar_Click">Grabar</asp:LinkButton>
                               </td>
                               <td>
                                   <div style="padding: 3px 5px 3px 5px; width: 100px; font-size:12px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Estado:
                                   </div>
                               </td>
                               <td>
                                   <asp:Label ID="lblestado" runat="server" Font-Bold="True" Font-Size="12px" ForeColor="#000000"></asp:Label>
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
                    <asp:Panel ID="pcodtrans" runat="server">
                        <table style="width: 100%; font-family: 'Arvo', serif; font-size: 12px; font-weight: normal;">
                        <tr>
                            <td style="width:11%;">
                                <div style="padding: 3px 5px 3px 5px; width: 120px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                        #/Transferencia:
                                    </div>
                            </td>
                            <td>
                                <asp:Label ID="lblcodigotrans" runat="server" Font-Size="12px" Font-Bold="True" 
                                    ForeColor="#000000"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                </td>
               </tr>
               <tr>
                   <td style="text-align: left">
                       <asp:Panel ID="pActE" runat="server">
                       <div style="font-weight: bold; font-size: 16px">DATOS PARA EL ENVIO</div>
                       <table style="width: 100%; font-family: 'Arvo', serif; font-size: 12px; font-weight: normal;">
                           <tr>
                               <td style="width:15%;">
                                   <div style="padding: 3px 5px 3px 5px; width: 130px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Nombre Contacto:
                                   </div>
                               </td>
                               <td style="width:40%;">
                                   <asp:Label ID="lblnombrecontacto" runat="server" Font-Size="12px" Font-Bold="True" 
                                       ForeColor="#000000"></asp:Label>
                               </td>
                               <td style="width:10%;">
                                   <div style="padding: 3px 5px 3px 5px; width: 100px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Teléfono:
                                   </div>
                               </td>
                               <td style="width:40%;">
                                   <asp:Label ID="lbltelefonoenvio" runat="server" Font-Size="12px" Font-Bold="True" 
                                       ForeColor="#000000"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td style="width:15%;">
                                   <div class="ForT" style="padding: 3px 5px 3px 5px; width: 130px; background-color: #B90000; color: #ffffff; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px;">
                                       Dirección Envio:
                                   </div>
                               </td>
                               <td colspan="3">
                                   <asp:Label ID="lbldireccionenvio" runat="server" Font-Size="12px" Font-Bold="True" 
                                       ForeColor="#000000"></asp:Label>
                               </td>
                           </tr>
                       </table>
                       </asp:Panel>
                   </td>                  
               </tr>
               <tr>
                   <td>
                       <asp:GridView ID="GvRProductos" runat="server" CssClass="Productos" 
                           AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdPrefactura" 
                           EmptyDataText="No existen datos para la busqueda seleccionada" 
                           EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                           onpageindexchanging="GvRProductos_PageIndexChanging" Width="100%">
                           <AlternatingRowStyle BackColor="#DCDCDC" />
                           <Columns>
                               <asp:TemplateField>
                                   <%--<HeaderTemplate>
                                       <asp:ImageButton ID="refresh" runat="server" Height="20px" 
                                           ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" 
                                           onclick="refresh_Click" style="margin:2px;" ToolTip="Cargar categorias" />
                                   </HeaderTemplate>--%>
                                   <ItemTemplate>
                                       <asp:HiddenField ID="IdPrefactura" runat="server" 
                                           Value='<%# Bind("IdPrefactura") %>' />
                                       <asp:HiddenField ID="Id_Producto" runat="server" 
                                           Value='<%# Bind("Id_Producto") %>' />
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField ItemStyle-HorizontalAlign="center">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="refresh" runat="server" Width="80px"
                                           ImageUrl='<%# Bind("Img") %>'
                                           style="margin:2px;" />
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Left" />
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
                               <asp:TemplateField HeaderText="Cantidad" 
                                   ItemStyle-HorizontalAlign="Center">
                                   <EditItemTemplate>
                                       <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Precio" 
                                   ItemStyle-HorizontalAlign="Center">
                                   <EditItemTemplate>
                                       $<asp:Label ID="Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       $<asp:Label ID="Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Descuento" 
                                   ItemStyle-HorizontalAlign="Right">
                                   <EditItemTemplate>
                                       $<asp:Label ID="Descuento" runat="server" Text='<%# Bind("Descuento") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       $<asp:Label ID="Descuento" runat="server" Text='<%# Bind("Descuento") %>'></asp:Label>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" />
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Valor" 
                                   ItemStyle-HorizontalAlign="Right">
                                   <EditItemTemplate>
                                       $<asp:Label ID="Valor" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                       $<asp:Label ID="Valor" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
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
                                   <div style="padding: 3px 5px 3px 5px; width: 116px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px; float: right; font-size: 14px;">
                                       Total Descuento:
                                   </div>
                               </td>
                               <td style="padding-right: 20px;" width="85px">
                                   <asp:Label ID="lbltotalDesc" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td style="text-align: right">
                                   <div style="padding: 3px 5px 3px 5px; width: 116px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px; float: right; font-size: 14px;">
                                       Total Subtotal:
                                   </div>
                               </td>
                               <td style="padding-right: 20px;" width="85px">
                                   <asp:Label ID="lblsubtotal" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td style="text-align: right">
                                   <div style="padding: 3px 5px 3px 5px; width: 116px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px; float: right; font-size: 14px;">
                                       Costo de envio:
                                   </div>
                               </td>
                               <td style="padding-right: 20px;" width="85px">
                                   <asp:Label ID="lblcosto" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td style="text-align: right">
                                   <div style="padding: 3px 5px 3px 5px; width: 40px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px; float: right; font-size: 14px;">
                                       Iva:
                                   </div>
                               </td>
                               <td style="padding-right: 20px;" width="85px">
                                   <asp:Label ID="lbliva" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td style="text-align: right">
                                   <div style="padding: 3px 5px 3px 5px; width: 77px; background-color: #B90000; color: #FFFFFF; -webkit-border-top-left-radius: 5px; -webkit-border-bottom-left-radius: 5px; -moz-border-radius-topleft: 5px; -moz-border-radius-bottomleft: 5px; border-top-left-radius: 5px; border-bottom-left-radius: 5px; float: right; font-size: 14px;">
                                       Total Final:
                                   </div>
                               </td>
                               <td style="padding-right: 20px;" width="85px">
                                   <asp:Label ID="lbltotalF" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label>
                               </td>
                           </tr>
                       </table>
                   </td>
               </tr>
           </table>
       </div>
        <br />
       </ContentTemplate>
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
