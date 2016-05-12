<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="controlVistaRendiciones.ascx.cs" Inherits="VCFramework.SitioWeb.controles.controlVistaRendiciones" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<link rel="stylesheet" href="../css/magnific-popup.css"/>
    <%--<script src="../js/vendor/jquery.magnific-popup.js"></script>--%>

<%--<script type="text/javascript">
    $(document).ready(function () {
        $('.link1_1').magnificPopup({ type: 'iframe' });
    });
</script>--%>

<div class="row">
    <div class="medium-12 columns">
<dx:ASPxGridView ID="grillaDocumentos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSLISTADO" Width="100%" ClientInstanceName="grid" Theme="Mulberry1">
                <Settings ShowFilterRow="True" ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Detalle" VisibleIndex="4" ShowInCustomizationForm="True" Width="45%" Caption="Detalle">
                        <Settings AllowAutoFilter="False" AllowFilterBySearchPanel="True" AllowHeaderFilter="False" AutoFilterCondition="Contains" />
                        <CellStyle Wrap="True">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="0" Width="10%">
                        <DataItemTemplate>
                                
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="item" NavigateUrl='<%# Eval("UrlDocumento", "{0}")%>'>
                                        <span data-tooltip aria-haspopup="true" class="has-tip" title="Descargar">
                                        <i class="foundicon-down-arrow" ></i></span>
                            </asp:HyperLink>
                            <a class="link1_1 foundicon-search" data-tooltip aria-haspopup="true" class="has-tip" title="Vista Previa" href="http://docs.google.com/viewer?url=http://www.cpas.cl/Boletas/<%# Eval("NombreDocumento", "{0}")%> &embedded=true"></a>
                            </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Fecha" FieldName="FechaMovimiento" VisibleIndex="2" Width="15%">
                        <Settings AllowAutoFilter="False" AllowHeaderFilter="False" ShowInFilterControl="False" />
                        <CellStyle Wrap="True">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="N° Comp." FieldName="NumeroComprobante" VisibleIndex="3" Width="15%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="$" FieldName="Monto" VisibleIndex="5" Width="10%">
                        <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn VisibleIndex="6" Width="5%" Caption=" ">
                        <DataItemTemplate>
                            <i class='<%# Eval("Icon", "{0}")%>' ></i></span>
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
                    <Header  Font-Bold="True"  Wrap="True">
                    <Paddings Padding="1%" />
                    <BackgroundImage Repeat="NoRepeat" />
                </Header>
                </Styles>
                <Border BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px" />
            </dx:ASPxGridView>

            <asp:ObjectDataSource ID="ODSLISTADO" runat="server" SelectMethod="ObtenerIngresoEgresoPorInstId" TypeName="VCFramework.NegocioMySQL.IngresoEgreso">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="instId" SessionField="INST_ID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

    </div>

</div>
