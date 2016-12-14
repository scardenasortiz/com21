<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" Culture="auto" UICulture="auto" CodeFile="rtransacciones.aspx.cs" Inherits="administrador_rtransacciones" %>

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
	.disableSelection();
    });

    function script2() {
        //document.getElementById("imgLOAD").style.display = "none";
        return confirm("Desea eliminar el usuario.");


    }
</script>
<%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   <div class="demoarea" style="margin-left: 5px">
       <asp:HiddenField ID="idBuscar" runat="server" Value="0"/>
       <table style="width: 100%; font-family: 'Arvo', serif; font-size: 14px; font-weight: bold;">
           <tr>
               <td width="16%">
                   &nbsp;</td>
               <td width="40">
                   &nbsp;</td>
               <td style="width: 15%">
                   Fecha inicio</td>
               <td>
                   Fecha final</td>
               <td style="width: 5%">
                   &nbsp;</td>
               <td width="19%">
                   Usuario</td>
               <td style="width: 3%">
                   &nbsp;</td>
           </tr>
           <tr>
               <td width="16%">
                   &nbsp;</td>
               <td width="60">
                   &nbsp;</td>
               <td>
                   <asp:TextBox ID="txtfechaini" runat="server" Width="150px"></asp:TextBox>
                   <ajaxToolkit:CalendarExtender ID="defaultCalendarExtender" runat="server"  
                       TargetControlID="txtfechaini" Format="MM/dd/yyyy" />
               </td>
               <td style="width: 15%">
                   <asp:TextBox ID="txtfechafi" runat="server" Width="150px"></asp:TextBox>
                   <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"  TargetControlID="txtfechafi" Format="MM/dd/yyyy" />
               </td>
               <td>
                   <asp:ImageButton ID="IBFechas" runat="server" Height="30px" 
                       ImageUrl="~/images/find.png" Width="30px" onclick="IBFechas_Click" />
               </td>
               <td width="19%">
                   <asp:TextBox ID="txtusuario" runat="server" Width="200px"></asp:TextBox>
               </td>
               <td>
                   <asp:ImageButton ID="IBUsuario" runat="server" 
                       ImageUrl="~/images/find.png" Height="30px" Width="30px" onclick="IBUsuario_Click" 
                       />
               </td>
           </tr>
           </table>
        <br />
        <asp:Panel ID="pSi" runat="server">
            <div>
        <asp:GridView ID="GvRTransacccion" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdTransaccion" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                Width="100%" onpageindexchanging="GvRTransacccion_PageIndexChanging" onselectedindexchanged="GvRTransacccion_SelectedIndexChanged" 
                EmptyDataText="No existen datos para la busqueda seleccionada" PageSize="13">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Actualizar Transacciones" onclick="refresh_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="IdTransaccion" runat="server" 
                                                Value='<%# Bind("IdTransaccion") %>' />
                                                <asp:HiddenField ID="IdUsuario" runat="server" 
                                                Value='<%# Bind("IdUsuario") %>' />
                                                <asp:HiddenField ID="CodUpdate" runat="server" 
                                                Value='<%# Bind("CodUpdate") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transacción" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtransaccion" runat="server" CommandName="Select" Text='<%# Bind("IdTransaccion") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Usuario" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Usuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Usuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Forma Pago" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="DescripcionFP" runat="server" Text='<%# Bind("DescripcionFP") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="DescripcionFP" runat="server" Text='<%# Bind("DescripcionFP") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado Transaccion" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="EstadoTransaccion" runat="server" Text='<%# Bind("EstadoTransaccion") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="EstadoTransaccion" runat="server" Text='<%# Bind("EstadoTransaccion") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Compra" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Facturado" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="Facturado" runat="server" Checked='<%# Bind("Facturado") %>' Enabled="false"></asp:CheckBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Facturado" runat="server" Checked='<%# Bind("Facturado") %>' Enabled="false"></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#ABCD43" Font-Bold="True" ForeColor="#333333" 
                                    Font-Size="14px" />
                                <PagerStyle BackColor="#999999" Font-Names="Helvetica" 
                                    Font-Size="12px" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" Font-Names="Helvetica" Font-Size="14px" 
                                    ForeColor="Black" />
                            </asp:GridView>
        </div>
        </asp:Panel>
        <asp:Panel ID="pNo" runat="server">
            <div>
                <table cellspacing="0" cellpadding="4" border="0" id="ctl00_ContentPlaceHolder1_GvRTransacccion" style="color:#333333;width:100%;border-collapse:collapse;">
			<tbody><tr style="color:#333333;background-color:#ABCD43;font-size:14px;font-weight:bold;">
				<th scope="col">
                                         <input type="image" name="ctl00$ContentPlaceHolder1$GvRTransacccion$ctl01$refresh" id="ctl00_ContentPlaceHolder1_GvRTransacccion_ctl01_refresh" title="Actualizar Transacciones" src="../images/imagenes/icons_variados_theme_negro/64_refresh.png" style="height:20px;border-width:0px;margin:2px;">
                                       </th><th scope="col">Transacción</th><th scope="col">Usuario</th><th scope="col">Forma Pago</th><th scope="col">Estado Transaccion</th><th scope="col">Fecha Compra</th><th scope="col">Facturado</th>
			</tr><tr style="color:Black;background-color:#EEEEEE;font-family:Helvetica;font-size:14px;">
				<td colspan="7">
                                            NO EXISTE TRANSACCIONES REGISTRADAS.
                                        </td>
			</tr>
		</tbody></table>
            </div>
        </asp:Panel>
        
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