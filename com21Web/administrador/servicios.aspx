<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="servicios.aspx.cs" Inherits="administrador_servicios" %>

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
			<h2>Servicios</h2>
			<div class="dragbox-content" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:Panel ID="pMensajesAlertas" runat="server" Visible="false">
<div id="DMensaje" class="mensajes" runat="server"></div>
</asp:Panel>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 22%">
                            <asp:HiddenField ID="hfIdServicios" runat="server" />
                            Título:</td>
                        <td>
                            <asp:TextBox ID="txttitulo" runat="server" Width="95%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 22%">
                            Categoria:</td>
                        <td>
                            <asp:DropDownList ID="ddlcategorias" runat="server" Width="70%">
                            </asp:DropDownList></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Descripción corta:</td>
                        <td>
                            <asp:TextBox ID="txtinfo" runat="server" Height="50px" TextMode="MultiLine" 
                                Width="95%" MaxLength="240"></asp:TextBox><br />
                            <asp:Label ID="Label2" runat="server" Text="Máximo 240 caracteres"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Descripción:</td>
                        <td>
                        <HTMLEditor:Editor runat="server" Id="txtdescripcion" Height="180px" 
                                AutoFocus="true" Width="100%" NoUnicode="True" />
                                <%--<FCKeditorV2:FCKeditor ID="txtdescripcion" runat="server" Height="250px" Width="95%" BasePath="~/fckeditor/">
                    </FCKeditorV2:FCKeditor>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Imagen:</td>
                        <td>
                            <asp:Image ID="img" runat="server" Height="75px" Width="75px" 
                                ImageUrl="~/images/SIN_IMAGEN_SERV.png" />
                                <br />
                            <asp:Label ID="Label1" runat="server" Text="Tamaño de la imagen ancho:450, alto:450" Font-Size="10px"></asp:Label>
                            <br />
                            <asp:Label ID="Label3" runat="server" Font-Size="10px" Text="Formato de la imagen: jpg, png, gif, bmp"></asp:Label>
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
                            <asp:CheckBox ID="cbactivar" runat="server" Font-Size="10px" 
                                Text="marque para publicar" />
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
                </Triggers>
                </asp:UpdatePanel>   
        </div>
		</div>
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<h2>Servicios Ingresados</h2>
            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>--%>
			<div class="dragbox-content" >
                <asp:Panel ID="slidesi" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                           Para editar cada elemento por favor dar clic en la imagen 
                            <img alt="" src="../images/64_edit_page.png" height="22" width="22" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GvServicios" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Servicio" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvServicios_PageIndexChanging"
                                onrowdeleting="GvServicios_RowDeleting" 
                                onselectedindexchanged="GvServicios_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Servicios" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Servicio" runat="server" 
                                                Value='<%# Bind("Id_Servicio") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Servicio" runat="server" 
                                                Value='<%# Bind("Id_Servicio") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Servicios" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td width="77">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Ruta") %>' Width="74" Height="74" />
                                                    </td>
                                                    <td style="text-align: left; vertical-align: top;">
                                                        <div style="font-size: 14px; margin-bottom: 5px;"><asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label></div>
                                                        <div style="font-size: 12px"><asp:Label ID="Informacion" runat="server" Text='<%# Bind("Descrip") %>'></asp:Label></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size: 10px; text-align: left;" colspan="2">
                                                        Ingresado: <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Publicada" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                   </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Servicios" OnClientClick="return confirm('Desea eliminar el servicio');" />
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
                <asp:Panel ID="slideno" runat="server">
                    No existen servicios ingresados</asp:Panel>
			</div>
            <%--</ContentTemplate>
            </asp:UpdatePanel> --%>
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
