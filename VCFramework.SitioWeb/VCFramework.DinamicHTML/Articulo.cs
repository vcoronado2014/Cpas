using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.DinamicHTML
{
    public class Articulo
    {
        public int Id { get; set;  }
        public int Visible { get; set; }
        public int UsaImagen { get; set; }
        public string UrlImagen { get; set; }
        public string Fecha { get; set; }
        public int UsaFecha { get; set; }
        public int UsaTitulo { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public int Eliminado { get; set; }

        public int InstId { get; set; }

        public int TipoArticulo { get; set;  }

        public static List<Articulo> ListarArticulos(int idIstitucion, int tipoArticulo)
        {
            VCFramework.NegocioMySQL.Factory fac = new VCFramework.NegocioMySQL.Factory();
            VCFramework.NegocioMySQL.FiltroGenerico filtro = new NegocioMySQL.FiltroGenerico();
            filtro.Campo = "INST_ID";
            filtro.Valor = idIstitucion.ToString();
            List<Articulo> lista2 = new List<Articulo>();
            if (idIstitucion == 0)
            {
                Articulo art1 = new Articulo();
                art1.UsaImagen = 1;
                art1.UrlImagen = "~/img/quienes-somos.jpg";
                art1.UsaTitulo = 1;
                art1.Visible = 1;
                art1.Titulo = "¿QUIENES SOMOS?";
                art1.Contenido = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa. Boudin aliqua adipisicing rump corned beef.";
                lista2.Add(art1);

                Articulo art2 = new Articulo();
                art2.UsaImagen = 1;
                art2.UrlImagen = "~/img/nuestra-vision.png";
                art2.UsaTitulo = 1;
                art2.Visible = 1;
                art2.Titulo = "NUESTRA VISIÓN";
                art2.Contenido = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa. Boudin aliqua adipisicing rump corned beef.";
                lista2.Add(art2);

                Articulo art3 = new Articulo();
                art3.UsaImagen = 1;
                art3.UrlImagen = "~/img/nuestros-servicios.png";
                art3.UsaTitulo = 1;
                art3.Visible = 1;
                art3.Titulo = "NUESTROS SERVICIOS";
                art3.Contenido = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa. Boudin aliqua adipisicing rump corned beef.";
                lista2.Add(art3);
            }
            else
            {
                List<object> lista = fac.Leer<Articulo>(filtro);
                
                if (lista != null)
                {
                    //lista = lista.FindAll(p => p.TipoArticulo == tipoArticulo);
                    lista2 = lista.Cast<Articulo>().ToList().FindAll(p => p.TipoArticulo == tipoArticulo); 
                }
            }
            return lista2;
        }

    }
    public enum TipoArticuloEnum
    {
        Articulo = 1,
        Articulo_inferior = 2
    }
}
