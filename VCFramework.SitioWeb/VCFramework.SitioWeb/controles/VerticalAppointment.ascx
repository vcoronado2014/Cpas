<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VerticalAppointment.ascx.cs" Inherits="VCFramework.SitioWeb.controles.VerticalAppointment" %>
<div class="row">
    <div class="panel callout">
        <div class="medium-12 columns">
            <asp:Label ID="lblHeader" runat="server"></asp:Label>
        </div>
        <div class="medium-1 columns" id="imageContainer">

        </div>
        <div class="medium-11 columns">
            <div class="row">
                <div class="medium-2 columns">
                    <span>Subject:</span>
                </div>
                <div class="medium-10 columns">
                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="medium-2 columns">
                    <span>Ubicación:</span>
                </div>
                <div class="medium-10 columns">
                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                </div>
            </div>
            <div class="medium-12 columns">
                <asp:Label ID="lblDescription" runat="server"></asp:Label>
            </div>

        </div>
    </div>

</div>

