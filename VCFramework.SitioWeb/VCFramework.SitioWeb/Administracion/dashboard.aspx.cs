using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            UsuarioFuncional usu = new UsuarioFuncional();
            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    lblIngresosEgresos.Text = VCFramework.NegocioMySQL.IngresoEgreso.SumaEgresosIngresos(usu.AutentificacionUsuario.InstId);
                }
                else
                {
                    lblIngresosEgresos.Text = VCFramework.NegocioMySQL.IngresoEgreso.SumaEgresosIngresos(3);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}