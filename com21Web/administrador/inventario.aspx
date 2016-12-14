<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="inventario.aspx.cs" Inherits="administrador_inventario" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

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
<%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
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
               <td width="19%">
                   </td>
               <td width="40">
                   &nbsp;</td>
               <td width="19%">
                   Producto</td>
               <td width="10">
                   &nbsp;</td>
           </tr>
           <tr>
               <td width="16%">
                   &nbsp;</td>
               <td width="60">
                   &nbsp;</td>
               <td width="19%">
                   &nbsp;</td>
               <td width="60">
                   &nbsp;</td>
               <td width="19%">
                   <asp:TextBox ID="txtproducto" runat="server" Width="240px"></asp:TextBox>
               </td>
               <td width="10">
                   <asp:ImageButton ID="IBProducto" runat="server" 
                       ImageUrl="~/images/find.png" Height="30px" Width="30px" 
                       onclick="IBProducto_Click"/>
                   </td>
           </tr>
           </table>
        <br />
        <asp:Panel ID="pSi" runat="server">
            <div>
        <asp:GridView ID="GvRProductos" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Inventario" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                Width="100%" onpageindexchanging="GvRProductos_PageIndexChanging" onselectedindexchanged="GvRProductos_SelectedIndexChanged" 
                EmptyDataText="No existen datos para la busqueda seleccionada" PageSize="16">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Inventario" runat="server" 
                                                Value='<%# Bind("Id_Inventario") %>' />
                                                <asp:HiddenField ID="Id_Producto" runat="server" 
                                                Value='<%# Bind("Id_Producto") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Producto" ItemStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label> 
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Titulo" runat="server" Text='<%# Bind("Titulo") %>'></asp:Label> 
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad Inicial" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Precio Inicial" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            $<asp:Label ID="Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            $<asp:Label ID="Precio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha Ingreso" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="FechaIngreso" runat="server" Text='<%# Bind("FechaIngreso") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Actualizar Inventario" onclick="refresh_Click" />
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" OnClientClick="return confirm('Desea visualizar a detalle');">Ver detalle</asp:LinkButton>
                                            <%--<asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Producto" OnClientClick="return confirm('Desea eliminar el producto');" />--%>
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
                &nbsp;&nbsp;&nbsp;
                <table cellspacing="0" cellpadding="4" border="0" id="ctl00_ContentPlaceHolder1_GvRProductos" style="color:#333333;width:100%;border-collapse:collapse;">
			<tbody><tr style="color:#333333;background-color:#ABCD43;font-size:14px;font-weight:bold;">
				<th scope="col">&nbsp;</th><th scope="col">Producto</th><th scope="col">Cantidad Inicial</th><th scope="col">Precio Inicial</th><th scope="col">Fecha Ingreso</th><th scope="col">
                                         <input type="image" name="ctl00$ContentPlaceHolder1$GvRProductos$ctl01$refresh" id="ctl00_ContentPlaceHolder1_GvRProductos_ctl01_refresh" title="Actualizar Inventario" src="../images/imagenes/icons_variados_theme_negro/64_refresh.png" style="height:20px;border-width:0px;margin:2px;">
                                       </th>
			</tr><tr style="color:Black;background-color:#EEEEEE;font-family:Helvetica;font-size:14px;">
				<td colspan="6">
                                            
                                                    NO EXITE REGISTRO DE INVETARIO.</td>
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
