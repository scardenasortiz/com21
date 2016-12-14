<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="correosesp.aspx.cs" Inherits="administrador_correosesp" %>

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


   <div class="demoarea" style="margin-left: 5px">
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Correo</h2>
			<div class="dragbox-content" >
            <asp:HiddenField ID="hfnombre" runat="server" />
            <asp:Panel ID="pSBE" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <table style="width: 100%;">
                    <tr>
                        <td>
                            <table style="width: 100%;">
                             <tr>
                                 <td style="text-align: right; font-weight: bold;">
                                      De:</td>
                                 <td style="text-align: left" width="90%">
                                     <asp:Label ID="lblde" runat="server"></asp:Label>
                                 </td>
                             </tr>
                                <tr>
                                    <td style="text-align: right; font-weight: bold;">
                                        Para:</td>
                                    <td style="text-align: left" width="90%">
                                        <asp:Label ID="lblpara" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; font-weight: bold;">
                                        Asunto:</td>
                                    <td style="text-align: left" width="90%">
                                        <asp:Label ID="lblasunto" runat="server"></asp:Label></td>
                                </tr>
                         </table>
                        </td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="border-color: #ABCD43; width: 100%; border-top-style: solid; border-top-width: 2px;">
                    <tr>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="text-align: left" width="90%">
                                        <asp:Label ID="lblmensaje" runat="server"></asp:Label>
                                    </td>
                                </tr>
                         </table>
                        </td>
                    </tr>
                </table>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
        </div>
		</div>
             
        
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<h2>Responder Correo</h2>
			<div class="dragbox-content" >
                <asp:HiddenField ID="hfletraBS" runat="server" />
                <asp:Panel ID="pSBS" runat="server">
                
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <table style="width: 100%;">
                             <tr>
                                 <td style="text-align: right; font-weight: bold; vertical-align: top;">
                                      De:</td>
                                 <td style="text-align: left" width="90%">
                                     <asp:TextBox ID="txtde" runat="server" Width="90%" CssClass="btncurve"
                                         Enabled="False">rzambrano@com21.com.ec,xbaque@com21.com.ec,mronquillo@com21.com.ec</asp:TextBox>
                                 </td>
                             </tr>
                                <tr>
                                    <td style="text-align: right; font-weight: bold; vertical-align: top;">
                                        Para:</td>
                                    <td style="text-align: left" width="90%">
                                        <asp:TextBox ID="txtpara" runat="server"
                    Width="90%" CssClass="btncurve" Enable="false" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; font-weight: bold; vertical-align: top;">
                                        Asunto:</td>
                                    <td style="text-align: left" width="90%">
                                        <asp:TextBox ID="txtasunto" runat="server" 
                    Width="90%" CssClass="btncurve" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; font-weight: bold; vertical-align: top;">
                                        Mensaje:</td>
                                    <td style="text-align: left" width="90%">
                                        <asp:TextBox ID="txtmensaje" runat="server" Height="100px" TextMode="MultiLine" 
                    Width="90%" CssClass="btncurve"></asp:TextBox>
                                    </td>
                                </tr>
                         </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-right: 10px">
                            <asp:Button ID="btnenviar" runat="server" Text="Enviar" CssClass="btncurve" 
        BackColor="#ABCD43" Font-Bold="True" ForeColor="White" Height="27px" 
        Width="90px" Font-Size="16px" onclick="btnenviar_Click" />
                        </td>
                    </tr>
                </table>
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
