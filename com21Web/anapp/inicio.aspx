<%@ Page Language="C#" AutoEventWireup="true" EnableSessionState="True" CodeFile="inicio.aspx.cs" Inherits="anapp_inicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jspagina/jquery-1.7.min.js"></script>
<%--<script type="text/javascript" src="js/jspagina/jquery.prettyPhoto.js"></script>
<script type="text/javascript" src="js/jspagina/superfish.js"></script>
<script type="text/javascript" src="js/jspagina/jquery.easing.1.3.js"></script>--%>
<script type="text/javascript" src="js/jspagina/jquery.mobile.customized.min.js"></script>
<%--<script type="text/javascript" src="js/jspagina/scripts.js"></script>--%>
<%--<script type="text/javascript" src="js/jspagina/easyTooltip.js"></script>
<script type="text/javascript" src="js/jspagina/jquery.jcarousel.min.js"></script>
<script type="text/javascript" src="js/jspagina/jquery.iosslider.min.js"></script>--%>
<!--[if lt IE 7]>
<script type="text/javascript">
//<![CDATA[
//]]>
</script>
<![endif]-->
<!--[if lt IE 9]>
	<style>
	body {
		min-width: 960px !important;
	}
	</style>
<![endif]-->
<link rel="stylesheet" type="text/css" href="css/styles.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/responsive.css" media="all"/>
<%--<link rel="stylesheet" type="text/css" href="css/superfish.css" media="all"/>--%>
<%--<link rel="stylesheet" type="text/css" href="css/camera.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/widgets.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/cloud-zoom.css" media="all"/>
<link rel="stylesheet" type="text/css" href="css/print.css" media="print"/>--%>
<%--<script type="text/javascript" src="js/jspagina/prototype.js"></script>
<script type="text/javascript" src="js/jspagina/ccard.js"></script>
<script type="text/javascript" src="js/jspagina/validation.js"></script>
<script type="text/javascript" src="js/jspagina/builder.js"></script>
<script type="text/javascript" src="js/jspagina/effects.js"></script>
<script type="text/javascript" src="js/jspagina/dragdrop.js"></script>
<script type="text/javascript" src="js/jspagina/controls.js"></script>
<script type="text/javascript" src="js/jspagina/slider.js"></script>
<script type="text/javascript" src="js/jspagina/js.js"></script>
<script type="text/javascript" src="js/jspagina/form.js"></script>
<script type="text/javascript" src="js/jspagina/translate.js"></script>
<script type="text/javascript" src="js/jspagina/cookies.js"></script>
<script type="text/javascript" src="js/jspagina/cloud-zoom.1.0.2.min.js"></script>
<script type="text/javascript" src="js/jspagina/bootstrap.js"></script>
<script type="text/javascript" src="js/jspagina/msrp.js"></script>--%>
<!--[if lt IE 8]>
<link rel="stylesheet" type="text/css" href="css/styles-ie.css" media="all" />
<![endif]-->
<!--[if lt IE 7]>
<script type="text/javascript" src="js/ds-sleight.js"></script>
<script type="text/javascript" src="js/ie6.js"></script>
<![endif]-->
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
    <div id="mostrar" runat="server" style="background-color: #FFFFFF">
    </div>
    </form>
</body>
</html>
