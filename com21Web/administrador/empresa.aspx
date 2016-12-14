<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="empresa.aspx.cs" Inherits="administrador_empresa" %>

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


   <div class="demoarea" style="margin-left: 5px">
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2 style="font-family: 'font-family: 'Nunito'', sans-serif">Sucursales</h2>
			<div class="dragbox-content" >
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 35%">
                            <asp:HiddenField ID="hfletra" runat="server" />
                            <asp:HiddenField ID="hfIdEmpresa" runat="server" />
                            <asp:HiddenField ID="hfIdEmpresaP" runat="server" />
                            Sucursal:</td>
                        <td>
                            <asp:TextBox ID="txtempresa" runat="server" Width="65%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Provincia:</td>
                        <td>
                            <asp:DropDownList ID="ddlprovincia" runat="server" AutoPostBack="True" 
                                Height="23px" onselectedindexchanged="ddlprovincia_SelectedIndexChanged" 
                                Width="65%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Ciudad:</td>
                        <td>
                            <asp:DropDownList ID="ddlciudad" runat="server" Height="23px" Width="65%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Principal:</td>
                        <td>
                            <asp:CheckBox ID="cbsucursalp" runat="server" Font-Size="10px" 
                                Text="marque para definir matriz" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Despachar:</td>
                        <td>
                            <asp:CheckBox ID="cbdespacho" runat="server" Font-Size="10px" 
                                Text="marque para definir matriz de despacho de productos" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Publicar:</td>
                        <td>
                            <asp:CheckBox ID="cbsucursal" runat="server" 
                                Text="marque para publicar" Font-Size="10px" />
                        </td>
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
                    </tr>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
        </div>
		</div>
        
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
             <h2>  Sucursales Ingresados</h2>
                 <div class="dragbox-content">
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                     <asp:Panel ID="pSi" runat="server" Visible="false">
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
                                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                     <ContentTemplate>
                                      <asp:TextBox ID="txtbuscarempresa" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds"></asp:TextBox>
                                           <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                 runat="server" TargetControlID="txtbuscarempresa" WatermarkCssClass="watermarked" 
                                 WatermarkText="Buscar empresa" />
                                          </ContentTemplate>
                                     </asp:UpdatePanel>
                            
                                 </td>
                                 <td style="text-align: right" width="30px">
                                     <asp:ImageButton ID="ImageButton1" runat="server" Height="28px" 
                                         ImageUrl="~/images/23.png" Width="28px" onclick="ImageButton1_Click" />
                                 </td>
                             </tr>
                         </table>
                         </td>
                         <%--<td style="text-align: right; vertical-align: bottom;">
                            
                         </td>--%>
                         </tr>
                         <tr>
                             <td>
                                 <asp:GridView ID="GvEmpresa" runat="server" AllowPaging="True" 
                                     AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                                     BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Id_Empresa" 
                                     EnableModelValidation="True" GridLines="None" 
                                     onpageindexchanging="GvEmpresa_PageIndexChanging" 
                                     onrowdeleting="GvEmpresa_RowDeleting" 
                                     onselectedindexchanged="GvEmpresa_SelectedIndexChanged" Width="100%">
                                     <AlternatingRowStyle BackColor="#DCDCDC" />
                                     <Columns>
                                         <asp:TemplateField ShowHeader="False">
                                             <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar paises" onclick="refresh_Click" />
                                        </HeaderTemplate>
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                     Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                     ToolTip="Ver/Editar Empresa" />
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField>
                                             <EditItemTemplate>
                                                 <asp:HiddenField ID="Id_Empresa" runat="server" Value='<%# Bind("Id_Empresa") %>' />
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:HiddenField ID="Id_Empresa" runat="server" Value='<%# Bind("Id_Empresa") %>' />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Empresa" ItemStyle-HorizontalAlign="Center">
                                             <EditItemTemplate>
                                                 <asp:Label ID="Empresa" runat="server" Text='<%# Bind("Empresa") %>'></asp:Label>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Empresa" runat="server" Text='<%# Bind("Empresa") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Fecha Ingreso" 
                                             ItemStyle-HorizontalAlign="Center">
                                             <EditItemTemplate>
                                                 <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Matriz" ItemStyle-HorizontalAlign="Center">
                                             <EditItemTemplate>
                                                 <asp:CheckBox ID="Principal" runat="server" Checked='<%# Bind("Principal") %>' 
                                                     Enabled="false" />
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:CheckBox ID="Principal" runat="server" Checked='<%# Bind("Principal") %>' 
                                                     Enabled="false" />
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center">
                                             <EditItemTemplate>
                                                 <asp:CheckBox ID="Activar" runat="server" Checked='<%# Bind("Activar") %>' 
                                                     Enabled="false" />
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:CheckBox ID="Activar" runat="server" Checked='<%# Bind("Activar") %>' 
                                                     Enabled="false" />
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField ShowHeader="False">
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                     Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                     ToolTip="Eliminar Empresa" OnClientClick="return confirm('Al eliminar la sucursal, se eliminaran los costos de envio.');" />
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                     </Columns>
                                     <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                     <HeaderStyle BackColor="#ABCD43" Font-Bold="True" ForeColor="#333333" />
                                     <PagerStyle BackColor="#999999" Font-Names="Helvetica" Font-Size="12px" 
                                         ForeColor="Black" HorizontalAlign="Center" />
                                     <RowStyle BackColor="#EEEEEE" Font-Names="Helvetica" Font-Size="14px" 
                                         ForeColor="Black" />
                                     <%--<SelectedRowStyle Font-Bold="True" BackColor="#008A8C" ForeColor="White" />--%>
                                 </asp:GridView>
                             </td>
                         </tr>
                     </table>
                     </asp:Panel>
                     <asp:Panel ID="pNo" runat="server" Visible="false">
                         No existen sucursales ingresadas
                     </asp:Panel>
                     </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>
		</div>
	    </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
