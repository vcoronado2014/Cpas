<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cargaMasiva.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.cargaMasiva" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register src="../controles/vistaMensaje.ascx" tagname="vistaMensaje" tagprefix="uc1" %>
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
                    pnlGeneral.PerformCallback('subir|' + fileName + '|' + fileUrl);

                }
            }

            </script>
    <style type="text/css">
        .destacado {
            background-color:burlywood;
        }
    </style>


            <dx:ASPxCallbackPanel ID="pnlGeneral" ClientInstanceName="pnlGeneral" runat="server" Width="100%" OnCallback="pnlGeneral_Callback">
                <PanelCollection>
                    <dx:PanelContent runat="server">
                        <div class="row panel bg-titulo" style="margin: 0.1em;">
                            <span class="tituloContacto"><i class="foundicon-website padding-right-15 style3"></i>
                                Carga Masiva de Usuarios </span>
                            <div class="right">
                                <dx:ASPxHyperLink ID="hlDescarga" runat="server" Text="Descargar Plantilla" Target="_blank" NavigateUrl="~/Plantilla_Apoderados.xlsx">
                                </dx:ASPxHyperLink>
                            </div>

                        </div>

                        <div class="row">
                            <div class="name-field medium-6 columns">
                                <label>
                                    Subir Archivo 
                                <dx:ASPxUploadControl ID="upload" ClientInstanceName="upload" runat="server" UploadMode="Auto" Width="100%" ShowProgressPanel="True" ShowUploadButton="True" OnFileUploadComplete="upload_FileUploadComplete">
                                    <UploadButton Text="Subir">
                                    </UploadButton>
                                    <ValidationSettings AllowedFileExtensions=".xls, .xlsx" MaxFileSize="4194304" MaxFileSizeErrorText="El archivo Excede el tamaño permitido {0} bytes">
                                    </ValidationSettings>
                                    <ClientSideEvents FileUploadComplete="onFileUploadComplete" />
                                </dx:ASPxUploadControl>
                                    <span>
                                        <dx:ASPxLabel ID="lblNombreArchivoSubido" ClientInstanceName="lblNombreArchivoSubido" runat="server" Text="" Font-Bold="True" ClientVisible="False"></dx:ASPxLabel>
                                    </span>
                                </label>

                            </div>
                            <div class="name-field medium-6 columns destacado">
                                <p>Sólo se permite subir archivos con el Formato válido otorgado por CPAS, estos archivos sólo deben ser en formato Excel (xlsx, xls). Si desea descargar una copia del Archivo presione el link <strong>Descarga.</strong></p>

                            </div>
                        </div>
                        <div class="row">
                            <dx:ASPxSpreadsheet ID="Excel1" runat="server" WorkDirectory="~/App_Data/WorkDirectory" Visible="False" Width="100%"></dx:ASPxSpreadsheet>
                            </div>
                            <div class="row">
                            <%--<dx:ASPxLabel ID="lblMensaje" runat="server" Text=""></dx:ASPxLabel>--%>
                            <uc1:vistaMensaje ID="vistaMensaje1" runat="server" />
                        </div>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>



</asp:Content>
