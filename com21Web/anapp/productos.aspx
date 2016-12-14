<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productos.aspx.cs" Inherits="anapp_productos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Inicio APP</title>
	<link rel="stylesheet"  href="cssJqueryMobile/jquery.mobile-1.1.0.min.css" />
	<script src="cssJqueryMobile/jquery-1.7.1.min.js"></script>
	<script src="cssJqueryMobile/jquery.mobile-1.1.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
//            $(".linkDes").click(function () {
//                var hrefUrl = $('a').attr('href');
//                window.location.href = hrefUrl;
            //            });
            $.mobile.pageLoadErrorMessage = false;
            $.mobile.fixedToolbars.show(true);
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
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div id="mostrar" runat="server" style="background-color: #FFFFFF">
    
    </div>
   <%-- <asp:UpdatePanel ID="upMantenimiento" runat="server">
    <ContentTemplate>
    </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
