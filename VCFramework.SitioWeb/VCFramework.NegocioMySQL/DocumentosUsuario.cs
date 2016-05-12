using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class DocumentosUsuario
    {
        public static List<VCFramework.Entidad.DocumentosUsuario> ObtenerDocumentosPorInstId(int instId)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "INST_ID";
            filtro.Valor = instId.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.DocumentosUsuario>(filtro);
            List<VCFramework.Entidad.DocumentosUsuario> lista2 = new List<VCFramework.Entidad.DocumentosUsuario>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.DocumentosUsuario>().ToList();
            }
            if (lista2 != null)
                lista2 = lista2.FindAll(p => p.Eliminado == 0);
            return lista2;
        }
        public static VCFramework.Entidad.DocumentosUsuario ObtenerDocumentoId(int id)
        {
            VCFramework.Entidad.DocumentosUsuario retorno = new Entidad.DocumentosUsuario();
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ID";
            filtro.Valor = id.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.DocumentosUsuario>(filtro);
            List<VCFramework.Entidad.DocumentosUsuario> lista2 = new List<VCFramework.Entidad.DocumentosUsuario>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.DocumentosUsuario>().ToList().FindAll(p => p.Eliminado == 0);
            }
            if (lista2 != null)
                retorno = lista2[0];

            return retorno;
        }
    }
}
