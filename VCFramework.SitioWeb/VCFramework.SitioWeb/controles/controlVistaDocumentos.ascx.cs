using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace VCFramework.SitioWeb.controles
{
    public partial class controlVistaDocumentos : System.Web.UI.UserControl
    {
        public void EsconderFiltro()
        {
            grillaDocumentos.Settings.ShowFilterRow = false;
        }
        public void EsconderColumnas()
        {
            grillaDocumentos.Columns[5].Visible = false;
            grillaDocumentos.Columns[2].Visible = false;
            grillaDocumentos.Columns[3].Visible = false;
            grillaDocumentos.Font.Size = 7;
        }
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
                    //Response.Redirect("~/default.aspx");
                }
            }
            else
            {
                //retorno
                //Response.Redirect("~/default.aspx");
            }
        }


        protected void grillaDocumentos_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters != "")
            {

                ODSLISTADO.DataBind();
                grillaDocumentos.DataBind();
            }
        }

        protected void grillaDocumentos_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "Tamano")
            {
                e.Cell.Text = e.CellValue.ToString() + " Kb.";
            }
            if (e.DataColumn.FieldName == "NombreArchivo")
            {
                StringBuilder sb = new StringBuilder();
                string[] texto = e.CellValue.ToString().Split(' ');
                string nuevoNombre = string.Empty;
                if (texto.Length > 0)
                {
                    for (int i = 0; i < texto.Length; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(texto[i]);
                            sb.Append(" ");
                        }
                    }
                }
                e.Cell.Text = sb.ToString();
            }
        }

        protected void grillaDocumentos_FocusedRowChanged(object sender, EventArgs e)
        {
            //if (grillaDocumentos.FocusedRowIndex > 0)
            //{
            //    Response.Redirect("~/usuario/vistadocumentos.aspx");
            //}
        }
    }
}