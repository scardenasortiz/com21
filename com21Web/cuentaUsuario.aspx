<%@ Page Language="C#" MasterPageFile="~/master/infoproductos.master" AutoEventWireup="true" CodeFile="cuentaUsuario.aspx.cs" Inherits="cuentaUsuario" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .Subrayar
    {
        text-decoration: underline;
    }
</style>
<link href='js/SpryCollapsiblePanel.css' rel='stylesheet' type='text/css' />
<script type="text/javascript" src="js/SpryCollapsiblePanel.js"></script>
    <%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="row">
<div class="col-main span9">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="padding-s">
<div class="account-create">
<div id="CollapsiblePanel2" class="CollapsiblePanel">
  <div class="CollapsiblePanelTab" tabindex="0" 
        style="padding: 5px; font-size: 17px; height: 20px; color: #000000;">Editar datos personales</div>
  <div class="CollapsiblePanelContent" style="padding-left: 5px; padding-top: 5px; padding-right: 5px;">
  <div>
<div class="fieldset">
<h2 class="legend"><asp:LinkButton ID="lbleditar" runat="server" 
        onclick="lbleditar_Click" CssClass="Subrayar">Editar</asp:LinkButton></h2>
<ul class="form-list">
<li class="fields">
<div class="customer-name">
<div class="field name-firstname">
<label for="firstname" class="required"><em>*</em>Nombres</label>
<div class="input-box">
<asp:TextBox ID="txtnombres" runat="server" ToolTip="Nombres" CssClass="input-text required-entry" Enabled="false"></asp:TextBox>
</div>
</div>
<div class="field name-lastname">
<label for="lastname" class="required"><em>*</em>Apellidos</label>
<div class="input-box">
<asp:TextBox ID="txtapellidos" runat="server" ToolTip="Apellidos" CssClass="input-text required-entry" Enabled="false"></asp:TextBox>
</div>
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Email</label>
<div class="input-box">
<asp:TextBox ID="txtcorreo" runat="server" ToolTip="Correo" CssClass="input-text required-entry" Enabled="false"></asp:TextBox>
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Telefono</label>
<div class="input-box">
<asp:TextBox ID="txttelefono" runat="server" ToolTip="Telefono" 
        CssClass="input-text required-entry" MaxLength="9" Enabled="false"></asp:TextBox>
        <br />
<asp:Label ID="Label6" runat="server" Text="Ejemplo: 042xxxxxx" 
        Font-Size="11px" ForeColor="#666666"></asp:Label>
<ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender2"
           runat="server"
           TargetControlID="txttelefono"
           FilterType="Numbers" />
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Celular</label>
<div class="input-box">
<asp:TextBox ID="txtcelular" runat="server" ToolTip="Celular" CssClass="input-text required-entry" Enabled="false"></asp:TextBox>
<br />
<asp:Label ID="Label7" runat="server" Text="Ejemplo: 0992xxxxxx" 
        Font-Size="11px" ForeColor="#666666"></asp:Label>
<ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender3"
           runat="server"
           TargetControlID="txtcelular"
           FilterType="Numbers" />
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Dirección</label>
<div class="input-box">
<asp:TextBox ID="txtdireccion" runat="server" ToolTip="Dirección" CssClass="input-text required-entry" Enabled="false"></asp:TextBox>
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Cédula</label>
<div class="input-box">
<asp:TextBox ID="txtcedula" runat="server" ToolTip="Cédula" CssClass="input-text required-entry" Enabled="false" MaxLength="15"></asp:TextBox>
<ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender4"
           runat="server"
           TargetControlID="txtcedula"
           FilterType="Numbers" />
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Sexo</label>
<div class="input-box">
    <asp:DropDownList ID="ddlsexo" runat="server" CssClass="checkbox" Width="200px" Enabled="false">
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
    <asp:DropDownList ID="ddlprovinciadatos" runat="server" CssClass="checkbox" 
        Width="200px" Enabled="false" AutoPostBack="True" 
        onselectedindexchanged="ddlprovinciadatos_SelectedIndexChanged">
    </asp:DropDownList>
    </div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Ciudad</label>
<div class="input-box">
    <asp:DropDownList ID="ddlciudaddatos" runat="server" CssClass="checkbox" Width="200px" Enabled="false">
    </asp:DropDownList>
    </div>
</div>
</li>
<li>
<div class="field name-firstname">
<div class="input-box">
    <asp:CheckBox ID="cbboletin" runat="server" Text="Suscribete para recibir nuestras ofertas" Enabled="false" />
    </div>
</div>
<div class="buttons-set">
<p class="required">* campos requeridos</p>
<asp:Button ID="btneditardatos" runat="server" Text="Editar" ToolTip="Editar" 
        CssClass="button bordebotones" Height="30" Width="80" BackColor="#ABCD43" 
        ForeColor="White" Font-Bold="True" Font-Size="14px" 
        onclick="btneditardatos_Click" Enabled="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</div>
</li>
</ul>
</div>
</div>
  </div>
</div>
<div id="CollapsiblePanel3" class="CollapsiblePanel">
  <div class="CollapsiblePanelTab" tabindex="0" style="padding: 5px; font-size: 17px; height: 20px; color: #000000;">Cambiar contraseña</div>
  <div class="CollapsiblePanelContent" style="padding-left: 5px; padding-top: 5px; padding-right: 5px;">
    <div class="fieldset">
<ul class="form-list">
<li>
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
<asp:Button ID="btneditarclave" runat="server" Text="Editar" ToolTip="Editar" 
        CssClass="button bordebotones" Height="30" Width="80" BackColor="#ABCD43" 
        ForeColor="White" Font-Bold="True" Font-Size="14px" 
        onclick="btneditarclave_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblvalida" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</div>
</li>
</ul>
</div>
  </div>
</div>
<div id="CollapsiblePanel4" class="CollapsiblePanel">
  <div class="CollapsiblePanelTab" tabindex="0" style="padding: 5px; font-size: 17px; height: 20px; color: #000000;">Editar datos de envio</div>
  <div class="CollapsiblePanelContent" style="padding-left: 5px; padding-top: 5px; padding-right: 5px;">
    <div>
<div class="fieldset">
<%--<input type="hidden" name="success_url" value="">
<input type="hidden" name="error_url" value="">--%>
    <asp:HiddenField ID="hfIdentDire" runat="server" />
    <asp:HiddenField ID="hfIdDire" runat="server" />
<h2 id="direccion" runat="server" class="legend" style="color:#666666"></h2>
<ul class="form-list">
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Dirección</label>
<div class="input-box">
<asp:TextBox ID="txtdireccionenvio" runat="server" ToolTip="Dirección" CssClass="input-text required-entry"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="Agregar breve descripción de ubicacción de la casa" 
        Font-Size="11px" ForeColor="#666666"></asp:Label>
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Nombre de contacto</label>
<div class="input-box">
<asp:TextBox ID="txtNombrecontacto" runat="server" ToolTip="Nombre de Contacto" CssClass="input-text required-entry"></asp:TextBox>
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Celular o Teléfono para contacto</label>
<div class="input-box">
<asp:TextBox ID="txttelefonoenvio" runat="server" ToolTip="Celular" CssClass="input-text required-entry" MaxLength="10"></asp:TextBox>
<br />
<asp:Label ID="Label5" runat="server" Text="Ejemplo: 0992xxxxxx o 042xxxxxx" 
        Font-Size="11px" ForeColor="#666666"></asp:Label>
<ajaxToolkit:FilteredTextBoxExtender
           ID="FilteredTextBoxExtender1"
           runat="server"
           TargetControlID="txttelefonoenvio"
           FilterType="Numbers" />
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>País</label>
<div class="input-box">
<asp:DropDownList ID="ddlpais" runat="server" CssClass="checkbox" Width="200px" 
        AutoPostBack="true" onselectedindexchanged="ddlpais_SelectedIndexChanged">
    </asp:DropDownList>
</div>
</div>
</li>
<li>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Provincia</label>
<div class="input-box">
<asp:DropDownList ID="ddlprovincia" runat="server" CssClass="checkbox" Width="200px" 
        AutoPostBack="true" 
        onselectedindexchanged="ddlprovincia_SelectedIndexChanged">
    </asp:DropDownList>
</div>
</div>
<div class="field name-firstname">
<label for="email_address" class="required"><em>*</em>Ciudad</label>
<div class="input-box">
<asp:DropDownList ID="ddlciudad" runat="server" CssClass="checkbox" Width="200px">
    </asp:DropDownList>
</div>
</div>
</li>
<li>
<%--<input type="checkbox" name="is_subscribed" title="Sign Up for Newsletter" value="1" id="is_subscribed" class="checkbox">
<label for="is_subscribed">Suscribirse al boletín</label>--%>
<div class="buttons-set">
<p class="required">* campos requeridos</p>
<asp:Button ID="btneditarenvio" runat="server" Text="Editar" ToolTip="Editar" 
        CssClass="button bordebotones" Height="30" Width="80" BackColor="#ABCD43" 
        ForeColor="White" Font-Bold="True" Font-Size="14px" 
        onclick="btneditarenvio_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
</div>
</li>
</ul>
</div>
</div>
  </div>
</div>
<script type="text/javascript">
<!--
    //    var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1");
    var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2");
    var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3");
    var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4");
//-->
</script>
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