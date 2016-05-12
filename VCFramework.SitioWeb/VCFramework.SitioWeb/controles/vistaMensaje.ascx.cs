using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.controles
{
    public partial class vistaMensaje : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool ClientVisible
        {
            set { rpMensaje.ClientVisible = value; }
        }
        public bool UsaHeader {
            set { rpMensaje.ShowHeader = value; }
        }
        public string TextoHeader
        {
            set { rpMensaje.HeaderText = value; }
        }
        public string Mensaje
        {
            set { lblMensajeError.Text = value; }
        }
        public bool UsaIcono { set { imgError.ClientVisible = value; } }
        public void ColorFondo(System.Drawing.Color color)
        {
            rpMensaje.BackColor = color;
        }
        public void ColorFuente(System.Drawing.Color color)
        {
            lblMensajeError.ForeColor = color;
        }
        public void MostrarMensaje(EstiloMensaje estilo, bool muestraIcono, bool usaHedaer, string mensaje, string mensajeHeader)
        {
            UsaHeader = usaHedaer;
            TextoHeader = mensajeHeader;
            Mensaje = mensaje;
            //UsaIcono = muestraIcono;
            ClientVisible = true;
            if (muestraIcono)
            {
                if (estilo == EstiloMensaje.Alerta)
                    imgAlerta.ClientVisible = true;
                if (estilo == EstiloMensaje.Error)
                    imgError.ClientVisible = true;
                if (estilo == EstiloMensaje.Ok)
                    imgOk.ClientVisible = true;
            }
            if (estilo == EstiloMensaje.Alerta)
                lblMensajeError.ForeColor = System.Drawing.Color.Blue;
            if (estilo == EstiloMensaje.Error)
                lblMensajeError.ForeColor = System.Drawing.Color.Red;
            if (estilo == EstiloMensaje.Ok)
                lblMensajeError.ForeColor = System.Drawing.Color.Black;


        }

    }
}