<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="vistaMensaje.ascx.cs" Inherits="VCFramework.SitioWeb.controles.vistaMensaje" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="row" style="margin-left:2%;">
    <dx:ASPxRoundPanel ID="rpMensaje" runat="server" ShowCollapseButton="true" Width="98%" Theme="Mulberry" ClientVisible="False">
        <ContentPaddings Padding="5px" />
        <PanelCollection>
<dx:PanelContent runat="server">
    <div class="medium-2 columns">
        <dx:ASPxImage ID="imgError" runat="server" ShowLoadingImage="true" ClientVisible="False" Height="40px" ImageUrl="~/controles/icoError.jpg" Width="40px"></dx:ASPxImage>
        <dx:ASPxImage ID="imgAlerta" runat="server" ClientVisible="False" Height="40px" ImageUrl="~/controles/icoAlerta.png" ShowLoadingImage="True" Width="40px">
        </dx:ASPxImage>
        <dx:ASPxImage ID="imgOk" runat="server" ClientVisible="False" Height="40px" ImageUrl="~/controles/icoOk.jpg" ShowLoadingImage="True" Width="40px">
        </dx:ASPxImage>
    </div>
    <div class="medium-10 columns">
        <dx:ASPxLabel ID="lblMensajeError" runat="server" Text="" Font-Bold="True" Font-Size="13pt"></dx:ASPxLabel>
    </div>
</dx:PanelContent>
</PanelCollection>
    </dx:ASPxRoundPanel>

</div>