using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.DinamicHTML
{
    public class Cuerpo
    {
        public List<Articulo> Articulos { get; set; }

        public static Cuerpo Obtener(int idInstitucion, int tipoArticulo)
        {
            Cuerpo retorno = new Cuerpo();
            retorno.Articulos = new List<Articulo>();

            if (idInstitucion == 0)
            {
                //devolver generico
                Articulo art1 = new Articulo();
                art1.UsaImagen = 1;
                art1.UrlImagen = "http://placehold.it/400x300&text=[img]";
                art1.UsaTitulo = 1;
                art1.Visible = 1;
                art1.Titulo = "This is a content section.";
                art1.Contenido = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa. Boudin aliqua adipisicing rump corned beef.";
                retorno.Articulos.Add(art1);

                Articulo art2 = new Articulo();
                art2.UsaImagen = 1;
                art2.UrlImagen = "http://placehold.it/400x300&text=[img]";
                art2.UsaTitulo = 1;
                art2.Visible = 1;
                art2.Titulo = "This is a content section.";
                art2.Contenido = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa. Boudin aliqua adipisicing rump corned beef.";
                retorno.Articulos.Add(art2);

                Articulo art3 = new Articulo();
                art3.UsaImagen = 1;
                art3.UrlImagen = "http://placehold.it/400x300&text=[img]";
                art3.UsaTitulo = 1;
                art3.Visible = 1;
                art3.Titulo = "This is a content section.";
                art3.Contenido = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa. Boudin aliqua adipisicing rump corned beef.";
                retorno.Articulos.Add(art3);
            }
            else
            {
                retorno.Articulos = Articulo.ListarArticulos(idInstitucion, tipoArticulo);

            }


            return retorno;

        }
    }
}
