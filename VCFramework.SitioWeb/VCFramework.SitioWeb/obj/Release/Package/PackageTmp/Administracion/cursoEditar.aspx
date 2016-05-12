<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cursoEditar.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.cursoEditar" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        /* nuevos estilos de las grillas */

    #ContentPlaceHolder1_pnlGeneral_grillaCursos_DXHeadersRow0 table {
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

    <dx:ASPxCallbackPanel ID="pnlGeneral" runat="server" ClientInstanceName="pnlGeneral" Width="100%" OnCallback="pnlGeneral_Callback">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <asp:HiddenField ID="hidId" runat="server" Value="0" />
                <div class="row panel bg-titulo" style="margin:0.1em;">
                    <span class="tituloContacto"><i class="foundicon-address-book padding-right-15 style3"></i>
                        <asp:Literal ID="litOperacion" runat="server"></asp:Literal>
                        Curso </span>
                    <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" CausesValidation="False" ClientInstanceName="btnEliminar" CssClass="button right" Native="True" Text="Eliminar" ClientVisible="False">
                        <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('eliminar;');
}" />
                        </dx:ASPxButton>
                </div>

                <div class="panel" id="panelPrincipal">
                    <!-- contenido -->
                    <div class="row">

                    </div>
                    <!-- contrtoles -->
                    <hr />
                    <div class="row panel">
                        <dx:ASPxLabel ID="litMensaje" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                    <div class="row">
                        
                        <dx:ASPxValidationSummary ID="validationSummary" ClientInstanceName="validationSummary" RenderMode="Table" ValidationGroup="panel" runat="server" Width="100%" BackColor="Aqua">
                            <HeaderStyle BackColor="Aqua" />
                            <Border BorderStyle="None" />
                        </dx:ASPxValidationSummary>
                    </div>
                    <div class="row">
                         <dx:ASPxButton ID="btnLimpiar" ClientInstanceName="btnLimpiar" AutoPostBack="false" runat="server" Text="Limpiar" CssClass="button" Native="true" CausesValidation="False" ClientVisible="true">
                            <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('limpiar;');
}" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnGuardar" Native="true" AutoPostBack="false" CssClass="button right" runat="server" Text="Guardar" ValidationContainerID="panelPrincipal" ValidationGroup="panel">
                            <ClientSideEvents Click="function(s, e) {
                                if (ASPxClientEdit.ValidateGroup('panel')){

		                            var instId = cmbInstitucion.GetValue();
       		                        var regId = cmbRegion.GetValue();
      		                        var comId = cmbComuna.GetValue();
                                    if (s.GetText() == 'Modificar')
                                    {
                                        pnlGeneral.PerformCallback('guardar;' + instId + ';' + regId + ';' + comId);
                                    }
                                    else
                                    {
                                        pnlGeneral.PerformCallback('insertar;' + instId + ';' + regId + ';' + comId);
                                    }

}


}" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnVolver" runat="server" CausesValidation="False" ClientInstanceName="btnLimpiar" CssClass="button warning" Native="True" Text="Volver" OnClick="btnVolver_Click">

                        </dx:ASPxButton>
                        
                    </div>

                </div>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

        <script src="../js/jquery-2.1.4.min.js"></script>
        
        <script src="../js/vendor/modernizr.js"></script>

        <script src="../js/foundation.min.js"></script>
        <script src="../js/foundation/foundation.equalizer.js"></script>


        <script src="../js/foundation/foundation.abide.js"></script>
        <script type="text/javascript">
            $(document).foundation('abide', 'reflow');
            $(document).ready(function () {
                

            });
            function Validate_Page()
            {
                var retorno = false;
                $('#form1').on('valid.fndtn.abide', function () {
                    // Handle the submission of the form
                    retorno = true;
                });
                return retorno;

            }
            </script>

</asp:Content>
