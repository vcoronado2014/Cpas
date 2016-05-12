<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SeleccionReporte.aspx.cs" Inherits="VCFramework.SitioWeb.Reportes.SeleccionReporte" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-2.1.4.min.js"></script>
    <script src="../js/vendor/modernizr.js"></script>

    <script src="../js/foundation.min.js"></script>
    <script src="../js/foundation/foundation.accordion.js"></script>

    <script type="text/javascript">
        
        function EnviarReporte()
        {
            var rpt = rdblReportes.GetValue();
            var fechaInicio = dtFechaInicio.GetText();
            var fechaTermino = dtFechaTermino.GetText();
            var tipo = 0;
            var url = "";
            var tipoMovimiento = 0;
            
            //validar y enviar
            if (rpt == 'Reporte de Actas')
            {
                tipo = 1;
                //url
                url = 'rptActasN.aspx?tipo=' + tipo + '&fecha_inicio=' + fechaInicio + '&fecha_termino=' + fechaTermino;
                window.open(url, '_blank', '', true);

            }
            if (rpt == 'Reporte de Rendiciones') {
                tipo = 2;
                tipoMovimiento = cmbTipoMovimiento.GetValue();
                //url
                url = 'rptActasN.aspx?tipo=' + tipo + '&fecha_inicio=' + fechaInicio + '&fecha_termino=' + fechaTermino + '&tipo_movimiento=' + tipoMovimiento;
                window.open(url, '_blank', '', true);

            }
            if (rpt == 'Reporte de Votaciones') {
                tipo = 3;
                //url
                url = 'rptActasN.aspx?tipo=' + tipo + '&fecha_inicio=' + fechaInicio + '&fecha_termino=' + fechaTermino;
                window.open(url, '_blank', '', true);

            }

        }
        $(document).foundation();

    </script>
    <style type="text/css">
        .margin_left_2{
            margin-left:2%;
        }

    </style>
    <div class="row panel bg-titulo" style="margin:0.1em;">
        <span class="tituloContacto"><i class="foundicon-tools padding-right-15"></i>Reportes</span>
        <dx:ASPxLabel ID="lblUsuId" ClientInstanceName="lblUsuId" ClientVisible="false" runat="server" Text="">
        </dx:ASPxLabel>
        <dx:ASPxLabel ID="lblInstId" ClientInstanceName="lblInstId" ClientVisible="false" runat="server" Text="">
        </dx:ASPxLabel>
    </div>

    <div class="row">
        <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" Width="100%" ClientInstanceName="pnlFiltros" OnCallback="ASPxCallbackPanel1_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <div class="row">
                        <div class="medium-12 columns">
                            <dx:ASPxRadioButtonList ID="rdblReportes" runat="server" Width="96%" RepeatColumns="1" CssClass="margin_left_2" ClientInstanceName="rdblReportes">
                                <RadioButtonStyle Wrap="True">
                                </RadioButtonStyle>
                                
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	pnlFiltros.PerformCallback(s.GetValue());
}" />
                                <Items>
                                    <dx:ListEditItem Text="Reporte de Actas" Value="Reporte de Actas" />
                                    <dx:ListEditItem Text="Reporte de Rendiciones" Value="Reporte de Rendiciones" />
                                    <dx:ListEditItem Text="Reporte de Votaciones" Value="Reporte de Votaciones" />
                                </Items>
                                <RootStyle CssClass="medium-12 columns">
                                </RootStyle>
                            </dx:ASPxRadioButtonList>
                        </div>


                    </div>


                    <div class="row panel" style="margin-left:2%;margin-right:2%;">
                        <div class="medium-2 columns">
                            <dx:ASPxLabel ID="lblFechaInicio" runat="server" Text="Fecha Inicio" ClientVisible="False"></dx:ASPxLabel>
                        </div>
                        <div class="medium-4 columns">
                            <dx:ASPxDateEdit ID="dtFechainicio" ClientInstanceName="dtFechaInicio" runat="server" Width="100%" CssClass="dropdown" ClientVisible="False">
                            </dx:ASPxDateEdit>
                        </div>
                        <div class="medium-2 columns">
                            <dx:ASPxLabel ID="lblFechaTermino" runat="server" Text="Fecha Termino" ClientVisible="False"></dx:ASPxLabel>
                        </div>
                        <div class="medium-4 columns" style="margin-bottom:10px">
                            <dx:ASPxDateEdit ID="dtFechaTermino" ClientInstanceName="dtFechaTermino" runat="server" Width="100%" CssClass="dropdown" ClientVisible="False">
                            </dx:ASPxDateEdit>
                        </div>
                        <div class="medium-2 columns">
                            <dx:ASPxLabel ID="lblTipoMovimiento" runat="server" Text="Tipo Movimiento" ClientVisible="False"></dx:ASPxLabel>
                        </div>
                        <div class="medium-4 columns">
                            <dx:ASPxComboBox ID="cmbTipoMovimiento" ClientInstanceName="cmbTipoMovimiento" runat="server" ValueType="System.String" ClientVisible="False" SelectedIndex="0" Width="100%">
                                <Items>
                                    <dx:ListEditItem Selected="True" Text="Todos" Value="0" />
                                    <dx:ListEditItem Text="Ingresos" Value="1" />
                                    <dx:ListEditItem Text="Egresos" Value="2" />
                                </Items>
                            </dx:ASPxComboBox>
                        </div>
                        <hr />
                        <!-- botonera -->
                        <div class="row">
                            <dx:ASPxButton ID="btnEnviar" ClientInstanceName="btnEnviar" AutoPostBack="False" runat="server" Text="Enviar" CssClass="button right" Native="true" CausesValidation="False" ClientVisible="true" Style="border: 0 solid #2285a2; -webkit-appearance: none; -moz-appearance: none; border-radius: 0; cursor: pointer; font-family: Helvetica, Roboto, Arial, sans-serif; font-weight: normal; line-height: normal; position: relative; text-align: center; text-decoration: none; display: inline-block; font-size: 1rem; background-color: #2ba6cb; color: #FFFFFF; transition: background-color 300ms ease-out; top: 0px; left: 0px;" Visible="False">
                                
                                <ClientSideEvents Click="function(s, e) {
	EnviarReporte();
}" />
                                
                            </dx:ASPxButton>
                        </div>
                    </div>

                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>

</asp:Content>
