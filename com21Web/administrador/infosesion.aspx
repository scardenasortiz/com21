<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="infosesion.aspx.cs" Inherits="administrador_infosesion" %>

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
<%--   <div class="demoarea" style="margin-left: 5px">
        <br />--%>
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2 style="font-family: 'font-family: 'Nunito'', sans-serif">Registros de sessiones</h2>
			<div class="dragbox-content" >
                <table style="width: 100%;">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
		</div>
        
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<%--<h2>Registro de items</h2>--%>
			<div class="dragbox-content" >
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: right" width="50%">
                            Publicidades/Promociones:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lblpromopubli" runat="server" Font-Bold="True" 
                                ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Administradores:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lbladmin" runat="server" Font-Bold="True" ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Categorias:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lblcategorias" runat="server" Font-Bold="True" 
                                ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Sub-categorias:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lblsubcategorias" runat="server" Font-Bold="True" 
                                ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Nosotros:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lblnosotros" runat="server" Font-Bold="True" ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Misión/Visión:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lblmisionvision" runat="server" Font-Bold="True" 
                                ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Marca:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lblmarca" runat="server" Font-Bold="True" ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Productos:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lblproductos" runat="server" Font-Bold="True" 
                                ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Galería:</td>
                        <td style="font-size: 14px">
                            <asp:Label ID="lblgaleria" runat="server" Font-Bold="True" ForeColor="#ABCD43"></asp:Label>
                        </td>
                    </tr>
                </table>
			</div>
		</div>
	    </div>
  <%--  </div>--%>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
