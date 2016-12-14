<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="correos.aspx.cs" Inherits="administrador_correos" %>

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
<style type="text/css">
    .leidos
    {
        background-color: #fff;
    }
</style>
    <%-- <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:UpdatePanel ID="upMantenimiento" runat="server">
    <ContentTemplate>


   <div class="demoarea" style="margin-left: 5px">
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Bandeja de Entrada</h2>
			<div class="dragbox-content" >
            <asp:HiddenField ID="hfletraBE" runat="server" />
            <asp:Panel ID="pSBE" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                           Para ver cada correo por favor dar clic en la imagen 
                            <img alt="" src="../images/64_email.png" height="22" width="22" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 100%;">
                             <%--<tr>
                                 <td style="text-align: right">
                                      <asp:TextBox ID="txtbuscarinbox" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds" ></asp:TextBox>
                             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
                                 runat="server" TargetControlID="txtbuscarinbox" WatermarkCssClass="watermarked" 
                                 WatermarkText="Buscar Correos Entrantes" />
                                 </td>
                                 <td style="text-align: right" width="30px">
                                     <asp:ImageButton ID="ImageButton2" runat="server" Height="28px" 
                                         ImageUrl="~/images/23.png" Width="28px" onclick="imgCE_Click" />
                                 </td>
                             </tr>--%>
                         </table>
                        </td>
                    </tr>
                    <tr>
                        <td style=" padding:6px;">
                            <asp:GridView ID="GvCorreoE" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_InOut" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvCorreoE_PageIndexChanging"
                                onrowdeleting="GvCorreoE_RowDeleting" 
                                onselectedindexchanged="GvCorreoE_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                       <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="24px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar Correos Entrantes" onclick="refreshCE_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="24px" ImageUrl="~/images/64_email.png" style="margin:2px;" 
                                                ToolTip="Ver Correo" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_InOut" runat="server" 
                                                Value='<%# Bind("Id_InOut") %>' />
                                                <asp:HiddenField ID="Leido" runat="server" 
                                                Value='<%# Bind("Leido") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Para" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="Para" runat="server" Text='<%# Bind("Para") %>' Font-Size="11px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="text-align: left; vertical-align: top;">
                                                        <div style="font-size: 11px">
                                                            <asp:LinkButton ID="Titulo" runat="server" CommandName="Select"><%# Eval("Titulo") %></asp:LinkButton></div>
                                                        <div style="font-size: 11px"><asp:Label ID="Informacion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <div><asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>' Font-Size="11px"></asp:Label></div>
                                                        <div><asp:Label ID="Hora" runat="server" Text='<%# Bind("Hora") %>' Font-Size="11px"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="24px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Correo" OnClientClick="return confirm('Si desea eliminar el correo se hará de forma permanente.');" />
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
                <asp:Panel ID="pNBE" runat="server">
                    No existen correo en su bandeja de entrada actualmente.
                </asp:Panel>
        </div>
		</div>
             
        
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<h2>Bandeja de Salida</h2>
			<div class="dragbox-content" >
                <asp:HiddenField ID="hfletraBS" runat="server" />
                <asp:Panel ID="pSBS" runat="server">
                <table style="width: 100%;">
                    <%--<tr>
                        <td>
                            Para ver cada correo por favor dar clic en la imagen 
                            <img alt="" src="../images/64_email.png" height="22" width="22" />
                        </td>
                    </tr>--%>
                   <%-- <tr>
                        <td>
                                <table style="width: 100%;">
                                 <tr>
                                     <td style="text-align: right">
                                          <asp:TextBox ID="txtbuscaroutbox" runat="server"
                                     Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                              BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds" ></asp:TextBox>
                                 <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                     runat="server" TargetControlID="txtbuscaroutbox" WatermarkCssClass="watermarked" 
                                     WatermarkText="Buscar Correo Salientes" />
                                     </td>
                                     <td style="text-align: right" width="30px">
                                         <asp:ImageButton ID="ImageButton1" runat="server" Height="28px" 
                                             ImageUrl="~/images/23.png" Width="28px" onclick="ImageButton1_Click" />
                                     </td>
                                 </tr>
                             </table>
                        </td>
                    </tr>--%>
                    <tr>
                        <td style=" padding:6px;">
                            <asp:GridView ID="GvCorreoS" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_InOut" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvCorreoS_PageIndexChanging"
                                onrowdeleting="GvCorreoS_RowDeleting" 
                                onselectedindexchanged="GvCorreoS_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                       <HeaderTemplate>
                                         <%--<asp:ImageButton ID="refresh" runat="server"
                                                Height="24px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar Correos Entrantes" onclick="refreshCE_Click" />--%>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="24px" ImageUrl="~/images/64_email.png" style="margin:2px;" 
                                                ToolTip="Ver Correo" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_InOut" runat="server" 
                                                Value='<%# Bind("Id_InOut") %>' />
                                                <asp:HiddenField ID="Leido" runat="server" 
                                                Value='<%# Bind("Leido") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Para" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="Para" runat="server" Text='<%# Bind("Para") %>' Font-Size="11px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="text-align: left; vertical-align: top;">
                                                        <div style="font-size: 11px">
                                                            <asp:Label ID="Titulo" runat="server" Text='<%# Eval("Titulo") %>' ></asp:Label></div>
                                                        <div style="font-size: 11px"><asp:Label ID="Informacion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <div><asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>' Font-Size="11px"></asp:Label></div>
                                                        <div><asp:Label ID="Hora" runat="server" Text='<%# Bind("Hora") %>' Font-Size="11px"></asp:Label></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="24px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Correo" OnClientClick="return confirm('Si desea eliminar el correo se hará de forma permanente.');" />
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
                <asp:Panel ID="pNBS" runat="server">
                    No existen correo en su bandeja de salida actualmente.
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
<%--    <Triggers>
           <asp:PostBackTrigger ControlID="lbvisualizar" />
           </Triggers>--%>
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
