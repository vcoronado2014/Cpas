<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="VCFramework.SitioWeb._default" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register Src="~/controles/controlVistaDocumentos.ascx" TagPrefix="uc1" TagName="controlVistaDocumentos" %>
<%@ Register Src="~/controles/controlVistaRendiciones.ascx" TagPrefix="uc1" TagName="controlVistaRendiciones" %>



<%@ Register assembly="DevExpress.XtraScheduler.v15.2.Core, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>



<%@ Register src="controles/controlVistaDocumentosUsuario.ascx" tagname="controlVistaDocumentosUsuario" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/default.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/vendor/modernizr.js"></script>

    <script src="../js/foundation.min.js"></script>
    <script src="../js/foundation/foundation.equalizer.js"></script>
    <script src="../js/foundation/foundation.accordion.js"></script>
    
    <script src="../js/foundation/foundation.tooltip.js"></script>
    <script>
        $(document).foundation({
            equalizer: {
                // Specify if Equalizer should make elements equal height once they become stacked.
                equalize_on_stack: false,
                // Allow equalizer to resize hidden elements
                act_on_hidden_el: false
            }

        });
    </script>
    
    <dx:ASPxPanel ID="pnlOtros" runat="server" Width="100%" ClientVisible="False">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <div class="row" data-equalizer="foo">
                    <div class="medium-4 columns panelUI" data-equalizer-watch="foo">
                        <div class="heading">
                            <span class="title">Documentos de Asamblea</span><dx:ASPxHyperLink CssClass="right padding-right-15" ID="hlirDocumentos" runat="server" Text="Ir..." NavigateUrl="~/Usuario/vistaDocumentos.aspx" Font-Size="11pt" ForeColor="White">
                            </dx:ASPxHyperLink>
                        </div>
                        <div class="content padding10">

                            <uc1:controlVistaDocumentos ID="controlVistaDocumentos1" runat="server" />

                        </div>

                    </div>

                    <div class="medium-4 columns panelUI" data-equalizer-watch="foo">
                        <div class="heading">
                            <span class="title">Rendiciones</span><dx:ASPxHyperLink CssClass="right padding-right-15" ID="hlirRendiciones" runat="server" Text="Ir..." NavigateUrl="~/Usuario/vistaRendiciones.aspx" Font-Size="11pt" ForeColor="White">
                            </dx:ASPxHyperLink>
                        </div>
                        <div class="content padding10">
                            <uc1:controlVistaRendiciones runat="server" ID="controlVistaRendiciones" />
                        </div>

                    </div>
                    <div class="medium-4 columns panelUI" data-equalizer-watch="foo">
                        <div class="heading">
                            <span class="title">Documentos</span><dx:ASPxHyperLink CssClass="right padding-right-15" ID="ASPxHyperLink1" runat="server" Text="Ir..." NavigateUrl="~/Usuario/vistaDocumentosUsuario.aspx" Font-Size="11pt" ForeColor="White">
                            </dx:ASPxHyperLink>
                        </div>
                        <div class="content padding10">

                            <uc2:controlVistaDocumentosUsuario ID="controlVistaDocumentosUsuario1" runat="server" />

                        </div>

                    </div>

                </div>
                <div class="row">

                    <%--<uc1:controlVistaCalendario runat="server" ID="controlVistaCalendario" />--%>



                    <div class="medium-2 columns">&nbsp;</div>
                    <div class="medium-8 columns panelUI">
                        <div class="content padding10">
                            <div class="heading">
                                <span class="title">Calendario</span>
                            </div>
                            <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" ActiveViewType="Month" AppointmentDataSourceID="odsCalendario" ClientIDMode="AutoID" Font-Size="8pt" Start="2016-05-15" Theme="Mulberry1" Width="100%">
                                <Storage>
                                    <Appointments>
                                        <Mappings AppointmentId="Id" Description="Detalle" End="FechaTermino" Label="Etiqueta" Location="Ubicacion" Start="FechaInicio" Subject="Asunto" />
                                    </Appointments>
                                </Storage>
                                <Views>
                                    <DayView TimeScale="01:00:00">
                                        <VisibleTime End="22:00:00" Start="09:00:00" />
                                        <TimeRulers>
                                            <cc1:TimeRuler />
                                        </TimeRulers>
                                        <DayViewStyles ScrollAreaHeight="300px">
                                        </DayViewStyles>
                                    </DayView>
                                    <WorkWeekView Enabled="False">
                                        <WorkWeekViewStyles ScrollAreaHeight="300px">
                                        </WorkWeekViewStyles>
                                        <TimeRulers>
                                            <cc1:TimeRuler />
                                        </TimeRulers>
                                    </WorkWeekView>
                                    <WeekView ShortDisplayName="Sem.">
                                        <WeekViewStyles>
                                            <DateCellBody Height="60px">
                                            </DateCellBody>
                                        </WeekViewStyles>
                                    </WeekView>
                                    <MonthView>
                                        <MonthViewStyles>
                                            <DateCellBody Height="60px">
                                            </DateCellBody>
                                        </MonthViewStyles>
                                    </MonthView>
                                    <TimelineView Enabled="False" ShowMoreButtons="False">
                                    </TimelineView>
                                    <FullWeekView>
                                        <TimeRulers>
                                            <cc1:TimeRuler />
                                        </TimeRulers>
                                    </FullWeekView>
                                </Views>
                                <Styles>
                                    <Buttons Native="True">
                                    </Buttons>
                                    <ToolTipRoundedCorners>
                                        <Content BackColor="White">
                                            <Border BorderStyle="None" />
                                        </Content>
                                    </ToolTipRoundedCorners>
                                    <Toolbar BackColor="White">
                                    </Toolbar>
                                    <HorizontalResourceHeader BackColor="#CCFF66">
                                    </HorizontalResourceHeader>
                                    <Appointment BackColor="#CCFF33">
                                        <Border BorderStyle="None" BorderWidth="0px" BorderColor="#CCFF33" />
                                    </Appointment>
                                </Styles>
                                <OptionsCustomization AllowAppointmentCopy="None" AllowAppointmentCreate="None" AllowAppointmentDelete="None" AllowAppointmentDrag="None" AllowAppointmentDragBetweenResources="None" AllowAppointmentEdit="None" AllowAppointmentResize="None" AllowInplaceEditor="None" />
                                <OptionsToolTips ShowAppointmentDragToolTip="False" ShowAppointmentToolTip="False" ShowSelectionToolTip="False" />
                                <ResourceNavigator Visibility="Never" />
                            </dxwschs:ASPxScheduler>
                            <asp:ObjectDataSource ID="odsCalendario" runat="server" SelectMethod="ObtenerCalendarioPorInstId" TypeName="VCFramework.NegocioMySQL.Calendario">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="0" Name="instId" SessionField="INST_ID" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="medium-2 columns">&nbsp;</div>

                </div>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>   
     
    <div class="row">

        <asp:Repeater ID="rptProyectos" runat="server" Visible="false">
            <ItemTemplate>
                <ul class='<%# Eval("Clase", "{0}")%>'>

                    <li class='<%# Eval("ClaseTitulo", "{0}")%>'><%# Eval("Nombre", "{0}")%></li>
                    <%--<li class="price"><%# String.Format("{0:C}", Eval("Costo") ) %></li>--%>
                    <li class='<%# Eval("ClasePrecio", "{0}")%>'><%# Eval("CostoStr", "{0}")%></li>
                    <li class="description"><%# Eval("Objetivo", "{0}")%></li>
                    <li class="bullet-item"><%# Eval("Descripcion", "{0}")%></li>
                    <li class="bullet-item"><%# Eval("Beneficios", "{0}")%></li>
                    <%--<span class="secondary label">Secondary Label</span>--%>
                    <li class="bullet-item"><%# Eval("FechaInicio", "{0}")%> -- <%# Eval("FechaTermino", "{0}")%></li>
                    <li class='<%# Eval("InfoLista", "{0}")%>'><span class="alert label">Cantidad Votos: <%# Eval("CantidadVotos", "{0}")%></span><span class='<%# Eval("EsMiVoto", "{0}")%>'>Ya voté</span> </li>
                    <li class="cta-button"><a class="button" href='<%# Eval("UrlVotar", "{0}")%>'>Votar</a></li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>

    </div>

    <div class="row">
        <asp:Repeater ID="rptArticulos" runat="server">
            <ItemTemplate>
                <div class="medium-4 columns">
                    <%--<asp:Image ID="imgPrincipal" ImageUrl='<%# Eval("UrlImagen", "{0}")%>' runat="server" CssClass="small-centered img-Center"  />--%>
                    <dx:ASPxImage ID="imgPrincipal" ImageUrl='<%# Eval("UrlImagen", "{0}")%>'  runat="server" ShowLoadingImage="true" CssClass="small-centered img-Center"></dx:ASPxImage>
                    <h4 class="text-center"><%# Eval("Titulo", "{0}")%></h4>
                    <p class="text-justify padding10"><%# Eval("Contenido", "{0}")%></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <dx:ASPxPanel ID="pnlNuestrasFuncionalidades" runat="server" Width="100%" ClientVisible="false">
        <PanelCollection>
<dx:PanelContent runat="server">
    <div class="row">
        <div class="medium-12 columns">
            <div class="panel">
                <h4 class="text-center">NUESTRAS FUNCIONALIDADES</h4>
                <div class="row">
                    <div class="medium-3 columns">
                        <img alt="funcionalidades" src="img/funcionalidades.jpg" />
                    </div>
                    <div class="medium-9 columns">
                        <ol>
                            <li>Gestión  de perfiles y roles de la plataforma de gestión CPAs.</li>
                            <li>Carga masiva de usuarios (padres y apoderados).</li>
                            <li>Calendario de cronograma de actividades del CPAs y de los establecimientos.</li>
                            <li>Gestión  documental (actas y documentos).</li>
                            <li>CPAs al ser una plataforma multi-dispositivo,  permite adjuntar, renombrar y eliminar imágenes (boletas,  facturas o relacionados desde su celular).</li>
                            <li>Módulo de notificaciones masivas para los usuarios inscritos del establecimiento con foco comunicacional y de recordatorios (relacionados con el cronograma de actividades del CPAs).</li>
                            <li>Módulo de gestión del TRICEL y votación on-line para el proceso de elecciones del CPAs.</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
    </div>

</dx:PanelContent>
</PanelCollection>
    </dx:ASPxPanel>


    <div class="row">
        <div class="medium-12 columns">

            <div class="panel">
                <h4>¿Quiere saber más?</h4>

                <div class="row">
                    <div class="medium-9 columns">
                        <p>¡No dude en contactarnos y de forma inmediata nos comunicaremos con Usted.!</p>
                    </div>
                    <div class="medium-3 columns">
                        <a href="Contacto.aspx" class="radius button right">Contáctenos</a>
                    </div>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
