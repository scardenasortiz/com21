<%@ Page Language="C#" AutoEventWireup="true" EnableSessionState="True" CodeFile="recuperar.aspx.cs" Inherits="anapp_recuperar" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            $.mobile.fixedToolbars.show();
        });
    </script>
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
    
    </div>
    <div id="mostrar" runat="server">
        <div data-role="page" class="type-home" data-ajax="false" data-dom-cache="false">
    <div data-role="header" data-position="fixed"><h1 style="margin: .6em 1% .8em !important;">Recuperar Contraseña</h1></div>
    <div data-role="content" style="overflow-y:auto;">
    <asp:Panel ID="pMensajesAlertas" runat="server" Visible="false">
<div id="DMensaje" runat="server"></div>
</asp:Panel>
<label style="border-radius: 0em;-moz-border-radius: 0em !important; -webkit-border-radius: 0em !important; font-size: 10px; text-decoration: inherit; color: black;" data-role="info" data-ajax="false" data-inline="false">Ingrese su correo electrónico para poder enviar la contraseña de su cuenta.</label>
<br />
    <div data-role="fieldcontain" class="ui-hide-label">
    <asp:TextBox ID="txtcorreo" runat="server" placeholder="Correo electrónico"></asp:TextBox>
    </div>
 <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
        onclick="btnEnviar_Click" data-ajax="false" data-inline="true" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" data-ajax="false" 
            data-inline="true" data-theme="a" onclick="btnCancelar_Click" />
<%--<a href="#" class="EnviarCEnvio" style="border-radius: 0em;-moz-border-radius: 0em !important; -webkit-border-radius: 0em !important;" data-role="button" data-ajax="false" onclick="return false;" data-inline="true">Enviar</a>
<a href="Default.aspx" class="CancelarC" style="border-radius: 0em;-moz-border-radius: 0em !important; -webkit-border-radius: 0em !important;" data-role="button" data-ajax="false" data-inline="true" data-theme="a">Cancelar</a>--%>
</div>
</div>
    </div>
        <asp:HiddenField ID="E" runat="server" Value="0" />
    </ContentTemplate>

    </asp:UpdatePanel>
    </form>
</body>
</html>
