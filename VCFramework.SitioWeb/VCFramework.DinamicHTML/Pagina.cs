using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.DinamicHTML
{
    public class Pagina
    {
        public Encabezado Encabezado { get; set; }

        public Cuerpo Cuerpo { get; set; }

        public static Encabezado ObtenerEncabezado(int idInstitucion)
        {
            Pagina retorno = new Pagina();
            retorno.Encabezado = new Encabezado();
            retorno.Encabezado = Encabezado.Obtener(idInstitucion);

            return retorno.Encabezado;
        }
        public static Cuerpo ObtenerCuerpo(int idInstitucion, int tipoArticulo)
        {
            Pagina retorno = new Pagina();
            retorno.Cuerpo = new Cuerpo();
            retorno.Cuerpo   = Cuerpo.Obtener(idInstitucion, tipoArticulo);

            return retorno.Cuerpo;
        }

    }
}
