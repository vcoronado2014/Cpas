<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="controlVistaCalendario.ascx.cs" Inherits="VCFramework.SitioWeb.controles.controlVistaCalendario" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
    <link rel="stylesheet" href="../css/fullcalendar.css"/>
    <link rel="stylesheet" href="../css/fullcalendar.min.css"/>
<style>


	#calendar {
		max-width: 900px;
		margin: 0 auto;
	}

</style>
<script src="../js/moment.min.js"></script>
<script src="../js/fullcalendar.js"></script>
<script src="../js/es.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        var fechaActual = moment();
        //alert(fechaActual);
        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            defaultDate: fechaActual,
            editable: false,
            eventLimit: true, // allow "more" link when too many events
            events: {
                url: 'Calendario.ashx?usuId=' + lblUsuId.GetText(),
                error: function () {
                    $('#script-warning').show();
                }
            },
            loading: function (bool) {
                $('#loading').toggle(bool);
            }
        });

    });
</script>

    <dx:ASPxLabel ID="lblUsuId" runat="server" Text="" ClientInstanceName="lblUsuId" ClientVisible="False"></dx:ASPxLabel>

    <div id="calendar"></div>


