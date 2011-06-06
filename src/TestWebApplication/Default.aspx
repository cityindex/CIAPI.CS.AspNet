﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWebApplication.Default" %>

<%@ Register Assembly="CIAPI.AspNet.MarketGrid" Namespace="CIAPI.AspNet.MarketGrid" TagPrefix="cc1" %>
<%@ Register Assembly="CIAPI.AspNet.Authentication" Namespace="CIAPI.AspNet.Authentication" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CIAPI.AspNet widget demo</title>
   
    <!--<link type="text/css"  href="http://cdn.wijmo.com/themes/rocket/jquery-wijmo.css" rel="Stylesheet"/>-->
    <link type="text/css"  href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.10/themes/black-tie/jquery-ui.css" rel="Stylesheet"/>
<%--    <link type="text/css"  href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.10/themes/eggplant/jquery-ui.css" rel="Stylesheet"/>--%>

    <link type="text/css"  href="StyleSheet1.css" rel="Stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager" runat="server">
        <Scripts>
            <asp:ScriptReference Path="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js" />
            <asp:ScriptReference Path="http://ajax.microsoft.com/ajax/jquery.templates/beta1/jquery.tmpl.min.js" />
            <asp:ScriptReference Path="http://ajax.cdnjs.com/ajax/libs/json2/20110223/json2.js" />
            <asp:ScriptReference Path="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/jquery-ui.min.js" />
        </Scripts>
    </asp:ScriptManager>
    
    <div>
        <cc1:Authentication runat="server" Width="200px" />
<%--        <cc1:MarketGrid runat="server" />--%>
    </div>
    </form>
</body>
</html>