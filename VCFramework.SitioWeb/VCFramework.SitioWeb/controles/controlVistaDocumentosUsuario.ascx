<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="controlVistaDocumentosUsuario.ascx.cs" Inherits="VCFramework.SitioWeb.controles.controlVistaDocumentosUsuario" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<link rel="stylesheet" href="../css/magnific-popup.css"/>

<div class="row">
    <div class="medium-12 columns">
        <dx:ASPxGridView ID="grillaDocumentos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSLISTADO" Width="100%" ClientInstanceName="grid" OnCustomCallback="grillaDocumentos_CustomCallback" OnHtmlDataCellPrepared="grillaDocumentos_HtmlDataCellPrepared" Theme="Mulberry1" KeyFieldName="Id">
            <Settings ShowFilterRow="True" ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
            <Columns>
                <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False" ShowInCustomizationForm="True">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NombreArchivo" VisibleIndex="2" ShowInCustomizationForm="True" Width="54%">
                    <Settings AllowAutoFilter="True" AllowFilterBySearchPanel="True" AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                    <CellStyle Wrap="True">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Tamano" VisibleIndex="3" ShowInCustomizationForm="True" Width="10%">
                    <Settings AllowAutoFilter="False" AllowFilterBySearchPanel="False" AllowHeaderFilter="False" AutoFilterCondition="Contains" />
                    <CellStyle Wrap="True">
                    </CellStyle>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="0" Width="6%">
                    <DataItemTemplate>
                        <asp:HyperLink ID="hlInicio" runat="server" CssClass="item" NavigateUrl='<%# Eval("Url", "{0}")%>'>
                                        <span data-tooltip aria-haspopup="true" class="has-tip" title="Descargar">
                                
                                        <i class="foundicon-down-arrow" ></i></span>
                        </asp:HyperLink>
                         <a class="link1_2 foundicon-search" data-tooltip aria-haspopup="true" class="has-tip" title="Vista Previa" href="http://docs.google.com/viewer?url=http://www.cpas.cl/Repositorio/<%# Eval("NombreArchivo", "{0}")%> &embedded=true"></a>

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
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
            </Columns>
            <Styles>
                <Header  Font-Bold="True"  Wrap="True">
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
