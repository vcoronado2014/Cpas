using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            // do the bartman
            
            
            //evaluamos antes el request
            if (Request.QueryString["Usuario"] != null && Request.QueryString["Clave"] != null)
            {
                string user_login = Request.QueryString["Usuario"];
                string user_password = Request.QueryString["Clave"];
                if (LogicLogin.ValidarUsuario(user_login, user_password))
                {
                    Session["USUARIO_AUTENTICADO"] = LogicLogin.ObtenerUsuario(user_login, user_password);
                    UsuarioFuncional usu1 = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    if (usu1.AutentificacionUsuario.Id <= 0)
                        Response.Redirect("~/Ingreso.aspx");
                    else
                    {
                        //correcto
                        Entidad.LoginUsuario login = new Entidad.LoginUsuario();
                        login.FechaMovimiento = DateTime.Now;
                        login.TipoMovimiento = "Ingresar Android";
                        login.UsuId = usu1.AutentificacionUsuario.Id;
                        NegocioMySQL.LoginUsuario.Insertar(login);
                        Session["ES_ANDROID"] = true;
                        //Response.Redirect("~/default.aspx");


                    }
                }
            }


            
            UsuarioFuncional usu = new UsuarioFuncional();
            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    //acciones
                    
                    literalMenu.Text = RolesPermisos.RetornaMenu(usu.Rol.Id.ToString());
                    
                    //***************************************
                    //setear todos los valores y ocultar los menus.
                    pnlDatos.Visible = true;
                    ActivarInicioSesion();
                    litUsuario.Text = usu.AutentificacionUsuario.NombreUsuario;
                    lblIdInstGlobal.Text = usu.AutentificacionUsuario.InstId.ToString();
                    litRol.Text = usu.Rol.Nombre;
                }
                else
                {
                    
                    //***************************************
                    //quitar los valores
                    pnlDatos.Visible = false;
                    DesactivarInicioSesion();
                }
            }
            else
            {
               
                //***************************************
                //quitar los valores
                pnlDatos.Visible = false;
                DesactivarInicioSesion();
            }
            


            //obtención del encabezado
            VCFramework.DinamicHTML.Encabezado pagina = new VCFramework.DinamicHTML.Encabezado();
            if (usu.AutentificacionUsuario != null)
            {
                if (usu.AutentificacionUsuario.InstId > 0)
                {
                    //tiene institucion valida

                    pagina = VCFramework.DinamicHTML.Pagina.ObtenerEncabezado(usu.AutentificacionUsuario.InstId);
                    List<Entidad.VinculosInstitucion> vinculos = NegocioMySQL.VinculosInstitucion.ObtenerPorInstId(usu.AutentificacionUsuario.InstId);
                    if (vinculos != null && vinculos.Count == 1)
                    {
                        hlVinculoImg1.ImageUrl = vinculos[0].ImagenVinculo1;
                        hlVinculoImg1.NavigateUrl = vinculos[0].UrlVinculo1;
                        hlVinculoTexto1.Text = vinculos[0].TextoVinculo1;
                        hlVinculoTexto1.NavigateUrl = vinculos[0].UrlVinculo1;
                        if (vinculos[0].VisibleVinculo1 == 1)
                        {
                            hlVinculoImg1.Visible = true;
                            hlVinculoTexto1.Visible = true;
                        }
                        else
                        {
                            hlVinculoImg1.Visible = false;
                            hlVinculoTexto1.Visible = false;
                        }
                        //***************************
                        hlVinculoImg2.ImageUrl = vinculos[0].ImagenVinculo2;
                        hlVinculoImg2.NavigateUrl = vinculos[0].UrlVinculo2;
                        hlVinculoTexto2.Text = vinculos[0].TextoVinculo2;
                        hlVinculoTexto2.NavigateUrl = vinculos[0].UrlVinculo2;
                        if (vinculos[0].VisibleVinculo2 == 1)
                        {
                            hlVinculoImg2.Visible = true;
                            hlVinculoTexto2.Visible = true;
                        }
                        else
                        {
                            hlVinculoImg2.Visible = false;
                            hlVinculoTexto2.Visible = false;
                        }
                        //**************************
                        hlVinculoImg3.ImageUrl = vinculos[0].ImagenVinculo3;
                        hlVinculoImg3.NavigateUrl = vinculos[0].UrlVinculo3;
                        hlVinculoTexto3.Text = vinculos[0].TextoVinculo3;
                        hlVinculoTexto3.NavigateUrl = vinculos[0].UrlVinculo3;
                        if (vinculos[0].VisibleVinculo3 == 1)
                        {
                            hlVinculoImg3.Visible = true;
                            hlVinculoTexto3.Visible = true;
                        }
                        else
                        {
                            hlVinculoImg3.Visible = false;
                            hlVinculoTexto3.Visible = false;
                        }


                    }
                 
                    //pagina = VCFramework.DinamicHTML.Pagina.ObtenerEncabezado(3);
                }
            }
            else
                pagina = VCFramework.DinamicHTML.Pagina.ObtenerEncabezado(3);

            if (pagina.UsaImagenSuperior == 1)
            {
                imgSuperior.ImageUrl = pagina.UrlImagenSuperior;
                if (Session["ES_ANDROID"] != null)
                {
                    if (Convert.ToBoolean(Session["ES_ANDROID"].ToString()) == true)
                    imgSuperior.Visible = false;
                }
                else
                {
                    imgSuperior.Visible = true;
                }
            }
            else
            {
                imgSuperior.Visible = false;
            }
            litTituloEncabezado.Text = pagina.TituloEncabezado != null && pagina.TituloEncabezado != string.Empty ? pagina.TituloEncabezado : "CPAS";
            LitSubtituloEncabezado.Text = pagina.SubtiTuloEncabezado != null && pagina.SubtiTuloEncabezado != string.Empty ? pagina.SubtiTuloEncabezado : "Centro de Padres y Apoderados";


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private void DesactivarInicioSesion()
        {
            hlCerrarSesion.Visible = false;
            hlIniciarSesion.Visible = true;
        }
        private void ActivarInicioSesion()
        {
            hlCerrarSesion.Visible = true;
            hlIniciarSesion.Visible = false;
        }

        protected void hlCerrarSesion_Click(object sender, EventArgs e)
        {
            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                UsuarioFuncional usu = new UsuarioFuncional();
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    Entidad.LoginUsuario login = new Entidad.LoginUsuario();
                    login.FechaMovimiento = DateTime.Now;
                    login.TipoMovimiento = "Salir";
                    login.UsuId = usu.AutentificacionUsuario.Id;
                    NegocioMySQL.LoginUsuario.Insertar(login);
                }
            }
            Session["USUARIO_AUTENTICADO"] = null;
            if (Session["ES_ANDROID"] != null)
            {
                Session["ES_ANDROID"] = null;
                Response.Redirect("~/default.aspx");
            }
            else
            {
                Response.Redirect("~/ingreso.aspx");
            }
        }
    }
}