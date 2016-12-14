<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="administrador_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Com21 - Administrador::.</title>
    <link href="../css/estiloscom21.css" rel="stylesheet" type="text/css" />
    <link href="../css/com21.css" rel="stylesheet" type="text/css" />
<link rel="icon" href="../images/logocom21icon.png" type="image/x-icon"/>
    
    <style type="text/css">
        .style1
        {
            width: 81px;
        }
        .style2
        {
        }
        .style3
        {
            font-family: Verdana;
            font-style: normal;
            font-weight: normal;
            font-size: 34px;
        }
        .style4
        {
            font-family: Verdana;
            font-style: normal;
            font-weight: normal;
            font-size: 12pt;
        }
        .style5
        {
            width: 348px;
        }
    </style>
    <script language="javascript" type="text/javascript">
    function AbrirVentana(Pagina)
    {
        window.showModalDialog(Pagina);
    }
    </script>
</head>
<body style="background-color:#FFFFFF; margin:0px">

    <form id="form1" runat="server" style="background-color: #FFFFFF">
    <br />

   <div style="width:950px; margin:auto; background-color:#FFF">
<div align="center" id="informacion">  
    <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:ToolkitScriptManager>
            <br />
    
    <br />
       <br />
       <br />
            <div>
                <table>
                    <tr>
                        <td class="style5" valign="top" style="vertical-align: middle">
                            <span class="style3" style="color: #333333">Control Panel </span>
                            <span class="style4" style="color: #333333">powered by&nbsp; </span>&nbsp;</td>
                        <td>
                            <asp:Image ID="Image4" runat="server" 
                                ImageUrl="~/images/logocom21.jpg" Width="130px" />
                        </td>
                    </tr>
                </table>
                <br />
       </div>
       <div id="informacion" style="margin:auto; width:340px;">
           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
               <ContentTemplate>
                   <center>
                       <table style="width: 340px">
                           <tr style="height:30px;">
                               <td class="style2">
                                   &nbsp;</td>
                               <td class="style1">
                               </td>
                               <td style="width:65%">
                               </td>
                           </tr>
                           <tr>
                               <td align="left" class="style2">
                                   &nbsp;</td>
                               <td align="left" class="style1">
                                   <asp:Label ID="lbl_usuario" runat="server" Text="Usuario" Width="54px"></asp:Label>
                               </td>
                               <td align="left">
                                   <asp:TextBox ID="txt_usuario" runat="server" CssClass="cajaTexto" 
                                       MaxLength="15" ValidationGroup="sesion" 
                                       Width="180px"></asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td align="left" class="style2">
                                   &nbsp;</td>
                               <td align="left" class="style1">
                                   <asp:Label ID="lbl_pass" runat="server" Text="Password" Width="69px"></asp:Label>
                               </td>
                               <td align="left">
                                   <asp:TextBox ID="txt_password" runat="server" CssClass="cajaTexto" 
                                       MaxLength="15"  ValidationGroup="sesion" TextMode="Password" Width="180px"></asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td align="center" colspan="3" class="style2" height="70">
                                   <asp:Button ID="BtnIniciarSesion" runat="server" Font-Names="Helvetica" 
                                       Font-Overline="False" Font-Size="12pt" Height="40px" Width="130px" 
                                       onclick="BtnIniciarSesion_Click" Text="Conectar" ValidationGroup="sesion" />
                               </td>
                           </tr>
                       </table>
                   </center>
               </ContentTemplate>
           </asp:UpdatePanel>
       </div>
       <br />
       <br />
    <br />
       <asp:Image ID="Image3" runat="server" ImageUrl="~/images/logocom21.jpg" 
        Width="80px" Height="56px" />
       <br />
                                   <asp:HyperLink ID="HyperLink1" runat="server" 
                                       CssClass="Datos" 
        NavigateUrl="~/Default.aspx" Font-Bold="True" Font-Underline="False" 
        ForeColor="#333333">www.com21.com.ec</asp:HyperLink>
       <br />
  
     <asp:Panel ID="pnlProgress" runat="server" Style="display: none; width: 500px; background-color: white"
        Width="44px">
        <div style="padding-right: 8px; padding-left: 8px; padding-bottom: 8px; padding-top: 8px">
            <table border="0" cellpadding="2" cellspacing="0" style="width: 113%; height: 50px;">
                <tbody>
                    <tr>
                        <td style="width: 50%">
                        </td>
                        <td style="text-align: right">
                            <asp:Image ID="Image2" runat="server" Height="70px" ImageUrl="~/images/logocom21.jpg"
                                Width="88px" /></td>
                        <td style="white-space: nowrap; text-align: left; font-family: verdana; font-size: 12px;">
                            <span class="Datos" 
                                style="font-size: 12px; font-family: Talo; font-weight: bold; color: #000000;">&nbsp;&nbsp; Autenticando Administrador Com21 S.A.</span>
                        </td>
                        <td style="width: 50%">
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
    
    <br />
       </div>
<div style="height:30px; " align="center">
    <table cellpadding="10" cellspacing="0" width="90%">
         <tr style="color:#ffffff; font-size: 10px; font-family:Verdana, Geneva, sans-serif; text-align:left">
                <td align="center" 
                    style="font-family: verdana; font-size: 10px; font-weight: bold; color: #333333">
                    ® Todos los derechos reservados 2013 - Creado por 
                    <a href="#" 
                        style="color: #333333; text-decoration: none;" target="_blank">DESIGNSIE</a></td>
            </tr>
    </table>
</div>
</div>

    </form>
</body> <script type="text/javascript">

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
</html>
