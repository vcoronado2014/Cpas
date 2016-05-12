using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region pruebas de insercion
            //VCFramework.Entidad.AutentificacionUsuario au = new Entidad.AutentificacionUsuario();
            //au.CorreoElectronico = "vcoronado.alarcon@gmail.com";
            //au.Eliminado = 0;
            //au.EsVigente = 1;
            //au.NombreUsuario = "vcoronado";
            //au.Password = "123456";




            //VCFramework.Entidad.Rol rol = new Entidad.Rol();
            //rol.Nuevo = true;
            //rol.Nombre = "Super Administrador";
            //rol.Descripcion = "Rol encargado de administrar todo el sistema con permisos especiales";
            //VCFramework.NegocioMySQL.Factory fac = new NegocioMySQL.Factory();

            //fac.Insertar<VCFramework.Entidad.Rol>(rol);
            #endregion

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (LogicLogin.ValidarUsuario(user_login.Text, user_password.Text))
            {
                Session["USUARIO_AUTENTICADO"] = LogicLogin.ObtenerUsuario(user_login.Text, user_password.Text);
                UsuarioFuncional usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                if (usu.AutentificacionUsuario.Id <= 0)
                    Response.Redirect("~/Ingreso.aspx");
                else
                {
                    //correcto
                    Entidad.LoginUsuario login = new Entidad.LoginUsuario();
                    login.FechaMovimiento = DateTime.Now;
                    login.TipoMovimiento = "Ingresar";
                    login.UsuId = usu.AutentificacionUsuario.Id;
                    NegocioMySQL.LoginUsuario.Insertar(login);
                    Response.Redirect("~/default.aspx");


                }
            }
        }
    }
}