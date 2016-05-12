using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace VCFramework.SitioWeb
{
    public class ReportesLogic
    {

        public static List<EntidadFuniconal.ReporteActas> ObtenerReporteActas(int idInst)
        {
            List<EntidadFuniconal.ReporteActas> lista = new List<EntidadFuniconal.ReporteActas>();

            List<Entidad.Documentos> listaDocumentos = NegocioMySQL.Documentos.ObtenerDocumentosPorInstId(idInst);

            if (listaDocumentos != null && listaDocumentos.Count > 0)
            {
                foreach (Entidad.Documentos doc in listaDocumentos)
                {
                    EntidadFuniconal.ReporteActas acta = new EntidadFuniconal.ReporteActas();
                    acta.FechaSubida = doc.FechaSubida;
                    acta.NombreDocumento = doc.NombreArchivo;
                    Entidad.Persona persona = NegocioMySQL.Persona.ObtenerPersonaPorUsuId(doc.UsuId);
                    if (persona != null && persona.Id > 0)
                        acta.NombreUsuarioCargador = persona.Nombres + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno;
                    acta.TipoDocumento = "Acta";
                    lista.Add(acta);
                }



            }
            return lista;
        }
        private static DateTime ConvertirFecha(string fecha)
        {
            DateTime fechaDocumento = DateTime.MinValue;
            if (fecha != null && fecha != string.Empty)
            {
                if (fecha.Contains("-"))
                {
                    fechaDocumento = Convert.ToDateTime(fecha);
                }
                else
                {
                    string[] partesFecha = fecha.Split(' ');
                    if (partesFecha != null && partesFecha.Length == 3)
                    {
                        string[] partes2 = partesFecha[0].Split('/');
                        string partesHora = partesFecha[1];
                        string fecha1 = partes2[1] + "-" + partes2[0] + "-" + partes2[2] + " " + partesHora;
                        fechaDocumento = Convert.ToDateTime(fecha1);
                    }
                }
            }
            return fechaDocumento;
        }
        public static List<EntidadFuniconal.ReporteActas> ObtenerReporteActasPorFecha(int idInst, DateTime fechaIni, DateTime fechaTer)
        {
            List<EntidadFuniconal.ReporteActas> lista = new List<EntidadFuniconal.ReporteActas>();

            List<Entidad.Documentos> listaDocumentos = NegocioMySQL.Documentos.ObtenerDocumentosPorInstId(idInst);

            if (listaDocumentos != null && listaDocumentos.Count > 0)
            {

                foreach (Entidad.Documentos doc in listaDocumentos)
                {
                    DateTime fechaDocumento = ConvertirFecha(doc.FechaSubida);
                    if (fechaDocumento >= fechaIni && fechaDocumento <= fechaTer)
                    {
                        EntidadFuniconal.ReporteActas acta = new EntidadFuniconal.ReporteActas();
                        acta.FechaSubida = fechaDocumento.ToShortDateString() + " " + fechaDocumento.ToShortTimeString();
                        acta.NombreDocumento = doc.NombreArchivo;
                        Entidad.Persona persona = NegocioMySQL.Persona.ObtenerPersonaPorUsuId(doc.UsuId);
                        if (persona != null && persona.Id > 0)
                            acta.NombreUsuarioCargador = persona.Nombres + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno;
                        acta.TipoDocumento = "Acta";
                        lista.Add(acta);
                    }
                }



            }
            return lista;
        }
        public static List<EntidadFuniconal.ReporteRendiciones> ObtenerReporteRendiciones(int idInst)
        {
            List<EntidadFuniconal.ReporteRendiciones> lista = new List<EntidadFuniconal.ReporteRendiciones>();

            List<EntidadFuniconal.IngresoEgresoFuncional> listaDocumentos = NegocioMySQL.IngresoEgreso.ObtenerIngresoEgresoPorInstId(idInst);

            if (listaDocumentos != null && listaDocumentos.Count > 0)
            {
                foreach (EntidadFuniconal.IngresoEgresoFuncional doc in listaDocumentos)
                {
                    EntidadFuniconal.ReporteRendiciones acta = new EntidadFuniconal.ReporteRendiciones();
                    acta.FechaSubida = doc.FechaMovimiento.ToShortDateString() + " " + doc.FechaMovimiento.ToShortTimeString();
                    acta.NombreDocumento = doc.Detalle;
                    Entidad.Persona persona = NegocioMySQL.Persona.ObtenerPersonaPorUsuId(doc.UsuId);
                    if (persona != null && persona.Id > 0)
                        acta.NombreUsuarioCargador = persona.Nombres + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno;
                    if (doc.TipoMovimiento == 1)
                        acta.TipoMovimiento = "Ingreso";
                    else
                        acta.TipoMovimiento = "Egreso";
                    acta.NumeroComprobante = doc.NumeroComprobante;
                    acta.Monto = doc.Monto.ToString();

                    lista.Add(acta);
                }



            }
            return lista;
        }

        public static List<EntidadFuniconal.ReporteRendiciones> ObtenerReporteRendicionesPorFiltro(int idInst, DateTime fechaIni, DateTime fechaTer, int tipo)
        {
            List<EntidadFuniconal.ReporteRendiciones> lista = new List<EntidadFuniconal.ReporteRendiciones>();

            List<EntidadFuniconal.IngresoEgresoFuncional> listaDocumentos = NegocioMySQL.IngresoEgreso.ObtenerIngresoEgresoPorInstId(idInst);

            if (listaDocumentos != null && listaDocumentos.Count > 0)
            {
                foreach (EntidadFuniconal.IngresoEgresoFuncional doc in listaDocumentos)
                {
                    DateTime fechaDocumento = doc.FechaMovimiento;
                    if (fechaDocumento >= fechaIni && fechaDocumento <= fechaTer)
                    {

                            EntidadFuniconal.ReporteRendiciones acta = new EntidadFuniconal.ReporteRendiciones();
                            acta.FechaSubida = doc.FechaMovimiento.ToShortDateString() + " " + doc.FechaMovimiento.ToShortTimeString();
                            acta.NombreDocumento = doc.Detalle;
                            Entidad.Persona persona = NegocioMySQL.Persona.ObtenerPersonaPorUsuId(doc.UsuId);
                            if (persona != null && persona.Id > 0)
                                acta.NombreUsuarioCargador = persona.Nombres + " " + persona.ApellidoPaterno + " " + persona.ApellidoMaterno;
                            if (doc.TipoMovimiento == 1)
                                acta.TipoMovimiento = "Ingreso";
                            else
                                acta.TipoMovimiento = "Egreso";
                            acta.NumeroComprobante = doc.NumeroComprobante;
                            acta.Monto = doc.Monto.ToString();

                            lista.Add(acta);

                    }
                }
                if (tipo != 0)
                {
                    if (tipo == 1)
                        lista = lista.FindAll(p => p.TipoMovimiento == "Ingreso");
                    else
                        lista = lista.FindAll(p => p.TipoMovimiento == "Egreso");
                }



            }
            return lista;
        }
        public static List<EntidadFuniconal.ReporteVotaciones> ObtenerReporteVotaciones(int idInst, DateTime fechaIni, DateTime fechaTer)
        {
            List<EntidadFuniconal.ReporteVotaciones> listaDevolver = new List<EntidadFuniconal.ReporteVotaciones>();
            List<Entidad.Proyectos> lista = new List<Entidad.Proyectos>();

            lista = NegocioMySQL.Proyectos.ObtenerProyectosPorInstIdN(idInst);
            if (lista != null && lista.Count > 0)
            {
                lista = lista.FindAll(p => p.FechaInicio >= fechaIni && p.FechaInicio <= fechaTer);
                //procesamos la lista
                if (lista.Count > 0)
                {
                    foreach(Entidad.Proyectos proyecto in lista)
                    {
                        EntidadFuniconal.ReporteVotaciones votacion = new EntidadFuniconal.ReporteVotaciones();
                        votacion.Id = proyecto.Id;
                        votacion.Beneficios = proyecto.Beneficios;
                        votacion.Costo = proyecto.Costo;
                        votacion.Descripcion = proyecto.Descripcion;
                        votacion.FechaCreacion = proyecto.FechaCreacion;
                        votacion.FechaInicio = proyecto.FechaInicio;
                        votacion.FechaTermino = proyecto.FechaTermino;
                        votacion.Nombre = proyecto.Nombre;
                        votacion.Objetivo = proyecto.Objetivo;
                        //ahora buscamos los archivos del proyecto
                        StringBuilder sbArchivos = new StringBuilder();
                        List<Entidad.ArchivosProyecto> archivos= NegocioMySQL.ArchivosProyecto.ObtenerArchivosPorProyectoId(proyecto.Id, null);
                        if (archivos != null && archivos.Count > 0)
                        {
                            foreach(Entidad.ArchivosProyecto arc in archivos)
                            {
                                sbArchivos.AppendFormat("Archivo {0}, subido con fecha {1}", arc.RutaArchivo, proyecto.FechaCreacion.ToShortDateString());
                                sbArchivos.Append("\r\n");
                            }
                        }
                        votacion.DocumentosDelProyecto = sbArchivos.ToString();
                        //ahora buscamos la cantidad de usuarios de la institucion
                        List<Entidad.AutentificacionUsuario> usuarios = NegocioMySQL.AutentificacionUsuario.ListarUsuariosPorInstId(idInst);
                        //usuarios = usuarios.FindAll(p => p.RolId == 9);
                        if (usuarios != null && usuarios.Count > 0)
                        {
                            votacion.CantidadApoderadosInscritos = usuarios.Count;
                        }
                        //ahora la cantidad de votaciones
                        List<Entidad.Votaciones> votaciones = NegocioMySQL.Votaciones.ObtenerVotaciones(proyecto.Id);
                        int votacionesSi = 0;
                        int votacionesNo = 0;
                        if (votaciones != null && votaciones.Count > 0)
                        {
                            foreach(Entidad.Votaciones vot in votaciones)
                            {
                                if (vot.Valor == 1)
                                    votacionesSi++;
                                else
                                    votacionesNo++;
                            }
                        }
                        votacion.CantidadVotosNo = votacionesNo;
                        votacion.CantidadVotosSi = votacionesSi;

                        listaDevolver.Add(votacion);
                    }
                }

            }

            return listaDevolver;
        }

        public static EntidadFuniconal.ReporteEncabezado ObtenerEncabezado(string nombreCompleto, string institucion, string fechaInicio, string fechaTermino, string nombreReporte, string detalle)
        {
            EntidadFuniconal.ReporteEncabezado rpt = new EntidadFuniconal.ReporteEncabezado();

            rpt.Detalle = detalle;
            rpt.FechaInicio = fechaInicio;
            rpt.FechaTermino = fechaTermino;
            rpt.FuncionarioSolicitador = nombreCompleto;
            rpt.NombreInstitucion = institucion;
            rpt.NombreReporte = nombreReporte;

            return rpt;

        }

    }

}