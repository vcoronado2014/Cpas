using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace VCFramework.NegocioMySQL
{
    public class Institucion
    {
        static ObjectCache cache = MemoryCache.Default;
        private static List<VCFramework.Entidad.Institucion> fileContents = cache["fileContentsInst"] as List<VCFramework.Entidad.Institucion>;
        private static DateTimeOffset tiempoCache = Cache.Fuerte();
        private static string nombreArchivo = "cacheInstitucion.txt";

        public static List<VCFramework.Entidad.Institucion> ListarInstituciones()
        {
            
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            List<VCFramework.Entidad.Institucion> lista2 = new List<VCFramework.Entidad.Institucion>();
            if (fileContents == null)
            {
                List<object> lista = fac.Leer<VCFramework.Entidad.Institucion>();

                if (lista != null)
                {
                    lista2 = lista.Cast<VCFramework.Entidad.Institucion>().ToList();
                }

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = tiempoCache;

                List<string> filePaths = new List<string>();
                string cacheFilePath = AppDomain.CurrentDomain.BaseDirectory + nombreArchivo;

                filePaths.Add(cacheFilePath);

                policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                fileContents = lista2;

                cache.Set("fileContentsInst", fileContents, policy);
            }
            else
            {
                lista2 = fileContents.Cast<VCFramework.Entidad.Institucion>().ToList();
            }
            return lista2;
        }
        public static VCFramework.Entidad.Institucion ObtenerInstitucionPorId(int id)
        {
            VCFramework.Entidad.Institucion retorno = new Entidad.Institucion();

            List<VCFramework.Entidad.Institucion> lista = ListarInstituciones();

            if (lista != null && lista.Count > 0)
            {
                retorno = lista.Find(p => p.Id == id && p.Eliminado == 0);
            }

            return retorno;
        }

    }
}
