<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CrearTricel.aspx.cs" Inherits="VCFramework.SitioWeb.Tricel.CrearTricel" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
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
     #ContentPlaceHolder1_pnlGeneral_grillaDocumentos_col3 table {
         border: none;
         background-color: #D8D8D8;
     }
     #ContentPlaceHolder1_pnlGeneral_grillaDocumentos_col1 table {
         border: none;
         background-color: #D8D8D8;
     }
    </style>
    
        <script src="../js/jquery-2.1.4.min.js"></script>
        
        <script src="../js/vendor/modernizr.js"></script>

        <script src="../js/foundation.min.js"></script>
        <script src="../js/foundation/foundation.equalizer.js"></script>


        <script src="../js/foundation/foundation.abide.js"></script>
        <script type="text/javascript">
            $(document).foundation();
            function onFileUploadComplete(s, e) {
                if (e.callbackData) {
                    var fileData = e.callbackData.split('|');
                    var fileName = fileData[0],
                        fileUrl = fileData[1],
                        fileSize = fileData[2];
                    //se completo la carga
                    pnlGeneral.PerformCallback('subir|' + fileName);
                    grid.PerformCallback('actualizar');
                }
            }
            function EliminarArchivo(id) {
                //alert(id);
                if (confirm('Esta seguro de eliminar este archivo?'))
                    grid.PerformCallback('eliminar|' + id);
            }
            </script>
    <dx:ASPxCallbackPanel ID="pnlGeneral" runat="server" ClientInstanceName="pnlGeneral" Width="100%" OnCallback="pnlGeneral_Callback">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <asp:HiddenField ID="hidId" runat="server" Value="0" />
                <div class="row panel bg-titulo" style="margin: 0.1em;">
                    <span class="tituloContacto"><i class="foundicon-tools padding-right-15 style3"></i>
                        <asp:Literal ID="litOperacion" runat="server"></asp:Literal>
                        Tricel </span>
                    <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" CausesValidation="False" ClientInstanceName="btnEliminar" CssClass="button right" Native="True" Text="Eliminar" ClientVisible="False" style="-webkit-appearance: none;-moz-appearance: none;border-radius: 0;border-style: solid;border-width: 0;cursor: pointer;font-family: Helvetica, Roboto, Arial, sans-serif;font-weight: normal;line-height: normal;margin: 0 0 1.25rem;position: relative;text-align: center;text-decoration: none;display: inline-block;padding: 1rem 2rem 1.0625rem 2rem;font-size: 1rem;background-color: #2ba6cb;border-color: #2285a2;color: #FFFFFF;transition: background-color 300ms ease-out;">
                        <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('eliminar|');
}" />
                    </dx:ASPxButton>
                </div>
                <div class="panel" id="panelPrincipal">
                    <div class="row">
                        <div class="name-field medium-3 columns">
                            <label>
                                Fecha 
                                <dx:ASPxLabel ID="lblFechaMovimiento" runat="server" Text="" ></dx:ASPxLabel>

                            </label>
                        </div>
                        <div class="name-field medium-3 columns">
                            <label>
                                Usuario 
                                <dx:ASPxLabel ID="lblUsuario" runat="server" Text=""></dx:ASPxLabel>
                            </label>

                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                Institución 
                                <dx:ASPxLabel ID="lblInstitucion" runat="server" Text=""></dx:ASPxLabel>
                            </label>

                        </div>

                    </div>
                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                1. Nombre del Tricel <small>requerido</small>
                                <dx:ASPxTextBox ID="txtNombreProyecto" runat="server" Native="true" ClientInstanceName="txtNombreProyecto" Width="100%">
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Nombre Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                2. Objetivo del Tricel <small>requerido</small> 
                                <dx:ASPxMemo ID="memObjetivo" runat="server" Height="70px" Width="100%" Native="true">
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Objetivo Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxMemo>

                            </label>
                        </div>

                    </div>
                    <%--<div class="row">
                        <div class="name-field medium-6 columns">
                        <label>
                            3. Descripción <small>requerido</small>
                            <dx:ASPxMemo ID="memDescripcion" runat="server" Height="70px" Width="100%" Native="true">
                                <ValidationSettings ValidationGroup="panel">
                                    <RequiredField IsRequired="True" ErrorText="Descripción Requerido" />
                                </ValidationSettings>
                            </dx:ASPxMemo>

                        </label>
                    </div>
                        <div class="name-field medium-6 columns">
                        <label>
                            4. Beneficios <small>requerido</small>
                            <dx:ASPxMemo ID="memBeneficios" runat="server" Height="70px" Width="100%" Native="true">
                                <ValidationSettings ValidationGroup="panel">
                                    <RequiredField IsRequired="True" ErrorText="Beneficios Requerido" />
                                </ValidationSettings>
                            </dx:ASPxMemo>

                        </label>
                    </div>
                    </div>--%>
                    
                    <div class="row">
                        <h4 class="small-12 columns subheader">Rango de Votaciones</h4>
                        <div class="name-field medium-4 columns">
                            <label>
                                Fecha Inicio <small>requerido</small>
                                <dx:ASPxDateEdit ID="dtFechainicio" runat="server" Width="100%" CssClass="dropdown" >
                                    <ValidationSettings ValidationGroup="panel">
                                    <RequiredField IsRequired="True" ErrorText="Fecha Inicio Requerida" />
                                </ValidationSettings>

                                </dx:ASPxDateEdit>
                            </label>
                        </div>
                        <div class="name-field medium-4 columns">
                            <label>
                                Fecha Término <small>requerido</small>
                                <dx:ASPxDateEdit ID="dtFechaTermino" runat="server" Width="100%" CssClass="dropdown">
                                        <ValidationSettings ValidationGroup="panel">
                                    <RequiredField IsRequired="True" ErrorText="Fecha Término Requerida" />
                                </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </label>
                        </div>
                        <div class="name-field medium-4 columns">
                            <label>
                                Agregar Responsables <small>requerido</small>
                                <dx:ASPxTokenBox ID="txtResponsables" ClientInstanceName="txtResponsables" runat="server" ItemValueType="System.String" Width="100%" Theme="Mulberry" NullText="Seleccione" DataSourceID="odsUsuarios" TextField="NombreCompleto" ValueField="Id" IncrementalFilteringMode="None">
                                    <ValidationSettings ValidationGroup="panel">
                                    <RequiredField IsRequired="True" ErrorText="Debe agregar responsables del Tricel." />
                                </ValidationSettings>
                            </dx:ASPxTokenBox>
                            <asp:ObjectDataSource ID="odsUsuarios" runat="server" SelectMethod="ListarUsuariosEnvoltorioConRol" TypeName="VCFramework.SitioWeb.LogicLogin">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="0" Name="instId" SessionField="INST_ID" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            </label>
                        </div>
                   
                    </div>
                </div>

                    <div class ="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                Subir Archivo 
                                <dx:ASPxUploadControl ID="upload" ClientInstanceName="upload" runat="server" UploadMode="Auto" Width="100%" ShowProgressPanel="True" ShowUploadButton="True" OnFileUploadComplete="upload_FileUploadComplete">
                                    <UploadButton Text="Subir">
                                    </UploadButton>
                                    <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .gif, .png, .doc, .docx, .xls, .xlsx, .pdf" MaxFileSize="4194304" MaxFileSizeErrorText="El archivo Excede el tamaño permitido {0} bytes">
                                    </ValidationSettings>
                                    <ClientSideEvents FileUploadComplete="onFileUploadComplete" />
                                </dx:ASPxUploadControl>
                                <span>Archivo subido: 
                                    <dx:ASPxLabel ID="lblNombreArchivoSubido" ClientInstanceName="lblNombreArchivoSubido" runat="server" Text="" Font-Bold="True"></dx:ASPxLabel>
                                </span>
                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <h1 class="row subheader">Listado de Archivos</h1>
                            <dx:ASPxGridView ID="grillaDocumentos" runat="server" AutoGenerateColumns="False" DataSourceID="ODSLISTADO" Width="100%" ClientInstanceName="grid" OnCustomCallback="grillaDocumentos_CustomCallback" OnHtmlDataCellPrepared="grillaDocumentos_HtmlDataCellPrepared">
                                <Settings ShowFilterRow="True" ShowGroupButtons="False" ShowHeaderFilterBlankItems="False" />
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False" ShowInCustomizationForm="True">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="RutaArchivo" VisibleIndex="2" ShowInCustomizationForm="True" Width="50%">
                                        <Settings AllowAutoFilter="False" AllowFilterBySearchPanel="False" AllowHeaderFilter="False" AutoFilterCondition="Contains" />
                                        <CellStyle Wrap="True">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ProId" VisibleIndex="3" ShowInCustomizationForm="True" Width="10%" Visible ="false">
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

                                            <button class="item button small"
                                                onclick="EliminarArchivo('<%# Eval("Id", "{0}") %>');return false">
                                                <i class="foundicon-remove"></i>
                                            </button>
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

                            <asp:ObjectDataSource ID="ODSLISTADO" runat="server" SelectMethod="ObtenerArchivosPorTricelId" TypeName="VCFramework.NegocioMySQL.ArchivosTricel">
                                <SelectParameters>
                                    <asp:Parameter Name="triId" Type="Int32" />
                                    <asp:SessionParameter DefaultValue="" Name="listaSesion" SessionField="LISTA_SESION_TRI" Type="Object" />
                                </SelectParameters>
                            </asp:ObjectDataSource>

                        </div>

                    </div>
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
                        <dx:ASPxButton ID="btnLimpiar" ClientInstanceName="btnLimpiar" AutoPostBack="false" runat="server" Text="Limpiar" CssClass="button" Native="true" CausesValidation="False" ClientVisible="true" style="-webkit-appearance: none;-moz-appearance: none;border-radius: 0;border-style: solid;border-width: 0;cursor: pointer;font-family: Helvetica, Roboto, Arial, sans-serif;font-weight: normal;line-height: normal;margin: 0 0 1.25rem;position: relative;text-align: center;text-decoration: none;display: inline-block;padding: 1rem 2rem 1.0625rem 2rem;font-size: 1rem;background-color: #2ba6cb;border-color: #2285a2;color: #FFFFFF;transition: background-color 300ms ease-out;">
                            <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('limpiar;');
}" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnGuardar" Native="true" AutoPostBack="false" CssClass="button right" runat="server" Text="Guardar" ValidationContainerID="panelPrincipal" ValidationGroup="panel" style="-webkit-appearance: none;-moz-appearance: none;border-radius: 0;border-style: solid;border-width: 0;cursor: pointer;font-family: Helvetica, Roboto, Arial, sans-serif;font-weight: normal;line-height: normal;margin: 0 0 1.25rem;position: relative;text-align: center;text-decoration: none;display: inline-block;padding: 1rem 2rem 1.0625rem 2rem;font-size: 1rem;background-color: #2ba6cb;border-color: #2285a2;color: #FFFFFF;transition: background-color 300ms ease-out;">
                            <ClientSideEvents Click="function(s, e) {
                                if (ASPxClientEdit.ValidateGroup('panel')){

		     if (s.GetText() == 'Modificar')
                                    {
                                        pnlGeneral.PerformCallback('guardar|'+lblNombreArchivoSubido.GetText());
                                    }
                                    else
                                    {
                                        pnlGeneral.PerformCallback('insertar|'+lblNombreArchivoSubido.GetText());
                                    }

}


}" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btnVolver" runat="server" CausesValidation="False" ClientInstanceName="btnLimpiar" CssClass="button warning" Native="True" Text="Volver" OnClick="btnVolver_Click" style="-webkit-appearance: none;-moz-appearance: none;border-radius: 0;border-style: solid;border-width: 0;cursor: pointer;font-family: Helvetica, Roboto, Arial, sans-serif;font-weight: normal;line-height: normal;margin: 0 0 1.25rem;position: relative;text-align: center;text-decoration: none;display: inline-block;padding: 1rem 2rem 1.0625rem 2rem;font-size: 1rem;color: #FFFFFF;transition: background-color 300ms ease-out;">
                        </dx:ASPxButton>

                    </div>



            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

</asp:Content>
