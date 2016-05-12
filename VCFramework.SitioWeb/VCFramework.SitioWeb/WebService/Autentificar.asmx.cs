using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace VCFramework.SitioWeb.WebService
{
    /// <summary>
    /// Summary description for Autentificar
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Autentificar : System.Web.Services.WebService
    {

        [WebMethod]
        public string Validar(string usuario, string clave)
        {
            string retorno = "";
            UsuarioFuncional usu = null;
            try {
                usu = new UsuarioFuncional();
                usu = VCFramework.SitioWeb.LogicLogin.ObtenerUsuario(usuario, clave);
                if (usu != null && usu.AutentificacionUsuario != null && usu.AutentificacionUsuario.Id > 0)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    retorno = js.Serialize(usu);

                    //retorno = usu.Persona.Nombres + " "+ usu.Persona.ApellidoPaterno + " " + usu.Persona.ApellidoMaterno;
                }
            }
            catch(Exception ex)
            {
                NegocioMySQL.Utiles.Log(ex);
            }
            return retorno;
        }

        [WebMethod]
        public string ObtenerProyectosListadosTricel(string instId, string usuId)
        {
            string retorno = "";
            int idInst = int.Parse(instId);
            int idUsu = int.Parse(usuId);
            List<Entidad.Proyectos> lista = new List<Entidad.Proyectos>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                lista = NegocioMySQL.Proyectos.ObtenerProyectosListasPorInstId(idInst, idUsu);
                if (lista != null && lista.Count > 0)
                {
                    retorno = js.Serialize(lista);
                }
                else
                    retorno = ObtenerProyecto();
            }
            catch (Exception ex)
            {
                NegocioMySQL.Utiles.Log(ex);
            }
            return retorno;
        }
        [WebMethod]
        public string ObtenerDocumentos(string instId)
        {
            int idInst = int.Parse(instId);
            string retorno = "";
            List<Entidad.Documentos> lista = new List<Entidad.Documentos>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                lista = NegocioMySQL.Documentos.ObtenerDocumentosPorInstId(idInst);
                if (lista != null && lista.Count > 0)
                {
                    retorno = js.Serialize(lista);
                }
                else
                    retorno = ObtenerDocumentoAsamblea();
            }
            catch (Exception ex)
            {
                NegocioMySQL.Utiles.Log(ex);
            }
            return retorno;
        }

        [WebMethod]
        public string ObtenerDocumentosUsuario(string instId)
        {
            int idInst = int.Parse(instId);
            string retorno = "";
            List<Entidad.DocumentosUsuario> lista = new List<Entidad.DocumentosUsuario>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                lista = NegocioMySQL.DocumentosUsuario.ObtenerDocumentosPorInstId(idInst);
                if (lista != null && lista.Count > 0)
                {
                    retorno = js.Serialize(lista);
                }
                else
                    retorno = ObtenerDocumento();

            }
            catch (Exception ex)
            {
                NegocioMySQL.Utiles.Log(ex);
            }
            return retorno;
        }


        [WebMethod]
        public string ObtenerNotificaciones(string instId, string usuId)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("es-CL", true);
            DateTime fechaHoraActual = DateTime.Now;
            DateTime fechaHoraComprarar = DateTime.Now.AddMinutes(-5);
            string retorno = "";
            int idInst = int.Parse(instId);
            int idUsu = int.Parse(usuId);
            List<Entidad.Proyectos> lista = new List<Entidad.Proyectos>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<NotificacionRetorno> listaDevolver = new List<NotificacionRetorno>();
            //primero obtenemos los proyectos y las listas tricel
            List<Entidad.Proyectos> listaProyectosTricel = NegocioMySQL.Proyectos.ObtenerProyectosListasPorInstId(idInst, idUsu);
            if (listaProyectosTricel != null && listaProyectosTricel.Count > 0)
            {
                listaProyectosTricel = listaProyectosTricel.FindAll(p => p.FechaCreacion >= fechaHoraComprarar);
                //procesar de acuerdo a la fecha hora
                if (listaProyectosTricel != null && listaProyectosTricel.Count > 0)
                {
                    foreach(Entidad.Proyectos proy in listaProyectosTricel)
                    {
                        NotificacionRetorno not = new NotificacionRetorno();
                        not.Fecha = proy.FechaInicio.ToShortDateString() + " - " + proy.FechaTermino.ToShortDateString();
                        not.Id = proy.Id;
                        not.Nombre = proy.Nombre;
                        not.Tipo = 1;
                        not.Url = "";
                        listaDevolver.Add(not);
                    }
                }

            }
            List<Entidad.Documentos> listaDocumentos = NegocioMySQL.Documentos.ObtenerDocumentosPorInstId(idInst);
            if (listaDocumentos != null && listaDocumentos.Count > 0)
            {
                //listaDocumentos = listaDocumentos.FindAll(p => DateTime.Parse(p.FechaSubida, culture, System.Globalization.DateTimeStyles.AssumeLocal) >= fechaHoraComprarar);
                if (listaDocumentos != null && listaDocumentos.Count > 0)
                {
                    foreach(Entidad.Documentos doc in listaDocumentos)
                    {

                        DateTime fechaDocumento = DateTime.MinValue;
                        if (doc.FechaSubida != null && doc.FechaSubida != string.Empty)
                        {
                            if (doc.FechaSubida.Contains("-"))
                            {
                                fechaDocumento = Convert.ToDateTime(doc.FechaSubida);
                            }
                            else
                            {
                                string[] partesFecha = doc.FechaSubida.Split(' ');
                                if (partesFecha != null && partesFecha.Length == 3)
                                {
                                    string[] partes2 = partesFecha[0].Split('/');
                                    string partesHora = partesFecha[1];
                                    string fecha = partes2[1] + "-" + partes2[0] + "-" + partes2[2] + " " + partesHora;
                                    fechaDocumento = Convert.ToDateTime(fecha);
                                }
                            }
                        }
                        if (fechaDocumento != DateTime.MinValue && fechaDocumento >= fechaHoraComprarar)
                        {
                            NotificacionRetorno not = new NotificacionRetorno();
                            not.Fecha = doc.FechaSubida;
                            not.Id = doc.Id;
                            not.Nombre = doc.NombreArchivo;
                            not.Tipo = 2;
                            not.Url = doc.Url;
                            listaDevolver.Add(not);
                        }
                    }
                }
            }
            List<Entidad.DocumentosUsuario> listaDocumentosUsuario = NegocioMySQL.DocumentosUsuario.ObtenerDocumentosPorInstId(idInst);
            if (listaDocumentosUsuario != null && listaDocumentosUsuario.Count > 0)
            {
                //listaDocumentos = listaDocumentos.FindAll(p => DateTime.Parse(p.FechaSubida, culture, System.Globalization.DateTimeStyles.AssumeLocal) >= fechaHoraComprarar);
                if (listaDocumentosUsuario != null && listaDocumentos.Count > 0)
                {
                    foreach (Entidad.DocumentosUsuario doc in listaDocumentosUsuario)
                    {

                        DateTime fechaDocumento = DateTime.MinValue;
                        if (doc.FechaSubida != null && doc.FechaSubida != string.Empty)
                        {
                            if (doc.FechaSubida.Contains("-"))
                            {
                                fechaDocumento = Convert.ToDateTime(doc.FechaSubida);
                            }
                            else
                            {
                                string[] partesFecha = doc.FechaSubida.Split(' ');
                                if (partesFecha != null && partesFecha.Length == 3)
                                {
                                    string[] partes2 = partesFecha[0].Split('/');
                                    string partesHora = partesFecha[1];
                                    string fecha = partes2[1] + "-" + partes2[0] + "-" + partes2[2] + " " + partesHora;
                                    fechaDocumento = Convert.ToDateTime(fecha);
                                }
                            }
                        }
                        if (fechaDocumento != DateTime.MinValue && fechaDocumento >= fechaHoraComprarar)
                        {
                            NotificacionRetorno not = new NotificacionRetorno();
                            not.Fecha = doc.FechaSubida;
                            not.Id = doc.Id;
                            not.Nombre = doc.NombreArchivo;
                            not.Tipo = 2;
                            not.Url = doc.Url;
                            listaDevolver.Add(not);
                        }
                    }
                }
            }
            List<EntidadFuniconal.IngresoEgresoFuncional> listaRendiciones = NegocioMySQL.IngresoEgreso.ObtenerIngresoEgresoPorInstId(idInst);
            if (listaRendiciones != null && listaRendiciones.Count > 0)
            {
                listaRendiciones = listaRendiciones.FindAll(p => p.FechaMovimiento >= fechaHoraComprarar);
                if (listaRendiciones != null && listaRendiciones.Count > 0)
                {
                    foreach(EntidadFuniconal.IngresoEgresoFuncional ing in listaRendiciones)
                    {
                        NotificacionRetorno not = new NotificacionRetorno();

                        not.Fecha = ing.FechaMovimiento.ToShortDateString();
                        not.Id = ing.Id;
                        if (ing.TipoMovimiento == 1)
                            not.Nombre = "Ingreso: " + ing.NombreDocumento;
                        if (ing.TipoMovimiento == 2)
                            not.Nombre = "Egreso: " + ing.NombreDocumento;
                        
                        not.Tipo = 3;
                        not.Url = ing.UrlDocumento;
                        not.Detalle = ing.Detalle;
                        
                        listaDevolver.Add(not);
                    }
                }

            }
            if (listaDevolver.Count == 0)
            {
                NotificacionRetorno not = new NotificacionRetorno();
                not.Fecha = DateTime.Now.ToShortDateString();
                not.Id = 0;
                not.Nombre = "No hay";
                not.Tipo = 4;
                not.Url = "";
                listaDevolver.Add(not);
            }
            //el calendario no se va considerar debido a que contiene los mismos elementos creados
            //que los proyectos y las listas tricel
            try {
                retorno = js.Serialize(listaDevolver);
            }
            catch(Exception ex)
            {
                NegocioMySQL.Utiles.Log(ex);
            }
            return retorno;
        }

        [WebMethod]
        public string ObtenerRendiciones(string instId)
        {
            int idInst = int.Parse(instId);
            string retorno = "";
            List<EntidadFuniconal.IngresoEgresoFuncional> lista = new List<EntidadFuniconal.IngresoEgresoFuncional>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                lista = NegocioMySQL.IngresoEgreso.ObtenerIngresoEgresoPorInstId(idInst);
                if (lista != null && lista.Count > 0)
                {
                    retorno = js.Serialize(lista);
                }
                else
                    retorno = ObtenerRendicion();
            }
            catch (Exception ex)
            {
                NegocioMySQL.Utiles.Log(ex);
            }
            return retorno;
        }

        private string ObtenerDocumentoAsamblea()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Entidad.Documentos doc = new Entidad.Documentos();
            doc.NombreArchivo = "No Hay";
            doc.FechaSubida = DateTime.Now.ToShortDateString();
            doc.Extension = "";
            doc.Tamano = 0;
            doc.Url = "";
            return js.Serialize(doc);


        }
        private string ObtenerDocumento()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Entidad.DocumentosUsuario doc = new Entidad.DocumentosUsuario();
            doc.NombreArchivo = "No Hay";
            doc.FechaSubida = DateTime.Now.ToShortDateString();
            doc.Extension = "";
            doc.Tamano = 0;
            doc.Url = "";
            return js.Serialize(doc);


        }
        private string ObtenerRendicion()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            EntidadFuniconal.IngresoEgresoFuncional doc = new EntidadFuniconal.IngresoEgresoFuncional();
            doc.Detalle = "No Hay";
            doc.FechaMovimiento = DateTime.Now;
            doc.FechaMovimientoDate = DateTime.Now;
            doc.Icon = "";
            doc.Monto = 0;
            doc.NombreDocumento = "";
            doc.NumeroComprobante = "0";
            doc.TipoMovimientoString = "0";
            doc.UrlDocumento = "";
            return js.Serialize(doc);


        }
        private string ObtenerProyecto()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Entidad.Proyectos doc = new Entidad.Proyectos();
            doc.Nombre = "No Hay";
            doc.FechaCreacion = DateTime.Now;
            doc.Beneficios = "";
            doc.Costo = 0;
            doc.Descripcion = "";
            doc.FechaInicio = DateTime.Now;
            doc.FechaTermino = DateTime.Now;
            doc.Objetivo = "";
            return js.Serialize(doc);


        }

    }
}
