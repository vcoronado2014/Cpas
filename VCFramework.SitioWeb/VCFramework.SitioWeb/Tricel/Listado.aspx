<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="VCFramework.SitioWeb.Tricel.Listado" %>
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
        .fg-red{color:red;}
        .fg-blue{color:blue;}
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
#ContentPlaceHolder1_pnlGeneral_grillaDocumentos_col3 table
{
	border: none;
    background-color: #D8D8D8;
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


    </script>


        <script type="text/javascript">
        //$(document).foundation();
        //function onFileUploadComplete(s, e) {
        //    if (e.callbackData) {
        //        var fileData = e.callbackData.split('|');
        //        var fileName = fileData[0],
        //            fileUrl = fileData[1],
        //            fileSize = fileData[2];
        //        //enviar callback
        //        grid.PerformCallback('actualizar');
        //        //DXUploadedFilesContainer.AddFile(fileName, fileUrl, fileSize);
        //    }
        //}
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
        //function EliminarArchivo(id)
        //{
        //    //alert(id);
        //    if (confirm('Esta seguro de eliminar este archivo?'))
        //        grid.PerformCallback('eliminar|' + id);
        //}
    </script>
        <div class="row panel bg-titulo" style="margin:0.1em;">
        <span class="tituloContacto"><i class="foundicon-tools padding-right-15"></i>Listas Tricel</span>
    </div>
<%--    <div class="row">
        <div class="medium-12 columns">

            <div class="panel">
                 <h4>¿Desea Agregar otro Tricel?</h4>

                <div class="row">
                    <div class="medium-9 columns">
                        <p>Presione nuevo y será redirigido a la página de creación</p>
                    </div>
                    <div class="medium-3 columns">
                        <a href="CrearTricel.aspx?eliminar=false&editar=false&nuevo=true&id=0" class="radius button right" style="-webkit-appearance: none;-moz-appearance: none;border-radius: 0;border-style: solid;border-width: 0;cursor: pointer;font-family: Helvetica, Roboto, Arial, sans-serif;font-weight: normal;line-height: normal;margin: 0 0 1.25rem;position: relative;text-align: center;text-decoration: none;display: inline-block;padding: 1rem 2rem 1.0625rem 2rem;font-size: 1rem;background-color: #2ba6cb;border-color: #2285a2;color: #FFFFFF;transition: background-color 300ms ease-out;">Nuevo</a>
                    </div>
                </div>
            </div>

        </div>
    </div>--%>
    <div class="row">
        <div class="large-12 columns">
                   
            <dx:ASPxGridView ID="grillaDocumentos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSLISTADO" Width="100%" ClientInstanceName="grid" OnHtmlDataCellPrepared="grillaDocumentos_HtmlDataCellPrepared" Theme="Mulberry1" KeyFieldName="Id">
                <Settings ShowFilterRow="True" ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False" ShowInCustomizationForm="True">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="0" Width="10%">
                        <DataItemTemplate>
                                <asp:HyperLink ID="hlInicio" runat="server" CssClass="item" Visible='<%# Eval("IconoEditar") %>' NavigateUrl='<%# Eval("Id", "CrearLista.aspx?editar=true&eliminar=false&nuevo=false&id={0}&TRI_ID={0}")%>'>
                                        <span data-tooltip aria-haspopup="true" class="has-tip" title="Editar">
                                        <i class="foundicon-edit" ></i></span>
                                </asp:HyperLink>
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="item" Visible='<%# Eval("IconoEliminar") %>' NavigateUrl='<%# Eval("Id", "CrearLista.aspx?eliminar=true&editar=false&nuevo=false&id={0}&TRI_ID={0}")%>' data-tooltip aria-haspopup="true" class="has-tip" title="Eliminar Lista">
                                        <i class="foundicon-trash"></i>
                                </asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="item" Visible='<%# Eval("IconoCrear") %>' NavigateUrl='<%# Eval("TriId", "CrearLista.aspx?eliminar=false&editar=false&nuevo=true&id={0}&TRI_ID={0}")%>' data-tooltip aria-haspopup="true" class="has-tip" title="Crear Lista">
                                        <i class="foundicon-add-doc"></i>
                                </asp:HyperLink>


                            </DataItemTemplate>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Nombre" VisibleIndex="2" Width="35%">
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn FieldName="Objetivo" VisibleIndex="3" Width="40%">
                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False" AllowFilterBySearchPanel="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" ShowFilterRowMenu="False" ShowFilterRowMenuLikeItem="False" ShowInFilterControl="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tricel N°" FieldName="TriId" VisibleIndex="4" Width="5%">
                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False" AllowFilterBySearchPanel="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" ShowFilterRowMenu="False" ShowFilterRowMenuLikeItem="False" ShowInFilterControl="False" />
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

            <asp:ObjectDataSource ID="ODSLISTADO" runat="server" SelectMethod="ObtenerListaTricelFuncional" TypeName="VCFramework.NegocioMySQL.ListaTricel">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="idTricel" Type="Int32" />
                    <asp:SessionParameter DefaultValue="0" Name="usuResponsable" SessionField="USU_ID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>

        <dx:ASPxLabel ID="lblIngresosEgresos" ClientInstanceName="lblIngresosEgresos" runat="server" Text="0|0" ClientVisible="false"></dx:ASPxLabel>
    </div>

</asp:Content>
