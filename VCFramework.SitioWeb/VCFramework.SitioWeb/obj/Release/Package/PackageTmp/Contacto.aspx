<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="VCFramework.SitioWeb.Contacto" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <span class="tituloContacto"><i class="foundicon-mail padding-right-15 style3"></i>  
        Contacto</span>
    </div>
    <div class="panel">
        <dx:ASPxCallbackPanel ID="pnlCorreo" ClientInstanceName="pnlCorreo" runat="server" Width="100%" OnCallback="pnlCorreo_Callback">
            <ClientSideEvents EndCallback="function(s, e) {
	if (lblMensaje.GetText() != '')
		alert(lblMensaje.GetText());
}" />
            <PanelCollection>
                <dx:PanelContent runat="server">

                    <div class="name-field small-12 columns">
                        <label>
                            Su Nombre <small>requerido</small>
                            <input type="text" required pattern="[a-zA-Z]+" id="lblNombre"/>
                        </label>
                        <small class="error">El Nombre es requerido.</small>
                    </div>
                    <div class="number-field medium-6 columns">
                        <label>
                            Teléfono <small>Sólo números</small>
                            <input type="number" id="lblTelefono" />
                        </label>
                        <small class="error">Teléfono inválido.</small>
                    </div>
                    <div class="email-field medium-6 columns">
                        <label>
                            Correo Electrónico <small>requerido</small>
                            <input type="email" required id="lblEmail"/>
                        </label>
                        <small class="error">Correo inválido.</small>
                    </div>
                    <div class="name-field small-12 columns">
                        <label>
                            Motivo de su consulta <small>requerido</small>
                            <textarea required id="memMotivo"></textarea>
                        </label>
                        <small class="error">El Motivo es requerido.</small>
                    </div>
                    <div class="row">
                        <dx:ASPxLabel ID="lblMensaje" ClientInstanceName="lblmensaje" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                    <div class="row">
                        <button type="reset">Limpiar</button>
                        <button type="submit" class="right" id="btnEnviar">Enviar</button>
                    </div>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>

        <script src="js/vendor/jquery.js"></script>
        <script src="js/foundation/foundation.js"></script>
        <script src="js/foundation/foundation.abide.js"></script>
        <script type="text/javascript">
            $(document).foundation('abide', 'reflow');
            $(document).ready(function () {
                
                $('#form1')
                  .on('invalid.fndtn.abide', function () {
                      var invalid_fields = $(this).find('[data-invalid]');
                      console.log(invalid_fields);
                      //alert('invalid');
                  })
                  .on('valid.fndtn.abide', function () {
                      console.log('valid!');
                      //alert('valid');
                      var nombre = lblNombre.value;
                      var telefono = lblTelefono.value;
                      var email = lblEmail.value;
                      var motivo = memMotivo.value;
                      pnlCorreo.PerformCallback(nombre + '|' + telefono + '|' + email + '|' + motivo);


                  });

            });


        </script>
    </div>

</asp:Content>
