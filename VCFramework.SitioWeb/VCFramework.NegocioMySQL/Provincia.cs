using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using VCFramework.Negocio.Factory;

namespace VCFramework.NegocioMySQL
{
    public class Provincia
    {
        public static System.Configuration.ConnectionStringSettings setCns = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BDColegioSql"];
        public static System.Configuration.ConnectionStringSettings setCnsWebLun = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MSUsuarioLunConectionString"];


        static ObjectCache cache = MemoryCache.Default;
        private static List<VCFramework.Entidad.Provincia> fileContents = cache["fileContentsProv"] as List<VCFramework.Entidad.Provincia>;
        //este esta en días
        private static DateTimeOffset tiempoCache = Cache.Mensual();
        private static string nombreArchivo = "cacheProvincia.txt";

        public static List<VCFramework.Entidad.Provincia> ListarProvincias()
        {
            Factory fac = new Factory();
            List<VCFramework.Entidad.Provincia> lista2 = new List<VCFramework.Entidad.Provincia>();

            if (fileContents == null)
            {
                List<object> lista = fac.Leer<VCFramework.Entidad.Provincia>(setCns);

                if (lista != null)
                {
                    lista2 = lista.Cast<VCFramework.Entidad.Provincia>().ToList();
                }
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = tiempoCache;

                List<string> filePaths = new List<string>();
                string cacheFilePath = AppDomain.CurrentDomain.BaseDirectory + nombreArchivo;

                filePaths.Add(cacheFilePath);

                policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                fileContents = lista2;

                cache.Set("fileContentsProv", fileContents, policy);
            }
            else
            {
                lista2 = fileContents.Cast<VCFramework.Entidad.Provincia>().ToList();
            }
            return lista2;
        }
        public static List<VCFramework.Entidad.Provincia> ObtenerProvinciasDeLaRegion(string regId)
        {
            Factory fac = new Factory();
            List<VCFramework.Entidad.Provincia> lista2 = new List<VCFramework.Entidad.Provincia>();

            lista2 = ListarProvincias().FindAll(p => p.RegId == int.Parse(regId));
            
            return lista2;
        }


    }
}
