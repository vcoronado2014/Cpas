using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.RecuperarClave
{
    public partial class Cambiar : System.Web.UI.Page
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
                    txtUsername.Text = string.Empty;
                    litMensaje.Text = "Este usuario no existe, ingrese otro";

                    txtUsername.Focus();
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

                if (txtUsername.Text != "")
                {
                    string[] param = e.Parameter.Split(';');
                    string userName = param[1];
                    Entidad.AutentificacionUsuario aus = VCFramework.NegocioMySQL.AutentificacionUsuario.ListarUsuarios().Find(p => p.NombreUsuario == userName);
                    if (aus == null || aus.Id <= 0)
                        litMensaje.Text = "Error al recuperar usuario.";
                    else
                    {
                        //anviar clave
                        //NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                        //MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeRecuperarClave(aus.NombreUsuario, aus.Password, aus.CorreoElectronico);
                        //cr.Enviar(mnsj);
                        var task = System.Threading.Tasks.Task.Factory.StartNew(() => EnviarCorreo(aus.NombreUsuario, NegocioMySQL.Utiles.DesEncriptar(aus.Password), aus.CorreoElectronico));
                        litMensaje.Text = "Dentro de los proximos minutos recibirá un correo electrónico con su contraseña.";
                    }
                }
                else
                {
                    litMensaje.Text = "Debe escribir un usuario en el cuadro de texto.";
                }

            }
        }
        private void EnviarCorreo(string nombreUsuario, string password, string correo)
        {
            NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
            MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeRecuperarClave(nombreUsuario,password, correo);
            cr.Enviar(mnsj);
        }
    }
}