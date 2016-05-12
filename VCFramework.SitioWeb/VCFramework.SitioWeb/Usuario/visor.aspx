<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visor.aspx.cs" Inherits="VCFramework.SitioWeb.Usuario.visor" %>

<%@ Register src="../controles/controlVistaCalendario.ascx" tagname="controlVistaCalendario" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="../css/fullcalendar.css"/>
    <link rel="stylesheet" href="../css/fullcalendar.min.css"/>
<%--    <link rel="stylesheet" href="../css/fullcalendar.print.css"/>--%>
        <script src="../js/jquery-2.1.4.min.js"></script>


        <script src="../js/vendor/modernizr.js"></script>
        
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <uc1:controlVistaCalendario ID="controlVistaCalendario1" runat="server" />
        
    </div>
    </form>
</body>
</html>
