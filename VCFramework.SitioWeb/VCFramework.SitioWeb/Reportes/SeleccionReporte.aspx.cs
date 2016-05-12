using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Reportes
{
    public partial class SeleccionReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;

                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    lblInstId.Text = usu.AutentificacionUsuario.InstId.ToString();
                    lblUsuId.Text = usu.AutentificacionUsuario.Id.ToString();

                }
                else
                {
                    //retorno
                    Response.Redirect("~/default.aspx");
                }
            }
        }
        private void MostrarControlesReporteActas()
        {
            lblFechaInicio.ClientVisible = true;
            lblFechaTermino.ClientVisible = true;
            dtFechainicio.ClientVisible = true;
            dtFechaTermino.ClientVisible = true;
            DateTime ahora = DateTime.Now;
            DateTime inicio = DateTime.Now.AddMonths(-1);
            dtFechainicio.Date = inicio;
            dtFechaTermino.Date = ahora;
            btnEnviar.Visible = true;

        }
        private void MostrarControlesReporteRendiciones()
        {
            lblFechaInicio.ClientVisible = true;
            lblFechaTermino.ClientVisible = true;
            dtFechainicio.ClientVisible = true;
            dtFechaTermino.ClientVisible = true;
            DateTime ahora = DateTime.Now;
            DateTime inicio = DateTime.Now.AddMonths(-1);
            dtFechainicio.Date = inicio;
            dtFechaTermino.Date = ahora;
            btnEnviar.Visible = true;
            lblTipoMovimiento.ClientVisible = true;
            cmbTipoMovimiento.ClientVisible = true;

        }

        protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter != null)
            {
                string parametro = e.Parameter;
                switch(parametro)
                {
                    case "Reporte de Actas":
                        MostrarControlesReporteActas();
                        break;
                    case "Reporte de Rendiciones":
                        MostrarControlesReporteRendiciones();
                        break;
                    case "Reporte de Votaciones":
                        MostrarControlesReporteActas();
                        break;
                }

            }
        }

        //protected void btnEnviar_Click(object sender, EventArgs e)
        //{
        //    if (rdblReportes.SelectedIndex > 0)
        //    {
        //        DevExpress.Web.ListEditItem item = rdblReportes.SelectedItem;
        //        if (item != null)
        //        {
        //            if (item.Value.ToString() == "Reporte de Actas")
        //            {
        //                Response.Redirect() 
        //            }
        //        }
        //    }
        //}
    }
}