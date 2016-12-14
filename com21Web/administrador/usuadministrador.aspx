﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="usuadministrador.aspx.cs" Inherits="administrador_usuadministrador" %>

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
        <br />
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Administradores</h2>
			<div class="dragbox-content" >
                <asp:UpdatePanel ID="upMantenimiento" runat="server">
                <ContentTemplate>
                <asp:HiddenField ID="hfletra" runat="server" />
                <asp:HiddenField ID="hfIdsadmin" runat="server" />
                <table style="width: 100%;">
                    <tr>
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
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 30%">
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
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; width: 30%">
                            Nombres:</td>
                        <td>
                            <asp:TextBox ID="txtnombres" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Apellidos:</td>
                        <td>
                            <asp:TextBox ID="txtapellidos" runat="server" 
                                Width="200px"></asp:TextBox>
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
                            <asp:TextBox ID="txtcorreo" runat="server" 
                                Width="200px"></asp:TextBox>
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
                            <asp:TextBox ID="txttelefono" runat="server" 
                                Width="200px" MaxLength="10"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender
            ID="FilteredTextBoxExtender3"
            runat="server" 
            TargetControlID="txttelefono"
            FilterType="Numbers"
            ValidChars="" />
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
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                            <asp:TextBox ID="txtusuario" runat="server" 
                                Width="200px" ontextchanged="txtusuario_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <span id="Span1" runat="server"></span>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: right; font-size: 12px; font-style: italic; vertical-align: top;">
                            Clave:</td>
                        <td>
                            <asp:TextBox ID="txtclave" runat="server" 
                                Width="200px" TextMode="Password"></asp:TextBox>
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
                            <asp:CheckBox ID="cbactivar" runat="server" Visible="False" />
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
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: center; font-size: 12px; font-style: italic;" 
                            colspan="2">
                            <asp:Label ID="Label1" runat="server" 
                                Text="Por favor registrar un correo valido, para las notificaciones" 
                                Font-Size="11px"></asp:Label><br />
                                <asp:Label ID="Label2" runat="server" 
                                Text="Para editar no es necesario ingresar la clave, si digita se cambiará automaticamente" 
                                Font-Size="11px"></asp:Label>
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
			<h2>Administradores Ingresados</h2>
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
                                 WatermarkText="Buscar administrador" />
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
                                AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Administrador" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                onpageindexchanging="GvAdmin_PageIndexChanging"
                                onrowdeleting="GvAdmin_RowDeleting" 
                                onselectedindexchanged="GvAdmin_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Cargar Administrador" onclick="refresh_Click" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="VerEditar" runat="server" CommandName="Select" 
                                                Height="20px" ImageUrl="~/images/64_edit_page.png" style="margin:2px;" 
                                                ToolTip="Ver/Editar Administrador" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Administrador" runat="server" 
                                                Value='<%# Bind("Id_Administrador") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="Id_Administrador" runat="server" 
                                                Value='<%# Bind("Id_Administrador") %>' />
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
                                    <asp:TemplateField HeaderText="Activo" ItemStyle-HorizontalAlign="Center">
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
                                                ToolTip="Eliminar Administrador" OnClientClick="return confirm('Desea eliminar el administrador');" />
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
