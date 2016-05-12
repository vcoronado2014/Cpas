using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class EditorArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                UsuarioFuncional usu = new UsuarioFuncional();
                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    if (usu != null && usu.AutentificacionUsuario.Id > 0)
                    {
                        Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                    }
                    else
                    {
                        Session["INST_ID"] = 3;
                    }
                }
                else
                {
                    Session["INST_ID"] = 3;
                }
            }
        }
    }
}