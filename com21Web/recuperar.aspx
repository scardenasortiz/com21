<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/infoproductos.master" CodeFile="recuperar.aspx.cs" Inherits="recuperar" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <%--  <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>

<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:HiddenField ID="hftipo" runat="server" />
<div class="col-main span9">
<div class="padding-s">
<div class="page-title">
<h1>Olvidaste tu contraseña?</h1>
</div>
<div id="form-validate">
<div class="fieldset">
<h2 class="legend">Recupere su contraseña aquí</h2>
<p>Introduzca su dirección de correo electrónico. Usted recibirá un enlace para restablecer tu contraseña.</p>
<ul class="form-list">
<li>
<label for="email_address" class="required"><em>*</em>Dirección de correo electrónico</label>
<div class="input-box">
<asp:TextBox ID="txtemail" runat="server" CssClass="input-text required-entry validate-email"></asp:TextBox>
<br />
<asp:Label ID="lblinfo" runat="server" ForeColor="Red"></asp:Label>
<br />
<asp:Label ID="lblcorrecto" runat="server" ForeColor="#ABCD43"></asp:Label>
</div>
</li>
</ul>
</div>
<div class="buttons-set">
<p class="required">* Campos requeridos</p>
<p class="back-link"><a href="iniciar.aspx"><small>« </small>Volver a login</a></p>
<div style="float:right"><asp:Button ID="btncrearcuenta" runat="server" 
        Text="Enviar" ToolTip="Enviar" CssClass="button bordebotones" Height="35" 
        Width="100" BackColor="#ABCD43" ForeColor="White" Font-Bold="True" 
        Font-Size="14px" onclick="btncrearcuenta_Click" /></div>
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
