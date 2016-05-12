using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class UsuarioLista
    {
        public static List<VCFramework.Entidad.UsuarioLista> Obtener(int idLista)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "LTR_ID";
            filtro.Valor = idLista.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.UsuarioLista>(filtro);
            List<VCFramework.Entidad.UsuarioLista> lista2 = new List<VCFramework.Entidad.UsuarioLista>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.UsuarioLista>().ToList();
            }
            if (lista2 != null)
                lista2 = lista2.FindAll(p => p.Eliminado == 0);
            return lista2;
        }
        public static VCFramework.Entidad.UsuarioLista ObtenerId(int id)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ID";
            filtro.Valor = id.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.UsuarioLista>(filtro);
            List<VCFramework.Entidad.UsuarioLista> lista2 = new List<VCFramework.Entidad.UsuarioLista>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.UsuarioLista>().ToList();
            }
            if (lista2 != null)
            {
                lista2 = lista2.FindAll(p => p.Eliminado == 0);

                return lista2[0];
            }
            else
                return new Entidad.UsuarioLista();
        }
        public static VCFramework.Entidad.UsuarioLista ObtenerIdLtr(string rol, int ltrId)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "ROL";
            filtro.Valor = rol.ToString();
            filtro.TipoDato = TipoDatoGeneral.Varchar;

            FiltroGenerico filtro2 = new FiltroGenerico();
            filtro2.Campo = "LTR_ID";
            filtro2.Valor = ltrId.ToString();
            filtro2.TipoDato = TipoDatoGeneral.Entero;

            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            filtros.Add(filtro);
            filtros.Add(filtro2);

            List<object> lista = fac.Leer<VCFramework.Entidad.UsuarioLista>(filtros);
            List<VCFramework.Entidad.UsuarioLista> lista2 = new List<VCFramework.Entidad.UsuarioLista>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.UsuarioLista>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                lista2 = lista2.FindAll(p => p.Eliminado == 0);

                return lista2[0];
            }
            else
                return new Entidad.UsuarioLista();
        }
    }
}
