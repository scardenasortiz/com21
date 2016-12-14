<%@ Page Language="C#" AutoEventWireup="true" CodeFile="envioCorreo.aspx.cs" Inherits="anapp_envioCorreo" %>

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
            $.mobile.fixedToolbars.show(true);
//            $(".EnviarCEnvio").click(function () {
//                var btn = "#" + "<%=btnEnviar.ClientID %>";
//                $(btn).click();
//            });
//            $(".CancelarC").click(function () {
//                var btn = "#" + "<%=btnCancelar.ClientID %>";
//                $(btn).click();
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
<body style="background-color: #FFFFFF">
    <form id="form1" runat="server">
    <%--<asp:ScriptManager ID="scriptupdate" runat="server"></asp:ScriptManager>--%>
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="updateenvio" runat="server">
    <ContentTemplate>
    <asp:HiddenField ID="HfURLRe" runat="server" />
    <div style="display:none">
    <asp:Button ID="btnEnviar" runat="server" Text="enviar" 
        onclick="btnEnviar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="enviar" 
        onclick="btnCancelar_Click" />
    </div>
    <div id="mostrar" runat="server">
        <div data-role="page" class="type-home" data-ajax="false" data-dom-cache="false">
    <div data-role="header" data-position="fixed"><h1>Contáctenos</h1></div>
    <div data-role="content" style="overflow-y:auto;">
    <asp:Panel ID="pMensajesAlertas" runat="server" Visible="false">
<div id="DMensaje" runat="server"></div>
</asp:Panel>
    <div data-role="fieldcontain" class="ui-hide-label">
	<label for="username">Nombre:</label>
    <asp:TextBox ID="txtnombre" runat="server" placeholder="Nombre"></asp:TextBox>
    </div>
    <div data-role="fieldcontain" class="ui-hide-label">
    <label for="username">Correo:</label>
    <asp:TextBox ID="txtcorreo" runat="server" placeholder="Correo"></asp:TextBox>
</div>
<div data-role="fieldcontain" class="ui-hide-label">
    <label for="username">Teléfono:</label>
    <asp:TextBox ID="txttelefono" runat="server" placeholder="Teléfono"></asp:TextBox>
</div>
<div data-role="fieldcontain" class="ui-hide-label">
    <label for="username">Mensaje:</label>
    <asp:TextBox ID="txtmensaje" runat="server" placeholder="Mensaje" 
        TextMode="MultiLine"></asp:TextBox>
</div>
    
        <asp:Button ID="btnValidar" runat="server" Text="Enviar" 
            onclick="btnValidar_Click" CssClass="BtnCuadrado" data-inline="true" />
            <asp:Button ID="btnCancelarE" runat="server" data-inline="true" data-theme="a" Text="Cancelar" 
            onclick="btnCancelar_Click" CssClass="BtnCuadrado" />
<%--<a href="#" class="EnviarCEnvio" style="border-radius: 0em;-moz-border-radius: 0em !important; -webkit-border-radius: 0em !important;" data-role="button" data-ajax="false" onclick="return false;" data-inline="true">Enviar</a>
<a href="#" class="CancelarC" style="border-radius: 0em;-moz-border-radius: 0em !important; -webkit-border-radius: 0em !important;" data-role="button" data-ajax="false" data-inline="true" data-theme="a">Cancelar</a>--%>
</div>
</div>
    </div>
        <asp:HiddenField ID="E" runat="server" Value="0" />
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
