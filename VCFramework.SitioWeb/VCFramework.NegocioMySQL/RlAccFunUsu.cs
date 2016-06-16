﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VCFramework.Negocio.Factory;

namespace VCFramework.NegocioMySQL
{
    public class RlAccFunUsu
    {
        public static System.Configuration.ConnectionStringSettings setCns = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MSUsuarioLunConectionString"];

        public static List<VCFramework.Entidad.RlAccFunUsu> ListarRelacionPorUsuId(int usuId)
        {
            Factory fac = new Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "USU_ID";
            filtro.Valor = usuId.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;

            List<object> lista = fac.Leer<VCFramework.Entidad.RlAccFunUsu>(filtro, setCns);
            List<VCFramework.Entidad.RlAccFunUsu> lista2 = new List<VCFramework.Entidad.RlAccFunUsu>();
            if (lista != null)
            {

                lista2 = lista.Cast<VCFramework.Entidad.RlAccFunUsu>().ToList();
            }

            return lista2;
        }
    }
}
