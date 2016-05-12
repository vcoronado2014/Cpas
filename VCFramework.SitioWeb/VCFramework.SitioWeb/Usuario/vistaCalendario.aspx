<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="vistaCalendario.aspx.cs" Inherits="VCFramework.SitioWeb.Usuario.vistaCalendario" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>


<%@ Register assembly="DevExpress.XtraScheduler.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%--    <link rel="stylesheet" href="../css/fullcalendar.print.css"/>--%>
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
        .panelUI {
            display: block;
            position: relative;
            background-color: #ffffff;
        }
        .panelUI > .heading {
            padding: .625rem 0;
            color: #ffffff;
            background-color: #1ba1e2;
            cursor: default;
            vertical-align: middle;
            z-index: 2;
            height: 2.625rem;
            box-shadow: -1px 6px 6px -6px rgba(0, 0, 0, 0.35);
            font: 500 1.125rem/1.1 "Segoe UI", "Open Sans", sans-serif, serif;
            -webkit-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }
        .panelUI > .heading, .panelUI > .content {
            display: block;
            position: relative;
            color: #1d1d1d;
        }
        .panelUI > .heading > .title {
            margin-left: .625rem;
            color:white;
        }
        .panelUI > .content {
            background-color: #e8f1f4;
            z-index: 1;
            font-size: 0.875rem;
        }
        .panelUI > .heading, .panelUI > .content {
            display: block;
            position: relative;
            color: #1d1d1d;
        }
        .padding10 {
            padding: 0.625rem;
        }
        /*.dxscToolbarContainer {display:none;}*/
        .dxscToolbarContainer {
            background: #e4e4e4;
            padding: 0;
            margin: 0;
        }
        .dxscToolbar {
            border: none;
            background: #e4e4e4;
            padding: 0;
        }
        table tr th, table tr td {
            color: #222222;
            font-size: 0.875rem;
            padding: 0.1rem 0.1rem;
            text-align: left;
        }
        #ctl00_ContentPlaceHolder1_ASPxScheduler1_viewVisibleIntervalBlock_innerContent{ visibility:hidden;width: 0px;}
        #ctl00_ContentPlaceHolder1_ASPxScheduler1_viewVisibleIntervalBlock_ctl00_mainCell{ visibility:hidden;width: 0px;}
        .dxscToolbar_Office2003Blue {
             padding: 0; 
        }
        /*.dxscLabelControlPair {visibility:hidden;}*/
        #ctl00_ContentPlaceHolder1_ASPxScheduler1_formBlock_AptFrmTemplateContainer_AppointmentForm_lblResource {visibility:hidden;}
        #ctl00_ContentPlaceHolder1_ASPxScheduler1_formBlock_AptFrmTemplateContainer_AppointmentForm_edtResource  {visibility:hidden;}
        #ctl00_ContentPlaceHolder1_ASPxScheduler1_formBlock_AptFrmTemplateContainer_AppointmentForm_chkReminder {visibility:hidden;}
        #ctl00_ContentPlaceHolder1_ASPxScheduler1_formBlock_AptFrmTemplateContainer_AppointmentForm_lblReminder{visibility:hidden;}
        #ctl00_ContentPlaceHolder1_ASPxScheduler1_formBlock_AptFrmTemplateContainer_AppointmentForm_cbReminder{visibility:hidden;}
        .dxscToolbar_Mulberry {
            border: none;
            background: #fafafa;
            padding: 0;
            margin:0;
            height: 0px;
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
        

    </script>
    <div class="row panel bg-titulo" style="margin:0.1em;">
        <span class="tituloContacto"><i class="foundicon-calendar padding-right-15"></i>Calendario Institucional</span>
    </div>



    <div class="row padding10" style="margin:5px;">

            <dxwschs:ASPxScheduler ID="ASPxScheduler1" ClientInstanceName="ASPxScheduler1" runat="server" ActiveViewType="Month" AppointmentDataSourceID="odsCalendario" ClientIDMode="AutoID" Start="2015-12-13" Theme="Mulberry" Font-Size="12px" OnAppointmentFormShowing="ASPxScheduler1_AppointmentFormShowing">
                <Storage>
                    <Appointments>
                        <Mappings AllDay="Borrado" AppointmentId="Id" Description="Descripcion" End="FechaTermino" Label="Etiqueta" Location="Ubicacion" Start="FechaInicio" Status="Status" Subject="Asunto" Type="Tipo" />
                        <statuses>
                            <dxwschs:AppointmentStatus DisplayName="Libre" MenuCaption="&amp;Free" Type="Free" />
                            <dxwschs:AppointmentStatus Color="99, 198, 76" DisplayName="Tentativa" MenuCaption="&amp;Tentative" Type="Tentative" />
                            <dxwschs:AppointmentStatus Color="217, 83, 83" DisplayName="Fuera de la Oficina" MenuCaption="&amp;Out Of Office" Type="OutOfOffice" />
                        </statuses>
                        <labels>
                            <dxwschs:AppointmentLabel Color="Window" DisplayName="Ninguno" MenuCaption="&amp;None" />
                            <dxwschs:AppointmentLabel Color="255, 194, 190" DisplayName="Importante" MenuCaption="&amp;Important" />
                            <dxwschs:AppointmentLabel Color="168, 213, 255" DisplayName="Negocios" MenuCaption="&amp;Business" />
                            <dxwschs:AppointmentLabel Color="193, 244, 156" DisplayName="Personal" MenuCaption="&amp;Personal" />
                            <dxwschs:AppointmentLabel Color="243, 228, 199" DisplayName="Votaciones" MenuCaption="&amp;Votation" />
                        </labels>
                    </Appointments>
                </Storage>
                <Views>
<DayView>
    <VisibleTime End="23:00:00" Start="08:00:00" />
    <TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
</DayView>

<WorkWeekView Enabled="False"><TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
</WorkWeekView>

                    <WeekView DisplayName="Sem." ShortDisplayName="Sem.">
                    </WeekView>
                    <TimelineView Enabled="False">
                    </TimelineView>
                    <FullWeekView DisplayName="Sem.">
                        <TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
                    </FullWeekView>
                </Views>

                <OptionsBehavior ShowCurrentTime="Always" ShowRemindersForm="False" />

                <OptionsForms AppointmentFormVisibility="FillControlArea" AppointmentFormTemplateUrl="~/controles/AppointmentForm.ascx" />

                <ResourceNavigator EnableResourceComboBox="False" />

            </dxwschs:ASPxScheduler>
            

            <asp:ObjectDataSource ID="odsCalendario" runat="server" SelectMethod="ObtenerCalendarioPorInstId" TypeName="VCFramework.NegocioMySQL.Calendario" DeleteMethod="EliminarEvento" InsertMethod="CrearEvento" UpdateMethod="UpdateEvento">
                <DeleteParameters>
                    <asp:Parameter Name="AppointmentId" Type="Int32" />
                    <asp:Parameter Name="Status" Type="Int32" />
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="Tipo" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="FechaInicio" Type="DateTime" />
                    <asp:Parameter Name="FechaTermino" Type="DateTime" />
                    <asp:Parameter Name="Status" Type="Int32" />
                    <asp:Parameter Name="Asunto" Type="String" />
                    <asp:Parameter Name="Ubicacion" Type="String" />
                    <asp:Parameter Name="Etiqueta" Type="Int32" />
                    <asp:Parameter Name="Tipo" Type="Int32" />
                    <asp:SessionParameter DefaultValue="0" Name="InstId" SessionField="INST_ID" Type="Int32" />
                    <asp:Parameter Name="Borrado" Type="Boolean" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="instId" SessionField="INST_ID" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="FechaInicio" Type="DateTime" />
                    <asp:Parameter Name="FechaTermino" Type="DateTime" />
                    <asp:Parameter Name="Status" Type="Int32" />
                    <asp:Parameter Name="Asunto" Type="String" />
                    <asp:Parameter Name="Ubicacion" Type="String" />
                    <asp:Parameter Name="Etiqueta" Type="Int32" />
                    <asp:Parameter Name="Tipo" Type="Int32" />
                    <asp:SessionParameter DefaultValue="0" Name="InstId" SessionField="INST_ID" Type="Int32" />
                    <asp:Parameter Name="Borrado" Type="Boolean" />
                </UpdateParameters>
            </asp:ObjectDataSource>

    </div>

</asp:Content>
