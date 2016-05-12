using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioFuncional usu = new UsuarioFuncional();
            //List<VCFramework.DinamicHTML.Articulo> articulos = new List<DinamicHTML.Articulo>();
            //List<UsuarioFuncional> lista = new List<UsuarioFuncional>();


            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                
                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                    ////verificamos el rol 
                    //if (usu.Rol.Nombre.Contains("Super"))
                    //{
                    //    lista = LogicLogin.ListarUsuariosFuncional();
                    //}
                    //else
                    //{
                    //    lista = LogicLogin.ListarUsuariosFuncional(usu.Institucion.Id);
                    //}
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
            //rptPersonas.DataSource = lista;
            //rptPersonas.DataBind();

        }
    }
}