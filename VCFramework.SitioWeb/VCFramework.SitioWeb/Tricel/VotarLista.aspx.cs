using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace VCFramework.SitioWeb.Tricel
{
    public partial class VotarLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Lst_id"] != null)
                {
                    UsuarioFuncional usu = new UsuarioFuncional();

                    if (Session["USUARIO_AUTENTICADO"] != null)
                    {
                        usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    }
                    hidId.Value = Request.QueryString["Lst_id"];
                    Session["LST_ID"] = int.Parse(Request.QueryString["Lst_id"].ToString());
                    Recuperar(int.Parse(Request.QueryString["Lst_id"].ToString()), usu.AutentificacionUsuario.Id, usu.AutentificacionUsuario.InstId);
                    int proId = int.Parse(Request.QueryString["Lst_id"].ToString());
                    //BUSCAR LAS VOTACIONES DE LA LISTA
                    //lblIngresosEgresos.Text = VCFramework.NegocioMySQL.Votaciones.SumaVotaciones(proId);

                }
                else
                {
                    //Response.Redirect();
                }
            }
        }
        private void Recuperar(int id, int usuId, int instId)
        {
            if (id > 0)
            {
                //Entidad.ListaTricel entidad = VCFramework.NegocioMySQL.ListaTricel.ObtenerListaTricelPorId(id)[0];
                EntidadFuniconal.ListaTricelFuncional entidad = VCFramework.NegocioMySQL.ListaTricel.ObtenerListaTricelFuncionalPorId(instId, usuId, id);
                if (entidad != null)
                {
                    try
                    {
                        UsuarioFuncional usu = new UsuarioFuncional();

                        if (Session["USUARIO_AUTENTICADO"] != null)
                        {
                            usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                        }
                        //lblFechaMovimiento.Text = entidad.FechaCreacion.ToShortDateString();
                        lblInstitucion.Text = usu.Institucion.Nombre;
                        lblUsuario.Text = usu.AutentificacionUsuario.NombreUsuario;
                        lblFechaMovimiento.Text = entidad.Tricel.FechaCreacion.ToShortDateString();
                        lblInstitucion.Text = usu.Institucion.Nombre;
                        lblUsuario.Text = usu.AutentificacionUsuario.NombreUsuario;
                        lblNombreProyecto.Text = entidad.Nombre;
                        lblObjetivo.Text = entidad.Objetivo;
                        lblDescripcion.Text = entidad.Descripcion;
                        lblBeneficios.Text = entidad.Beneficios;
                        //dejar monto en formato miles
                        //string formateado = string.Format(new System.Globalization.CultureInfo("es-CL"), "{0:C0}", entidad.Costo);
                        lblMonto.Text = "Lista Tricel";
                        //lblMonto.Text = String.Format("{0:c}", entidad.Costo.ToString());

                        lblFechaInicio.Text = entidad.Tricel.FechaInicio.ToShortDateString();
                        lblFechaTermino.Text = entidad.Tricel.FechaTermino.ToShortDateString();
                        ////verificar si ya votó o no
                        int [] listas = NegocioMySQL.ListaTricel.ObtenerArregloListasDelTricel(entidad.TriId);
                        StringBuilder votos = new StringBuilder();
                        votos.Append(NegocioMySQL.VotTricel.SumarVotaciones(listas));
                        Session["TRI_ID"] = entidad.TriId;
                        if (votos.Length > 0)
                        {
                            List<Entidad.VotTricel> votacionesLista = NegocioMySQL.VotTricel.ObtenerVotacionPorUsuario(usu.AutentificacionUsuario.Id, id, entidad.TriId);
                            literalListaVotos.Text = votos.ToString();
                            if (votacionesLista != null && votacionesLista.Count > 0)
                            {
                                //el usuario ya voto
                                lblYaVoto.Text = "Ud. ya ha votado. Lo hizo el día " + votacionesLista[0].FechaVotacion.ToShortDateString() + " " + votacionesLista[0].FechaVotacion.ToShortTimeString();
                                btnVotar.ClientEnabled = false;
                            }
                            else
                            {
                                lblYaVoto.Text = "Ud. aún no ha votado.";
                                btnVotar.ClientEnabled = true;
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        EstiloMensaje(Administracion.EstiloMensaje.Error, ex.Message);
                        VCFramework.NegocioMySQL.Utiles.Log(ex);
                    }
                }
                else
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Advertencia, "NO ENCONTRADO");
                    VCFramework.NegocioMySQL.Utiles.Log("NO encontrado");
                }

            }
        }
        private void EstiloMensaje(Administracion.EstiloMensaje estilo, string mensaje)
        {
            switch (estilo)
            {
                case Administracion.EstiloMensaje.Ok:
                    litMensaje.Font.Size = 12;
                    litMensaje.Font.Bold = true;
                    litMensaje.Text = mensaje;
                    break;
                case Administracion.EstiloMensaje.Advertencia:
                    litMensaje.Font.Size = 13;
                    litMensaje.Font.Bold = true;
                    litMensaje.ForeColor = System.Drawing.Color.Blue;
                    litMensaje.Text = mensaje;
                    break;
                case Administracion.EstiloMensaje.Error:
                    litMensaje.Font.Size = 13;
                    litMensaje.Font.Bold = true;
                    litMensaje.ForeColor = System.Drawing.Color.Red;
                    litMensaje.Text = mensaje;
                    break;
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
                Entidad.VotTricel voto = new Entidad.VotTricel();
                voto.FechaVotacion = DateTime.Now;
                voto.InstId = usu.AutentificacionUsuario.InstId;
                voto.LtrId = int.Parse(Request.QueryString["Lst_id"].ToString());
                voto.UsuIdVotador = usu.AutentificacionUsuario.Id;
                voto.TriId = int.Parse(Session["TRI_ID"].ToString());
                NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
                try
                {
                    int idVoto = fac.Insertar<Entidad.VotTricel>(voto);

                    if (idVoto > 0)
                    {
                        EstiloMensaje(Administracion.EstiloMensaje.Ok, "Voto Generado con éxito.");
                    }
                    else
                    {
                        EstiloMensaje(Administracion.EstiloMensaje.Error, "Error al Guardar el voto.");
                    }
                }
                catch (Exception ex)
                {
                    EstiloMensaje(Administracion.EstiloMensaje.Error, ex.Message);
                }

                Recuperar(voto.LtrId, voto.UsuIdVotador, voto.InstId);


            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}