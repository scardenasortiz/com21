<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="rproductos.aspx.cs" Inherits="administrador_rproductos" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="js/print.js"></script> 
    <script type="text/javascript">
        $(document).ready(function()
        {
	        $(".printer").bind("click",function()
	         {
		        $(".Aimprimir").printArea();
	        });
        });

    function imprimirDiv() {
        //Hacemos referencia al área a imprimir
        var div_print = document.getElementById("<%=cuerpo_rpt.ClientID%>");
        //Creamos una nueva página
        var pp = window.open('', div_print, 'width=1100px, height=660px, resizable=no');
        //Añadimos la etiqueta HTML de apertura
        pp.document.writeln('<HTML><HEAD><title>Reportes Productos</title><LINK href=Reportes.css  type="text/css" rel="stylesheet">')
        pp.document.writeln('</HEAD>')
        //Añadimos el cuerpo de la página HTMLself.close();
        pp.document.writeln('<body onLoad="self.close();">');
        //Añadimos el formulario
        pp.document.writeln('<form>');
        //Escribimos el área de impresión de la página especificada
        pp.document.writeln(div_print.innerHTML);
        //Cerramos la etiqueta HTML
        pp.document.writeln('</form></body></HTML>');
        pp.document.close();
        pp.print();
        pp.close();
        return true;
    }
    function imprime(muestra) {
        var div_print = document.getElementById("<%=cuerpo_rpt.ClientID%>");
        var ficha=document.getElementById("<%=cuerpo_rpt.ClientID%>");
        var ventimp=window.open(' ','popimpr');
        ventimp.document.write(ficha.innerHTML);
        ventimp.document.close();
        ventimp.print();ventimp.close();
    }
    </script>
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
    
   <div class="demoarea" style="margin-left: 5px">
       
       <table style="width: 100%; font-family: 'Arvo', serif; font-size: 14px; font-weight: bold;">
           <tr>
               <td width="16%">
                   Cantidad</td>
               <td width="40">
                   &nbsp;</td>
               <td width="19%">
                   Categorias</td>
               <td width="40">
                   &nbsp;</td>
               <td width="19%">
                   Precio</td>
               <td width="40">
                   &nbsp;</td>
               <td width="19%">
                   Marcas</td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td width="16%">
                   <asp:DropDownList ID="ddlCantidad" runat="server" Height="22px" Width="170px">
                       <asp:ListItem Value="0">Entre 1 - 5</asp:ListItem>
                       <asp:ListItem Value="1">Entre 6 -15</asp:ListItem>
                       <asp:ListItem Value="2">Entre 16 - 30</asp:ListItem>
                       <asp:ListItem Value="3">Entre 31 - 45</asp:ListItem>
                       <asp:ListItem Value="4">Mayor a 45</asp:ListItem>
                   </asp:DropDownList>
               
               </td>
               <td width="60">
                   <asp:ImageButton ID="IBCantidad" runat="server" 
                       ImageUrl="~/images/find.png" Height="30px" onclick="IBCantidad_Click" 
                       Width="30px" />
                   </td>
               <td width="19%">
                   <asp:DropDownList ID="ddlCategorias" runat="server" Height="22px" Width="200px">
                   </asp:DropDownList>
               </td>
               <td width="60">
                   <asp:ImageButton ID="IBCategoria" runat="server" 
                       ImageUrl="~/images/find.png" Height="30px" Width="30px" 
                       onclick="IBCategoria_Click" />
                   </td>
               <td width="19%">
                   <asp:DropDownList ID="ddlPrecio" runat="server" Height="22px" Width="200px">
                       <asp:ListItem Value="0">$0,00 - $500,00</asp:ListItem>
                       <asp:ListItem Value="1">$500,01 - $800,00</asp:ListItem>
                       <asp:ListItem Value="2">$800,01 - $1000,00</asp:ListItem>
                       <asp:ListItem Value="3">$1000,01 - $1500,00</asp:ListItem>
                       <asp:ListItem Value="4">Mayor a $1500,00</asp:ListItem>
                   </asp:DropDownList>
               </td>
               <td width="60">
                   <asp:ImageButton ID="IBPrecio" runat="server" 
                       ImageUrl="~/images/find.png" Height="30px" Width="30px" 
                       onclick="IBPrecio_Click"/>
                   </td>
               <td width="19%">
                   <asp:DropDownList ID="ddlMarca" runat="server" Height="22px" Width="200px">
                   </asp:DropDownList>
               </td>
               <td>
                   <%--<asp:LinkButton ID="lblexcel" runat="server" onclick="lblexcel_Click">Descargar</asp:LinkButton>--%>
                   <asp:ImageButton ID="IBMarcas" runat="server" 
                       ImageUrl="~/images/find.png" Height="30px" Width="30px" onclick="IBMarcas_Click" 
                       />&nbsp;&nbsp;&nbsp;<%--<asp:ImageButton ID="imgxlsprint" 
                       runat="server" ImageUrl="~/images/excelprint1.png" Width="35px" Height="35px" 
                       onclick="imgxlsprint_Click" ToolTip="Excel" />&nbsp;--%><%--<a href="#" onclick="imprimirDiv();"><asp:Image ID="imgBtn_print" runat="server" ImageUrl="~/images/print.png" Width="35px" Height="35px" ToolTip="Imprimir" /></a>--%>
                       <a href="#" class="printer"><asp:Image ID="imgBtn_print2" runat="server" ImageUrl="~/images/print.png" Width="35px" Height="35px" ToolTip="Imprimir" /></a>
               </td>
           </tr>
           </table>
        <div style="font-size: 12px"><asp:Label ID="Informacion" runat="server" Text="Busquedas individuales"></asp:Label></div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="idBuscar" runat="server" Value="0"/>
       <asp:HiddenField ID="hfNombreReporte" runat="server" />
       <asp:HiddenField ID="hfruta" runat="server" />
       <asp:Label ID="lblruta" runat="server"></asp:Label>
        <div id="cuerpo_rpt" runat="server" class="Aimprimir">
        <asp:GridView ID="GvRProductos" runat="server" AllowPaging="True" CellPadding="4" DataKeyNames="Id_Producto" 
                                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                Width="100%" onpageindexchanging="GvRProductos_PageIndexChanging" 
                EmptyDataText="NO EXISTEN DATOS" PageSize="13" AutoGenerateColumns="False">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                         <asp:ImageButton ID="refresh" runat="server"
                                                Height="20px" 
                                ImageUrl="~/images/imagenes/icons_variados_theme_negro/64_refresh.png" style="margin:2px;" 
                                                ToolTip="Actualizar Inventario" onclick="refresh_Click" />
                                       </HeaderTemplate>
                                        <EditItemTemplate>
                                            <asp:HiddenField ID="Id_Producto" runat="server" 
                                                Value='<%# Bind("Id_Producto") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
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
                                    <asp:TemplateField HeaderText="Categorias" ItemStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:Label ID="Categoria" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Categoria" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub-Categorias" ItemStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:Label ID="Subcategoria" runat="server" Text='<%# Bind("Subcategoria") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Subcategoria" runat="server" Text='<%# Bind("Subcategoria") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marcas" ItemStyle-HorizontalAlign="Left">
                                        <EditItemTemplate>
                                            <asp:Label ID="Marca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Marca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                        <EditItemTemplate>
                                            <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
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
        <div id="cuerpo_rptV" runat="server">
            <table cellspacing="0" cellpadding="4" border="0" id="ctl00_ContentPlaceHolder1_GvRProductos" style="color:#333333;width:100%;border-collapse:collapse;">
			<tbody><tr style="color:#333333;background-color:#ABCD43;font-size:14px;font-weight:bold;">
				<th scope="col">
                                         <input type="image" name="ctl00$ContentPlaceHolder1$GvRProductos$ctl01$refresh" id="ctl00_ContentPlaceHolder1_GvRProductos_ctl01_refresh" title="Actualizar Inventario" src="../images/imagenes/icons_variados_theme_negro/64_refresh.png" style="height:20px;border-width:0px;margin:2px;">
                                       </th><th scope="col">Producto</th><th scope="col">Categorias</th><th scope="col">Sub-Categorias</th><th scope="col">Marcas</th><th scope="col">Cantidad</th><th scope="col">Precio</th><th scope="col">Fecha Ingreso</th>
			</tr><tr style="color:Black;background-color:#EEEEEE;font-family:Helvetica;font-size:14px;">
				<td colspan="8">
                                           NO EXISTEN PRODUCTOS PARA REPORTES
                                        </td>
			</tr>
		</tbody></table>
        </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="IBCantidad" />
            <asp:AsyncPostBackTrigger ControlID="IBCategoria" />
            <asp:AsyncPostBackTrigger ControlID="IBPrecio" />
            <asp:AsyncPostBackTrigger ControlID="IBMarcas" />
        </Triggers>
    </asp:UpdatePanel>
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
</asp:Content>
