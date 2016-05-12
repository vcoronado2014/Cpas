<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="movimientoEditar.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.movimientoEditar" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <script src="../js/jquery-2.1.4.min.js"></script>
        
        <script src="../js/vendor/modernizr.js"></script>

        <script src="../js/foundation.min.js"></script>
        <script src="../js/foundation/foundation.equalizer.js"></script>


        <script src="../js/foundation/foundation.abide.js"></script>
        <script type="text/javascript">
            $(document).foundation();
            function onFileUploadComplete(s, e) {
                if (e.callbackData) {
                    var fileData = e.callbackData.split('|');
                    var fileName = fileData[0],
                        fileUrl = fileData[1],
                        fileSize = fileData[2];
                    //se completo la carga
                    pnlGeneral.PerformCallback('subir|' + fileName);

                }
            }

            </script>
    <dx:ASPxCallbackPanel ID="pnlGeneral" runat="server" ClientInstanceName="pnlGeneral" Width="100%" OnCallback="pnlGeneral_Callback">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <asp:HiddenField ID="hidId" runat="server" Value="0" />
                <div class="row panel bg-titulo" style="margin: 0.1em;">
                    <span class="tituloContacto"><i class="foundicon-website padding-right-15 style3"></i>
                        <asp:Literal ID="litOperacion" runat="server"></asp:Literal>
                        Movimiento </span>
                    <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" CausesValidation="False" ClientInstanceName="btnEliminar" CssClass="button right" Native="True" Text="Eliminar" ClientVisible="False">
                        <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('eliminar|');
}" />
                    </dx:ASPxButton>
                </div>
                <div class="panel" id="panelPrincipal">
                    <div class="row">
                        <div class="name-field medium-2 columns">
                            <label>
                                Fecha 
                                <dx:ASPxLabel ID="lblFechaMovimiento" runat="server" Text=""></dx:ASPxLabel>

                            </label>
                        </div>
                        <div class="name-field medium-4 columns">
                            <label>
                                Tipo Movimiento <small>requerido</small>
                                <dx:ASPxComboBox ID="cmbTipoMovimiento" runat="server" ValueType="System.String" Native="true" ClientInstanceName="cmbTipoMovimiento" Width="100%">
                                    <Items>
                                        <dx:ListEditItem Text="Ingreso" Value="1" />
                                        <dx:ListEditItem Text="Egreso" Value="2" />
                                    </Items>
                            </dx:ASPxComboBox>

                            </label>

                        </div>
                        <div class="name-field medium-3 columns">
                            <label>
                                Número Comprobante <small>requerido</small>
                                <dx:ASPxTextBox ID="txtNumeroComprobante" runat="server" Native="true" ClientInstanceName="txtNumeroComprobante" Width="100%">
                                    <ValidationSettings ValidationGroup="panel">                                       
                                        <RequiredField IsRequired="True" ErrorText="Número Comprobante Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </label>

                        </div>
                        <div class="name-field medium-3 columns">
                            <label>
                                Monto <small>requerido</small>
                                <dx:ASPxTextBox ID="txtMonto" runat="server" Native="true" ClientInstanceName="txtMonto" Width="100%">
                                    <ValidationSettings ValidationGroup="panel">
                                        <RegularExpression ErrorText="Sólo números" ValidationExpression="^\d+$" />
                                        <RequiredField IsRequired="True" ErrorText="Monto Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </label>

                        </div>
                    </div>
                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                Detalle Movimiento 
                                <dx:ASPxMemo ID="memDetalle" runat="server" Height="140px" Width="100%" Native="true"></dx:ASPxMemo>

                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                Subir Archivo 
                                <dx:ASPxUploadControl ID="upload" ClientInstanceName="upload" runat="server" UploadMode="Auto" Width="100%" ShowProgressPanel="True" ShowUploadButton="True" OnFileUploadComplete="upload_FileUploadComplete">
                                    <UploadButton Text="Subir">
                                    </UploadButton>
                                    <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .gif, .png, .doc, .docx, .xls, .xlsx, .pdf" MaxFileSize="4194304" MaxFileSizeErrorText="El archivo Excede el tamaño permitido {0} bytes">
                                    </ValidationSettings>
                                    <ClientSideEvents  FileUploadComplete="onFileUploadComplete" />
                                </dx:ASPxUploadControl>
                                <span> Archivo subido:  <dx:ASPxLabel ID="lblNombreArchivoSubido" ClientInstanceName="lblNombreArchivoSubido" runat="server" Text="" Font-Bold="True"></dx:ASPxLabel></span>
                            </label>
                        </div>
                    </div>

                    <hr />
                    <div class="row panel">
                        <dx:ASPxLabel ID="litMensaje" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                    <div class="row">

                        <dx:ASPxValidationSummary ID="validationSummary" ClientInstanceName="validationSummary" RenderMode="Table" ValidationGroup="panel" runat="server" Width="100%" BackColor="Aqua">
                            <HeaderStyle BackColor="Aqua" />
                            <Border BorderStyle="None" />
                        </dx:ASPxValidationSummary>
                    </div>
                    <div class="row">
                        <dx:ASPxButton ID="btnLimpiar" ClientInstanceName="btnLimpiar" AutoPostBack="false" runat="server" Text="Limpiar" CssClass="button" Native="true" CausesValidation="False" ClientVisible="true">
                            <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('limpiar;');
}" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnGuardar" Native="true" AutoPostBack="false" CssClass="button right" runat="server" Text="Guardar" ValidationContainerID="panelPrincipal" ValidationGroup="panel">
                            <ClientSideEvents Click="function(s, e) {
                                if (ASPxClientEdit.ValidateGroup('panel')){

		     if (s.GetText() == 'Modificar')
                                    {
                                        pnlGeneral.PerformCallback('guardar|'+lblNombreArchivoSubido.GetText());
                                    }
                                    else
                                    {
                                        pnlGeneral.PerformCallback('insertar|'+lblNombreArchivoSubido.GetText());
                                    }

}


}" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnVolver" runat="server" CausesValidation="False" ClientInstanceName="btnLimpiar" CssClass="button warning" Native="True" Text="Volver" OnClick="btnVolver_Click">
                        </dx:ASPxButton>

                    </div>

                </div>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

</asp:Content>
