using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace VCFramework.SitioWeb.WebService
{
    /// <summary>
    /// Summary description for Proyectos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Proyectos : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Entidad.Proyectos> ObtenerProyectosListadosTricel(int instId, int usuId)
        {
            List<Entidad.Proyectos> lista = new List<Entidad.Proyectos>();
            try
            {
                lista = NegocioMySQL.Proyectos.ObtenerProyectosListasPorInstId(instId, usuId);
            }
            catch (Exception ex)
            {
                NegocioMySQL.Utiles.Log(ex);
            }
            return lista;
        }
    }
}
