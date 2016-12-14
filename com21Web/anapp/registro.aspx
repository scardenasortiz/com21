<%@ Page Language="C#" AutoEventWireup="true" EnableSessionState="True" CodeFile="registro.aspx.cs" Inherits="anapp_registro" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Inicio APP</title>
    <link rel="stylesheet"  href="cssJqueryMobile/MensajesEC.css" />
	<link rel="stylesheet"  href="cssJqueryMobile/jquery.mobile-1.1.0.min.css" />
	<script type="text/javascript" src="cssJqueryMobile/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="cssJqueryMobile/jquery.mobile-1.1.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.mobile.pageLoadErrorMessage = false;
            $.mobile.page.prototype.options.domCache = false;
            //$.mobile.fixedToolbars.show(false);
            //            $(".Crear").click(function () {
            //                var hrefUrl = $('a').attr('href');
            //                window.location.href = hrefUrl;
            //            });
            //            $(".Clave").click(function () {
            //                var hrefUrl = $('a').attr('href');
            //                window.location.href = hrefUrl;
            //            });
        });
    </script>
    <style type="text/css">
        html { overflow-y:hidden; }
        body { overflow-y:hidden; }
    </style>
    <script type="text/javascript" language="javascript">
        var isCloseBrowser = false;

        document.onkeydown = function () {
            if (window.event.altKey == true && window.event.keyCode == 115)
                isCloseBrowser = true;
        };
        window.onmousemove = function () {
            if (window.event.clientY <= 1 || window.event.clientX <= 1)
                isCloseBrowser = true;
        };
        window.onbeforeunload = function (evt) {
            var valor;
            if (isCloseBrowser) {
                valor = '1';
                document.cookie = 'IsCloseBrowser = ' + valor + '';
            }
            else {
                valor = '0';
                document.cookie = 'IsCloseBrowser = ' + valor + '';
            }
        };

        if (window.history) {
            function noBack() { window.history.forward() }
            noBack();
            window.onload = noBack;
            window.onpageshow = function (evt) { if (evt.persisted) noBack() }
            window.onunload = function () { void (0) }
        }
</script>
    </head>
<body>
    <form id="form1" runat="server">
     <%--<asp:ScriptManager ID="scriptupdate" runat="server"></asp:ScriptManager>--%>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="updateenvio" runat="server">
    <ContentTemplate>
    <div style="display:none">
    <asp:Button ID="btnEnviar" runat="server" Text="enviar" 
        onclick="btnEnviar_Click" />
      <%--  <asp:Button ID="btnCancelar" runat="server" Text="enviar" 
        onclick="btnCancelar_Click" />--%>
    </div>
    <div id="mostrar" runat="server">
        <div data-role="page" class="type-home" data-ajax="false" data-dom-cache="false">
    <div data-role="header" data-position="fixed"><h1>Regístrate</h1></div>
    <div data-role="content" style="overflow-y:auto;">
    <asp:Panel ID="pMensajesAlertas" runat="server" Visible="false">
<div id="DMensaje" runat="server"></div>
</asp:Panel>
    <div data-role="fieldcontain" class="ui-hide-label">
    <asp:TextBox ID="txtnombre" runat="server" placeholder="Nombres"></asp:TextBox>
    </div>
    <div data-role="fieldcontain" class="ui-hide-label">
    <asp:TextBox ID="txtapellidos" runat="server" placeholder="Apellidos"></asp:TextBox>
</div>
<div data-role="fieldcontain" class="ui-hide-label">
    <asp:TextBox ID="txtcorreo" runat="server" placeholder="Correo"></asp:TextBox>
    <ajaxToolkit:FilteredTextBoxExtender
            ID="FilteredTextBoxExtender3"
            runat="server" 
            TargetControlID="txtcorreo"
            FilterType="Custom, Numbers, LowercaseLetters"
            ValidChars="+-=/*().@_" />
</div>
<div data-role="fieldcontain" class="ui-hide-label">
    <asp:DropDownList ID="ddlsexo" runat="server">
        <asp:ListItem Value="0">Masculino</asp:ListItem>
        <asp:ListItem Value="1">Femenino</asp:ListItem>
    </asp:DropDownList>
</div>
        <asp:Button ID="btnValidar" runat="server" Text="Siguiente" 
            onclick="btnEnviar_Click" data-ajax="false" data-inline="false" />
            <asp:Button ID="btnCan" runat="server" Text="Cancelar" data-ajax="false" 
            data-inline="false" data-theme="a" onclick="btnCan_Click" />
<%--<a href="#" class="EnviarCEnvio" style="border-radius: 0em;-moz-border-radius: 0em !important; -webkit-border-radius: 0em !important;" data-role="button" data-ajax="false" onclick="return false;" data-inline="false">Siguiente</a>
<a href="Default.aspx" class="CancelarC" style="border-radius: 0em;-moz-border-radius: 0em !important; -webkit-border-radius: 0em !important;" data-role="button" data-ajax="false" data-inline="false" data-theme="a">Cancelar</a>--%>
</div>
</div>
    </div>
        <asp:HiddenField ID="E" runat="server" Value="0" />
        <asp:Panel ID="pnlProgress" runat="server" Style="display: none; width: 200px; background-color: #E2E2E2; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;"
        Width="44px">
        <div style="padding-right: 8px; padding-left: 8px; padding-bottom: 8px; padding-top: 8px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;">
            <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; height: 50px;">
                <tbody>
                    <tr>
                       <td style="text-align: center">
                           <asp:Image ID="Image4" runat="server" ImageUrl="~/images/loadinfo.net1.gif" />
                       </td> 
                    </tr>
                    <tr>
                    <td style="white-space: nowrap; text-align: center; font-family: verdana; font-size: 10px;">
                            <span class="Datos" 
                                style="font-size: 10px; font-family: Talo; font-weight:bold; color: #000000;"> POR FAVOR ESPERE, PROCESANDO...</span>
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
    </form>
</body>
</html>
