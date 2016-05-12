<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VotarProyecto.aspx.cs" Inherits="VCFramework.SitioWeb.Proyectos.VotarProyecto" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../css/chartist.min.css"/>
        <style type="text/css">
            .ct-series-a .ct-area, .ct-series-a .ct-slice-pie {
                fill: blue;
            }

            .ct-series-b .ct-area, .ct-series-b .ct-slice-pie {
                fill: red;
            }

            .pie-egresos {
                fill: red;
            }

            .pie-ingresos {
                fill: blue;
            }

            .ct-label {
                fill: white;
                color: white;
                font-size: 0.9em;
                line-height: 1;
            }

            @media only screen and (min-width: 1024px) {
                .ct-label {
                    font-size: 0.6em;
                }
            }
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
        .label.info {
            background-color: #a0d3e8;
            color: #333333;
            width: 100%;
            font-size: 1.3em;
            padding:0.2em;
        }
        .dxeCheckBoxList .dxe > table, .dxeRadioButtonList .dxe > table {
            width: 100%;
            background: transparent;
        }
        .dxeBase {
            font: 12px Tahoma, Geneva, sans-serif;
            background: transparent;
            border: none;
        }
    </style>
    
        <script src="../js/jquery-2.1.4.min.js"></script>
        
        <script src="../js/vendor/modernizr.js"></script>

        <script src="../js/foundation.min.js"></script>
        <script src="../js/foundation/foundation.equalizer.js"></script>


        <script src="../js/foundation/foundation.abide.js"></script>


    <script src="../js/vendor/all.js"></script>
    <script type="text/javascript">
        $(document).foundation();
        function ActualizaGraficoS(parametro) {
            

            var param = parametro;
            var params = param.split('|');
            var ingr = params[0];
            var egr = params[1];

            var data = '';
            if (parseInt(ingr) > 0 && parseInt(egr) > 0) {
                data = {
                    series: [{
                        value: egr,
                        name: 'No',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }, {
                        value: ingr,
                        name: 'Si',
                        className: 'pie-ingresos',
                        meta: 'Meta Two'
                    }]
                };
            }
            if (parseInt(ingr) > 0 && parseInt(egr) == 0) {
                data = {
                    series: [{
                        value: ingr,
                        name: 'Si',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }]
                };
            }
            if (parseInt(ingr) == 0 && parseInt(egr) > 0) {
                data = {
                    series: [{
                        value: egr,
                        name: 'No',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }]
                };
            }
            var sum = function (a) {
                var total = 0;
                var porc = 0;
                if (a > 0) {
                    if (data.series[1] != null) {
                        total = parseInt(data.series[0].value) + parseInt(data.series[1].value);
                    }
                    else
                        total = parseInt(data.series[0].value);

                    porc = (parseInt(a) * 100) / total;
                }
                return porc;
            };
            new Chartist.Pie('.ct-chart', data,
            {
                labelInterpolationFnc: function (value, indice) {
                    var nombre = data.series[indice].name;
                    var porc = Math.round(sum(value)) + '%';
                    var str = "(" + porc + ")";
                    return str;
                }
            }
            );
        }
        function ActualizaGrafico(valorN)
        {
            var sumar = false;
            if (valorN == 1)
                sumar = true;

            var param = lblIngresosEgresos.GetText();
            var params = param.split('|');
            var ingr = params[0];
            var egr = params[1];

            if (sumar)
            {
                ingr = parseInt(ingr) + 1;
            }
            else
            {
                if (parseInt(egr) > 0)
                {
                    egr = parseInt(egr) - 1;
                }
            }
            
            var data = '';
            if (parseInt(ingr) > 0 && parseInt(egr) > 0) {
                data = {
                    series: [{
                        value: egr,
                        name: 'No',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }, {
                        value: ingr,
                        name: 'Si',
                        className: 'pie-ingresos',
                        meta: 'Meta Two'
                    }]
                };
            }
            if (parseInt(ingr) > 0 && parseInt(egr) == 0) {
                data = {
                    series: [{
                        value: ingr,
                        name: 'Si',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }]
                };
            }
            if (parseInt(ingr) == 0 && parseInt(egr) > 0) {
                data = {
                    series: [{
                        value: egr,
                        name: 'No',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }]
                };
            }
            var sum = function (a) {
                var total = 0;
                var porc = 0;
                if (a > 0) {
                    if (data.series[1] != null) {
                        total = parseInt(data.series[0].value) + parseInt(data.series[1].value);
                    }
                    else
                        total = parseInt(data.series[0].value);

                    porc = (parseInt(a) * 100) / total;
                }
                return porc;
            };
            new Chartist.Pie('.ct-chart', data,
            {
                labelInterpolationFnc: function (value, indice) {
                    var nombre = data.series[indice].name;
                    var porc = Math.round(sum(value)) + '%';
                    var str = value + " (" + porc + ")";
                    return str;
                }
            }
            );
        }
        $(document).ready(function () {
            var param = lblIngresosEgresos.GetText();
            var params = param.split('|');
            var ingr = params[0];
            var egr = params[1];
            var data = '';
            if (parseInt(ingr) > 0 && parseInt(egr) > 0)
            {
                data = {
                    series: [{
                        value: egr,
                        name: 'No',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }, {
                        value: ingr,
                        name: 'Si',
                        className: 'pie-ingresos',
                        meta: 'Meta Two'
                    }]
                };
            }
            if (parseInt(ingr) > 0 && parseInt(egr) == 0) {
                data = {
                    series: [{
                        value: ingr,
                        name: 'Si',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }]
                };
            }
            if (parseInt(ingr) == 0 && parseInt(egr) > 0) {
                data = {
                    series: [{
                        value: egr,
                        name: 'No',
                        className: 'pie-egresos',
                        meta: 'Meta One'
                    }]
                };
            }

            var sum = function (a) {
                var total = 0;
                var porc = 0;
                if (a > 0) {

                    if (data.series[1] != null) {
                        total = parseInt(data.series[0].value) + parseInt(data.series[1].value);
                    }
                    else
                        total = parseInt(data.series[0].value);
                    porc = (parseInt(a) * 100) / total;
                }
                return porc;
            };
            new Chartist.Pie('.ct-chart', data,
            {
                labelInterpolationFnc: function (value, indice) {
                    var nombre = data.series[indice].name;
                    var porc = Math.round(sum(value)) + '%';
                    var str = "(" + porc + ")";
                    return str;
                }
            }
                );

        });
        

    </script>
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    <div class="row panel bg-titulo" style="margin: 0.1em;">
        <span class="tituloContacto"><i class="foundicon-checkmark padding-right-15 style3"></i>
            <asp:Literal ID="litOperacion" runat="server"></asp:Literal>
            Votación Proyecto </span>

    </div>
    <div class="" id="panelPrincipal">
        <!-- columena izquierda -->
        <div class="medium-8 columns panel">
            <ul class="pricing-table">
                         
                            <li class="title"><dx:ASPxLabel ID="lblNombreProyecto" runat="server" Text="" CssClass="title"></dx:ASPxLabel></li>
                            <li class="price">&nbsp;<dx:ASPxLabel ID="lblMonto" runat="server" Text="" CssClass="price"></dx:ASPxLabel></li>
                            <li class="description"><dx:ASPxLabel ID="lblDescripcion" runat="server" Text="" CssClass="text-justify"></dx:ASPxLabel></li>
                            <li class="bullet-item">Fecha Creación: <dx:ASPxLabel ID="lblFechaMovimiento" runat="server" Text=""></dx:ASPxLabel></li>
                            <li class="bullet-item">Usuario Creador: <dx:ASPxLabel ID="lblUsuario" runat="server" Text=""></dx:ASPxLabel></li>
                            <li class="bullet-item"><dx:ASPxLabel ID="lblFechaInicio" runat="server" Text=""></dx:ASPxLabel> -- <dx:ASPxLabel ID="lblFechaTermino" runat="server" Text=""></dx:ASPxLabel></li>
                            <li class="bullet-item">
                                <dx:ASPxGridView ID="grillaDocumentos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSLISTADO" Width="100%" ClientInstanceName="grid">
                                    <Settings ShowFilterRow="True" ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False" ShowInCustomizationForm="True">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="RutaArchivo" VisibleIndex="2" ShowInCustomizationForm="True" Width="50%">
                                            <Settings AllowAutoFilter="False" AllowFilterBySearchPanel="False" AllowHeaderFilter="False" AutoFilterCondition="Contains" />
                                            <CellStyle Wrap="True">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ProId" VisibleIndex="3" ShowInCustomizationForm="True" Width="10%" Visible="false">
                                            <Settings AllowAutoFilter="False" AllowFilterBySearchPanel="False" AllowHeaderFilter="False" AutoFilterCondition="Contains" />
                                            <CellStyle Wrap="True">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="0" Width="10%">
                                            <DataItemTemplate>
                                                <asp:HyperLink ID="hlInicio" runat="server" CssClass="item" NavigateUrl='<%# Eval("RutaArchivo", "{0}")%>'>
                                            <span data-tooltip aria-haspopup="true" class="has-tip" title="Descargar">
                                            <i class="foundicon-down-arrow" ></i></span>
                                                </asp:HyperLink>
                                            </DataItemTemplate>
                                        </dx:GridViewDataTextColumn>


                                    </Columns>
                                    <Styles>
                                        <Header BackColor="#D8D8D8" Font-Bold="True" ForeColor="#222222" Wrap="True">
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
                                        </HeaderFilterItem>
                                    </Styles>
                                    <Border BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px" />
                                </dx:ASPxGridView>

                                <asp:ObjectDataSource ID="ODSLISTADO" runat="server" SelectMethod="ObtenerArchivosPorProyectoId" TypeName="VCFramework.NegocioMySQL.ArchivosProyecto">
                                    <SelectParameters>
                                        <asp:QueryStringParameter DefaultValue="0" Name="proId" QueryStringField="Pro_id" Type="Int32" />
                                        <asp:SessionParameter DefaultValue="" Name="listaSesion" SessionField="LISTA_SESION" Type="Object" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </li>
                            <%--<li class="cta-button"><a class="button" href='<%# Eval("UrlVotar", "{0}")%>'>Votar</a></li>--%>
                            <dx:ASPxLabel ID="lblInstitucion" runat="server" Text="" ClientVisible="false"></dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblObjetivo" runat="server" Text="" ClientVisible="false"></dx:ASPxLabel>
                            <dx:ASPxLabel ID="lblBeneficios" runat="server" Text="" ClientVisible="false"></dx:ASPxLabel>

            </ul>
        </div>
        <!-- columena derecha -->
        <div class="medium-4 columns panel">
            <dx:ASPxCallbackPanel ID="pnlVotaciones" runat="server" Width="100%" ClientInstanceName="pnlVotaciones" OnCallback="pnlVotaciones_Callback">
                <ClientSideEvents EndCallback="function(s, e) {
	var valores = lblIngresosEgresos.GetText();
                    ActualizaGraficoS(valores);
}" />
                <PanelCollection>
                    <dx:PanelContent runat="server">
                        <dx:ASPxLabel ID="lblIngresosEgresos" ClientInstanceName="lblIngresosEgresos" runat="server" Text="0|0" ClientVisible="false"></dx:ASPxLabel>
                        <div class="row">
                            <fieldset>
                                <legend>Gráfico
                                </legend>
                                <div class="large-12 columns panel callout">
                                    <div class="chart">
                                        <div class="ct-chart ct-golden-section ct-negative-labels">
                                        </div>

                                    </div>
                                </div>
                                <div class="medium-6 columns">
                                    <label style="background-color:blue; color:white; text-align:center;">SI</label>
                                </div>
                                <div class="medium-6 columns">
                                    <label style="background-color:red; color:white; text-align:center;">NO</label>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row">
                            <fieldset>
                                <legend>Mi Votación</legend>
                                <div class="row">
                                    <dx:ASPxLabel ID="lblYaVoto" runat="server" Text="" Font-Bold="True" Font-Size="12pt"></dx:ASPxLabel>
                                </div>
                                <div class="row">
                                    <dx:ASPxRadioButtonList ID="rdlVoto" runat="server" ValueType="System.String" Native="True" RepeatDirection="Horizontal" Width="100%" ClientInstanceName="rdlVoto" BackColor="Transparent">
                                        <RadioButtonStyle BackColor="Transparent">
                                            <Border BorderStyle="None" />
                                        </RadioButtonStyle>
                                        <Paddings PaddingTop="10px" />
                                        <Items>
                                            <dx:ListEditItem Text="Si" Value="1" />
                                            <dx:ListEditItem Text="No" Value="0" />
                                        </Items>
                                        <RootStyle BackColor="Transparent">
                                            <Border BorderStyle="None" />
                                        </RootStyle>
                                        <Border BorderStyle="None" />
                                    </dx:ASPxRadioButtonList>
                                </div>
                                <div class="row" style="margin-top:5px; padding-top:5px;">
                                    <dx:ASPxButton ID="btnVotar" runat="server" AutoPostBack="False" CausesValidation="False" ClientInstanceName="btnVotar" CssClass="button right warning" Native="True" Text="Votar" Style="-webkit-appearance: none; -moz-appearance: none; border-radius: 0; border-style: solid; border-width: 0; cursor: pointer; font-family: Helvetica, Roboto, Arial, sans-serif; font-weight: normal; line-height: normal; margin: 0 0 1.25rem; position: relative; text-align: center; text-decoration: none; display: inline-block; padding: 1rem 2rem 1.0625rem 2rem; font-size: 1rem;  border-color: #2285a2;  transition: background-color 300ms ease-out; padding-top:15px;" ClientEnabled="false">
                                        <ClientSideEvents Click="function(s, e) {
                                            if (confirm('¿Está seguro de votar?')){
                                            var valor = rdlVoto.GetValue();


    //ActualizaGrafico(valor);
                                            	pnlVotaciones.PerformCallback('votar|' + valor);
                                            }
}" />
                                    </dx:ASPxButton>
                                </div>
                            </fieldset>
                        </div>

                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>

        </div>

    </div>
</asp:Content>
