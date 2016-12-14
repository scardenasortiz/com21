<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/infoproductos.master" CodeFile="iniciar.aspx.cs" Inherits="iniciar" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>--%>
        <style type="text/css">
            .Espacio
            {
                padding-left: 5px;
            }
        </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div class="container">
<div class="row">
<div class="span12">
<div class="main">
<div class="col-main">
<div class="padding-s" style="padding-right:0px">
<div class="account-login">
<div class="page-title" style="padding-left: 10px;">
<h1>Ingresa o Crea una cuenta</h1>
</div>
<div class="col2-set">
<div class="wrapper">
<div class="registered-users-wrapper">
<div class="col-2 registered-users" style="border: 0px solid #ececec;">
<div class="content">
<h2>Cliente Registrado</h2>
<p>Si usted tiene una cuenta con nosotros, por favor ingrese.</p>
<ul class="form-list">
<li>
<label for="email" class="required"><em>*</em>Usuario</label>
<div class="input-box">
<asp:TextBox ID="txtcorreo" runat="server" class="input-text required-entry validate-password Espacio" ToolTip="Email" Height="30px"></asp:TextBox>
</div>
</li>
<li>
<label for="pass" class="required"><em>*</em>Clave</label>
<div class="input-box">
<asp:TextBox ID="txtclave" runat="server" class="input-text required-entry validate-password Espacio" ToolTip="Clave" TextMode="Password" Height="30px"></asp:TextBox>
</div>
</li>
</ul>

<p class="required">* campos requeridos</p>
<div class="buttons-set" style="padding-top: 15px;">
<a href="recuperar.aspx" class="f-left">Has olvidado tu contraseña?</a>
<asp:Button ID="btnlogin" runat="server" Text="Login" ToolTip="Login" CssClass="button bordebotones" Height="35" Width="80" BackColor="#ABCD43" ForeColor="White" Font-Bold="True" Font-Size="14px" onclick="btnlogin_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblnologin" runat="server" Text="*Usuario o Clave incorrectos" ForeColor="Red" Visible="false"></asp:Label>
</div>
</div>
</div>
</div>
<div class="new-users-wrapper">
<div class="col-1 new-users" style="border: 0px solid #ececec;">
<div class="content">
<h2>Nuevo Cliente</h2>
<p>Al crear una cuenta en nuestra tienda, podrá realizar el proceso de compra más rápidamente, almacenar dirección de envío, ver y hacer un seguimiento de sus pedidos en su cuenta y más.</p>
<div class="buttons-set">
<asp:Button ID="btncrearcuenta" runat="server" Text="Creas una Cuenta" ToolTip="Creas una Cuenta" CssClass="button bordebotones" Height="35" Width="150" BackColor="#ABCD43" ForeColor="White" Font-Bold="True" Font-Size="14px" onclick="btncrearcuenta_Click" />
</div>
</div>
</div>
</div>
</div>
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
