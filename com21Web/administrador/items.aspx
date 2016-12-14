<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="items.aspx.cs" Inherits="administrador_items" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:UpdatePanel ID="upMantenimiento" runat="server">
    <ContentTemplate>   <link rel="stylesheet" type="text/css" href="../css/stylespanel/styles.css" />
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
   <div class="demoarea" style="margin-left: 5px">
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Producto</h2>
			<div class="dragbox-content" >
            <asp:UpdatePanel ID="upproducto" runat="server">
            <ContentTemplate>
            <asp:HiddenField ID="hfletra" runat="server" />
                <asp:HiddenField ID="hfIdproducto" runat="server" />
                <asp:HiddenField ID="hfids" runat="server" />
                <asp:HiddenField ID="hfinvent" runat="server" Value="0" />
                <asp:HiddenField ID="hfinsertid" runat="server" />
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 20%">
                            Título:</td>
                        <td>
                            <asp:TextBox ID="txttitulo" runat="server" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; ">
                            Código del producto:</td>
                        <td>
                            <asp:TextBox ID="txtcodigo" runat="server" Width="70%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Descripción:</td>
                        <td>
                            <HTMLEditor:Editor runat="server" Id="txtdescripcion" Height="180px" 
                                AutoFocus="true" Width="100%" NoUnicode="True" />
                                <%--<FCKeditorV2:FCKeditor ID="txtdescripcion" runat="server" Height="250px" Width="100%" BasePath="~/fckeditor/">
                    </FCKeditorV2:FCKeditor>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Descripción corta:</td>
                        <td>
                            <asp:TextBox ID="txtdescripcioncorta" runat="server" Height="50px" 
                                TextMode="MultiLine" Width="100%" MaxLength="500"></asp:TextBox>
                                <br />
                                Máximo 500 caracteres.
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; ">
                            Categoria:</td>
                        <td>
                            <asp:DropDownList ID="ddlcategorias" runat="server" Width="70%" 
                                AutoPostBack="True" onselectedindexchanged="ddlcategorias_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Sub-Categoria:</td>
                        <td>
                            <asp:DropDownList ID="ddlsubcategoria" runat="server" Width="70%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; ">
                            Marca:</td>
                        <td>
                            <asp:DropDownList ID="ddlmarca" runat="server" Width="70%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Cantidad:</td>
                        <td>
                            <asp:TextBox ID="txtcantidad" runat="server" Width="30%"></asp:TextBox>
                            <br />
                            Ejemplo: 10
                            <ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender1"
           runat="server"
           TargetControlID="txtcantidad"
           FilterType="Numbers" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; ">
                            IVA:</td>
                        <td>
                            <asp:CheckBox ID="cbiva" runat="server" Text="Aplicar iva al producto" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top">
                            Precio Venta:</td>
                        <td>
                            <asp:TextBox ID="txtprecio" runat="server" Width="30%"></asp:TextBox>
                            <br />
                            Ejemplo: 63.43
                            <ajaxToolkit:FilteredTextBoxExtender
            ID="FilteredTextBoxExtender2"
            runat="server" 
            TargetControlID="txtprecio"
            FilterType="Custom, Numbers"
            ValidChars=",." />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top">
                            Precio Compra:</td>
                        <td>
                            <asp:TextBox ID="txtpreciocompra" runat="server" Width="30%"></asp:TextBox>
                            <br />
                            Ejemplo: 63.43
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
                                runat="server" FilterType="Custom, Numbers" TargetControlID="txtpreciocompra" 
                                ValidChars=",." />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top">
                            Descuento %:
                        </td>
                        <td>
                            <asp:TextBox ID="txtdescuento" runat="server" Width="30%">0</asp:TextBox>
                            <br />
                            Ejemplo: 10.34
                             <ajaxToolkit:FilteredTextBoxExtender
            ID="FilteredTextBoxExtender4"
            runat="server" 
            TargetControlID="txtdescuento"
            FilterType="Custom, Numbers"
            ValidChars=",." />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; ">
                            Imagen:</td>
                        <td>
                            <asp:Image ID="Image3" runat="server" Height="75px" Width="75px" 
                                ImageUrl="~/images/SIN_IMAGEN.png" />
                                <br />
                            <asp:Label ID="lblimagen" runat="server" Font-Size="10px" Text="Imagen ancho:600px, alto:600px"></asp:Label>
                            <br />
                            <asp:Label ID="Label1" runat="server" Font-Size="10px" Text="Extesión: gif, png, jpg, bmp"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; ">
                            Selecciona imagen:</td>
                        <td>
                            <asp:FileUpload ID="fuimagen" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; ">
                            &nbsp;</td>
                        <td>
                            <asp:LinkButton ID="lbvisualizar" runat="server" Font-Bold="True" 
                                ForeColor="#003366" onclick="lbvisualizar_Click">Visualizar</asp:LinkButton>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Publicar:</td>
                        <td>
                            <asp:CheckBox ID="cbactivar" runat="server" Text="marque para publicar" Font-Size="10px" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btninsert" runat="server" BackColor="#ABCD43" Font-Bold="True" 
                                ForeColor="#E2FCE6" Height="28px" Text="Grabar" Width="75px" 
                                onclick="btninsert_Click" />
                                <asp:Button ID="btnedit" runat="server" BackColor="#ABCD43" Font-Bold="True" 
                                ForeColor="#E2FCE6" Height="28px" Text="Grabar" Width="75px" 
                                Visible="false" onclick="btnedit_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table> 
           </ContentTemplate>
           <Triggers>
           <asp:PostBackTrigger ControlID="lbvisualizar" />
           <asp:AsyncPostBackTrigger ControlID="btninsert" />
           <asp:AsyncPostBackTrigger ControlID="btnedit" />
           </Triggers>
            </asp:UpdatePanel>
       </div>
		</div>
             
        
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<h2>Productos ingresados</h2>
			<div class="dragbox-content" >
                <asp:Panel ID="prosi" runat="server">
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
                                      <asp:TextBox ID="txtbuscarproducto" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds" ></asp:TextBox>
                             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
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
                        <td style=" padding:6px;">
                            
                            <asp:GridView ID="GvItems" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Producto" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvItems_PageIndexChanging"
                                onrowdeleting="GvItems_RowDeleting" 
                                onselectedindexchanged="GvItems_SelectedIndexChanged" Width="100%" 
                                onrowediting="GvItems_RowEditing" onrowcommand="GvItems_RowCommand" 
                                PageSize="18">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar productos" onclick="refresh_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select"
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Productos" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="SubirImagen" runat="server" CommandName="Edit" Height="20px" ImageUrl="~/images/64_upload.png" style="margin:2px;" 
                                                ToolTip="Subir Imagenes para Producto" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
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
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
                                   </asp:TemplateField>
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
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Producto" OnClientClick="return confirm('Desea eliminar el producto');" />
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
                <asp:Panel ID="prono" runat="server">
                    <table cellspacing="0" cellpadding="4" border="0" style="color:#333333;width:100%;border-

collapse:collapse;">
			<tbody><tr style="color:#333333;background: #ABCD43;font-weight:bold;">
				<th 

scope="col">Producto</th><th scope="col">Fecha Ingreso</th><th 

scope="col">Publicada</th>
			</tr><tr style="color:Black;background-color:#EEEEEE;font-family:Helvetica;font-size:14px;background: #dddddd;">
				    <td align="left" colspan="3" >
                                            
                                        No existen productos ingresados.</td>
			</tr>
		</tbody></table>
                </asp:Panel>
                <%--<asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopup">
            <asp:Panel ID="Panel3" runat="server" Style="cursor: move; background-color: #DDDDDD;
                border: solid 1px Gray; color: Black">
                <div>
                    <p>
                        Choose the paragraph style you would like:</p>
                </div>
            </asp:Panel>
            <div>
                <p>
                    <input type="radio" name="Radio" id="RadioA" checked="checked" onclick="styleToSelect = 'sampleStyleA';" />
                    <label for="RadioA" class="sampleStyleA" style="padding: 3px;">
                        Sample paragraph text</label>
                </p>
                <p>
                    <input type="radio" name="Radio" id="RadioB" onclick="styleToSelect = 'sampleStyleB';" />
                    <label for="RadioB" class="sampleStyleB" style="padding: 3px;">
                        Sample paragraph text</label>
                </p>
                <p>
                    <input type="radio" name="Radio" id="RadioC" onclick="styleToSelect = 'sampleStyleC';" />
                    <label for="RadioC" class="sampleStyleC" style="padding: 3px;">
                        Sample paragraph text</label>
                </p>
                <p>
                    <input type="radio" name="Radio" id="RadioD" onclick="styleToSelect = 'sampleStyleD';" />
                    <label for="RadioD" class="sampleStyleD" style="padding: 3px;">
                        Sample paragraph text</label>
                </p>
                <p style="text-align: center;">
                    <asp:Button ID="OkButton" runat="server" Text="OK" />
                    <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
                </p>
            </div>
        </asp:Panel>--%>
       <%-- <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server"TargetControlID="LinkButton1"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" OkControlID="OkButton"
            OnOkScript="onOk()" CancelControlID="CancelButton" DropShadow="true" PopupDragHandleControlID="Panel3" />--%>
			</div>
		</div>
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
    <telerik:RadToolTip ID="RadToolTip3" runat="server" 
                            Animation="FlyIn" ManualClose="True" Modal="True" 
                            Skin="Default">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <asp:HiddenField ID="IdImagenes" runat="server" />
    <asp:HiddenField ID="IdProductoPopup" runat="server" />
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
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
                            <asp:LinkButton ID="lblimagenes_productos" runat="server" Font-Bold="True" 
                                Font-Italic="True" ForeColor="#333333" onclick="lbimagenes_Click">Visualizar Imagenes</asp:LinkButton>
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
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="marque para publicar" />
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
                            <asp:Button ID="btninsert_imagenes" runat="server" BackColor="#ABCD43" Font-Bold="True" 
                                ForeColor="#E2FCE6" Height="28px" Text="Grabar" 
                                Width="75px" onclick="btninsert_imagenes_Click" />
                            <asp:Button ID="btnedit_imagenes" runat="server" BackColor="#ABCD43" Font-Bold="True" 
                                ForeColor="#E2FCE6" Height="28px" Text="Grabar" 
                                Visible="false" Width="75px" onclick="btnedit_imagenes_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="lblimagenes_productos" />
                            </Triggers>
                        </asp:UpdatePanel>
                                     </telerik:RadToolTip>
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
    </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
