﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cambiar.aspx.cs" Inherits="VCFramework.SitioWeb.RecuperarClave.Cambiar" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="../js/vendor/modernizr.js"></script>

    <script src="../js/vendor/jquery.js"></script>
    <script src="../js/foundation.min.js"></script>
    <script src="../js/foundation/foundation.equalizer.js"></script>
    <script src="../js/foundation/foundation.tooltip.js"></script>
    <script>
        $(document).foundation();
    </script>
    <div class="row panel bg-titulo" style="margin: 0.1em;">
        <span class="tituloContacto"><i class="foundicon-unlock padding-right-15"></i>Recuperar Clave</span>
    </div>
    <dx:ASPxCallbackPanel ID="pnlGeneral" runat="server" ClientInstanceName="pnlGeneral" Width="100%" OnCallback="pnlGeneral_Callback">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <div class="row">
                    <div class="medium-12 columns">

                        <div class="panel">
                            <%--<h4>Ingrese su nombre de Usuario</h4>--%>

                            <div class="row">
                                <div class="medium-8 columns">
                                    <p>Ingrese su nombre de usuario y luego presione el botón Recuperar</p>
                                </div>
                                <div class="medium-4 columns">
                                    <dx:ASPxTextBox ID="txtUsername" runat="server" Width="100%" Native="true" ClientInstanceName="txtUsername">
                                        <ClientSideEvents TextChanged="function(s, e) {
pnlGeneral.PerformCallback('usuario;' + s.GetText());
	
}" />
                                        <ValidationSettings ValidationGroup="panel">
                                            <RequiredField IsRequired="True" ErrorText="Usuario Requerido" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </div>
                            </div>

                            <div class="row">
                                <dx:ASPxPanel ID="pnlCreacion" runat="server" Width="100%" ClientVisible="False">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server">
                                            <div class="row callout">
                                                <div class="medium-12 columns">
                                                <span>La clave será enviada a su correo electrónico <strong>
                                                    <dx:ASPxLabel ID="lblCorreoRecuperar" runat="server" Text="" Font-Bold="True" Font-Size="Large"></dx:ASPxLabel>.</strong> Si ésta seguro de continuar presione el botón  <strong>"Siguiente"</strong>.</span>
                                                </div>
                                                
                                            </div>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxPanel>
                            </div>
                            <div class="row right">
                                
                                                    <dx:ASPxButton ID="btnGuardar" Native="true" AutoPostBack="false" CssClass="button right" runat="server" Text="Recuperar" ValidationContainerID="panelPrincipal" ValidationGroup="panel">
                                                        <ClientSideEvents Click="function(s, e) {
                                if (ASPxClientEdit.ValidateGroup('panel')){
                                    var usuario = txtUsername.GetText();
		                            
                                    pnlGeneral.PerformCallback('recuperar;' + usuario);
                                    

}


}" />
                                                    </dx:ASPxButton>
                               
                            </div>
                            <div class="row">
                                <dx:ASPxLabel ID="litMensaje" runat="server" Text="" CssClass="dxvsValidationSummary"></dx:ASPxLabel>
                                <dx:ASPxValidationSummary ID="validationSummary" ClientInstanceName="validationSummary" RenderMode="Table" ValidationGroup="panel" runat="server" Width="100%" BackColor="Aqua">
                                    <HeaderStyle BackColor="Aqua" />
                                    <Border BorderStyle="None" />
                                </dx:ASPxValidationSummary>
                            </div>
                        </div>

                    </div>
                </div>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
</asp:Content>
