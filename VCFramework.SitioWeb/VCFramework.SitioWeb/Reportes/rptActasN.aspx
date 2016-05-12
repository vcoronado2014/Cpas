<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptActasN.aspx.cs" Inherits="VCFramework.SitioWeb.Reportes.rptActasN" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="script/jquery-1.12.1.js"></script>
    <script src="script/jquery-ui.js"></script>
    <script src="script/globalize.js"></script>
    <script src="script/knockout-3.4.0.js"></script>

    <link href="script/jquery-ui.css" type="text/css" rel="Stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>


        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="panelRpt" OnCallback="ASPxCallbackPanel1_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="webDocumentViewer" runat="server"  ClientInstanceName="webDocumentViewer">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>



            <script> 
                $(document).ready(function () {
                    panelRpt.PerformCallback();
                });
        
    })
</script> 
    </div>
    </form>
</body>
</html>
