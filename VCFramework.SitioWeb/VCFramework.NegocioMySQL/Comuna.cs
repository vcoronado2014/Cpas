using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace VCFramework.NegocioMySQL
{
    public class Comuna
    {
        static ObjectCache cache = MemoryCache.Default;
        private static List<VCFramework.Entidad.Comuna> fileContents = cache["fileContentsCom"] as List<VCFramework.Entidad.Comuna>;
        //este esta en días
        private static DateTimeOffset tiempoCache = Cache.Mensual();
        private static string nombreArchivo = "cacheComuna.txt";

        public static List<VCFramework.Entidad.Comuna> ListarComunas()
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            List<VCFramework.Entidad.Comuna> lista2 = new List<VCFramework.Entidad.Comuna>();

            if (fileContents == null)
            {
                List<object> lista = fac.Leer<VCFramework.Entidad.Comuna>();

                if (lista != null)
                {
                    lista2 = lista.Cast<VCFramework.Entidad.Comuna>().ToList();
                }
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = tiempoCache;

                List<string> filePaths = new List<string>();
                string cacheFilePath = AppDomain.CurrentDomain.BaseDirectory + nombreArchivo;

                filePaths.Add(cacheFilePath);

                policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                fileContents = lista2;

                cache.Set("fileContentsCom", fileContents, policy);
            }
            else
            {
                lista2 = fileContents.Cast<VCFramework.Entidad.Comuna>().ToList();
            }
            return lista2;
        }
        public static List<VCFramework.Entidad.Comuna> ObtenerComunasDeLaRegion(string regId)
        {
            Entidad.Comuna comInsertar = new Entidad.Comuna();
            comInsertar.Nombre = "Seleccione";
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            List<VCFramework.Entidad.Comuna> listaRetorno = new List<VCFramework.Entidad.Comuna>();

            List<VCFramework.Entidad.Provincia> provincias = Provincia.ObtenerProvinciasDeLaRegion(regId);

            if (provincias != null && provincias.Count > 0)
            {
                

                foreach(VCFramework.Entidad.Provincia prov in provincias)
                {

                    List<VCFramework.Entidad.Comuna> comunas = ListarComunas().FindAll(p => p.ProvId == prov.Id);

                    if (comunas != null)
                    {
                        listaRetorno.AddRange(comunas);
                    }

                }
            }
            if (listaRetorno != null)
                listaRetorno.Insert(0, comInsertar);

            return listaRetorno;
        }

        public static VCFramework.Entidad.Comuna ObtenerComunaPorId(int idComuna)
        {
            return ListarComunas().Find(p => p.Id == idComuna);
        }


    }
}
