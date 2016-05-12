using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.controles
{
    public partial class controlVistaRendiciones : System.Web.UI.UserControl
    {
        public void EsconderFiltro()
        {
            grillaDocumentos.Settings.ShowFilterRow = false;
        }
        public void EsconderColumnas()
        {
            grillaDocumentos.Columns[4].Visible = false;
            grillaDocumentos.Columns[2].Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;

                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                    Session["USU_ID"] = usu.AutentificacionUsuario.Id;

                }
                else
                {
                    //retorno
                    //Response.Redirect("~/default.aspx");
                }
            }
            else
            {
                //retorno
               // Response.Redirect("~/default.aspx");
            }
        }
    }
}