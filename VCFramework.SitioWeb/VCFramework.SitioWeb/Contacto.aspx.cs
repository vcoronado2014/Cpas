using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace VCFramework.SitioWeb
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pnlCorreo_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter != null && e.Parameter.Length > 0)
            {
                var param = e.Parameter.Split('|');
                try
                {
                    string nombre = param[0];
                    string telefono = param[1];
                    string email = param[2];
                    string motivo = param[3];
                    NegocioMySQL.ServidorCorreo cr = new NegocioMySQL.ServidorCorreo();
                    MailMessage mnsj = NegocioMySQL.Utiles.ConstruyeMensajeContacto(nombre, telefono, email, motivo);

                    //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));
                    cr.Enviar(mnsj);

                    lblMensaje.Text = "Mensaje enviado correctamente, nos pondremos en contacto a la brevedad posible.";

                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                }
            }
        }
    }
}