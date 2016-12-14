<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="asignarproducto.aspx.cs" Inherits="administrador_asignarproducto" %>

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
    <%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:UpdatePanel ID="upMantenimiento" runat="server">
    <ContentTemplate>


   <div class="demoarea" style="margin-left: 5px">
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Asignar marca</h2>
			<div class="dragbox-content" >
            <asp:HiddenField ID="hfletra" runat="server" />
            <asp:HiddenField ID="hfletras" runat="server" />
                <asp:HiddenField ID="hfIdproducto" runat="server" />
                <asp:HiddenField ID="hfIdmarca" runat="server" />
                <asp:HiddenField ID="hfIdCat" runat="server" />
                <asp:HiddenField ID="hfIdSubCat" runat="server" />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 30%">
                            Marca:</td>
                        <td>
                            <asp:Label ID="lblmarca" runat="server" Text="**Sin marca seleccionada**"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 30%">
                            Producto:</td>
                        <td>
                            <asp:Label ID="lblproducto" runat="server" Text="**Sin producto seleccionado**"></asp:Label>
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
                                ForeColor="#E2FCE6" Height="28px" Text="Grabar" Width="75px" 
                                onclick="btninsert_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table> 
                
        
        </div>
		</div>
        <div class="dragbox" id="item2" >
			<h2>Marcas Ingresadas</h2>
			<div class="dragbox-content" >
                <asp:Panel ID="pMarcasi" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Para asignar una marca por favor dar clic en la imagen 
                            <img alt="" src="../images/64_edit_page.png" height="22" width="22" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 100%;">
                             <tr>
                                 <td style="text-align: right">
                                      <asp:TextBox ID="txtbuscarmarca" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds" ></asp:TextBox>
                             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
                                 runat="server" TargetControlID="txtbuscarmarca" WatermarkCssClass="watermarked" 
                                 WatermarkText="Buscar marcas" />
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
                        <td style=" padding:6px;">
                            <asp:GridView ID="GvMarca" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Marca" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvMarca_PageIndexChanging" onselectedindexchanged="GvMarca_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar marcas" onclick="refresh_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Marca" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Marca" runat="server" 
                                                Value='<%# Bind("Id_Marca") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Marca" runat="server" 
                                                Value='<%# Bind("Id_Marca") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marca" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Marca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Marca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
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
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
                                   </asp:TemplateField>
                                   <%-- <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Marca" OnClientClick="return confirm('Al eliminar la marca, se inactivarán los productos sujetos a la marca.');" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
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
                <asp:Panel ID="pMarcano" runat="server">
                    No existen marcas ingresadas
                </asp:Panel>
			</div>
		</div>  
        
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<h2>Productos sin marca</h2>
			<div class="dragbox-content" >
                <asp:Panel ID="prosi" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Para seleccionar un producto por favor dar clic en la imagen 
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
                                onpageindexchanging="GvItems_PageIndexChanging" onselectedindexchanged="GvItems_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar Productos" onclick="refreshs_Click" />
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
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
                                   </asp:TemplateField>
                                    <%--<asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Producto" OnClientClick="return confirm('Desea eliminar el producto');" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Categoria" runat="server" 
                                                Value='<%# Bind("Id_Categoria") %>' />
                                                <asp:HiddenField ID="Id_SubCategoria" runat="server" 
                                                Value='<%# Bind("Id_SubCategoria") %>' />
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
                            <%--<asp:LinkButton ID="lbasignar" runat="server" Font-Bold="True" 
                                Font-Italic="True" ForeColor="#333333" onclick="lbasignar_Click">Más Imagen</asp:LinkButton>--%>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="prono" runat="server">
                    No existen productos sin marca</asp:Panel>
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

