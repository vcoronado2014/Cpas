<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.dashboard" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../css/chartist.min.css"/>
    <style type="text/css">

    .ct-series-a .ct-area, .ct-series-a .ct-slice-pie {
        fill: red;
    } 
    .ct-series-b .ct-area, .ct-series-b .ct-slice-pie {
        fill: blue;
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
        font-size: 1.05em;
        line-height: 1;
    }
    </style>
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/vendor/modernizr.js"></script>

    <script src="../js/foundation.min.js"></script>
    <script src="../js/foundation/foundation.accordion.js"></script>
    <script src="../js/vendor/all.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var param = lblIngresosEgresos.GetText();
            var params = param.split('|');
            var ingr = params[0];
            var egr = params[1];
            var data = {
                series: [{
                    value: egr,
                    name: 'Egresos',
                    className: 'pie-egresos',
                    meta: 'Meta One'
                }, {
                    value: ingr,
                    name: 'Ingresos',
                    className: 'pie-ingresos',
                    meta: 'Meta Two'
                }]
            };
            var sum = function (a) {
                var total = parseInt(data.series[0].value) + parseInt(data.series[1].value);
                var porc = (parseInt(a) * 100) / total;
                return porc;
            };
            new Chartist.Pie('.ct-chart', data,
            {
                labelInterpolationFnc: function (value, indice) {
                    var nombre = data.series[indice].name;
                    var porc = Math.round(sum(value)) + '%';
                    var str = nombre + ' $' + value + " (" + porc + ")";
                    return str;
                }
            }
                );

        });
        

    </script>

    <div class="row panel bg-titulo" style="margin: 0.1em;">
        <span class="tituloContacto"><i class="foundicon-graph"></i>Dashboard</span>
    </div>
    <div class="row">
        <div class="medium-12 columns">

            <div class="panel">
                <div class="row">
                    <div class="medium-12 columns">
                        <p>Esta página le muestra información gráfica de sus Ingresos/Egresos.</p>
                    </div>

                </div>
            </div>

        </div>
    </div>
    <div class="row">
        <div class="medium-12 columns">
            <div class="chart">
                <div class="ct-chart ct-golden-section ct-negative-labels">
                    
                </div>

            </div>

        </div>
    </div>
    <dx:ASPxLabel ID="lblIngresosEgresos" ClientInstanceName="lblIngresosEgresos" runat="server" Text="0|0" ClientVisible="false"></dx:ASPxLabel>

</asp:Content>
