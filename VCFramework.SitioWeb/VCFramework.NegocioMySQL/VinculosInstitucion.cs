using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class VinculosInstitucion
    {
        public static List<VCFramework.Entidad.VinculosInstitucion> ObtenerPorInstId(int instId)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "INST_ID";
            filtro.Valor = instId.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.VinculosInstitucion>(filtro);
            List<VCFramework.Entidad.VinculosInstitucion> lista2 = new List<VCFramework.Entidad.VinculosInstitucion>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.VinculosInstitucion>().ToList();
            }

            return lista2;
        }

    }
}
