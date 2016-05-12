<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="documentosUsuario.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.documentosUsuario" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .button {
            -webkit-appearance: none;
            -moz-appearance: none;
            border-radius: 0;
            border-style: none;
            border-width: 0;
            cursor: pointer;
            font-family: Helvetica, Roboto, Arial, sans-serif;
            /* font-weight: normal; */
            /* line-height: normal; */
             margin: 0; 
            position: relative;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            padding: 0;
            font-size: 1rem;
            /* background-color: #2ba6cb; */
            /* border-color: #285a2; */
             color: black;
             background-color: transparent;
            transition: background-color 300ms ease-out;
        }
        /* nuevos estilos de las grillas */
    /*.dx-wrap {
        background-color: PeachPuff;
    }
    .dx-vam {
        background-color: PeachPuff;
    }
    .dxgvHeader_Mulberry1, .dxgvHeader_Mulberry1 table {
        color: #8d8d8d;
        background-color: PeachPuff;
    }*/
    #ContentPlaceHolder1_grillaDocumentos_DXHeadersRow0 table {
        color: #8d8d8d;
        background-color: PeachPuff;
            border-width: 0;
    }
    #ContentPlaceHolder1_grillaUsuarios_DXHeadersRow0 table {
        color: #8d8d8d;
        background-color: PeachPuff;
            border-width: 0;
    }
    #ContentPlaceHolder1_controlVistaDocumentos1_grillaDocumentos_DXHeadersRow0 table {
        color: #8d8d8d;
        background-color: PeachPuff;
            border-width: 0;
    }
    #ContentPlaceHolder1_pnlOtros_controlVistaDocumentos1_grillaDocumentos_DXHeadersRow0 table {
        color: #8d8d8d;
        background-color: PeachPuff;
            border-width: 0;
    }
    #ContentPlaceHolder1_pnlOtros_controlVistaRendiciones_grillaDocumentos_DXHeadersRow0 table {
        color: #8d8d8d;
        background-color: PeachPuff;
            border-width: 0;
    }
    #ContentPlaceHolder1_controlVistaRendiciones1_grillaDocumentos_DXHeadersRow0 table {
        color: #8d8d8d;
        background-color: PeachPuff;
            border-width: 0;
    }
    .dxscToolbar_Mulberry1 {
            border: none;
            background: #fafafa;
            padding: 0;
            margin:0;
            height: 0;
        }
    .dxscViewSelectorButton_Mulberry1
    {
	    padding: 5px 8px 6px;
    }
    .dxscViewNavigatorButton_Mulberry1.dxscViewNavigatorGotoTodayButton,
.dxscViewNavigatorButtonHover_Mulberry1.dxscViewNavigatorGotoTodayButton,
.dxscViewNavigatorButtonPressed_Mulberry1.dxscViewNavigatorGotoTodayButton
{
	border-width: 0;
	background: none;
	color: #BF4E6A;
	padding: 3px 5px 5px;
}
    #ctl00_ContentPlaceHolder1_ASPxScheduler1_viewNavigatorBlock_ctl00 {border:none;}
    #ctl00_ContentPlaceHolder1_ASPxScheduler1_viewNavigatorBlock_ctl00_IC {border:none;}
    #ctl00_ContentPlaceHolder1_ASPxScheduler1_viewNavigatorBlock_ctl00_IC table {border:none;}
    #ctl00_ContentPlaceHolder1_ASPxScheduler1_viewSelectorBlock_ctl00 {border:none;}
    #ctl00_ContentPlaceHolder1_ASPxScheduler1_viewSelectorBlock_ctl00_ctl01 {border:none;}
    #ctl00_ContentPlaceHolder1_ASPxScheduler1_viewNavigatorBlock_ctl00 {border:none;}
    #ctl00_ContentPlaceHolder1_pnlOtros_ASPxScheduler1_viewNavigatorBlock_ctl00_IC {border:none;}
    #ctl00_ContentPlaceHolder1_pnlOtros_ASPxScheduler1_viewNavigatorBlock_ctl00_IC table {border:none;}
    #ctl00_ContentPlaceHolder1_pnlOtros_ASPxScheduler1_viewSelectorBlock_ctl00 {border:none;}
    #ctl00_ContentPlaceHolder1_pnlOtros_ASPxScheduler1_viewSelectorBlock_ctl00_ctl01 {border:none;}
    #ctl00_ContentPlaceHolder1_pnlOtros_ASPxScheduler1_viewNavigatorBlock_ctl00 {border:none;}

.dx-ac {
    text-align: center;
    background-color: rgb(244, 206, 147);
    border: none;
}
.dx-al > * {
    background-color: rgb(244, 206, 147);
    border: none;
}
.dxscCellWithPadding {
    padding: 1px;
    background-color: rgb(244, 206, 147);
    border: none;
}
#ctl00_ContentPlaceHolder1_pnlOtros_ASPxScheduler1_aptsBlock_AptTemplateContainer110_ctl00_appointmentDiv{    background-color: rgb(193, 244, 156);
    border: none;}
.dxscAppointmentInnerBorders_Mulberry1
{	
    border: solid 1px #cbcbcb;
    padding: 0px;
    background-color:blue;
}

@media only screen and (max-width: 500px) {
    .tituloContacto{
        color: #0f69b4;
        padding: 0 0 5px;
        margin: 0 0 2px;
    
        font-size:1.0em;
        padding-left:5px;
    }
}
    </style>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/vendor/modernizr.js"></script>

    <script src="../js/foundation.min.js"></script>
    <script src="../js/foundation/foundation.accordion.js"></script>

    <script type="text/javascript">
        $(document).foundation();
        function onFileUploadComplete(s, e) {
            if (e.callbackData) {
                var fileData = e.callbackData.split('|');
                var fileName = fileData[0],
                    fileUrl = fileData[1],
                    fileSize = fileData[2];
                //enviar callback
                grid.PerformCallback('actualizar');
                //DXUploadedFilesContainer.AddFile(fileName, fileUrl, fileSize);
            }
        }
        function OnInit(s, e) {
            AdjustSize();
        }
        function OnEndCallback(s, e) {
            AdjustSize();
        }
        function OnControlsInitialized(s, e) {
            ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                AdjustSize();
            });
        }
        function AdjustSize() {
            var height = Math.max(50, document.documentElement.clientHeight);
            grid.SetHeight(height);
        }
        function EliminarArchivo(id)
        {
            //alert(id);
            if (confirm('Esta seguro de eliminar este archivo?'))
                grid.PerformCallback('eliminar|' + id);
        }
    </script>
    <div class="row panel bg-titulo" style="margin:0.1em;">
        <span class="tituloContacto"><i class="foundicon-page padding-right-15"></i>Administración de Documentos</span>
    </div>
    <div class="row">
        <div class="medium-12 columns">

            <div class="panel">
                <div class="row">
                    <div class="medium-12 columns">
                        <p>Esta página le permitirá subir los archivos al Repositorio de su Establecimiento.</p>
                    </div>
                    
                </div>
            </div>

        </div>
    </div>
    <div class="row">
        <p class="informativo"><small><strong>Importante: </strong>Se permite aubir archivos con extensión Pdf, Word, Excel e imágenes que no superen los 4 MB en tamaño.</small></p>
    </div>
    <div class="row">
        <div class="medium-12 columns">
        
        <dx:ASPxUploadControl ID="UploadControl" ClientInstanceName="UploadControl" runat="server" UploadMode="Auto" Width="100%" ShowUploadButton="true" ShowProgressPanel="true" OnFileUploadComplete="UploadControl_FileUploadComplete">
            <AdvancedModeSettings EnableMultiSelect="True" EnableFileList="True" EnableDragAndDrop="True" />
            <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .gif, .png, .doc, .docx, .xls, .xlsx, .pdf" MaxFileSize="4194304" MaxFileSizeErrorText="El archivo Excede el tamaño permitido {0} bytes">
            </ValidationSettings>
            <ClientSideEvents  FileUploadComplete="onFileUploadComplete" />
            </dx:ASPxUploadControl>
            
        </div>
    </div>
    <div class="row">
        <div class="medium-12 columns">
            <dx:ASPxGridView ID="grillaDocumentos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSLISTADO" Width="100%" ClientInstanceName="grid" OnCustomCallback="grillaDocumentos_CustomCallback" OnHtmlDataCellPrepared="grillaDocumentos_HtmlDataCellPrepared" Theme="Mulberry1">
                <Settings ShowFilterRow="True" ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NombreArchivo" VisibleIndex="2" ShowInCustomizationForm="True" Width="50%">
                        <Settings AllowAutoFilter="True" AllowFilterBySearchPanel="True" AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                        <CellStyle Wrap="True">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Tamano" VisibleIndex="3" ShowInCustomizationForm="True" Width="10%">
                        <Settings AllowAutoFilter="False" AllowFilterBySearchPanel="False" AllowHeaderFilter="False" AutoFilterCondition="Contains" />
                        <CellStyle Wrap="True">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="0" Width="10%">
                        <DataItemTemplate>
                            <asp:HyperLink ID="hlInicio" runat="server" CssClass="item" NavigateUrl='<%# Eval("Url", "{0}")%>'>
                                        <span data-tooltip aria-haspopup="true" class="has-tip" title="Descargar">
                                        <i class="foundicon-down-arrow" ></i></span>
                            </asp:HyperLink>

                            <button class="item button"
                                onclick="EliminarArchivo('<%# Eval("Id", "{0}") %>');return false">
                                <i class="foundicon-remove"></i>
                            </button>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Fecha Subida" FieldName="FechaSubida" VisibleIndex="4" Width="20%">
                        <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                        <CellStyle Wrap="True">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption=" " FieldName="Extension" VisibleIndex="5" Width="10%">
                        <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                        <DataItemTemplate>
                            <dx:ASPxImage ID="ASPxImage1" runat="server" ImageUrl='<%# Eval("Extension") %>' IsPng="True" ShowLoadingImage="True" Width="30px">
                            </dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>
                    <%--<Header BackColor="#D8D8D8" Font-Bold="True" ForeColor="#222222" Wrap="True">
                        <Paddings Padding="1%" />
                        <BackgroundImage Repeat="NoRepeat" />
                    </Header>
                    <GroupRow BackColor="#D8D8D8">
                    </GroupRow>
                    <GroupPanel BackColor="#D8D8D8">
                    </GroupPanel>
                    <HeaderPanel BackColor="#D8D8D8" ForeColor="#222222" Wrap="True">
                        <Paddings Padding="0px" />
                    </HeaderPanel>
                    <HeaderFilterItem BackColor="#D8D8D8">
                    </HeaderFilterItem>--%>
                    <Header Font-Bold="True" Wrap="True">
                        <Paddings Padding="1%" />
                        <BackgroundImage Repeat="NoRepeat" />
                    </Header>
                </Styles>
                <Border BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px" />
            </dx:ASPxGridView>

            <asp:ObjectDataSource ID="ODSLISTADO" runat="server" SelectMethod="ObtenerDocumentosPorInstId" TypeName="VCFramework.NegocioMySQL.DocumentosUsuario">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="instId" SessionField="INST_ID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
    </div>
</asp:Content>
