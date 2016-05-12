<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditorEncabezado.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.EditorEncabezado" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register src="../controles/vistaMensaje.ascx" tagname="vistaMensaje" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #ContentPlaceHolder1_pnlGeneral_pageTab_BinaryImage_DXImageContainer {
            height: 152px;
            width: 100%;
            line-height: 154px;
        }
        .sub{
                font: 500 1.3rem/1.1 "Segoe UI", "Open Sans", sans-serif, serif;
                padding-left:5%;
        }
        .hr {
            border: 0;
            height: 2px;
            background-color: #88b9e3;
        }
        #ContentPlaceHolder1_pnlGeneral_pageTab_txtSubtitulo{
            margin-left:10%;
            margin-top:2%;
            text-align: center;
        }
        #ContentPlaceHolder1_pnlGeneral_pageTab_txtTitulo{
            /*margin-left:10%;*/
            margin-top:2%;
            /*text-align: center;*/
        }
        .bg-aqua{background-color:aqua;}
        @media only screen and (max-width: 500px) {
            .tituloContacto {
                color: #0f69b4;
                padding: 0 0 5px;
                margin: 0 0 2px;
                font-size: 1.0em;
                padding-left: 5px;
            }
        }
    </style>
        <script src="../js/jquery-2.1.4.min.js"></script>

    <script src="../js/vendor/modernizr.js"></script>

    <script src="../js/foundation.min.js"></script>
    <script src="../js/foundation/foundation.accordion.js"></script>

    <script type="text/javascript">
        $(document).foundation();
        $(function(){

            // Bind the resize event. When the window size changes, update its corresponding


            $(window).resize(function(){
                $("#ContentPlaceHolder1_pnlGeneral_pageTab_BinaryImage_DXImageContainer").width("100%");
                $("#ContentPlaceHolder1_pnlGeneral_pageTab_BinaryImagenArt1_DXImageContainer").width("100%");
                $("#ContentPlaceHolder1_pnlGeneral_pageTab_BinaryImagenArt2_DXImageContainer").width("100%");
                $("#ContentPlaceHolder1_pnlGeneral_pageTab_BinaryImagenArt3_DXImageContainer").width("100%");
            });

            // Updates the info div immediately.

            //$(window).resize();

        });
    </script>
    <div class="row panel bg-titulo" style="margin:0.1em;">
        <span class="tituloContacto"><i class="foundicon-settings padding-right-15"></i>Editor de Contenido</span>
    </div>
    
    <dx:ASPxCallbackPanel ID="pnlGeneral" runat="server" Width="98%" ClientInstanceName="pnlGeneral" OnCallback="pnlGeneral_Callback" Paddings-PaddingLeft="2%">
<Paddings PaddingLeft="2%"></Paddings>
        <PanelCollection>
            <dx:PanelContent runat="server">
                <!-- imagen encabezado -->
                <div class="row">
                    <dx:ASPxPageControl ID="pageTab" runat="server" ActiveTabIndex="0" Width="100%" Theme="Mulberry1" OnActiveTabChanged="pageTab_ActiveTabChanged" >
                                <TabPages>
                                    <dx:TabPage Text="Encabezado y Contenido">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">

                                                <div class="medium-12 columns">
                                                    <h6 class="sub">Imagen de Encabezado
                            
                                                    </h6>
                                                    <hr class="hr" />
                                                    <p class="informativo">
                                                        Considere que la imagen a seleccionar debe ser proporcional al encabezado, por ejemplo una imagen de 700 pixeles de largo por 90 pixeles de alto. <small>Seleccione la imagen que desea como encabezado de su página.
                                                        </small>
                                                    </p>
                                                </div>
                                                <div class="medium-12 columns">
                                                    <dx:ASPxBinaryImage ID="BinaryImage" ClientInstanceName="ClientBinaryImage" Width="100%" Height="8%" ShowLoadingImage="true" LoadingImageUrl="~/Content/Loading.gif" runat="server" ImageSizeMode="FillAndCrop" OnCustomCallback="BinaryImage_CustomCallback">
                                                        <EmptyImage AlternateText="Seleccione Imagen" Width="100%">
                                                        </EmptyImage>
                                                        <%--<OpenDialogButtonImage Width="100%" />--%>
                                                        <EditingSettings Enabled="true" EmptyValueText="No hay imágen">
                                                            <UploadSettings>
                                                                <UploadValidationSettings MaxFileSize="4194304"></UploadValidationSettings>
                                                            </UploadSettings>
                                                        </EditingSettings>
                                                        <RootStyle Wrap="True">
                                                        </RootStyle>
                                                    </dx:ASPxBinaryImage>
                                                </div>
                                                <!-- subtitulo encabezado -->
                                                <div class="row">
                                                    <h6 class="sub">Títulos del Encabezado</h6>
                                                    <hr class="hr" />
                                                    <p class="informativo">
                                                        <small>Ingrese o modifique el texto del Titulo izquierdo y derecho del Encabezado.
                                                        </small>
                                                    </p>
                                                </div>
                                                <div class="row bg-datos bg-datos">
                                                    <div class="medium-6 columns left">
                                                        <dx:ASPxTextBox ID="txtTitulo" runat="server" Width="90%" Native="true" BackColor="#333333" ForeColor="White">
                                                            <ValidationSettings Display="None" ValidationGroup="Panel">
                                                                <RequiredField ErrorText="Título izquierdo requerido" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                    <div class="medium-6 columns label right round success">

                                                        <dx:ASPxTextBox ID="txtSubtitulo" runat="server" Width="80%" Native="true" Paddings-PaddingLeft="5%" BackColor="#5da423" ForeColor="White">
                                                            <Paddings PaddingLeft="5%"></Paddings>
                                                            <ValidationSettings Display="None" ValidationGroup="Panel">
                                                                <RequiredField ErrorText="Titulo derecho requerido" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>

                                                    </div>
                                                </div>

                                                <!-- articulos -->
                                                <div class="medium-12 columns">
                                                    <h6 class="sub">Articulos de la Página Principal
                            
                                                    </h6>
                                                    <hr class="hr" />
                                                    <p class="informativo">
                                                        <small>Puede editar 3 Artículos para su página por defecto
                                                        </small>
                                                    </p>
                                                </div>
                                                <div class="row">
                                                    <h6 class="sub">Articulo Número 1                           
                                                    </h6>
                                                    <div class="medium-4 columns bg-aqua">
                                                        <!-- imagen superior -->
                                                        <span>Seleccione imágen.</span>
                                                        <dx:ASPxBinaryImage ID="BinaryImagenArt1" ClientInstanceName="BinaryImagenArt1" Width="100%" ShowLoadingImage="true" LoadingImageUrl="~/Content/Loading.gif" runat="server" ImageSizeMode="FillAndCrop">
                                                            <EmptyImage AlternateText="Seleccione Imagen" Width="100%">
                                                            </EmptyImage>
                                                            <EditingSettings Enabled="true" EmptyValueText="No hay imágen">
                                                                <UploadSettings>
                                                                    <UploadValidationSettings MaxFileSize="4194304"></UploadValidationSettings>
                                                                </UploadSettings>
                                                            </EditingSettings>
                                                            <RootStyle Wrap="True">
                                                            </RootStyle>
                                                        </dx:ASPxBinaryImage>
                                                        <!-- titulo del primer articulo -->
                                                        <span>Ingrese Titulo.</span>
                                                        <dx:ASPxTextBox ID="txtTituloArt1" runat="server" Width="98%" Native="true" Paddings-PaddingLeft="5%">
                                                            <Paddings PaddingLeft="5%"></Paddings>
                                                            <ValidationSettings Display="None" ValidationGroup="Panel">
                                                                <RequiredField ErrorText="Titulo Articulo 1 Requerido" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                        <!-- contenido del primer articulo -->
                                                        <span>Ingrese Contenido</span>
                                                        <dx:ASPxMemo ID="memContenidoArt1" runat="server" Height="130px" Width="100%" Native="true" HorizontalAlign="Justify"></dx:ASPxMemo>
                                                    </div>
                                                    <h6 class="sub">Articulo Número 2                           
                                                    </h6>
                                                    <div class="medium-4 columns bg-aqua">
                                                        <!-- imagen superior -->
                                                        <span>Seleccione imágen.</span>
                                                        <dx:ASPxBinaryImage ID="BinaryImagenArt2" ClientInstanceName="BinaryImagenArt2" Width="100%" ShowLoadingImage="true" LoadingImageUrl="~/Content/Loading.gif" runat="server" ImageSizeMode="FillAndCrop">
                                                            <EmptyImage AlternateText="Seleccione Imagen" Width="100%">
                                                            </EmptyImage>
                                                            <EditingSettings Enabled="true" EmptyValueText="No hay imágen">
                                                                <UploadSettings>
                                                                    <UploadValidationSettings MaxFileSize="4194304"></UploadValidationSettings>
                                                                </UploadSettings>
                                                            </EditingSettings>
                                                            <RootStyle Wrap="True">
                                                            </RootStyle>
                                                        </dx:ASPxBinaryImage>
                                                        <!-- titulo del primer articulo -->
                                                        <span>Ingrese Titulo.</span>
                                                        <dx:ASPxTextBox ID="txtTituloArt2" runat="server" Width="98%" Native="true" Paddings-PaddingLeft="5%">
                                                            <Paddings PaddingLeft="5%"></Paddings>
                                                            <ValidationSettings Display="None" ValidationGroup="Panel">
                                                                <RequiredField ErrorText="Titulo Articulo 1 Requerido" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                        <!-- contenido del primer articulo -->
                                                        <span>Ingrese Contenido</span>
                                                        <dx:ASPxMemo ID="memContenidoArt2" runat="server" Height="130px" Width="100%" Native="true" HorizontalAlign="Justify"></dx:ASPxMemo>
                                                    </div>
                                                    <h6 class="sub">Articulo Número 3                           
                                                    </h6>
                                                    <div class="medium-4 columns bg-aqua">
                                                        <!-- imagen superior -->
                                                        <span>Seleccione imágen.</span>
                                                        <dx:ASPxBinaryImage ID="BinaryImagenArt3" ClientInstanceName="BinaryImagenArt3" Width="100%" ShowLoadingImage="true" LoadingImageUrl="~/Content/Loading.gif" runat="server" ImageSizeMode="FillAndCrop">
                                                            <EmptyImage AlternateText="Seleccione Imagen" Width="100%">
                                                            </EmptyImage>
                                                            <EditingSettings Enabled="true" EmptyValueText="No hay imágen">
                                                                <UploadSettings>
                                                                    <UploadValidationSettings MaxFileSize="4194304"></UploadValidationSettings>
                                                                </UploadSettings>
                                                            </EditingSettings>
                                                            <RootStyle Wrap="True">
                                                            </RootStyle>
                                                        </dx:ASPxBinaryImage>
                                                        <!-- titulo del primer articulo -->
                                                        <span>Ingrese Titulo.</span>
                                                        <dx:ASPxTextBox ID="txtTituloArt3" runat="server" Width="98%" Native="true" Paddings-PaddingLeft="5%">
                                                            <Paddings PaddingLeft="5%"></Paddings>
                                                            <ValidationSettings Display="None" ValidationGroup="Panel">
                                                                <RequiredField ErrorText="Titulo Articulo 1 Requerido" IsRequired="True" />
                                                            </ValidationSettings>
                                                        </dx:ASPxTextBox>
                                                        <!-- contenido del primer articulo -->
                                                        <span>Ingrese Contenido</span>
                                                        <dx:ASPxMemo ID="memContenidoArt3" runat="server" Height="130px" Width="100%" Native="true" HorizontalAlign="Justify"></dx:ASPxMemo>
                                                    </div>

                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Text="Configuraciones">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <!-- contenido configuraciones -->
                                                <div class="medium-12 columns">
                                                    <h6 class="sub">Configuraciones de envíos de Correos
                            
                                                    </h6>
                                                    <hr class="hr" />
                                                    <p class="informativo">
                                                        Usted puede configurar el envío de correos automáticos en esta página.
                                                    </p>
                                                </div>
                                                <div class="row panel">
                                                    <div class="medium-6 columns">
                                                        <dx:ASPxCheckBox ID="chkEnviaDocumentos" runat="server" Native="True" Text="¿Desea habilitar el envío de correo automático cuando se crea o se modifica un documento?"></dx:ASPxCheckBox>
                                                    </div>
                                                    <div class="medium-6 columns">
                                                        <dx:ASPxCheckBox ID="chkEnviaRendiciones" runat="server" Native="True" Text="¿Desea habilitar el envío de correo automático cuando se crea o se modifica una rendición?"></dx:ASPxCheckBox>
                                                    </div>
                                                    
                                                </div>
                                                <hr class="hr" />
                                                <div class="row panel">
                                                    <div class="medium-6 columns">
                                                        <dx:ASPxCheckBox ID="chkEnviaProyectos" runat="server" Native="True" Text="¿Desea habilitar el envío de correo automático cuando se crea o se modifica un proyecto?"></dx:ASPxCheckBox>
                                                    </div>
                                                    <div class="medium-6 columns">
                                                        <dx:ASPxCheckBox ID="chkEnviaEvento" runat="server" Native="True" Text="¿Desea habilitar el envío de correo automático cuando se crea o se modifica un evento del calendario.?"></dx:ASPxCheckBox>
                                                    </div>
                                                    
                                                </div>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                </TabPages>
                                <TabStyle Font-Italic="False" Font-Size="8pt">
                                </TabStyle>
                    </dx:ASPxPageControl>
                    <div class="row">
                        
                        <dx:ASPxValidationSummary ID="validationSummary" ClientInstanceName="validationSummary" RenderMode="Table" ValidationGroup="panel" runat="server" Width="100%" BackColor="Aqua">
                            <HeaderStyle BackColor="Aqua" />
                            <Border BorderStyle="None" />
                        </dx:ASPxValidationSummary>
                    </div>
                    <div class="row">
                        <uc1:vistaMensaje ID="vistaMensaje1" runat="server" />
                    </div>
                    <div class="row">
                        <dx:ASPxButton ID="btnGuardar" Native="true" AutoPostBack="false" CssClass="button right" runat="server" Text="Guardar" ValidationContainerID="panelPrincipal" ValidationGroup="panel" style="margin-right:2%;" >
                            <ClientSideEvents Click="function(s, e) {
                                if (ASPxClientEdit.ValidateGroup('Panel')){
                                    pnlGeneral.PerformCallback('guardar');
		                           

}


}" />
                        </dx:ASPxButton>
                    </div>
                    
                </div>


            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

       

      
</asp:Content>
