using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class Monitoreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;

                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    if (usu.Rol.Id == 1)
                    {
                        Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                        Session["USU_ID"] = usu.AutentificacionUsuario.Id;
                        grillaDocumentos.GroupBy(grillaDocumentos.Columns[0]);
                        grillaDocumentos.ExpandAll();
                    }
                    else
                    {
                        Response.Redirect("~/default.aspx");
                    }

                }
                else
                {
                    //retorno
                    Response.Redirect("~/default.aspx");
                }
            }
            else
            {
                //retorno
                Response.Redirect("~/default.aspx");
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            if (grillaDocumentos != null && grillaDocumentos.VisibleRowCount > 0)
            {
                ASPxGridViewExporter1.WriteXlsToResponse("Monitoreo");
            }
        }
    }
}