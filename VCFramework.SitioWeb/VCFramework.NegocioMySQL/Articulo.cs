using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySQL
{
    public class Articulo
    {
        public static int Modificar(Entidad.Articulo item)
        {
            int retorno = 0;

            item.Modificado = true;
            item.Nuevo = false;
            item.Borrado = false;

            Factory fac = new Factory();

            retorno = fac.Update<Entidad.Articulo>(item);

            return retorno;
        }
    }
}
