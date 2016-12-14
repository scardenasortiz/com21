<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="costoenvio.aspx.cs" Inherits="administrador_ciudad" %>

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
			<h2>Costo Envio</h2>
			<div class="dragbox-content" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:HiddenField ID="hfidciudad" runat="server" />
                    <asp:HiddenField ID="hfIdcosto" runat="server" />
                    <asp:HiddenField ID="hfpais" runat="server" />
                    <asp:HiddenField ID="hfprovincia" runat="server" />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 30%">
                            Costo Envio:</td>
                        <td>
                            <asp:TextBox ID="txtcosto" runat="server" Width="65%"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender
            ID="FilteredTextBoxExtender3"
            runat="server" 
            TargetControlID="txtcosto"
            FilterType="Custom, Numbers"
            ValidChars=",." />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 30%">
                            Pais:</td>
                        <td>
                            <asp:DropDownList ID="ddlpais" runat="server" AutoPostBack="True" Width="65%" 
                                onselectedindexchanged="ddlpais_SelectedIndexChanged" Height="23px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 30%">
                            Provincia:</td>
                        <td>
                            <asp:DropDownList ID="ddlprovincia" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlprovincia_SelectedIndexChanged" Width="65%" 
                                Height="23px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Ciudad:</td>
                        <td>
                            <asp:DropDownList ID="ddlciudad" runat="server" Width="65%" Height="23px" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Sucursal:</td>
                        <td>
                            <asp:DropDownList ID="ddlsucursal" runat="server" Width="65%" Height="23px">
                            </asp:DropDownList>
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
                            <asp:CheckBox ID="cbactivar" runat="server" Text="marque para publicar" Font-Size="10px" />
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
                                <asp:Button ID="btnedit" runat="server" BackColor="#ABCD43" Font-Bold="True" 
                                ForeColor="#E2FCE6" Height="28px" Text="Grabar" Width="75px" 
                                Visible="false" onclick="btnedit_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                 
                
        
        </div>
		</div>
             
        
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<h2>Costos Ingresados</h2>
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
                            <asp:GridView ID="GvCosto" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Costo" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvCosto_PageIndexChanging"
                                onrowdeleting="GvCosto_RowDeleting" 
                                onselectedindexchanged="GvCosto_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Costo" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Costo" runat="server" 
                                                Value='<%# Bind("Id_Costo") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Costo" runat="server" 
                                                Value='<%# Bind("Id_Costo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Costo Envio" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Costo" runat="server" Text='<%# Bind("Costo") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Costo" runat="server" Text='<%# Bind("Costo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ciudad" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Ciudad" runat="server" Text='<%# Bind("Ciudad") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Ciudad" runat="server" Text='<%# Bind("Ciudad") %>'></asp:Label>
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
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Costo" OnClientClick="return confirm('Desea eliminar el costo.');" />
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
                    No existen costos de envios ingresadas
                </asp:Panel>
			</div>
		</div>
		<%--<div class="dragbox" id="item5" >
			<h2>Handle 5</h2>
			<div class="dragbox-content" >
				Nam rhoncus sodales libero, et facilisis nisi volutpat et. Nullam tellus eros, consequat eget tristique ultricies, rhoncus vitae magna. Duis nec scelerisque orci. Nullam a enim est, et eleifend nunc. Proin dui eros, vulputate eget consectetur quis, ultrices ac sem. Nulla aliquam metus eu magna placerat placerat. Suspendisse eget tellus turpis, et ultricies nisi. Etiam in diam mi, sed tincidunt eros. Phasellus convallis aliquam arcu, vitae fringilla quam pharetra sed. In at augue at nibh placerat feugiat at id elit. Curabitur sit amet quam ut turpis molestie blandit in vel nulla. 
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
