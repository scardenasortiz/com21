<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="imagenes.aspx.cs" Inherits="administrador_imagenes" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        //        .disableSelection();
    });

</script>
   <%-- <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
    
    <asp:UpdatePanel ID="upMantenimiento" runat="server">
    <ContentTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/administrador/items.aspx"><--Regresar</asp:LinkButton>
   <div class="demoarea" style="margin-left: 5px">
 <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Imagenes</h2>
			<div class="dragbox-content" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:HiddenField ID="hfletra" runat="server" />
                <asp:HiddenField ID="hfletras" runat="server" />
            <asp:HiddenField ID="IdImagenes" runat="server" />
    <asp:HiddenField ID="IdProducto" runat="server" />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 30%">
                            Título Producto:</td>
                        <td>
                            <asp:Label ID="lblproducto" runat="server" Font-Bold="True" Font-Size="9pt"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Imagen1:</td>
                        <td>
                            <asp:Image ID="img0" runat="server" Height="64px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_image.png" 
                                Width="64px" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Selecciona imagen:</td>
                        <td>
                            <asp:FileUpload ID="fuimagen0" runat="server" />
                            <br />
                            <asp:LinkButton ID="lbvisualizar1" runat="server" Font-Bold="True" 
                                Font-Italic="True" ForeColor="#333333" onclick="lbvisualizar1_Click" >Visualizar</asp:LinkButton>

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Imagen2:</td>
                        <td>
                            <asp:Image ID="img1" runat="server" Height="64px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_image.png" 
                                Width="64px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Selecciona imagen:</td>
                        <td>
                            <asp:FileUpload ID="fuimagen1" runat="server" />
                            <br />
                            <asp:LinkButton ID="lbvisualiza2" runat="server" Font-Bold="True" 
                                Font-Italic="True" ForeColor="#333333" onclick="lbvisualiza2_Click" >Visualizar</asp:LinkButton>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Imagen3:</td>
                        <td>
                            <asp:Image ID="img2" runat="server" Height="64px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_image.png" 
                                Width="64px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Selecciona imagen:</td>
                        <td>
                            <asp:FileUpload ID="fuimagen2" runat="server" />
                            <br />
                            <asp:LinkButton ID="lbvisualizar3" runat="server" Font-Bold="True" 
                                Font-Italic="True" ForeColor="#333333" onclick="lbvisualizar3_Click">Visualizar</asp:LinkButton>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Imagen4:</td>
                        <td>
                            <asp:Image ID="img" runat="server" Height="64px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_image.png" 
                                Width="64px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Selecciona imagen:</td>
                        <td>
                            <asp:FileUpload ID="fuimagen" runat="server" />
                            <br />
                            <asp:LinkButton ID="lbvisualizar" runat="server" Font-Bold="True" 
                                Font-Italic="True" ForeColor="#333333" onclick="lbvisualizar_Click">Visualizar</asp:LinkButton>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Publicar:</td>
                        <td>
                            <asp:CheckBox ID="cbactivar" runat="server" Text="marque para publicar" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btninsert" runat="server" BackColor="#ABCD43" Font-Bold="True" 
                                ForeColor="#E2FCE6" Height="28px" onclick="btninsert_Click" Text="Grabar" 
                                Width="75px" />
                            <asp:Button ID="btnedit" runat="server" BackColor="#ABCD43" Font-Bold="True" 
                                ForeColor="#E2FCE6" Height="28px" onclick="btnedit_Click" Text="Grabar" 
                                Visible="false" Width="75px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table> 
                </ContentTemplate>
                    <Triggers>
    <asp:PostBackTrigger ControlID="lbvisualizar" />
    <asp:PostBackTrigger ControlID="lbvisualizar1" />
    <asp:PostBackTrigger ControlID="lbvisualiza2" />
    <asp:PostBackTrigger ControlID="lbvisualizar3" />
    </Triggers>
                </asp:UpdatePanel>
        
        </div>
		</div>
        
                             
        
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<h2>Imagenes Ingresadas</h2>
			<div class="dragbox-content" >
                <asp:Panel ID="imgsi" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                           Para editar cada elemento por favor dar clic en la imagen 
                            <img alt="" src="../images/64_edit_page.png" height="22" width="22" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <table style="width: 100%;">
                             <tr>
                                 <td style="text-align: right">
                                      <asp:TextBox ID="txtbuscarimagenes" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds" ></asp:TextBox>
                             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                 runat="server" TargetControlID="txtbuscarimagenes" WatermarkCssClass="watermarked" 
                                 WatermarkText="Buscar imagenes" />
                                 </td>
                                 <td style="text-align: right" width="30px">
                                     <asp:ImageButton ID="ImageButton2" runat="server" Height="28px" 
                                         ImageUrl="~/images/23.png" Width="28px" onclick="ImageButton2_Click" />
                                 </td>
                             </tr>
                         </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GvImagenes" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Imagenes" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvImagenes_PageIndexChanging"
                                onrowdeleting="GvImagenes_RowDeleting" 
                                onselectedindexchanged="GvImagenes_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar categorias" onclick="refreshs_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Provincia" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Imagenes" runat="server" 
                                                Value='<%# Bind("Id_Imagenes") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Imagenes" runat="server" 
                                                Value='<%# Bind("Id_Imagenes") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Imagenes" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <table style="width:100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Lbltitulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="width:100%;">
                                <tr>
                                    <td>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Ruta") %>' Width="48" Height="48" />
                                    </td>
                                    <td>
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Bind("Ruta1") %>' Width="48" Height="48" />
                                    </td>
                                    <td>
                                    <asp:Image ID="Image3" runat="server" ImageUrl='<%# Bind("Ruta2") %>' Width="48" Height="48" />
                                    </td>
                                    <td>
                                    <asp:Image ID="Image4" runat="server" ImageUrl='<%# Bind("Rutas3") %>' Width="48" Height="48" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style=" font-size:10px">
                                    Ingresado: <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label> 
                                    </td>
                                </tr>
                            </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Imagen2" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Bind("Ruta1") %>' Width="48" Height="48" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Bind("Ruta1") %>' Width="48" Height="48" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Imagen3" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Image ID="Image3" runat="server" ImageUrl='<%# Bind("Ruta2") %>' Width="48" Height="48" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="Image3" runat="server" ImageUrl='<%# Bind("Ruta2") %>' Width="48" Height="48" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Imagen4" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Image ID="Image4" runat="server" ImageUrl='<%# Bind("Rutas3") %>' Width="48" Height="48" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="Image4" runat="server" ImageUrl='<%# Bind("Rutas3") %>' Width="48" Height="48" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
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
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Provincia" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#ABCD43" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#999999" Font-Names="Helvetica" 
                                    Font-Size="12px" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" Font-Names="Helvetica" Font-Size="14px" 
                                    ForeColor="Black" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="imgno" runat="server">
                    No existen imagenes de productos ingresados</asp:Panel>
			</div>
		</div>
        <%--<div class="dragbox" id="item3" >
			<h2>Productos</h2>
			<div class="dragbox-content" >
                <asp:Panel ID="prodsi" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Para asignar imagenes a cada elemento por favor dar clic en la imagen 
                            <img alt="" src="../images/64_edit_page.png" height="22" width="22" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                           
                            <table style="width: 100%;">
                             <tr>
                                 <td style="text-align: right">
                                      <asp:TextBox ID="txtbuscarproducto" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds" ></asp:TextBox>
                             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
                                 runat="server" TargetControlID="txtbuscarproducto" WatermarkCssClass="watermarked" 
                                 WatermarkText="Buscar productos" />
                                 </td>
                                 <td style="text-align: right" width="30px">
                                     <asp:ImageButton ID="ImageButton1" runat="server" Height="28px" 
                                         ImageUrl="~/images/23.png" Width="28px" onclick="ImageButton1_Click" />
                                 </td>
                             </tr>
                         </table>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GvProducto" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Producto" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onselectedindexchanged="GvProducto_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar categorias" onclick="refresh_Click" />
                                       </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Producto" runat="server" 
                                                Value='<%# Bind("Id_Producto") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Producto" runat="server" 
                                                Value='<%# Bind("Id_Producto") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Producto" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70%">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="vertical-align: top; width:50px">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Ruta") %>' Width="48" Height="48" />
                                                    </td>
                                                    <td style="vertical-align: top;">
                                                        <div><asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label></div>
                                                        <div style="font-size:10px">Ingresado: <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Provincia" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#ABCD43" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#999999" Font-Names="Helvetica" 
                                    Font-Size="12px" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" Font-Names="Helvetica" Font-Size="14px" 
                                    ForeColor="Black" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="prodno" runat="server">
                    No existen productos ingresados
                </asp:Panel>
			</div>
		</div>--%>
	    </div>
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
    </ContentTemplate>

    </asp:UpdatePanel>
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
