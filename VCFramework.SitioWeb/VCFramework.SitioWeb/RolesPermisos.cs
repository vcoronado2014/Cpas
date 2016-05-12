using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace VCFramework.SitioWeb
{
    public class RolesPermisos
    {
        public static string RetornaMenu(string rolId)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string[] arrPath = path.Split('/');
            int profundidad = arrPath.Length;

            ///Administracion/Usuarios.aspx

            StringBuilder sb = new StringBuilder();

            List<EntidadFuniconal.MenuGeneralFuncional> menuGLista = new List<EntidadFuniconal.MenuGeneralFuncional>();

            List<Entidad.GrupoItem> listaG = NegocioMySQL.GrupoItem.ListarGrupos();
            if (listaG != null && listaG.Count > 0)
            {
                foreach (Entidad.GrupoItem gg in listaG)
                {
                    EntidadFuniconal.MenuGeneralFuncional mnu = new EntidadFuniconal.MenuGeneralFuncional();
                    mnu.Grupo = new Entidad.GrupoItem();
                    mnu.Grupo = gg;
                    List<Entidad.ElementosGrupo> listaGG = NegocioMySQL.ElementosGrupo.ObtenerElementosGrupo(gg.Id);
                    mnu.Elementos = new List<Entidad.ElementosGrupo>();
                    mnu.Elementos = listaGG;
                    menuGLista.Add(mnu);

                }
            }
            if (menuGLista != null && menuGLista.Count > 0)
            {
                foreach(EntidadFuniconal.MenuGeneralFuncional menu in menuGLista)
                {
                    //ahora empezamos a construir
                    if (menu.Grupo.RolesId.Contains(rolId))
                    {
                        sb.Append("<li class='divider'></li>");
                        if (menu.Grupo.EsGrupo == 1)
                        {
                            sb.Append("<li class='has-dropdown'>");
                            if (menu.Grupo.ClassGrupo != string.Empty)
                                sb.AppendFormat("<a href='{0}' class='{1}'>  {2}</a>", menu.Grupo.HrefGrupo, menu.Grupo.ClassGrupo, menu.Grupo.NombreGrupo);
                            else
                                sb.AppendFormat("<a href='{0}'>{1}</a>", menu.Grupo.HrefGrupo, menu.Grupo.NombreGrupo);
                            sb.Append("<ul class='dropdown'>");
                            //foreach a los elementos
                            if (menu.Elementos != null && menu.Elementos.Count > 0)
                            {
                                foreach (Entidad.ElementosGrupo ele in menu.Elementos)
                                {
                                    //verifcamos si el rol tiene permisos en el subitem
                                    if (ele.RolesId.Contains(rolId))
                                    {
                                        //si la carpeta existe en relative path hay que quitarla
                                        if (ele.HrefItem != "#")
                                        {
                                            if (profundidad == 3)
                                            {
                                                ele.HrefItem = "../" + ele.HrefItem;
                                            }

                                        }

                                        sb.Append("<li>");
                                        sb.AppendFormat("<a class='{0}' href='{1}'>{2}</a>", ele.ClassItem, ele.HrefItem, ele.Nombre);
                                        sb.Append("</li>");
                                    }
                                }
                            }
                            sb.Append("</ul>");
                            sb.Append("</li>");

                        }
                        else
                        {

                            //si la carpeta existe en relative path hay que quitarla
                            if (menu.Grupo.HrefGrupo != "#")
                            {
                                if (profundidad == 3)
                                {
                                    menu.Grupo.HrefGrupo = "../" + menu.Grupo.HrefGrupo;
                                }

                            }

                            sb.Append("<li>");
                            sb.AppendFormat("<a class='{0}' href='{1}'>{2}</a>", menu.Grupo.ClassGrupo, menu.Grupo.HrefGrupo, menu.Grupo.NombreGrupo);
                            sb.Append("</li>");
                        }
                    }
                }
            }

            return sb.ToString();
        }
    }
}