using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VCFramework.Negocio.Factory;

namespace VCFramework.SitioWeb.Proyectos
{
    public partial class VotarProyecto : System.Web.UI.Page
    {
        public static System.Configuration.ConnectionStringSettings setCns = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MSUsuarioLunConectionString"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Pro_id"] != null)
                {

                    hidId.Value = Request.QueryString["Pro_id"];
                    Session["PRO_ID"] = int.Parse(Request.QueryString["Pro_id"].ToString());
                    Recuperar(int.Parse(Request.QueryString["Pro_id"].ToString()));
                    int proId = int.Parse(Request.QueryString["Pro_id"].ToString());
                    lblIngresosEgresos.Text = VCFramework.NegocioMySQL.Votaciones.SumaVotaciones(proId);

                }
                else
                {
                    //Response.Redirect();
                }
            }
        }
        private void Recuperar(int id)
        {
            if (id > 0)
            {
                Entidad.Proyectos entidad = VCFramework.NegocioMySQL.Proyectos.ObtenerProyectosPorId(id)[0];
                if (entidad != null)
                {
                    try
                    {
                        UsuarioFuncional usu = new UsuarioFuncional();

                        if (Session["USUARIO_AUTENTICADO"] != null)
                        {
                            usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                        }
                        lblFechaMovimiento.Text = entidad.FechaCreacion.ToShortDateString();
                        lblInstitucion.Text = usu.Institucion.Nombre;
                        lblUsuario.Text = usu.AutentificacionUsuario.NombreUsuario;
                        lblFechaMovimiento.Text = entidad.FechaCreacion.ToShortDateString();
                        lblInstitucion.Text = usu.Institucion.Nombre;
                        lblUsuario.Text = usu.AutentificacionUsuario.NombreUsuario;
                        lblNombreProyecto.Text = entidad.Nombre;
                        lblObjetivo.Text = entidad.Objetivo;
                        lblDescripcion.Text = entidad.Descripcion;
                        lblBeneficios.Text = entidad.Beneficios;
                        //dejar monto en formato miles
                        string formateado = string.Format(new System.Globalization.CultureInfo("es-CL"), "{0:C0}", entidad.Costo);
                        lblMonto.Text = formateado;
                        //lblMonto.Text = String.Format("{0:c}", entidad.Costo.ToString());

                        lblFechaInicio.Text = entidad.FechaInicio.ToShortDateString();
                        lblFechaTermino.Text = entidad.FechaTermino.ToShortDateString();
                        //verificar si ya votó o no
                        lblIngresosEgresos.Text = VCFramework.NegocioMySQL.Votaciones.SumaVotaciones(int.Parse(hidId.Value.ToString()));
                        List<Entidad.Votaciones> votacionesUsu = NegocioMySQL.Votaciones.ObtenerVotaciones(int.Parse(hidId.Value.ToString()), usu.AutentificacionUsuario.Id);
                        if (votacionesUsu != null && votacionesUsu.Count > 0)
                        {
                            
                            Entidad.Votaciones vot = votacionesUsu[0];
                            lblYaVoto.Text = "Ud. ya ha votado. Lo hizo el día " + vot.FechaVotacion.ToShortDateString() + " " + vot.FechaVotacion.ToShortTimeString();
                            //seteamos el valor del voto
                            rdlVoto.Value = vot.Valor.ToString();
                            rdlVoto.ClientEnabled = false;
                            btnVotar.ClientEnabled = false;
                        }
                        else
                        {
                            lblYaVoto.Text = "Ud. aún no ha votado.";
                            btnVotar.ClientEnabled = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        //EstiloMensaje(Administracion.EstiloMensaje.Error, ex.Message);
                        VCFramework.NegocioMySQL.Utiles.Log(ex);
                    }
                }
                else
                {
                    //EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "NO ENCONTRADO");
                    VCFramework.NegocioMySQL.Utiles.Log("NO encontrado");
                }

            }
        }

        protected void pnlVotaciones_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter != string.Empty)
            {
                string[] param = e.Parameter.Split('|');
                int valor = int.Parse(param[1]);
                UsuarioFuncional usu = new UsuarioFuncional();

                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                }
                Entidad.Votaciones voto = new Entidad.Votaciones();
                voto.Borrado = false;
                voto.Eliminado = 0;
                voto.FechaVotacion = DateTime.Now;
                voto.InstId = usu.AutentificacionUsuario.InstId;
                voto.Modificado = false;
                voto.Nuevo = true;
                voto.ProId = int.Parse(hidId.Value.ToString());
                voto.UsuIdVotador = usu.AutentificacionUsuario.Id;
                voto.Valor = valor;
                Factory fac = new Factory();
                fac.Insertar<Entidad.Votaciones>(voto, setCns);
                lblIngresosEgresos.Text = VCFramework.NegocioMySQL.Votaciones.SumaVotaciones(voto.ProId);
                Recuperar(voto.ProId);
                

            }
        }
    }
}