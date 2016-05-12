using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Reportes
{
    public partial class rptActasN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UsuarioFuncional usu = new UsuarioFuncional();
            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    if (Request.QueryString["tipo"] != null)
                    {
                        string tipo = Request.QueryString["tipo"].ToString();
                        switch (tipo)
                        {
                            case "1":
                                //reporte de actas
                                rptReporteActas report = new rptReporteActas();
                                DateTime fechaInicial = DateTime.Now.AddYears(-1);
                                DateTime fechaFinal = DateTime.Now.AddDays(1);

                                if (Request.QueryString["fecha_inicio"] != null)
                                {
                                    fechaInicial = Convert.ToDateTime(Request.QueryString["fecha_inicio"]);
                                }
                                if (Request.QueryString["fecha_termino"] != null)
                                {
                                    fechaFinal = Convert.ToDateTime(Request.QueryString["fecha_termino"]);
                                }
                                report.fechaIni.Value = fechaInicial;
                                report.fechaTer.Value = fechaFinal;
                                report.paramInstId.Value = usu.AutentificacionUsuario.InstId.ToString();
                                report.xrLabelTitulo.Text = "Reporte de Actas";
                                report.xrTableCellDesde.Text = fechaInicial.ToShortDateString();
                                report.xrTableCellHasta.Text = fechaFinal.ToShortDateString();
                                report.xrTableCellInstitucion.Text = usu.Institucion.Nombre;
                                report.xrTableCellSolicitado.Text = usu.Persona.Nombres + " " + usu.Persona.ApellidoPaterno + " " + usu.Persona.ApellidoMaterno;

                                webDocumentViewer.OpenReport(report);
                                break;
                            case "2":
                                //reporte de actas
                                rptRendiciones report1 = new rptRendiciones();
                                DateTime fechaInicial1 = DateTime.Now.AddYears(-1);
                                DateTime fechaFinal1 = DateTime.Now.AddDays(1);
                                int tipoMovimiento = 0;

                                if (Request.QueryString["fecha_inicio"] != null)
                                {
                                    fechaInicial1 = Convert.ToDateTime(Request.QueryString["fecha_inicio"]);
                                }
                                if (Request.QueryString["fecha_termino"] != null)
                                {
                                    fechaFinal1 = Convert.ToDateTime(Request.QueryString["fecha_termino"]);
                                }
                                if (Request.QueryString["tipo_movimiento"] != null)
                                {
                                    tipoMovimiento = int.Parse(Request.QueryString["tipo_movimiento"]);
                                }
                                report1.paramTipoMovimiento.Value = tipoMovimiento;
                                report1.paramFechaIni.Value = fechaInicial1;
                                report1.paramFechaTer.Value = fechaFinal1;
                                report1.paramInstId.Value = usu.AutentificacionUsuario.InstId.ToString();
                                report1.xrLabelTitulo.Text = "Reporte de Rendiciones";
                                report1.xrTableCellDesde.Text = fechaInicial1.ToShortDateString();
                                report1.xrTableCellHasta.Text = fechaFinal1.ToShortDateString();
                                report1.xrTableCellInstitucion.Text = usu.Institucion.Nombre;
                                report1.xrTableCellSolicitado.Text = usu.Persona.Nombres + " " + usu.Persona.ApellidoPaterno + " " + usu.Persona.ApellidoMaterno;

                                webDocumentViewer.OpenReport(report1);
                                break;
                            case "3":
                                //reporte de actas
                                rptVotaciones report2 = new rptVotaciones();
                                DateTime fechaInicial2 = DateTime.Now.AddYears(-1);
                                DateTime fechaFinal2 = DateTime.Now.AddDays(1);

                                if (Request.QueryString["fecha_inicio"] != null)
                                {
                                    fechaInicial2 = Convert.ToDateTime(Request.QueryString["fecha_inicio"]);
                                }
                                if (Request.QueryString["fecha_termino"] != null)
                                {
                                    fechaFinal2 = Convert.ToDateTime(Request.QueryString["fecha_termino"]);
                                }
                                report2.paramFechaInicio.Value = fechaInicial2;
                                report2.paramFechaTermino.Value = fechaFinal2;
                                report2.paramIdInst.Value = usu.AutentificacionUsuario.InstId.ToString();
                                report2.xrLabelTitulo.Text = "Reporte de Votaciones";
                                report2.xrTableCellDesde.Text = fechaInicial2.ToShortDateString();
                                report2.xrTableCellHasta.Text = fechaFinal2.ToShortDateString();
                                report2.xrTableCellInstitucion.Text = usu.Institucion.Nombre;
                                report2.xrTableCellSolicitado.Text = usu.Persona.Nombres + " " + usu.Persona.ApellidoPaterno + " " + usu.Persona.ApellidoMaterno;

                                webDocumentViewer.OpenReport(report2);
                                break;
                            default:
                                break;
                        }
                    }
                    

                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
            

        }

        protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            rptReporteActas report = new rptReporteActas();
            report.paramInstId.Value = "3";
            webDocumentViewer.OpenReport(report);

        }
    }
}