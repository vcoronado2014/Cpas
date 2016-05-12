<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usuarioEditar.aspx.cs" Inherits="VCFramework.SitioWeb.Administracion.usuarioEditar" EnableEventValidation="false" %>
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
                        Usuario </span>
                    <dx:ASPxButton ID="btnEliminar" runat="server" AutoPostBack="False" CausesValidation="False" ClientInstanceName="btnEliminar" CssClass="button right" Native="True" Text="Eliminar" ClientVisible="False">
                        <ClientSideEvents Click="function(s, e) {
	pnlGeneral.PerformCallback('eliminar;');
}" />
                        </dx:ASPxButton>
                </div>
                <div class="panel" id="panelPrincipal">
                    <div class="row">
                        <div class="name-field medium-5 columns">
                            <label>
                                Institución <small>requerido</small>
                                <dx:ASPxComboBox ID="cmbInstitucion" runat="server" ValueType="System.String" Native="true" ClientInstanceName="cmbInstitucion" Width="100%" DataSourceID="odsInstituciones" TextField="Nombre" ValueField="Id" ></dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="odsInstituciones" runat="server" SelectMethod="ListarInstituciones" TypeName="VCFramework.NegocioMySQL.Institucion"></asp:ObjectDataSource>
                            </label>
                            <small class="error">Usuario es requerido.</small>
                        </div>
                        <div class="name-field medium-4 columns">
                            <label>
                                <%--<asp:TextBox ID="txtUsername" runat="server" required pattern="[a-zA-Z]+"></asp:TextBox>--%>
                                Nombre de Usuario <small>requerido</small>
                                
                            <dx:ASPxLabel ID="lblMensajeUsuario" runat="server" ForeColor="#CC0000">
                            </dx:ASPxLabel>

                                <dx:ASPxTextBox ID="txtUsername" runat="server" Width="100%" Native="true"  >
                                    <ClientSideEvents TextChanged="function(s, e) {
pnlGeneral.PerformCallback('usuario;' + s.GetText());
	
}" />
                                    <ValidationSettings ValidationGroup="panel">
                                        <RequiredField IsRequired="True" ErrorText="Usuario Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </label>
                            <%--<small class="error">Usuario es requerido.</small>--%>
                        </div>
                        <div class="name-field medium-3 columns">
                            <%--<small class="error">Rut es requerido.</small>--%>
                            <label>
                                Rut <small>requerido</small>
                                <%--<asp:TextBox ID="txtRut" runat="server" required></asp:TextBox>--%>
                                <dx:ASPxLabel ID="lblMensajeRut" runat="server" ForeColor="#CC0000">
                            </dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtRut" runat="server" Native="true" ClientInstanceName="txtRut" Width="100%" MaxLength="10" >
                                    <ClientSideEvents TextChanged="function(s, e) {
	pnlGeneral.PerformCallback('rut;' + s.GetText());
}" />
                                    <MaskSettings ErrorText="Formato Inválido" Mask="99999999-A" />
                                    <ValidationSettings ValidationGroup="panel" ValidateOnLeave="False">
                                       
                                        <RegularExpression ErrorText="Formato Rut inválido" ValidationExpression="\b\d{1,8}\-[K|k|0-9]" />
                                       
                                        <RequiredField IsRequired="True" ErrorText="Rut Requerido" />
                                    </ValidationSettings>
                                    
                                </dx:ASPxTextBox>
                            </label>
                        </div>
                    </div>
                    <div class="medium-12 columns">
                        <div class="name-field medium-4 columns">
                            <label>
                                Nombres <small>requerido</small>
                                <dx:ASPxTextBox ID="txtNombres" ClientInstanceName="txtNombres" Native="true" runat="server" Width="100%">
                                    
                                    <ValidationSettings ValidationGroup="panel">
                                       
                                        <RequiredField IsRequired="True" ErrorText="Nombre Requerido" />
                                    </ValidationSettings>
                            </dx:ASPxTextBox>

                            </label>
                            
                        </div>
                        <div class="name-field medium-4 columns">
                            <label>
                                Apellido Paterno <small>requerido</small>
                                <dx:ASPxTextBox ID="txtApellidoPaterno" runat="server" Native="true" ClientInstanceName="txtApellidoPaterno" Width="100%">
                                    <ValidationSettings ValidationGroup="panel">
                                       
                                        <RequiredField IsRequired="True" ErrorText="Apellido Paterno Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </label>
                            
                        </div>
                        <div class="name-field medium-4 columns">
                            <label>
                                Apellido Materno 
                                <asp:TextBox ID="txtApellidoMaterno" runat="server"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="name-field medium-4 columns">
                            <label>
                                Región <small>requerido</small>
                                <dx:ASPxComboBox ID="cmbRegion" ClientInstanceName="cmbRegion" Native="true" runat="server" ValueType="System.String"  DataSourceID="odsRegiones" TextField="Nombre" ValueField="Id" Width="100%">
                                    <ClientSideEvents ValueChanged="function(s, e) {
	var id = s.GetValue();
pnlComunas.PerformCallback(id);
}" />
                                    
                            </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="odsRegiones" runat="server" SelectMethod="ListarRegiones" TypeName="VCFramework.NegocioMySQL.Region"></asp:ObjectDataSource>

                            </label>
                            
                        </div>
                        <div class="name-field medium-4 columns">
                            <label>
                                Comuna <small>requerido
                        
                    &nbsp;</small>
                                <dx:ASPxCallbackPanel ID="pnlComunas" ClientInstanceName="pnlComunas" runat="server" Width="100%" OnCallback="pnlComunas_Callback" Theme="Metropolis">
                                    <SettingsLoadingPanel Text="Cargando Comunas...&amp;hellip;" />
                                    <PanelCollection>
                                        <dx:PanelContent runat="server">
                                            <%--<asp:DropDownList ID="cmbComuna" runat="server" required DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>--%>
                                            <dx:ASPxComboBox ID="cmbComuna" ClientInstanceName="cmbComuna" Native="true" TextField="Nombre" ValueField="Id" runat="server" ValueType="System.String" Width="100%">
                                               
                                            </dx:ASPxComboBox>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxCallbackPanel>

                            </label>
                            
                        </div>
                        <div class="name-field medium-4 columns">
                            <label>
                                Dirección 
                    <dx:ASPxTextBox ID="txtDireccion" runat="server" Native="true" ClientInstanceName="txtDireccion" Width="100%">
                                    <ValidationSettings ValidationGroup="panel">
                                       
                                        <RequiredField IsRequired="True" ErrorText="Dirección Requerida" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </label>
                            
                        </div>

                    </div>
                    <div class="row">
                        <div class="name-field medium-6 columns">
                            <label>
                                Teléfonos 
                                <dx:ASPxTextBox ID="txtTelefonos" runat="server" Native="true" ClientInstanceName="txtTelefono" Width="100%">
                                    
                                </dx:ASPxTextBox>
                            </label>
                        </div>
                        <div class="name-field medium-6 columns">
                            <label>
                                Correo Electrónico <small>requerido</small>
                                <dx:ASPxTextBox ID="txtCorreo" runat="server" Native="true" ClientInstanceName="txtCorreo" Width="100%">
                                    <ValidationSettings ValidationGroup="panel">
                                       
                                        <RegularExpression ErrorText="Formato de correo inválido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                       
                                        <RequiredField IsRequired="True" ErrorText="Correo Electrónico Requerido" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="name-field medium-4 columns">
                            <%--<div class="row">
                                <dx:ASPxCheckBox ID="chkActivo" CssClass="" runat="server" ClientInstanceName="chkActivo" Native="True" Text="El usuario se encuentra ACTIVO" BackColor="Transparent">
                                    <Border BorderStyle="None" />
                                </dx:ASPxCheckBox>
                            </div>--%>
                            <label>
                                Seleccione Rol <small>requerido</small>
                                <asp:DropDownList ID="cmbRoles" runat="server" required DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
                            </label>
                        </div>
                        <div class="name-field medium-8 columns">
                            <div class="row">
                                <p class="informativo"><small><strong>Importante: </strong>Si usted está editando o modificando un usuario, deje estos espacios en blanco, a menos que desee <strong>cambiar </strong> la contraseña de dicho usuario, en ese caso ambos campos deben ser iguales y contener entre&nbsp; 6 y 10&nbsp; caracteres alfanuméricos.</small></p>
                            </div>
                            <div class="name-field medium-6 columns">
                                <label>
                                    Ingrese Password 
                                     <dx:ASPxTextBox ID="txtPassword" runat="server" Native="true" ClientInstanceName="txtPassword" Width="100%" Password="True" MaxLength="10">
                                         <ClientSideEvents TextChanged="function(s, e) {
	ValidarPassword(s.GetText(), txtPasswordRepita.GetText());
}" />
                                     </dx:ASPxTextBox>
                                </label>
                            </div>
                            <div class="name-field medium-6 columns">
                                <label>
                                    Reingrese Password 
                                    <dx:ASPxTextBox ID="txtPasswordRepita" runat="server" Native="true" ClientInstanceName="txtPasswordRepita" Width="100%" Password="True" MaxLength="10">
                                        <ClientSideEvents TextChanged="function(s, e) {
	ValidarPassword(s.GetText(), txtPasswordRepita.GetText());
}" />
                                    </dx:ASPxTextBox>
                                </label>
                            </div>
                            <div class="row" style="padding-left: 20px;">
                                <dx:ASPxLabel ID="lblMensajePassword" runat="server" Text="" ForeColor="#CC0000" ClientInstanceName="lblMensajePassword"></dx:ASPxLabel>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <%--<div class="medium-4 columns">--%>
                            <label>
                                Seleccione él o los cursos del Apoderado
                        
                            <dx:ASPxTokenBox ID="cmbCursos" runat="server" ItemValueType="System.String" DataSourceID="odsCursos" TextField="Nombre" ValueField="Id" Width="100%" Theme="Mulberry" NullText="Seleccione"></dx:ASPxTokenBox>
                                <asp:ObjectDataSource ID="odsCursos" runat="server" SelectMethod="ListarCursosPorInstId" TypeName="VCFramework.NegocioMySQL.Curso">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="0" Name="instId" SessionField="INST_ID" Type="Int32" />
                                        <asp:QueryStringParameter DefaultValue="0" Name="idUsu" QueryStringField="id" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>

                            </label>
                        <%--</div>--%>

                    </div>
                    
                    <hr />
                    <div class="row panel">
                        <%--<asp:Literal ID="litMensaje" runat="server"></asp:Literal>--%>
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
                
                //$('#form1')
                //  .on('invalid.fndtn.abide', function () {
                //      var invalid_fields = $(this).find('[data-invalid]');
                //      console.log(invalid_fields);
                //      //alert('invalid');
                //  })
                //  .on('valid.fndtn.abide', function () {
                //      console.log('valid!');
                //      //alert('valid');
                //      var instId = cmbInstitucion.GetValue();
                //      var regId = cmbRegion.GetValue();
                //      var comId = cnbComuna.GetValue();
                //      pnlGeneral.PerformCallback('guardar;' + instId + ';' + regId + ';' + comId);

                //  });

                //$("#ContentPlaceHolder1_pnlGeneral_cmbRegion").change(function () {
                //    //alert( "Handler for .change() called." );
                //    var id = $("#ContentPlaceHolder1_pnlGeneral_cmbRegion").val();
                //    pnlComunas.PerformCallback(id);
                //});

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
            function OnRutValidation(s, e) {
                var rut = e.value;
                if (rut == null || rut == "")
                    return;
                var digits = "_";
                for (var i = 0; i < rut.length; i++) {
                    if (rut.indexOf(rut.charAt(i)) == -1) {
                        e.isValid = false;
                        break;
                    }
                }
                if (e.isValid) {
                    
                    e.value = rut;
                }

            }
            function ValidarPassword(txtPasswordObj, txtPasswordRepitaObj)
            {
                if (txtPasswordObj != null && txtPasswordRepitaObj != null)
                {
                    if (txtPasswordObj != '' && txtPasswordRepitaObj != '')
                    {
                        //largo de los elementos
                        if (txtPasswordObj.length < 6 || txtPasswordRepitaObj.length < 6)
                        {
                            lblMensajePassword.SetText('Largo incorrecto, ingrese nuevamente.');
                            txtPassword.SetText('');
                            txtPasswordRepita.SetText('');
                            return;
                        }
                        if (txtPasswordObj != txtPasswordRepitaObj)
                        {
                            lblMensajePassword.SetText('Password no coinciden, ingrese nuevamente.');
                            txtPassword.SetText('');
                            txtPasswordRepita.SetText('');
                            return;
                        }
                        lblMensajePassword.SetText('');
                    }
                }
            }
            </script>
</asp:Content>
