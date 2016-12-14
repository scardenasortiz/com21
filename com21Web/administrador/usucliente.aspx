<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="usucliente.aspx.cs" Inherits="administrador_usucliente" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script src="../css/SpryCollapsiblePanel.js" type="text/javascript"></script>
<link href="../css/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
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
    <%-- <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   <div class="demoarea" style="margin-left: 5px">
        <br />
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Clientes</h2>
			<div class="dragbox-content" >
                <asp:UpdatePanel ID="upMantenimiento" runat="server">
                <ContentTemplate>
                <asp:HiddenField ID="hfletra" runat="server" />
                <asp:HiddenField ID="hfIdsuser" runat="server" />
                <table style="width: 100%;">
          <%--          <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Imagen:</td>
                        <td>
                            <asp:Image ID="img" runat="server" Height="64px" Width="64px" 
                                ImageUrl="~/images/users.png" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    <tr>
                        <td>
                            &nbsp; </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 15%">
                            Nombres:</td>
                        <td>
                            <asp:Label ID="lblnombres" runat="server" Text="**Sin nombres**"></asp:Label>
                        </td>
                        <td>
                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Apellidos:</td>
                        <td>
                            <asp:Label ID="lblapellidos" runat="server" Text="**Sin apellidos**"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Correo:</td>
                        <td>
                            <asp:Label ID="lblcorreo" runat="server" Text="**Sin correo**"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Telefono:</td>
                        <td>
                            <asp:Label ID="lbltelefono" runat="server" Text="**Sin telefono**"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Usuario:</td>
                        <td>
                            <asp:Label ID="lblusuario" runat="server" Text="**Sin usuario**"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Dirección:</td>
                        <td>
                            <asp:Label ID="lbldireccion" runat="server" Text="** Sin dirección **"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Sexo:</td>
                        <td>
                            <asp:Label ID="lblsexo" runat="server" Text="**Sin sexo**"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Cédula:</td>
                        <td>
                            <asp:Label ID="lblcedula" runat="server" Text="**Sin cédula**"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic;">
                            Celular:</td>
                        <td>
                            <asp:Label ID="lblcelular" runat="server" Text="**Sin celular**"></asp:Label>
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
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                </table>
                <table style="width:100%">
                <tr>
                <td>
                <div id="CollapsiblePanel1" class="CollapsiblePanel">
  <div class="CollapsiblePanelTab" tabindex="0">Historial de compras</div>
  <div class="CollapsiblePanelContent">
                                <asp:Panel ID="pNCompras" runat="server">
                                                                <table style="width: 100%;">
                                                                <tr>
                                            <td>
                                                <div style="font-size: 14px; color: #000000; vertical-align: top; font-family: 'Gloria Hallelujah', cursive; padding-top: 15px; padding-left: 6px;">
                                                    No exiten compras realizadas por el cliente.
                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pSCompras" runat="server">
                                                                <table style="width: 100%;">
                                                                <tr>
                                            <td>
                                                <div style="font-size: 14px; color: #000000; vertical-align: top; font-family: 'Gloria Hallelujah', cursive; padding-top: 15px; padding-left: 6px;">
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
                                    <%--<asp:TemplateField HeaderText="Usuario" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Usuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Usuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>--%>
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
                                    <%--<asp:TemplateField HeaderText="Fecha Compra" ItemStyle-HorizontalAlign="Center">
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
                                    </asp:TemplateField>--%>
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
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                </div>
                                </div>
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
			<h2>Clientes Ingresados</h2>
			<div class="dragbox-content">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
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
                                      <asp:TextBox ID="txtbuscaradmin" runat="server"
                                 Width="45%" Height="25px" BackColor="#E2FCE6" BorderColor="#BEBEBE" 
                                          BorderStyle="Solid" BorderWidth="1px" ForeColor="Gray" CssClass="curveds"></asp:TextBox>
                             <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                 runat="server" TargetControlID="txtbuscaradmin" WatermarkCssClass="watermarked" 
                                 WatermarkText="Buscar Clientes" />
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
                            <asp:GridView ID="GvAdmin" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Clientes" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" Width="100%" onpageindexchanging="GvAdmin_PageIndexChanging"
                                onrowdeleting="GvAdmin_RowDeleting" 
                                onselectedindexchanged="GvAdmin_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar Clientes" onclick="refresh_Click" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Clientes" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Clientes" runat="server" 
                                                Value='<%# Bind("Id_Clientes") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Clientes" runat="server" 
                                                Value='<%# Bind("Id_Clientes") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Usuario" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Usuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Usuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
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
                                    <%--<asp:TemplateField HeaderText="Activo" ItemStyle-HorizontalAlign="Center">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Aplicar" runat="server" Checked='<%# Bind("Activar") %>' Enabled="false" />
                                    </ItemTemplate>
                                   </asp:TemplateField>--%>
                                    <%--<asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Eliminar" runat="server" CommandName="Delete" 
                                                Height="20px" ImageUrl="~/images/64_trash_2.png" style="margin:2px;" 
                                                ToolTip="Eliminar Sub-Categoria" OnClientClick="return confirm('Al eliminar la sub-categoria, se inactivaran los productos hasta volver asignarlos a una nueva sub-categoria');" />
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
                <asp:Panel ID="prono" runat="server">
                    No existen items ingresados
                </asp:Panel>
                </ContentTemplate>
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
            var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1");
</script>
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

