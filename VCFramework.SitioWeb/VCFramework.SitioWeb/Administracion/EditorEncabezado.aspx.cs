using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VCFramework.SitioWeb.Administracion
{
    public partial class EditorEncabezado : System.Web.UI.Page
    {
        const string BITMAP_ID_BLOCK = "BM";
        const string JPG_ID_BLOCK = "\u00FF\u00D8\u00FF";
        const string PNG_ID_BLOCK = "\u0089PNG\r\n\u001a\n";
        const string GIF_ID_BLOCK = "GIF8";
        const string TIFF_ID_BLOCK = "II*\u0000";
        const int DEFAULT_OLEHEADERSIZE = 78;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UsuarioFuncional usu = new UsuarioFuncional();
                if (Session["USUARIO_AUTENTICADO"] != null)
                {
                    usu = Session["USUARIO_AUTENTICADO"] as UsuarioFuncional;
                    if (usu != null && usu.AutentificacionUsuario.Id > 0)
                    {
                        Session["INST_ID"] = usu.AutentificacionUsuario.InstId;
                        //recuperar los datos de la institución para setear los valores
                        //en el encabezado
                        CargarDatos(usu.AutentificacionUsuario.InstId);
                        
                        
                    }
                    else
                    {
                        Response.Redirect("~/default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }
        }
        private void CargarDatos(int idInst)
        {
            DinamicHTML.Encabezado encabezado = DinamicHTML.Encabezado.Obtener(idInst);
            if (encabezado != null)
            {
                string ruta = encabezado.UrlImagenSuperior;
                BinaryImage.ContentBytes = GetByteArrayFromImage(ruta);
                txtSubtitulo.Text = encabezado.SubtiTuloEncabezado;
                txtTitulo.Text = encabezado.TituloEncabezado;
            }
            //articulos
            //traeremos los por defecto en caso que la institución no tenga
            List<DinamicHTML.Articulo> articulosCPAS = VCFramework.DinamicHTML.Articulo.ListarArticulos(3, 1);
            List<DinamicHTML.Articulo> articulos = VCFramework.DinamicHTML.Articulo.ListarArticulos(idInst, 1);
            if (articulos != null && articulos.Count > 0)
            {
                if (articulos.Count == 3)
                {
                    //articulo 1
                    string rutaArt1 = articulos[0].UrlImagen;
                    BinaryImagenArt1.ContentBytes = GetByteArrayFromImage(rutaArt1);
                    txtTituloArt1.Text = articulos[0].Titulo;
                    memContenidoArt1.Text = articulos[0].Contenido;
                    //articulo 2
                    string rutaArt2 = articulos[1].UrlImagen;
                    BinaryImagenArt2.ContentBytes = GetByteArrayFromImage(rutaArt2);
                    txtTituloArt2.Text = articulos[1].Titulo;
                    memContenidoArt2.Text = articulos[1].Contenido;
                    //articulo 3
                    string rutaArt3 = articulos[2].UrlImagen;
                    BinaryImagenArt3.ContentBytes = GetByteArrayFromImage(rutaArt3);
                    txtTituloArt3.Text = articulos[2].Titulo;
                    memContenidoArt3.Text = articulos[2].Contenido;

                }
            }
            Entidad.ConfiguracionInstitucion config = NegocioMySQL.ConfiguracionInstitucion.ObtenerConfiguracionPorInstId(idInst);
            if (config != null)
            {
                if (config.EnviaCorreoEventos == 1)
                    chkEnviaEvento.Checked = true;
                if (config.EnviaDocumentos == 1)
                    chkEnviaDocumentos.Checked = true;
                if (config.EnviaProyectos == 1)
                    chkEnviaProyectos.Checked = true;
                if (config.EnviaRendiciones == 1)
                    chkEnviaRendiciones.Checked = true;
            }


        }
        protected byte[] GetByteArrayFromImage(string nombreArchivo)
        {
            byte[] byteArray = null;
            using (FileStream stream = new FileStream(Server.MapPath(nombreArchivo), FileMode.Open, FileAccess.Read))
            {
                byteArray = new byte[stream.Length];
                stream.Read(byteArray, 0, (int)stream.Length);
            }
            return byteArray;
        }
        protected System.Drawing.Image GetImageFromArray(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        protected void BinaryImage_CustomCallback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            //resize
            //Screen.PrimaryScreen.Bounds.Width
            
        }
        private string GuardadoImagen(int idEncabezado)
        {
            string nombreArchivo = "~/img/encabezadoCPAS_" + idEncabezado.ToString() + ".png";
            string archivoGuardar = Server.MapPath(nombreArchivo);
            byte[] byteArray = BinaryImage.ContentBytes;
            System.Drawing.Image img = GetImageFromArray(byteArray);

            img.Save(archivoGuardar, System.Drawing.Imaging.ImageFormat.Png);

            return nombreArchivo;

        }
        private string GuardadoImagenArticulo1(int idArticulo)
        {
            string nombreArchivo = "~/img/imgArticulo_" + idArticulo.ToString() + ".png";
            string archivoGuardar = Server.MapPath(nombreArchivo);
            byte[] byteArray = BinaryImagenArt1.ContentBytes;
            System.Drawing.Image img = GetImageFromArray(byteArray);

            img.Save(archivoGuardar, System.Drawing.Imaging.ImageFormat.Png);

            return nombreArchivo;

        }
        private string GuardadoImagenArticulo2(int idArticulo)
        {
            string nombreArchivo = "~/img/imgArticulo_" + idArticulo.ToString() + ".png";
            string archivoGuardar = Server.MapPath(nombreArchivo);
            byte[] byteArray = BinaryImagenArt2.ContentBytes;
            System.Drawing.Image img = GetImageFromArray(byteArray);

            img.Save(archivoGuardar, System.Drawing.Imaging.ImageFormat.Png);

            return nombreArchivo;

        }
        private string GuardadoImagenArticulo3(int idArticulo)
        {
            string nombreArchivo = "~/img/imgArticulo_" + idArticulo.ToString() + ".png";
            string archivoGuardar = Server.MapPath(nombreArchivo);
            byte[] byteArray = BinaryImagenArt3.ContentBytes;
            System.Drawing.Image img = GetImageFromArray(byteArray);

            img.Save(archivoGuardar, System.Drawing.Imaging.ImageFormat.Png);

            return nombreArchivo;

        }

        protected void pnlGeneral_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "guardar")
            {
                try
                {
                    int idInst = int.Parse(Session["INST_ID"].ToString());
                    //comenzamos guardando el encabezado, para eso debemos determinar si ya se encuentra
                    //o es nuevo
                    Entidad.Encabezado item = new Entidad.Encabezado();
                    List<Entidad.Encabezado> encabezados = NegocioMySQL.Encabezado.Obtener(idInst);
                    if (encabezados != null && encabezados.Count > 0)
                    {
                        if (encabezados[0].Id > 0)
                        {
                            
                            item = encabezados[0];
                            item.TituloEncabezado = txtTitulo.Text;
                            item.SubtituloEncabezado = txtSubtitulo.Text;
                            item.UrlImagenSuperior = GuardadoImagen(item.Id);
                            VCFramework.NegocioMySQL.Encabezado.Modificar(item);

                        }
                    }
                    //guardado de los items
                    List<DinamicHTML.Articulo> articulos = VCFramework.DinamicHTML.Articulo.ListarArticulos(idInst, 1);
                    if (articulos != null && articulos.Count > 0)
                    {
                        if (articulos.Count == 3)
                        {
                            //articulo 1
                            Entidad.Articulo art1 = new Entidad.Articulo();
                            art1.Id = articulos[0].Id;
                            art1.Eliminado = 0;
                            art1.Fecha = articulos[0].Fecha;
                            art1.InstId = articulos[0].InstId;
                            art1.TipoArticulo = articulos[0].TipoArticulo;
                            art1.UsaFecha = articulos[0].UsaFecha;
                            art1.UsaImagen = articulos[0].UsaImagen;
                            art1.UsaTitulo = articulos[0].UsaTitulo;
                            art1.Titulo = txtTituloArt1.Text;
                            art1.Contenido = memContenidoArt1.Text;
                            art1.UrlImagen = GuardadoImagenArticulo1(articulos[0].Id);
                            VCFramework.NegocioMySQL.Articulo.Modificar(art1);
                            //articulo 2
                            Entidad.Articulo art2 = new Entidad.Articulo();
                            art2.Id = articulos[1].Id;
                            art2.Eliminado = 0;
                            art2.Fecha = articulos[1].Fecha;
                            art2.InstId = articulos[1].InstId;
                            art2.TipoArticulo = articulos[1].TipoArticulo;
                            art2.UsaFecha = articulos[1].UsaFecha;
                            art2.UsaImagen = articulos[1].UsaImagen;
                            art2.UsaTitulo = articulos[1].UsaTitulo;
                            art2.Titulo = txtTituloArt2.Text;
                            art2.Contenido = memContenidoArt2.Text;
                            art2.UrlImagen = GuardadoImagenArticulo2(articulos[1].Id);
                            VCFramework.NegocioMySQL.Articulo.Modificar(art2);
                            //articulo 3
                            Entidad.Articulo art3 = new Entidad.Articulo();
                            art3.Id = articulos[2].Id;
                            art3.Eliminado = 0;
                            art3.Fecha = articulos[2].Fecha;
                            art3.InstId = articulos[2].InstId;
                            art3.TipoArticulo = articulos[2].TipoArticulo;
                            art3.UsaFecha = articulos[2].UsaFecha;
                            art3.UsaImagen = articulos[2].UsaImagen;
                            art3.UsaTitulo = articulos[2].UsaTitulo;
                            art3.Titulo = txtTituloArt3.Text;
                            art3.Contenido = memContenidoArt3.Text;
                            art3.UrlImagen = GuardadoImagenArticulo3(articulos[2].Id);
                            VCFramework.NegocioMySQL.Articulo.Modificar(art3);
                        }
                    }
                    //ahora las configuraciones
                    Entidad.ConfiguracionInstitucion config = NegocioMySQL.ConfiguracionInstitucion.ObtenerConfiguracionPorInstId(idInst);
                    if (config != null)
                    {
                        //documentos
                        if (chkEnviaDocumentos.Checked)
                            config.EnviaDocumentos = 1;
                        else
                            config.EnviaDocumentos = 0;

                        //envia eventos
                        if (chkEnviaEvento.Checked)
                            config.EnviaCorreoEventos = 1;
                        else
                            config.EnviaCorreoEventos = 0;

                        //envia proyectos
                        if (chkEnviaProyectos.Checked)
                            config.EnviaProyectos = 1;
                        else
                            config.EnviaProyectos = 0;

                        //envia rendiciones
                        if (chkEnviaRendiciones.Checked)
                            config.EnviaRendiciones = 1;
                        else
                            config.EnviaRendiciones = 0;

                        config.Borrado = false;
                        config.Nuevo = false;
                        config.Modificado = true;

                        NegocioMySQL.Factory fac = new NegocioMySQL.Factory();

                        fac.Update<Entidad.ConfiguracionInstitucion>(config);
                    }

                    vistaMensaje1.MostrarMensaje(SitioWeb.EstiloMensaje.Ok, true, false, "Guardado Exitosamente.", "");
                    CargarDatos(int.Parse(Session["INST_ID"].ToString()));
                    
                }
                catch(Exception ex)
                {
                    vistaMensaje1.MostrarMensaje(SitioWeb.EstiloMensaje.Error, true, false, ex.Message, "");
                    VCFramework.NegocioMySQL.Utiles.Log(ex);
                }
            }
        }

        public byte[] ConvertObjectToByteArray(object content)
        {
            if (content != null && !(content is DBNull))
            {
                byte[] oleFieldBytes = (byte[])content;
                byte[] imageBytes = null;
                // Get a UTF7 Encoded string version
                System.Text.Encoding u8 = System.Text.Encoding.UTF7;
                string strTemp = u8.GetString(oleFieldBytes);
                // Get the first 300 characters from the string
                string strVTemp = strTemp.Substring(0, 300);
                // Search for the block
                int iPos = -1;
                if (strVTemp.IndexOf(BITMAP_ID_BLOCK) != -1)
                {
                    iPos = strVTemp.IndexOf(BITMAP_ID_BLOCK);
                }
                else if (strVTemp.IndexOf(JPG_ID_BLOCK) != -1)
                {
                    iPos = strVTemp.IndexOf(JPG_ID_BLOCK);
                }
                else if (strVTemp.IndexOf(PNG_ID_BLOCK) != -1)
                {
                    iPos = strVTemp.IndexOf(PNG_ID_BLOCK);
                }
                else if (strVTemp.IndexOf(GIF_ID_BLOCK) != -1)
                {
                    iPos = strVTemp.IndexOf(GIF_ID_BLOCK);
                }
                else if (strVTemp.IndexOf(TIFF_ID_BLOCK) != -1)
                {
                    iPos = strVTemp.IndexOf(TIFF_ID_BLOCK);
                }
                // From the position above get the new image
                if (iPos == -1)
                {
                    iPos = DEFAULT_OLEHEADERSIZE;
                }
                //Array.Copy(
                imageBytes = new byte[oleFieldBytes.LongLength - iPos];
                MemoryStream ms = new MemoryStream();
                ms.Write(oleFieldBytes, iPos, oleFieldBytes.Length - iPos);
                imageBytes = ms.ToArray();
                ms.Close();
                ms.Dispose();
                return imageBytes;
            }
            return null;
        }

        protected void pageTab_ActiveTabChanged(object source, DevExpress.Web.TabControlEventArgs e)
        {

        }
    }
}