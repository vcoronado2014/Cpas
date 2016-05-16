<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Monitoreo.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.Monitoreo" %>
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
.dxgvGroupRow_Mulberry1 td.dxgv, .dxgvFocusedGroupRow_Mulberry1 td.dxgv {
    border: 0;
    border-bottom: 1px Solid #cbcbcb;
    vertical-align: middle;
    white-space: nowrap;
    padding: 5px 10px 6px;
    background-color: burlywood;
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

    <div class="row panel bg-titulo" style="margin: 0.1em;">
        <span class="tituloContacto"><i class="foundicon-page padding-right-15"></i>Monitoreo de accesos</span>
    </div>
    <div class="row">
        <div class="medium-12 columns">

            <div class="panel">
                <div class="row">
                    <div class="medium-10 columns">
                        <p>Esta página está diseñada para monitorear los movimientos de los usuarios respecto del acceso al Sistema.</p>
                    </div>
                    <div class="medium-2 columns">

                        <dx:ASPxButton ID="btnExportar" runat="server" OnClick="btnExportar_Click" Text="Exportar a Excel" Theme="Mulberry">
                        </dx:ASPxButton>

                    </div>

                </div>
            </div>
            <%--    <div class="row">
        <p class="informativo"><small><strong>Importante: </strong>Se permite aubir archivos con extensión Pdf, Word, Excel e imágenes que no superen los 4 MB en tamaño.</small></p>
    </div>--%>

        </div>
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" FileName="Monitoreo" GridViewID="grillaDocumentos" Landscape="True" PreserveGroupRowStates="True">
        </dx:ASPxGridViewExporter>
    </div>
<%--    <div class="row">
        <p class="informativo"><small><strong>Importante: </strong>Se permite aubir archivos con extensión Pdf, Word, Excel e imágenes que no superen los 4 MB en tamaño.</small></p>
    </div>--%>
    <div class="row">
                <div class="medium-12 columns">
            <dx:ASPxGridView ID="grillaDocumentos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSLISTADO" Width="100%" ClientInstanceName="grid" Theme="Mulberry1" KeyFieldName="NombreUsuario">
                <Settings ShowFilterRow="True" ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
                <SettingsText GroupPanel="Arrastre aquí para agrupar" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="NombreInstitucion" VisibleIndex="0">
                        <Settings AllowGroup="True" AllowHeaderFilter="False" GroupInterval="DisplayText" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NombreUsuario" VisibleIndex="1">
                        <Settings AllowGroup="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="NombreCompleto" VisibleIndex="2">
                        <Settings AllowAutoFilter="False" AllowGroup="False" AllowHeaderFilter="False" />
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="4" FieldName="Cantidad">
                        <Settings AllowAutoFilter="False" AllowGroup="False" AllowHeaderFilter="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="UltimaFechaLogin" VisibleIndex="5" Caption="Último Acceso">
                        <Settings AllowAutoFilter="False" AllowGroup="True" AllowHeaderFilter="True" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Rol" VisibleIndex="3">
                        <Settings AllowGroup="True" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Styles>

                    <Header Font-Bold="True" Wrap="True">
                        <Paddings Padding="1%" />
                        <BackgroundImage Repeat="NoRepeat" />
                    </Header>
                </Styles>
                <Border BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px" />
            </dx:ASPxGridView>

            <asp:ObjectDataSource ID="ODSLISTADO" runat="server" SelectMethod="ObtenerTodo" TypeName="VCFramework.NegocioMySQL.LoginUsuario">
            </asp:ObjectDataSource>

        </div>
    </div>
</asp:Content>
