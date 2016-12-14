﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="timer_prueba_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />
        <div id="timers" runat="server">
            <%--<asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="50000">
            </asp:Timer>--%>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="UpdatePanel1 not refreshed yet."></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Label ID="Label2" runat="server" Text="UpdatePanel2 not refreshed yet."></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>