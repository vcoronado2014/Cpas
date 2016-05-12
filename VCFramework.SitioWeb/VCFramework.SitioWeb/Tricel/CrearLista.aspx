<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CrearLista.aspx.cs" Inherits="VCFramework.SitioWeb.Tricel.CrearLista" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            function ValidaExisteUsuario(idUsuario, control, s)
            {
                if (s.GetValue() != '0') {
                    var idPresidente = cmbPresidente.GetValue();
                    if (idPresidente == idUsuario && control != 'Presidente') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idVicePresidente = cmbVicepresidente.GetValue();
                    if (idVicePresidente == idUsuario && control != 'Vicepresidente') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idSecretario = cmbSecretario.GetValue();
                    if (idSecretario == idUsuario && control != 'Secretario') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idTesorero = cmbTesorero.GetValue();
                    if (idTesorero == idUsuario && control != 'Tesorero') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idOtro1 = cmbOtro1.GetValue();
                    if (idOtro1 == idUsuario && control != 'Otro1') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idOtro2 = cmbOtro2.GetValue();
                    if (idOtro2 == idUsuario && control != 'Otro2') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idOtro3 = cmbOtro3.GetValue();
                    if (idOtro3 == idUsuario && control != 'Otro3') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idOtro4 = cmbOtro4.GetValue();
                    if (idOtro4 == idUsuario && control != 'Otro4') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idOtro5 = cmbOtro5.GetValue();
                    if (idOtro5 == idUsuario && control != 'Otro5') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                    var idOtro6 = cmbOtro6.GetValue();
                    if (idOtro6 == idUsuario && control != 'Otro6') {
                        alert('El usuario ya se encuentra seleccionado, intente con otro.');
                        s.SetValue(0);
                        return;
                    }
                }
            }

            </script>
    <style type="text/css">
        .labelN {
            display: inline-block;
            font-family: "Helvetica Neue", Helvetica, Roboto, Arial, sans-serif;
            font-weight: normal;
            line-height: 1;
            margin-bottom: auto;
            position: relative;
            text-align: center;
            text-decoration: none;
            /* white-space: nowrap; */
            padding: 0.25rem 0.5rem 0.25rem;
            /* font-size: 0.6875rem; */
            background-color: #2ba6cb;
            color: #FFFFFF;
        }
        .labelN.success {
            background-color: #5da423;
            color: #FFFFFF;
        }
    </style>
    <dx:ASPxCallbackPanel ID="pnlGeneral" runat="server" ClientInstanceName="pnlGeneral" Width="100%" OnCallback="pnlGeneral_Callback">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <asp:HiddenField ID="hidId" runat="server" Value="0" />
                <div class="row panel bg-titulo" style="margin: 0.1em;">
                    <span class="tituloContacto"><i class="foundicon-tools padding-right-15 style3"></i>
                        <asp:Literal ID="litOperacion" runat="server"></asp:Literal>
                        Lista Tricel </span>
                    <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" CausesValidation="False" ClientInstanceName="btnEliminar" CssClass="button right" Native="True" Text="Eliminar" ClientVisible="False" Style="-webkit-appearance: none; -moz-appearance: none; border-radius: 0; border-style: solid; border-width: 0; cursor: pointer; font-family: Helvetica, Roboto, Arial, sans-serif; font-weight: normal; line-height: normal; margin: 0 0 1.25rem; position: relative; text-align: center; text-decoration: none; display: inline-block; padding: 1rem 2rem 1.0625rem 2rem; font-size: 1rem; background-color: #2ba6cb; border-color: #2285a2; color: #FFFFFF; transition: background-color 300ms ease-out;">
                        <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('eliminar|');
}" />
                    </dx:ASPxButton>
                </div>
                <div class="panel" id="panelPrincipal">
                    <div class="row">
                        <div class="medium-12 columns small-centered success labelN" style="padding:8px;">
                            <asp:Literal ID="litInfoTricel" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                1. Nombre de la Lista <small>requerido</small>
                                <dx:ASPxTextBox ID="txtNombreProyecto" runat="server" Native="true" ClientInstanceName="txtNombreProyecto" Width="100%">
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Nombre Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                2. Objetivo de la Lista <small>requerido</small>
                                <dx:ASPxMemo ID="memObjetivo" runat="server" Height="70px" Width="100%" Native="true">
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Objetivo Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxMemo>

                            </label>
                        </div>

                    </div>
                    <div class="row">
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
                    </div>
                    <div class="row">
                        <h4 class="small-12 columns subheader">Rango de Votaciones</h4>
                        <div class="name-field medium-6 columns">
                            <label>
                                Fecha Inicio <small>requerido</small>
                                <dx:ASPxDateEdit ID="dtFechainicio" runat="server" Width="100%" CssClass="dropdown">
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Fecha Inicio Requerida" />
                                    </ValidationSettings>

                                </dx:ASPxDateEdit>
                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                Fecha Término <small>requerido</small>
                                <dx:ASPxDateEdit ID="dtFechaTermino" runat="server" Width="100%" CssClass="dropdown">
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Fecha Término Requerida" />
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </label>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                1. Presidente <small>requerido</small>
                                <dx:ASPxComboBox ID="cmbPresidente" ClientInstanceName="cmbPresidente" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Presidente', s);
}" />
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Presidente Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                


                                

                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                2. Vicepresidente <small>requerido</small> 
                                <dx:ASPxComboBox ID="cmbVicepresidente" ClientInstanceName="cmbVicepresidente" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Vicepresidente', s);
}" />
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Vicepresidente Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>

                            </label>
                        </div>

                    </div>
                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                3. Secretario <small>requerido</small>
                                <dx:ASPxComboBox ID="cmbSecretario" ClientInstanceName="cmbSecretario" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Secretario', s);
}" />
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Secretario Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                


                                

                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                4. Tesorero <small>requerido</small> 
                                <dx:ASPxComboBox ID="cmbTesorero" ClientInstanceName="cmbTesorero" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Tesorero', s);
}" />
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Tesorero Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>

                            </label>
                        </div>

                    </div>

                    <!-- no obligados -->
                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                5. Otro 
                                <dx:ASPxComboBox ID="cmbOtro1" ClientInstanceName="cmbOtro1" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
<ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Otro1', s);
}" />
                                </dx:ASPxComboBox>





                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                6. Otro 
                                <dx:ASPxComboBox ID="cmbOtro2" ClientInstanceName="cmbOtro2" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                   <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Otro2', s);
}" />
                                </dx:ASPxComboBox>

                            </label>
                        </div>

                    </div>
                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                7. Otro 
                                <dx:ASPxComboBox ID="cmbOtro3" ClientInstanceName="cmbOtro3" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Otro3', s);
}" />
                                </dx:ASPxComboBox>





                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                8. Otro 
                                <dx:ASPxComboBox ID="cmbOtro4" ClientInstanceName="cmbOtro4" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Otro4', s);
}" />
                                </dx:ASPxComboBox>

                            </label>
                        </div>

                    </div>

                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                9. Otro 
                                <dx:ASPxComboBox ID="cmbOtro6" ClientInstanceName="cmOtro6" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Otro5', s);
}" />
                                </dx:ASPxComboBox>





                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                10. Otro 
                                <dx:ASPxComboBox ID="cmbOtro7" ClientInstanceName="cmbOtro7" Native="true" Width="100%" runat="server" ValueType="System.String" TextField="NombreCompleto" ValueField="Id" SelectedIndex="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	ValidaExisteUsuario(s.GetValue(), 'Otro6', s);
}" />
                                </dx:ASPxComboBox>

                            </label>
                        </div>

                    </div>
                </div>
<%--                <asp:ObjectDataSource ID="odsUsuarios" runat="server" SelectMethod="ListarUsuariosEnvoltorioLista" TypeName="VCFramework.SitioWeb.LogicLogin">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="instId" SessionField="INST_ID" Type="Int32" />
                        <asp:SessionParameter DefaultValue="0" Name="usuId" SessionField="USU_ID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>--%>
                <!-- MENSAJE -->
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
                    <dx:ASPxButton ID="btnLimpiar" ClientInstanceName="btnLimpiar" AutoPostBack="false" runat="server" Text="Limpiar" CssClass="button" Native="true" CausesValidation="False" ClientVisible="true" Style="-webkit-appearance: none; -moz-appearance: none; border-radius: 0; border-style: solid; border-width: 0; cursor: pointer; font-family: Helvetica, Roboto, Arial, sans-serif; font-weight: normal; line-height: normal; margin: 0 0 1.25rem; position: relative; text-align: center; text-decoration: none; display: inline-block; padding: 1rem 2rem 1.0625rem 2rem; font-size: 1rem; background-color: #2ba6cb; border-color: #2285a2; color: #FFFFFF; transition: background-color 300ms ease-out;">
                        <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('limpiar;');
}" />
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="btnGuardar" Native="true" AutoPostBack="false" CssClass="button right" runat="server" Text="Guardar" ValidationContainerID="panelPrincipal" ValidationGroup="panel" Style="-webkit-appearance: none; -moz-appearance: none; border-radius: 0; border-style: solid; border-width: 0; cursor: pointer; font-family: Helvetica, Roboto, Arial, sans-serif; font-weight: normal; line-height: normal; margin: 0 0 1.25rem; position: relative; text-align: center; text-decoration: none; display: inline-block; padding: 1rem 2rem 1.0625rem 2rem; font-size: 1rem; background-color: #2ba6cb; border-color: #2285a2; color: #FFFFFF; transition: background-color 300ms ease-out;">
                        <ClientSideEvents Click="function(s, e) {
                                if (ASPxClientEdit.ValidateGroup('panel')){

		     if (s.GetText() == 'Modificar')
                                    {
                                        pnlGeneral.PerformCallback('guardar|');
                                    }
                                    else
                                    {
                                        pnlGeneral.PerformCallback('insertar|');
                                    }

}


}" />
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="btnVolver" runat="server" CausesValidation="False" ClientInstanceName="btnLimpiar" CssClass="button warning" Native="True" Text="Volver" OnClick="btnVolver_Click" Style="-webkit-appearance: none; -moz-appearance: none; border-radius: 0; border-style: solid; border-width: 0; cursor: pointer; font-family: Helvetica, Roboto, Arial, sans-serif; font-weight: normal; line-height: normal; margin: 0 0 1.25rem; position: relative; text-align: center; text-decoration: none; display: inline-block; padding: 1rem 2rem 1.0625rem 2rem; font-size: 1rem; color: #FFFFFF; transition: background-color 300ms ease-out;">
                    </dx:ASPxButton>

                </div>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

</asp:Content>

