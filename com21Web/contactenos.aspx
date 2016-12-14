<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/infoproductos.master" CodeFile="contactenos.aspx.cs" Inherits="contactenos" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link rel="stylesheet"  href="anapp/cssJqueryMobile/MensajesEC.css" />
    <%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:HiddenField ID="hftipo" runat="server" />
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<div class="col-main span9">
<asp:Panel ID="pMensajesAlertas" runat="server" Visible="false">
<div id="DMensaje" runat="server"></div>
</asp:Panel>
<div class="padding-s">
<div class="page-title category-title">
<h1><asp:Label ID="lbltitulo" runat="server" Text="Contáctenos"></asp:Label></h1>
</div> 
<div class="category-products">
<div style="padding-right: 5px; padding-left: 5px">
    <table style="width: 80%;">
        <tr>
            <td width="15%">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="font-size: 16px; color: #333333; font-weight: 550; text-align: right; padding-right: 15px; padding-top: 5px; padding-bottom: 5px;">
                Nombres:</td>
            <td style="padding-top: 5px; padding-bottom: 5px; vertical-align: top;">
                <asp:TextBox ID="txtnombres" runat="server" Width="50%" Height="18px" 
                    CssClass="btncurve"></asp:TextBox>
                &nbsp;(*)</td>
        </tr>
        <tr>
            <td style="font-size: 16px; color: #333333; font-weight: 550; text-align: right; padding-right: 15px; padding-top: 5px; padding-bottom: 5px;">
                Apellidos:</td>
            <td style="padding-top: 5px; padding-bottom: 5px; vertical-align: top;">
                <asp:TextBox ID="txtapellidos" runat="server" Width="50%" Height="18px" 
                    CssClass="btncurve"></asp:TextBox>
                &nbsp;(*)</td>
        </tr>
        <tr>
            <td style="font-size: 16px; color: #333333; font-weight: 550; text-align: right; padding-right: 15px; padding-top: 5px; padding-bottom: 5px;">
                Correo:</td>
            <td style="padding-top: 5px; padding-bottom: 5px; vertical-align: top;">
                <asp:TextBox ID="txtcorreo" runat="server" Width="50%" Height="18px" CssClass="btncurve"></asp:TextBox>
                &nbsp;(*)</td>
        </tr>
        <tr>
            <td style="font-size: 16px; color: #333333; font-weight: 550; text-align: right; padding-right: 15px; padding-top: 5px; padding-bottom: 5px;">
                Teléfono:</td>
            <td style="padding-top: 5px; padding-bottom: 5px; vertical-align: top;">
                <asp:TextBox ID="txttelefono" runat="server" Width="50%" Height="18px" 
                    MaxLength="10" CssClass="btncurve"></asp:TextBox>
                &nbsp;(*)<ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender1"
           runat="server"
           TargetControlID="txttelefono"
           FilterType="Numbers" /></td>
        </tr>
        <tr>
            <td style="font-size: 16px; color: #333333; font-weight: 550; text-align: right; padding-right: 15px; padding-top: 5px; padding-bottom: 5px;">
                Asunto:</td>
            <td style="padding-top: 5px; padding-bottom: 5px; vertical-align: top;">
                <asp:TextBox ID="txtasunto" runat="server" Width="50%" Height="18px" 
                    CssClass="btncurve"></asp:TextBox>
                &nbsp;(*)</td>
        </tr>
        <tr>
            <td style="font-size: 16px; color: #333333; font-weight: 550; text-align: right; padding-right: 15px; padding-top: 5px; padding-bottom: 5px;">
                Mensaje:</td>
            <td style="padding-top: 5px; padding-bottom: 5px; vertical-align: top;">
                <asp:TextBox ID="txtmensaje" runat="server" Height="90px" TextMode="MultiLine" 
                    Width="85%" CssClass="btncurve"></asp:TextBox>
                &nbsp;(*)</td>
        </tr>
        <tr>
            <td style="font-size: 16px; color: #333333; font-weight: 550; text-align: right; padding-right: 15px; padding-top: 5px; padding-bottom: 5px;">
                &nbsp;</td>
            <td style="padding-top: 5px; padding-bottom: 5px; vertical-align: bottom; text-align: right; padding-right: 65px;">
              <asp:Button ID="btnenviar" runat="server" Text="Enviar" CssClass="btncurve" 
        BackColor="#ABCD43" Font-Bold="True" ForeColor="White" Height="27px" 
        Width="90px" Font-Size="16px" onclick="btnenviar_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" 
                
                style="font-size: 10px; color: #333333; font-weight: 550; text-align: left; padding-right: 15px; padding-top: 5px; padding-bottom: 5px;">
                Nota: por favor llenar todos los campos, digitar un correo y teléfono válido 
                para ponernos en contacto con usted.</td>
        </tr>
    </table>
</div>
</div>
</div>
</div>
<div class="col-right sidebar span3">
<div class="block block-layered-nav">
<div class="block-content">
<asp:Image ID="Image1" runat="server" ImageUrl="~/images/publi.jpg" Width="100%" />
</div>
</div>
<div class="block block-layered-nav">
<div class="block-title">
<strong><span>Facebook</span></strong>
</div>
<div class="block-content">
<iframe src="//www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2Fpages%2FCOM-21-SA%2F166410506765758&amp;width=250&amp;height=365&amp;show_faces=true&amp;colorscheme=light&amp;stream=false&amp;border_color&amp;header=false&amp;appId=330721080316666" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:100%; height:395px;" allowTransparency="true"></iframe>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<asp:Panel ID="pnlProgress" runat="server" Style="display: none; width: 200px; background-color: #E2E2E2; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;"
        Width="44px">
        <div style="padding-right: 8px; padding-left: 8px; padding-bottom: 8px; padding-top: 8px; -webkit-border-radius: 5px; -moz-border-radius: 5px; border-radius: 5px;">
            <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; height: 50px;">
                <tbody>
                    <tr>
                       <td style="text-align: center">
                           <asp:Image ID="Image2" runat="server" ImageUrl="~/images/loadinfo.net1.gif" />
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
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
</asp:Content>


