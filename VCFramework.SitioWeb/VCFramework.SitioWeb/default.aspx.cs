using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Globalization;

namespace VCFramework.SitioWeb
{

    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string path = @"d:\ccc_Apoderados.xlsx";
            //ExcelLinq.ToEntidad(path, 1, 1, 1, 1);
            //NegocioMySQL.Utiles.Log("prueba");
            //NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
            //fac.EjecutarSP<Entidad.Curso>("SP_OBTENER_CURSO_POR_INST_ID;");
            //NegocioMySQL.Curso.ListarCursosPorInstId(3);
            //Entidad.Curso cur = new Entidad.Curso();
            //cur.Borrado = false;
            //cur.Eliminado = 0;
            //cur.Grupo = "";
            //cur.IdUsuResponsable = 0;
            //cur.InstId = 5;
            //cur.Modificado = false;
            //cur.Nombre = "Prueba";
            //cur.Nuevo = true;
            //cur.Orden = 9999;
            //cur.SubGrupo = "";
            //cur.Tipo = 0;
            //NegocioMySQL.Factory fac = new NegocioMySQL.Factory();
            //fac.Insertar<Entidad.Curso>(cur);
            //string prueba = NegocioMySQL.Utiles.ObtenerMensajeXML("Documento", true);
            if (!Page.IsPostBack)
            {
                UsuarioFuncional usu = new UsuarioFuncional();
                List<VCFramework.DinamicHTML.Articulo> articulos = new List<DinamicHTML.Articulo>();
                List<Entidad.Proyectos> proyectos = new List<Entidad.Proyectos>();
                List<EntidadFuniconal.ProyectosFuncional> proyectosF = new List<EntidadFuniconal.ProyectosFuncional>();
                bool tieneProyectos = false;
                ASPxScheduler1.Start = DateTime.Now;
                int cantidadProyectos = 0;
                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    pnlOtros.ClientVisible = true;
                    if (usu != null && usu.AutentificacionUsuario.Id > 0)
                    {
                        //proyectos = NegocioMySQL.Proyectos.ObtenerProyectosPorInstId(usu.AutentificacionUsuario.InstId);
                        if (usu.AutentificacionUsuario.InstId == 3)
                            pnlNuestrasFuncionalidades.ClientVisible = true;
                        proyectos = NegocioMySQL.Proyectos.ObtenerProyectosListasPorInstId(usu.AutentificacionUsuario.InstId, usu.AutentificacionUsuario.Id);
                        if (proyectos != null && proyectos.Count > 0)
                        {
                            tieneProyectos = true;
                            cantidadProyectos = proyectos.Count;
                        }
                        controlVistaDocumentos1.EsconderFiltro();
                        controlVistaDocumentos1.EsconderColumnas();

                        controlVistaRendiciones.EsconderFiltro();
                        controlVistaRendiciones.EsconderColumnas();

                        controlVistaDocumentosUsuario1.EsconderFiltro();
                        controlVistaDocumentosUsuario1.EsconderColumnas();

                        articulos = VCFramework.DinamicHTML.Articulo.ListarArticulos(usu.AutentificacionUsuario.InstId, 1);
                        //lblUsuIdDefault.Text = usu.AutentificacionUsuario.InstId.ToString();
                        //controlVistaCalendario.UsuId = usu.AutentificacionUsuario.InstId.ToString();
                    }
                    else
                    {
                        articulos = VCFramework.DinamicHTML.Articulo.ListarArticulos(3, 1);
                    }
                }
                else
                {
                    articulos = VCFramework.DinamicHTML.Articulo.ListarArticulos(3, 1);
                }
                
                if (tieneProyectos)
                {

                    //mostrar el panel y cargar el repeat
                    foreach (Entidad.Proyectos proyecto in proyectos)
                    {
                        EntidadFuniconal.ProyectosFuncional proy = new EntidadFuniconal.ProyectosFuncional();
                        proy.Beneficios = proyecto.Beneficios;
                       
                        string formateado = string.Format(new System.Globalization.CultureInfo("es-CL"), "{0:C0}", proyecto.Costo);
                        proy.CostoStr = formateado;
                        proy.Costo = proyecto.Costo;
                        proy.Descripcion = proyecto.Descripcion;
                        proy.Eliminado = proyecto.Eliminado;
                        proy.EnviaCorreo = proyecto.EnviaCorreo;
                        proy.EsVigente = proyecto.EsVigente;
                        proy.FechaCreacion = proyecto.FechaCreacion;
                        proy.FechaInicio = proyecto.FechaInicio;
                        proy.FechaTermino = proyecto.FechaTermino;
                        proy.FueAprobado = proyecto.FueAprobado;
                        proy.Id = proyecto.Id;
                        proy.InstId = proyecto.InstId;
                        proy.Nombre = proyecto.Nombre;
                        proy.NotificaPopup = proyecto.NotificaPopup;
                        proy.Objetivo = proyecto.Objetivo;
                        proy.UsuIdCreador = proyecto.UsuIdCreador;

                        if (proy.Nombre.Contains("Lista"))
                        {
                            //es una lista TRICEL
                            proy.CostoStr = "Lista Tricel.";
                            proy.ClasePrecio = "priceTr";
                            proy.ClaseTitulo = "titleTr";
                            proy.InfoLista = "bullet-item";
                            //cambiar
                            List<Entidad.VotTricel> votos = NegocioMySQL.VotTricel.ObtenerVotacionTricelPorListalId(proy.Id);
                            if (votos != null && votos.Count > 0)
                            {
                                proy.CantidadVotos = votos.Count;
                                if (votos.Exists(p=>p.UsuIdVotador == usu.AutentificacionUsuario.Id))
                                    proy.EsMiVoto = "success label right";
                                else
                                    proy.EsMiVoto = "hide";
                            }
                            else
                            {
                                proy.CantidadVotos = 0;
                                proy.EsMiVoto = "hide";
                            }
                        }
                        else
                        {
                            proy.ClasePrecio = "price";
                            proy.ClaseTitulo = "title";
                            proy.InfoLista = "hidden";
                            proy.EsMiVoto = "hide";
                        }

                        StringBuilder sb = new StringBuilder();

                        bool esPar = false;
                        //trabajamos con la cantidad de proyectos para determinar la cantidad de registros a mostrar
                        if ((cantidadProyectos % 2) == 0)
                        {
                            esPar = true;
                        }
                        if (esPar && cantidadProyectos <= 3)
                            sb.AppendFormat("{0}", "pricing-table medium-6 columns");
                        else
                            sb.AppendFormat("{0}", "pricing-table medium-4 columns");
                        if (esPar && cantidadProyectos > 3 && cantidadProyectos <= 5)
                            sb.AppendFormat("{0}", "pricing-table medium-3 columns");
                        else
                        {
                            if (sb.ToString() == "")
                                sb.AppendFormat("{0}", "pricing-table medium-3 columns");
                        }

                        proy.Clase = sb.ToString();
                        if (proy.Nombre.Contains("Lista"))
                            proy.UrlVotar = "Tricel/VotarLista.aspx?Lst_id=" + proy.Id.ToString();
                        else
                            proy.UrlVotar = "Proyectos/VotarProyecto.aspx?Pro_id=" + proy.Id.ToString();
                        proyectosF.Add(proy);
                    }
                    //generar rpt
                    
                    //litClase.Text = clase;
                    rptProyectos.DataSource = proyectosF;
                    rptProyectos.DataBind();
                    rptProyectos.Visible = true;



                }

                rptArticulos.DataSource = articulos;
                rptArticulos.DataBind();
            }
        }
    }
}