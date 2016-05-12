<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoCursos.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.ListadoCursos" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
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
    <script src="../js/vendor/modernizr.js"></script>

    <script src="../js/vendor/jquery.js"></script>
    <script src="../js/foundation.min.js"></script>
    <script src="../js/foundation/foundation.equalizer.js"></script>
    <script src="../js/foundation/foundation.tooltip.js"></script>
    <script>
        $(document).foundation();
    </script>
    <div class="row panel bg-titulo" style="margin:0.1em;">
        <span class="tituloContacto"><i class="foundicon-people padding-right-15"></i>  Administración de Cursos</span>
    </div>
    <div class="row">
        <div class="medium-12 columns">

            <div class="panel">
                <h4>¿Desea Agregar otro Curso?</h4>

                <div class="row">
                    <div class="medium-9 columns">
                        <p>Presione nuevo y será redirigido a la página de creación</p>
                    </div>
                    <div class="medium-3 columns">
                        <a href="cursoEditar.aspx?eliminar=false&editar=false&nuevo=true&id=0" class="radius button right">Nuevo</a>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="row">
        <div class="medium-12 columns">
            

                <dx:ASPxGridView ID="grillaUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="ODSLISTADO" Width="100%" ClientInstanceName="grid" Theme="Mulberry1">
                    <%--<Settings ShowVerticalScrollBar="true" VerticalScrollableHeight="0" />--%>
                    <Settings ShowFilterRow="True" ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False" ShowInCustomizationForm="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Grupo" VisibleIndex="2" ShowInCustomizationForm="True">
                            <Settings AllowAutoFilter="True" AllowFilterBySearchPanel="True" AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Nombre" VisibleIndex="3" ShowInCustomizationForm="True">
                            <Settings AllowAutoFilter="True" AllowFilterBySearchPanel="True" AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="0">
                            <DataItemTemplate>
                                <asp:HyperLink ID="hlInicio" runat="server" CssClass="item" NavigateUrl='<%# Eval("Id", "cursoEditar.aspx?editar=true&eliminar=false&nuevo=false&id={0}")%>'>
                                        <span data-tooltip aria-haspopup="true" class="has-tip" title="Editar">
                                        <i class="foundicon-edit" ></i></span>
                                </asp:HyperLink>
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="item" NavigateUrl='<%# Eval("Id", "cursoEditar.aspx?eliminar=true&editar=false&nuevo=false&id={0}")%>' data-tooltip aria-haspopup="true" class="has-tip" title="Eliminar">
                                        <i class="foundicon-trash"></i>
                                </asp:HyperLink>
                            </DataItemTemplate>
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

                <asp:ObjectDataSource ID="ODSLISTADO" runat="server" SelectMethod="ListarCursosPorInstId" TypeName="VCFramework.NegocioMySQL.Curso">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="instId" SessionField="INST_ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
        </div>
    </div>
    <script type="text/javascript">
        function OnInit(s, e) {
            AdjustSize();
        }
        function OnEndCallback(s, e) {
            AdjustSize();
        }
        function OnControlsInitialized(s, e) {
            ASPxClientUtils.AttachEventToElement(window, "resize", function(evt) {
                AdjustSize();
            });
        }
        function AdjustSize() {
            var height = Math.max(50, document.documentElement.clientHeight);
            grid.SetHeight(height);
        }
    </script>
</asp:Content>
