using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class IngresoEgreso
    {
        public static List<VCFramework.EntidadFuniconal.IngresoEgresoFuncional> ObtenerIngresoEgresoPorInstId(int instId)
        {
            List<VCFramework.EntidadFuniconal.IngresoEgresoFuncional> retorno = new List<EntidadFuniconal.IngresoEgresoFuncional>();
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "INST_ID";
            filtro.Valor = instId.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.IngresoEgreso>(filtro);
            List<VCFramework.Entidad.IngresoEgreso> lista2 = new List<VCFramework.Entidad.IngresoEgreso>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.IngresoEgreso>().ToList().FindAll(p => p.Eliminado == 0);
            }
            if (lista2 != null)
                lista2 = lista2.FindAll(p => p.Eliminado == 0);

            if (lista2 != null && lista2.Count > 0)
            {
                foreach (Entidad.IngresoEgreso ing in lista)
                {
                    if (ing.Eliminado == 0)
                    {
                        EntidadFuniconal.IngresoEgresoFuncional entidad = new EntidadFuniconal.IngresoEgresoFuncional();
                        entidad.Detalle = ing.Detalle;
                        entidad.Eliminado = ing.Eliminado;
                        entidad.FechaMovimiento = ing.FechaMovimiento;
                        entidad.FechaMovimientoDate = entidad.FechaMovimiento;
                        entidad.Id = ing.Id;
                        entidad.InstId = ing.InstId;
                        entidad.Monto = ing.Monto;
                        entidad.NumeroComprobante = ing.NumeroComprobante;
                        entidad.TipoMovimiento = ing.TipoMovimiento;
                        TipoOperacion tipoMov = TipoOperacion.Ingreso;
                        switch (entidad.TipoMovimiento)
                        {
                            case 1:
                                tipoMov = TipoOperacion.Ingreso;
                                entidad.Icon = "foundicon-left-arrow fg-blue";
                                break;
                            case 2:
                                tipoMov = TipoOperacion.Egreso;
                                entidad.Icon = "foundicon-right-arrow fg-red";
                                break;
                        }
                        entidad.TipoMovimientoString = tipoMov.ToString();
                        entidad.UrlDocumento = ing.UrlDocumento;
                        entidad.UsuId = ing.UsuId;
                        if (entidad.UrlDocumento != null)
                        {
                            string[] nombres = entidad.UrlDocumento.Split('/');
                            string nombre = nombres[nombres.Length - 1].ToString();
                            entidad.NombreDocumento = nombre;
                        }
                        retorno.Add(entidad);
                    }
                }
            }

            return retorno;
        }

        public static VCFramework.EntidadFuniconal.IngresoEgresoFuncional ObtenerIngresoEgresoPorId(int id)
        {
            VCFramework.EntidadFuniconal.IngresoEgresoFuncional retorno = new EntidadFuniconal.IngresoEgresoFuncional();
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ID";
            filtro.Valor = id.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.IngresoEgreso>(filtro);
            List<VCFramework.Entidad.IngresoEgreso> lista2 = new List<VCFramework.Entidad.IngresoEgreso>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.IngresoEgreso>().ToList().FindAll(p => p.Eliminado == 0);
            }
            if (lista2 != null)
                lista2 = lista2.FindAll(p => p.Eliminado == 0);

            if (lista2 != null && lista2.Count > 0)
            {
                foreach (Entidad.IngresoEgreso ing in lista)
                {
                    if (ing.Eliminado == 0)
                    {
                        EntidadFuniconal.IngresoEgresoFuncional entidad = new EntidadFuniconal.IngresoEgresoFuncional();
                        entidad.Detalle = ing.Detalle;
                        entidad.Eliminado = ing.Eliminado;
                        entidad.FechaMovimiento = ing.FechaMovimiento;
                        entidad.FechaMovimientoDate = entidad.FechaMovimiento;
                        entidad.Id = ing.Id;
                        entidad.InstId = ing.InstId;
                        entidad.Monto = ing.Monto;
                        entidad.NumeroComprobante = ing.NumeroComprobante;
                        entidad.TipoMovimiento = ing.TipoMovimiento;
                        TipoOperacion tipoMov = TipoOperacion.Ingreso;
                        switch (entidad.TipoMovimiento)
                        {
                            case 1:
                                tipoMov = TipoOperacion.Ingreso;
                                entidad.Icon = "foundicon-left-arrow fg-blue";
                                break;
                            case 2:
                                tipoMov = TipoOperacion.Egreso;
                                entidad.Icon = "foundicon-right-arrow fg-red";
                                break;
                        }
                        entidad.TipoMovimientoString = tipoMov.ToString();
                        entidad.UrlDocumento = ing.UrlDocumento;
                        entidad.UsuId = ing.UsuId;
                        if (entidad.UrlDocumento != null)
                        {
                            string[] nombres = entidad.UrlDocumento.Split('/');
                            string nombre = nombres[nombres.Length - 1].ToString();
                            entidad.NombreDocumento = nombre;
                        }
                        retorno = entidad;
                    }
                }
            }

            return retorno;
        }

        public static string SumaEgresosIngresos(int instId)
        {
            string retorno = "0";
            int ingresos = 0;
            int egresos = 0;
            List<VCFramework.EntidadFuniconal.IngresoEgresoFuncional> listaProcesar = ObtenerIngresoEgresoPorInstId(instId);
            if (listaProcesar != null && listaProcesar.Count > 0)
            {
                foreach(EntidadFuniconal.IngresoEgresoFuncional ing in listaProcesar)
                {
                    if (ing.TipoMovimiento == 1)
                        ingresos = ingresos + ing.Monto;
                    else
                        egresos = egresos + ing.Monto;
                }
            }
            retorno = ingresos.ToString() + "|" + egresos.ToString();

            return retorno;
        }
    }
    public enum TipoOperacion
    {
        Ingreso = 1,
        Egreso = 2
    }
}
