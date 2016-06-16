using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VCFramework.Negocio.Factory;

namespace VCFramework.NegocioMySQL
{
    public class Encabezado
    {
        public static System.Configuration.ConnectionStringSettings setCns = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MSUsuarioLunConectionString"];

        public static int Modificar(Entidad.Encabezado item)
        {
            int retorno = 0;

            item.Modificado = true;
            item.Nuevo = false;
            item.Borrado = false;

            Factory fac = new Factory();

            retorno = fac.Update<Entidad.Encabezado>(item, setCns);

            return retorno;
        }
        public static List<Entidad.Encabezado> Obtener(int idIstitucion)
        {
            Factory fac = new Factory();
            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "INST_ID";
            filtro.Valor = idIstitucion.ToString();
            List<object> lista = fac.Leer<Entidad.Encabezado>(filtro, setCns);
            List<Entidad.Encabezado> lista2 = new List<Entidad.Encabezado>();
            if (lista != null)
            {
                lista2 = lista.Cast<Entidad.Encabezado>().ToList();
            }
            return lista2;
        }
    }
}
