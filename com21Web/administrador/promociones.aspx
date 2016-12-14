<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="promociones.aspx.cs" Inherits="administrador_promociones" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/stylespanel/styles.css" />
    <link href="../anapp/cssJqueryMobile/MensajesEC.css" rel="stylesheet" />
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
        //$("#DMensaje").delay(10000).fadeOut();
        //        .disableSelection();
    });

</script>

   <%-- <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:UpdatePanel ID="upMantenimiento" runat="server">
    <ContentTemplate>


   <div class="demoarea" style="margin-left: 5px">
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Promociones/Publicidad</h2>
			<div class="dragbox-content" >
            <asp:Panel ID="pMensajesAlertas" runat="server" Visible="false">
<div id="DMensaje" class="mensajes" runat="server"></div>
</asp:Panel>
            <asp:UpdatePanel ID="upproducto" runat="server">
            <ContentTemplate>
            <asp:HiddenField ID="hfletra" runat="server" />
                <asp:HiddenField ID="hfIdproducto" runat="server" />
                <asp:HiddenField ID="hfIdpromo" runat="server" />
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 20%">
                            Seleccionar:</td>
                        <td>
                            <asp:DropDownList ID="ddlSeleccionar" runat="server" Width="50%" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlSeleccionar_SelectedIndexChanged" CssClass="ddlcurve" Height="23px">
                                <asp:ListItem Value="0">**Seleccionar**</asp:ListItem>
                                <asp:ListItem Value="1">Promoción</asp:ListItem>
                                <asp:ListItem Value="2">Publicidad</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Ubicación:</td>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td width="50%" style="vertical-align: top">
                                        <asp:DropDownList ID="ddlUbicar" runat="server" Width="50%" CssClass="ddlcurve" Height="23px">
                                            <asp:ListItem Value="0">**Seleccionar Ubicación**</asp:ListItem>
                                            <asp:ListItem Value="1">Prioridad 1</asp:ListItem>
                                            <asp:ListItem Value="2">Prioridad 2</asp:ListItem>
                                            <asp:ListItem Value="3">Prioridad 3</asp:ListItem>
                                            <%--<asp:ListItem Value="4">Prioridad 4</asp:ListItem>
                                            <asp:ListItem Value="5">Prioridad 5</asp:ListItem>--%>
                                            <asp:ListItem Value="6">Sin Prioridad</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <%--<td width="50%" style="text-align: right">
                                       <asp:Image ID="Image4" runat="server" ImageUrl="~/images/forma_pagina_web.png" 
                                Height="200px" Width="170px" />
                                    </td>--%>
                                </tr>
                            </table>
                            
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Imagen:</td>
                        <td>
                            <asp:Image ID="imgpropu" runat="server" Height="100" 
                                ImageUrl="~/images/promo_publi_sin.jpg" Width="300" />
                                <br />
                                <asp:Label ID="lblnot" runat="server" Text="Tamaño de la imagen ancho:768px, alto:140px" Font-Size="10px"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Seleccionar imagen:</td>
                        <td>
                            <asp:FileUpload ID="fimagenPro" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            &nbsp;</td>
                        <td>
                            <asp:LinkButton ID="lbvisualizarPro" runat="server" Font-Bold="True" 
                                ForeColor="#003366" onclick="lbvisualizarPro_Click">Visualizar</asp:LinkButton>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; " 
                            colspan="2">
                            <asp:Panel ID="pPromocion" runat="server" Visible="false">
                            <table style="width:100%;">
                                    <tr>
                                        <td>
                                            Sujeta a producto:</td>
                                        <td style="text-align: left">
                                            <asp:CheckBox ID="cbproducto" runat="server" 
                                                Text="Active la casilla para aplicar a un producto la promoción" 
                                                Font-Size="10px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Link del producto:</td>
                                        <td style="text-align: left">
                                            <asp:Label ID="lbllink" runat="server" Text="**No ha seleccionado el producto**"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pPublicidad" runat="server" Visible="false">
                                <table style="width:100%;">
                                    <tr>
                                        <td width="20%">
                                            Link:</td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtlink" runat="server" Width="60%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
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
                                Visible="false" onclick="btnedit_Click"/>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" 
                            style="text-align: center; font-size: 11px; font-style: italic;">
                            Nota: <asp:Label ID="Label1" runat="server" Text="Toda publicidad o promoción se ubicarán en los espacios con la letra de color naranja"></asp:Label>
                        </td>
                    </tr>
                </table> 
           </ContentTemplate>
           <Triggers>
           <asp:PostBackTrigger ControlID="lbvisualizarPro" />
           </Triggers>
            </asp:UpdatePanel>
       </div>
		</div>
        <div class="dragbox" id="item2" >
			<h2>Promociones/Publicidad ingresados</h2>
			<div class="dragbox-content" >
                <asp:Panel ID="pPPsi" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                           Para editar una promoción o publicidad por favor dar clic en la imagen 
                            <img alt="" src="../images/64_edit_page.png" height="22" width="22" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <table style="width: 100%;">
                             <tr>
                                 <td style="text-align: right">
                                      <asp:DropDownList ID="ddlbuscarseleccionar" runat="server" Width="40%" 
                                          CssClass="ddlcurve" Height="28px" BackColor="#E2FCE6" ForeColor="Gray">
                                          <asp:ListItem Value="0">**Seleccionar Busqueda**</asp:ListItem>
                                          <asp:ListItem Value="1">Promoción</asp:ListItem>
                                          <asp:ListItem Value="2">Publicidad</asp:ListItem>
                                          <%--<asp:ListItem Value="3">Prioridad</asp:ListItem>--%>
                                      </asp:DropDownList>
                                      &nbsp;
                                      <asp:DropDownList ID="ddlbuscarprioridad" runat="server" Width="40%" 
                                          CssClass="ddlcurve" Height="28px" BackColor="#E2FCE6" ForeColor="Gray" 
                                          Visible="False">
                                          <asp:ListItem Value="0">**Seleccionar Busqueda**</asp:ListItem>
                                            <asp:ListItem Value="1">Prioridad 1</asp:ListItem>
                                            <asp:ListItem Value="2">Prioridad 2</asp:ListItem>
                                            <asp:ListItem Value="3">Prioridad 3</asp:ListItem>
                                            <asp:ListItem Value="4">Prioridad 4</asp:ListItem>
                                            <asp:ListItem Value="5">Prioridad 5</asp:ListItem>
                                            <asp:ListItem Value="6">Sin Prioridad</asp:ListItem>
                                      </asp:DropDownList>
                                      <%--<asp:TextBox ID="txtbuscarpromopubli" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds" ></asp:TextBox>
                             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" 
                                 runat="server" TargetControlID="txtbuscarpromopubli" WatermarkCssClass="watermarked" 
                                 WatermarkText="Buscar promociones o publicidad" />--%>
                                 </td>
                                 <td style="text-align: right" width="30px">
                                     <asp:ImageButton ID="ImageButton2" runat="server" Height="28px" 
                                         ImageUrl="~/images/23.png" Width="28px" onclick="ImageButton2_Click" />
                                 </td>
                             </tr>
                         </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style=" padding:6px;">
                            
                            <asp:GridView ID="GvPP" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_ProPu" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvPP_PageIndexChanging"
                                onselectedindexchanged="GvPP_SelectedIndexChanged" Width="100%" 
                                onrowdeleting="GvPP_RowDeleting">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar Promociones/Publicidades" onclick="refresh1_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Promociones/Publicidad" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_ProPu" runat="server" 
                                                Value='<%# Bind("Id_ProPu") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_ProPu" runat="server" 
                                                Value='<%# Bind("Id_ProPu") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Promociones/Publicidad" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                        <table style="width:100%">
                                        <tr>
                                        <td><asp:Image ID="img" runat="server" ImageUrl='<%# Bind("Ruta") %>' Width="150" Height="75" />
                                        </td>
                                        </tr>
                                        <tr>
                                        <td style="font-size:11px; font-style:italic;">
                                        Ingresado: <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </td>
                                        </tr>
                                        </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        
                                    </ItemTemplate>
                                   </asp:TemplateField>--%>
                                   <asp:TemplateField HeaderText="Prioridad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Prioridad" runat="server" Text='<%# Bind("UbicarP") %>'></asp:Label>
                                    </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Promociones/Publicidades" OnClientClick="return confirm('Desea eliminar la promoción o publicidad');" />
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
                <asp:Panel ID="pPPno" runat="server">
                    No existen promociones y publicidad ingresados
                </asp:Panel>
			</div>
		</div>       
        </div>
        <div class="column" id="column2" >
        <img ID="Image1" class="imagenPequeña" src="../images/forma_pagina_web.png" width="195px" height="150px" />
		<div class="dragbox" id="item4" >
			<h2>Productos</h2>
			<div class="dragbox-content" >
                <asp:Panel ID="prosi" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                           Para asignar a una promoción por favor dar clic en la imagen 
                            <img alt="" src="../images/64_edit_page.png" height="22" width="22" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <%--Buscar: 
                            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                                Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">A</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">B</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">C</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">D</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton5" runat="server" onclick="LinkButton5_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">E</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton6" runat="server" onclick="LinkButton6_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">F</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton7" runat="server" onclick="LinkButton7_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">G</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton8" runat="server" onclick="LinkButton8_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">H</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton9" runat="server" onclick="LinkButton9_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">I</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton10" runat="server" onclick="LinkButton10_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">J</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton11" runat="server" onclick="LinkButton11_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">K</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton12" runat="server" onclick="LinkButton12_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">L</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton13" runat="server" onclick="LinkButton13_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">M</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton14" runat="server" onclick="LinkButton14_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">N</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton15" runat="server" onclick="LinkButton15_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">Ñ</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton16" runat="server" onclick="LinkButton16_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">O</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton17" runat="server" onclick="LinkButton17_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">P</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton18" runat="server" onclick="LinkButton18_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">Q</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton19" runat="server" onclick="LinkButton19_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">R</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton27" runat="server" onclick="LinkButton27_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">S</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton20" runat="server" onclick="LinkButton20_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">T</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton21" runat="server" onclick="LinkButton21_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">U</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton22" runat="server" onclick="LinkButton22_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">V</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton23" runat="server" onclick="LinkButton23_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">W</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton24" runat="server" onclick="LinkButton24_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">X</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton25" runat="server" onclick="LinkButton25_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">Y</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton26" runat="server" onclick="LinkButton26_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">Z</asp:LinkButton> - 
                            <asp:LinkButton ID="LinkButton28" runat="server" onclick="LinkButton28_Click" Font-Bold="True" Font-Size="11px" ForeColor="#599B1F">TODAS</asp:LinkButton>--%>
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
                                onselectedindexchanged="GvItems_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar Productos" onclick="refresh_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Productos" />
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
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" font-size:11px; font-style: italic;">
                                                        Ingresado: <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
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
                    No existen items ingresados
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
