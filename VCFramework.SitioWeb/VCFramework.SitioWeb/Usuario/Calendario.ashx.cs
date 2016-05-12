using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace VCFramework.SitioWeb.controles
{
    /// <summary>
    /// Summary description for Calendario
    /// </summary>
    public class Calendario : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            StringBuilder sb = new StringBuilder();
            string usuId = context.Request.QueryString["usuId"];

            sb.Append(VCFramework.NegocioMySQL.Calendario.ObtenerCalendarioInstJson(int.Parse(usuId)));
            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}