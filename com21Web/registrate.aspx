<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/infoproductos.master" CodeFile="registrate.aspx.cs" Inherits="registrate" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link rel="stylesheet"  href="anapp/cssJqueryMobile/MensajesEC.css" />
    <%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<div class="col-main span9">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
<asp:Panel ID="pMensajesAlertas" runat="server" Visible="false">
<div id="DMensaje" runat="server"></div>
</asp:Panel>
<div class="padding-s">
<div class="account-create">
<div class="page-title">
<h1>CREAR UNA CUENTA</h1>
</div>
<div>
<div class="fieldset">
<input type="hidden" name="success_url" value="">
<input type="hidden" name="error_url" value="">
<h2 class="legend">INFORMACIÓN PERSONAL</h2>
<ul class="form-list">
<li class="fields">
<div class="customer-name">
<div class="field name-firstname">
<label for="firstname" class="required"><em>*</em>Nombres</label>
<div class="input-box">
<asp:TextBox ID="txtnombres" runat="server" ToolTip="Nombres" CssClass="input-text required-entry"></asp:TextBox>
</div>
</div>
<div class="field name-lastname">
<label for="lastname" class="required"><em>*</em>Apellidos</label>
<div class="input-box">
<asp:TextBox ID="txtapellidos" runat="server" ToolTip="Apellidos" CssClass="input-text required-entry"></asp:TextBox>
</div>
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Email</label>
<div class="input-box">
<asp:TextBox ID="txtcorreo" runat="server" ToolTip="Correo" CssClass="input-text required-entry"></asp:TextBox>
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Telefono</label>
<div class="input-box">
<asp:TextBox ID="txttelefono" runat="server" ToolTip="Telefono" 
        CssClass="input-text required-entry"></asp:TextBox>
<%--<ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender1"
           runat="server"
           TargetControlID="txttelefono"
           FilterType="Numbers" />--%><ajaxToolkit:MaskedEditExtender
    TargetControlID="txttelefono" 
    Mask="(999)-999999"
    MessageValidatorTip="true" 
    OnFocusCssClass="MaskedEditFocus" 
    OnInvalidCssClass="MaskedEditError"
    MaskType="Number" 
    InputDirection="RightToLeft" 
    AcceptNegative="Left" 
    ErrorTooltipEnabled="True" runat="server"/>
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Celular</label>
<div class="input-box">
<asp:TextBox ID="txtcelular" runat="server" ToolTip="Celular" CssClass="input-text required-entry"></asp:TextBox>
           <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1"
    TargetControlID="txtcelular" 
    Mask="(999)9999999"
    MessageValidatorTip="true" 
    OnFocusCssClass="MaskedEditFocus" 
    OnInvalidCssClass="MaskedEditError"
    MaskType="Number" 
    InputDirection="RightToLeft" 
    AcceptNegative="Left" 
    ErrorTooltipEnabled="True" runat="server"/>
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Dirección</label>
<div class="input-box">
<asp:TextBox ID="txtdireccion" runat="server" ToolTip="Dirección" CssClass="input-text required-entry"></asp:TextBox>
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Cédula</label>
<div class="input-box">
<asp:TextBox ID="txtcedula" runat="server" ToolTip="Cédula" CssClass="input-text required-entry" MaxLength="10"></asp:TextBox>
<ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender3"
           runat="server"
           TargetControlID="txtcedula"
           FilterType="Numbers" /><ajaxToolkit:MaskedEditExtender
    TargetControlID="txtcedula" 
    Mask="9999999999"
    MessageValidatorTip="true" 
    OnFocusCssClass="MaskedEditFocus" 
    OnInvalidCssClass="MaskedEditError"
    MaskType="Number" 
    InputDirection="RightToLeft" 
    AcceptNegative="Left" 
    DisplayMoney="Left"
    ErrorTooltipEnabled="True"/>
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Sexo</label>
<div class="input-box">
    <asp:DropDownList ID="ddlsexo" runat="server" CssClass="checkbox" Width="200px">
        <asp:ListItem Value="0">Masculino</asp:ListItem>
        <asp:ListItem Value="1">Femenino</asp:ListItem>
    </asp:DropDownList>
    </div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Provincia</label>
<div class="input-box">
    <asp:DropDownList ID="ddlprovincia" runat="server" CssClass="checkbox" 
        Width="200px" AutoPostBack="True" 
        onselectedindexchanged="ddlprovincias_SelectedIndexChanged">
    </asp:DropDownList>
    </div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Ciudad</label>
<div class="input-box">
    <asp:DropDownList ID="ddlciudad" runat="server" CssClass="checkbox" 
        Width="200px">
    </asp:DropDownList>
    </div>
</div>
</li>
<li>
<div class="field name-firstname">
<div class="input-box">
    <asp:CheckBox ID="cbboletin" runat="server" Text="Suscribete para recibir nuestras ofertas"/>
    </div>
</div>
</li>
</ul>
</div><br />
<div class="fieldset">
<h2 class="legend">Información de acceso</h2>
<ul class="form-list">
<li class="fields">
<div class="field">
<label for="password" class="required"><em>*</em>Usuario</label>
<div class="input-box">
<asp:UpdatePanel ID="up2" runat="server">
<ContentTemplate><%--AutoPostBack="true" OnTextChanged="txtus_Changed"--%>
<asp:TextBox ID="txtus" runat="server" ToolTip="Usuario" CssClass="input-text required-entry"></asp:TextBox>
<br />
<span ID="Span1" runat="server" style="font-size: 9px; font-weight: bold;">
                                    </span>
</ContentTemplate>
</asp:UpdatePanel>
</div>
</div>
</li>
<li class="fields">
<div class="field">
<label for="confirmation" class="required"><em>*</em>Clave</label>
<div class="input-box">
<asp:TextBox ID="txtclave" runat="server" ToolTip="Clave" CssClass="input-text required-entry" TextMode="Password"></asp:TextBox>
<br />
<asp:Label ID="Label1" runat="server" Text="Minimo 6 caracteres, máximo 12" 
        Font-Size="11px" ForeColor="#666666"></asp:Label>
</div>
</div>
<div class="field">
<label for="confirmation" class="required"><em>*</em>Confirmar Clave</label>
<div class="input-box">
<asp:TextBox ID="txtconfirmar" runat="server" ToolTip="Confirmar Clave" CssClass="input-text required-entry" TextMode="Password"></asp:TextBox>
<asp:CompareValidator id="CompareValidator1"
runat="server" ErrorMessage="Clave incorrectas" 
ControlToValidate="txtconfirmar"
ControlToCompare="txtclave" Text="Claves incorrectas"></asp:CompareValidator>
</div>
</div>
<div class="buttons-set">
<p class="required">* campos requeridos</p>
<asp:Button ID="btncrearcuenta" runat="server" Text="Registrar" ToolTip="Registrar" CssClass="button bordebotones" Height="35" Width="100" BackColor="#ABCD43" ForeColor="White" Font-Bold="True" Font-Size="14px" onclick="btncrearcuenta_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblvalida" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</div>
</li>
</ul>
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
