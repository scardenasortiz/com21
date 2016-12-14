<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="pais.aspx.cs" Inherits="administrador_pais" %>

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
			<h2 style="font-family: 'font-family: 'Nunito'', sans-serif">País</h2>
			<div class="dragbox-content" >
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 35%">
                            <asp:HiddenField ID="hfletra" runat="server" />
                            <asp:HiddenField ID="hfIdPais" runat="server" />
                            País:</td>
                        <td>
                            <asp:TextBox ID="txtpais" runat="server" Width="65%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Publicar:</td>
                        <td>
                            <asp:CheckBox ID="cbpais" runat="server" Text="marque para publicar" Font-Size="10px" />
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
             <h2>  Paises Ingresados</h2>
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
                                      <asp:TextBox ID="txtbuscarpais" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds" 
                                          ontextchanged="txtbuscarpais_TextChanged"></asp:TextBox>
                             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                 runat="server" TargetControlID="txtbuscarpais" WatermarkCssClass="watermarked" 
                                 WatermarkText="Buscar país" />
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
                                 <asp:GridView ID="GvPais" runat="server" AllowPaging="True" 
                                     AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                                     BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Id_Pais" 
                                     EnableModelValidation="True" GridLines="None" 
                                     onpageindexchanging="GvPais_PageIndexChanging" 
                                     onrowdeleting="GvPais_RowDeleting" 
                                     onselectedindexchanged="GvPais_SelectedIndexChanged" Width="100%">
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
                                                     ToolTip="Ver/Editar Pais" />
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField>
                                             <EditItemTemplate>
                                                 <asp:HiddenField ID="Id_Pais" runat="server" Value='<%# Bind("Id_Pais") %>' />
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:HiddenField ID="Id_Pais" runat="server" Value='<%# Bind("Id_Pais") %>' />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="País" ItemStyle-HorizontalAlign="Center">
                                             <EditItemTemplate>
                                                 <asp:Label ID="Pais" runat="server" Text='<%# Bind("Pais") %>'></asp:Label>
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:Label ID="Pais" runat="server" Text='<%# Bind("Pais") %>'></asp:Label>
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
                                         <asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center">
                                             <EditItemTemplate>
                                                 <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Aplicar") %>' 
                                                     Enabled="false" />
                                             </EditItemTemplate>
                                             <ItemTemplate>
                                                 <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Aplicar") %>' 
                                                     Enabled="false" />
                                             </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                         </asp:TemplateField>
                                         <asp:TemplateField ShowHeader="False">
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                     Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                     ToolTip="Eliminar Pais" OnClientClick="return confirm('Si desea eliminar el pais, también se eliminaran sus provincias, ciudades y los costos de envio ingresados.');" />
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
                     No existen países ingresados
                     </asp:Panel>
                     </ContentTemplate>
                     <Triggers>
                     <asp:PostBackTrigger ControlID="txtbuscarpais" />
                     </Triggers>
                     </asp:UpdatePanel>
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
