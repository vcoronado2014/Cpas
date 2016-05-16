using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;

namespace VCFramework.SitioWeb.RecuperarClave
{
    public partial class Recuperar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pnlGeneral_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter.Contains("usuario"))
            {
                string[] param = e.Parameter.Split(';');
                Entidad.AutentificacionUsuario aus = VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuarios().Find(p => p.NombreUsuario == param[1].ToString());

                if (aus == null || aus.Id == 0)
                {
                    //txtUsername.Text = string.Empty;
                    litMensaje.Text = "Este usuario no existe, ingrese otro";

                    //txtUsername.Focus();
                }
                else
                {
                    lblCorreoRecuperar.Text = aus.CorreoElectronico;
                    pnlCreacion.ClientVisible = true;
                    btnGuardar.Focus();
                }

            }
            else if (e.Parameter.Contains("recuperar"))
            {

                if (txtClaveActual.Text != "" && txtNuevaClave.Text != "" && txtRepitaNuevaClave.Text != "")
                {
                    UsuarioFuncional usuActual = new UsuarioFuncional();

                    if (Session["USUARIO_AUTENTICADO"] != null)
                    {
                        usuActual = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    }
                    if (usuActual != null && usuActual.AutentificacionUsuario.Id > 0)
                    {

                        //clave incorrecta
                        if (NegocioMySQL.Utiles.DesEncriptar(usuActual.AutentificacionUsuario.Password) != txtClaveActual.Text)
                        {
                            litMensaje.Text = "Su clave Actual no coincide con nuestro registro.";
                            return;
                        }
                        if (txtNuevaClave.Text != txtRepitaNuevaClave.Text )
                        {
                            litMensaje.Text = "No coincide su nueva contraseña al repetirla, confirme la información y vuelva a intentarlo.";
                            return;
                        }
                        if (txtNuevaClave.Text.Length < 5)
                        {
                            litMensaje.Text = "La contraseña nueva debe tener al menos 5 caracteres.";
                            return;
                        }
                        //ahora modificamos al usuario
                        NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                        usuActual.AutentificacionUsuario.Borrado = false;
                        usuActual.AutentificacionUsuario.Modificado = true;
                        usuActual.AutentificacionUsuario.Nuevo = false;
                        usuActual.AutentificacionUsuario.Password = NegocioMySQL.Utiles.Encriptar(txtNuevaClave.Text);
                        if (fac.Update<Entidad.AutentificacionUsuario>(usuActual.AutentificacionUsuario) > 0)
                        {
                            //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                            //MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeCambiarClave(usuActual.AutentificacionUsuario.NombreUsuario, txtNuevaClave.Text, usuActual.AutentificacionUsuario.CorreoElectronico);
                            //cr.Enviar(mnsj);
                            var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(usuActual.AutentificacionUsuario.NombreUsuario, txtNuevaClave.Text, usuActual.AutentificacionUsuario.CorreoElectronico));
                            litMensaje.Text = "La password se ha modificado con éxito, dentro de unos minutos recibirá un correo con  el resultado de la operación. Los cambios no se llevarán a afecto hasta que salga del sistema.";
                        }
                        else
                        {
                            litMensaje.Text = "Error al cambiar la Password, contacte al Administrador.";
                        }

                    }
                    else
                    {
                        litMensaje.Text = "No se puede cambiar su contraseña Usuario NULO.";
                    }
                }
                else
                {
                    litMensaje.Text = "Debe llenar todos los datos";
                }

            }
        }
        private void EnviarCorreo(string nombreUsuario, string password, string correo)
        {
            NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
            MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeCambiarClave(nombreUsuario, password, correo);
            cr.Enviar(mnsj);
        }
    }
}