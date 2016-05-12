using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class RlAccFunUsu
    {
        public static List<VCFramework.Entidad.RlAccFunUsu> ListarRelacionPorUsuId(int usuId)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "USU_ID";
            filtro.Valor = usuId.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.RlAccFunUsu>(filtro);
            List<VCFramework.Entidad.RlAccFunUsu> lista2 = new List<VCFramework.Entidad.RlAccFunUsu>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.RlAccFunUsu>().ToList();
            }

            return lista2;
        }
    }
}
