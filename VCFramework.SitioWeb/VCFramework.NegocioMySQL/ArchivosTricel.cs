using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class ArchivosTricel
    {
        public static List<VCFramework.Entidad.ArchivosTricel> ObtenerArchivosPorTricelId(int triId, object listaSesion)
        {

            if (listaSesion != null)
            {
                List<VCFramework.Entidad.ArchivosTricel> lista = listaSesion as List<VCFramework.Entidad.ArchivosTricel>;
                return lista;
            }
            else
            {
                VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
                FiltroGenerico filtro = new FiltroGenerico();
                filtro.Campo = "TRI_ID";
                filtro.Valor = triId.ToString();
                filtro.TipoDato = TipoDatoGeneral.Entero;

                List<object> lista = fac.Leer<VCFramework.Entidad.ArchivosTricel>(filtro);
                List<VCFramework.Entidad.ArchivosTricel> lista2 = new List<VCFramework.Entidad.ArchivosTricel>();
                if (lista != null)
                {

                    lista2 = lista.Cast<VCFramework.Entidad.ArchivosTricel>().ToList();
                }
                if (lista2 != null)
                    lista2 = lista2.FindAll(p => p.Eliminado == 0);
                return lista2;
            }
        }

        public static List<VCFramework.Entidad.ArchivosTricel> ObtenerArchivoPorId(int id)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ID";
            filtro.Valor = id.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.ArchivosTricel>(filtro);
            List<VCFramework.Entidad.ArchivosTricel> lista2 = new List<VCFramework.Entidad.ArchivosTricel>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.ArchivosTricel>().ToList();
            }
            if (lista2 != null)
                lista2 = lista2.FindAll(p => p.Eliminado == 0);
            return lista2;
        }
    }
}
