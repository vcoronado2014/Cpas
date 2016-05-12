using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Tricel
{
    public partial class ListadoTricel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioFuncional usu = new UsuarioFuncional();

            if (Session["USUARIO_AUTENTICADO"] != null)
            {
                usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;

                if (usu != null && usu.AutentificacionUsuario.Id > 0)
                {
                    Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                    Session["USU_ID"] = usu.AutentificacionUsuario.Id;

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

        protected void grillaDocumentos_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "FechaCreacion")
                e.Cell.Text = Convert.ToDateTime(e.CellValue.ToString()).ToShortDateString();
            if (e.DataColumn.FieldName == "FechaInicio")
                e.Cell.Text = Convert.ToDateTime(e.CellValue.ToString()).ToShortDateString();
            if (e.DataColumn.FieldName == "FechaTermino")
                e.Cell.Text = Convert.ToDateTime(e.CellValue.ToString()).ToShortDateString();
        }
    }

}