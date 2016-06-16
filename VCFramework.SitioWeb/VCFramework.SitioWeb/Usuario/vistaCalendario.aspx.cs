using DevExpress.Web.ASPxScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Usuario
{
    public partial class vistaCalendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                ASPxScheduler1.Start = DateTime.Now;
                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                    Session["USU_ID"] = usu.AutentificacionUsuario.Id;
                    if (usu.Rol.Id == 9)
                    {
                        //solo usuarios con rol administrativo
                        ASPxScheduler1.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
                        ASPxScheduler1.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
                        ASPxScheduler1.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
                        ASPxScheduler1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
                        ASPxScheduler1.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
                        ASPxScheduler1.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
                        ASPxScheduler1.OptionsCustomization.AllowAppointmentResize = DevExpress.XtraScheduler.UsedAppointmentType.None;
                       

                    }
                    //controlVistaCalendario1.UsuId = usu.AutentificacionUsuario.InstId.ToString();

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

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }

        //protected void pnlDatos_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        //{
        //    if (e.Parameter == "guardar")
        //    {
        //        Factory fac = new Factory();
        //        #region guardar calendario
        //        Entidad.Calendario calendario = new Entidad.Calendario();
        //        calendario.Detalle = txtAsunto.Text;
        //        calendario.FechaInicio = dtFechainicio.Date;
        //        calendario.FechaTermino = dtFechaTermino.Date;
        //        calendario.InstId = int.Parse(Session["INST_ID"].ToString());
        //        calendario.Nuevo = true;
        //        calendario.Modificado = false;
        //        calendario.Borrado = false;
        //        calendario.Titulo = txtAsunto.Text;
        //        calendario.Url = "";
        //        calendario.Asunto = txtAsunto.Text;
        //        calendario.Ubicacion = txtUbicacion.Text;
        //        calendario.Etiqueta = 1;
        //        #endregion

        //        if (fac.Insertar<Entidad.Calendario>(calendario) > 0)
        //        {
        //            litMensaje.Text = "Evento creado con éxito.";
        //        }
        //    }
        //}

        protected void ASPxScheduler1_CustomCallback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            //odsCalendario.SelectParameters[0].DefaultValue = Session["INST_ID"].ToString();
            //odsCalendario.DataBind();
            //ASPxScheduler1.DataBind();

        }

        protected void ASPxScheduler1_AppointmentFormShowing(object sender, DevExpress.Web.ASPxScheduler.AppointmentFormEventArgs e)
        {
            e.Container = new AppointmentFormTemplateContainer((ASPxScheduler)sender);
        }

        protected void ASPxScheduler1_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {

        }
    }
}